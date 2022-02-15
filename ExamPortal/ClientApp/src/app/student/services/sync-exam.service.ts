import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Subject, throwError } from 'rxjs';
import { HttpTransportType, HubConnection, HubConnectionBuilder, IHttpConnectionOptions, LogLevel } from '@microsoft/signalr';
import { AuthService } from 'src/app/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class SyncExamService {

  private hubConnection: HubConnection;
  questions: Subject<any> = new Subject();

  constructor(
    private http: HttpClient,  
    @Inject('BASE_URL')private baseUrl: string,
    private authService: AuthService
  ) { }

  startExam(examId: string): void {
    this.http.get<any>(this.baseUrl + 'api/auth/Exam/' + examId +'/start').subscribe(res => console.log(res)); //StartExam 

    this.startConnection();
    this.setListeners();
  }

  private startConnection(): void  {
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
      .then(() => this.getQuestion())
      .catch(this.handleError)
  }

  private getQuestion(): void {
    this.hubConnection.invoke('getQuestion');
  }

  private setListeners(): void {
    this.hubConnection.on('question', reply => {
      console.log("Question reply: " + reply);
      this.questions.next(reply);
    });
  }

  
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }

}
