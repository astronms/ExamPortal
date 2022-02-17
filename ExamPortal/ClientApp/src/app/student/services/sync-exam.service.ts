import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, Subject, throwError } from 'rxjs';
import { HttpTransportType, HubConnection, HubConnectionBuilder, IHttpConnectionOptions, LogLevel } from '@microsoft/signalr';
import { AuthService } from 'src/app/services/auth.service';
import { catchError } from 'rxjs/operators';
import { PersonalExamInfoModel } from '../models/personal-exam-info.model';
import { QuestionModel } from '../models/question.model';
import { AnswerModel } from '../models/answer.model';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class SyncExamService {

  private hubConnection: HubConnection;
  private examId: string;
  public questions: Subject<QuestionModel> = new Subject<QuestionModel>();

  constructor(
    private http: HttpClient,  
    @Inject('BASE_URL')private baseUrl: string,
    private authService: AuthService
  ) { }

  getExamData(examId: string) : Observable<PersonalExamInfoModel>
  {
    return this.http.get<PersonalExamInfoModel>(this.baseUrl + 'api/auth/Exam/' + examId +'/prepare').pipe(
      catchError(this.handleError)
    );
  }

  startExam(examId: string): void 
  {
    this.examId = examId;
    this.startConnection();
    this.setListeners();
  }

  closeConnection() : void
  {
    this.hubConnection.stop();
  }

  sendAnswers(answer: AnswerModel)
  {
    this.hubConnection.invoke('sendAnswer', answer);
  }

  private startConnection(): void
  {
    const options: IHttpConnectionOptions = { //Add JWT Token
      accessTokenFactory: () => {
        return this.authService.userValue.token;
      }
    };

    this.hubConnection = new HubConnectionBuilder() 
      .configureLogging(LogLevel.Debug)
      .withUrl( this.baseUrl + 'examhub', options)
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .then(() => this.callStartExam())
      .then(() => this.callGetQuestion())
      .catch(this.handleError)
  }

  private callStartExam(): void 
  {
    this.hubConnection.invoke('startExam', this.examId);
  }

  private callGetQuestion(): void 
  {
    this.hubConnection.invoke('getQuestion', this.examId);
  }

  private setListeners(): void 
  {
    this.hubConnection.on('question', reply => {
      this.questions.next(reply);
    });
  }

  
  private handleError(error: HttpErrorResponse) 
  {
    if (error.status === 0)
      console.error('An error occurred:', error.error);
    else if(error.status === 410 || error.status === 403)
      return throwError(error.error);
    else
      console.error(`Backend returned code ${error.status}, body was: `, error.error);
  
    return throwError(
      'Something bad happened; please try again later.');
  }

}
