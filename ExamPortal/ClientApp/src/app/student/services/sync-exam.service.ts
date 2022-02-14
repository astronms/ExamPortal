import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Subject, throwError } from 'rxjs';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SyncExamService {

  private hubConnection: HubConnection;
  questions: Subject<any> = new Subject();

  constructor(
    private http: HttpClient,  
    @Inject('BASE_URL')private baseUrl: string
  ) { }

  startExam(examId: number) {
    this.http.get<any>(this.baseUrl + 'api/auth/Exam/' + examId +'/student').subscribe(res => console.log(res));
  }

  private startConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:5001/examhub')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(this.handleError)
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