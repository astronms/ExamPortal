import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, Subject, throwError } from 'rxjs';
import { HubConnection, HubConnectionBuilder, IHttpConnectionOptions, LogLevel } from '@microsoft/signalr';
import { AuthService } from 'src/app/services/auth.service';
import { catchError } from 'rxjs/operators';
import { PersonalExamInfoModel } from '../models/personal-exam-info.model';
import { QuestionModel } from '../models/question.model';
import { AnswerModel } from '../models/answer.model';
import { ExamResultModel } from 'src/app/models/exam-result-model';

@Injectable({
  providedIn: 'root'
})
export class SyncExamService {

  private hubConnection: HubConnection;
  private hubConnection2: HubConnection;
  private examId: string;
  public questions: Subject<QuestionModel> = new Subject<QuestionModel>();
  public examFinished: Subject<boolean> = new Subject<boolean>();

  constructor(
    private http: HttpClient,  
    @Inject('BASE_URL')private baseUrl: string,
    private authService: AuthService
  ) { }

  getExamData(examId: string) : Observable<PersonalExamInfoModel>
  {
    return this.http.get<PersonalExamInfoModel>(this.baseUrl + 'api/auth/Exam/' + examId +'/prepare').pipe(
      catchError(err => {
        if(err.status == 423)
        {
          return this.http.get<PersonalExamInfoModel>(this.baseUrl + 'api/auth/Exam/' + examId +'/IsPrepared').pipe(
            catchError(this.handleError)
          );
        }
        return this.handleError(err);
      })
    );
  }

  getExamResult(examResultGuid: string) : Observable<ExamResultModel>
  {
    return this.http.get<ExamResultModel>(this.baseUrl + 'api/auth/Exam/' + examResultGuid + '/result').pipe(
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
    this.hubConnection2.stop();
  }

  sendAnswers(answer: AnswerModel)
  {
    this.hubConnection2.invoke('sendAnswer', this.examId, answer);
  }

  private startConnection(): void
  {
    const options: IHttpConnectionOptions = { 
      accessTokenFactory: () => {
        return this.authService.userValue.token;
      }
    };

    this.hubConnection = new HubConnectionBuilder() 
      //.configureLogging(LogLevel.Debug)
      .configureLogging(LogLevel.None)
      .withUrl( this.baseUrl + 'examhub', options)
      .withAutomaticReconnect()
      .build();

    this.hubConnection2 = new HubConnectionBuilder() 
      //.configureLogging(LogLevel.Debug)
      .configureLogging(LogLevel.None)
      .withUrl( this.baseUrl + 'examhub', options)
      .withAutomaticReconnect()
      .build();

    this.hubConnection
      .start()
      .then(() => this.callStartExam())
      .then(() => this.callGetQuestion())
      .catch(this.handleError);

    this.hubConnection2
      .start()
      .catch(this.handleError);

  }

  private callStartExam(): void
  {
    this.hubConnection.invoke('startExam', this.examId)
      .catch(this.handleError);
  }

  private callGetQuestion(): void
  {
    this.hubConnection.invoke('getQuestion', this.examId)
      .catch(this.handleError);
  }

  private setListeners(): void 
  {
    this.hubConnection.on('Question', reply => {
      this.questions.next(reply);
    });

    this.hubConnection.on('FinishExam', () => {
      this.examFinished.next(true);
      this.closeConnection();
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
