import { QuestionModel } from '../../models/question.model';
import { GetQuestionReplyModel } from '../../models/get-question-reply.model';

import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SyncExamService } from '../../services/sync-exam.service';


@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: [],
})
export class ExamComponent {

  public timeLeft: number;

  public examFinished: boolean = false;

  private interval: any = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private examService: SyncExamService,
    private http: HttpClient,  
    @Inject('BASE_URL')private baseUrl: string
  ) { }

  ngOnInit() {
    var examId = this.route.snapshot.paramMap.get('id');
    

    /*try {
      this.examService = this.examFactoryService.getInstance();

      this.examService.examStatusObservable.subscribe(result => {
        if(result == ExamStatusEnum.EndQuestionTime)
          this.nextQuestion();
        else if(result == ExamStatusEnum.Finished)
          this.examFinished = true;
      });

      if(!this.examService.isPendingExam())
        this.router.navigate(["/exams"]);
      else
        this.nextQuestion();
    }
    catch(e)
    {
      console.log("Error in exam component!"); //Redirect to error page.
    }*/


  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }
  

  private setViewTimer() : void
  {
    this.interval = setInterval(() => {
      this.timeLeft--;
    }, 1000)
  }
  
}