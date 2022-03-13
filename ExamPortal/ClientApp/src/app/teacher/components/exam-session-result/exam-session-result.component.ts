import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';
import { ExamSessionResultService } from '../../services/exam-session-result.service';

@Component({
  selector: 'app-exam-session-result',
  templateUrl: './exam-session-result.component.html',
  styleUrls: ['./exam-session-result.component.css']
})
export class ExamSessionResultComponent implements OnInit{

  usersWithScore: UserModel[] = [];
  columnsToDisplay: string[] = ['index', 'firstName', 'lastName', 'studentIndex', 'scoreRatio'];
  examSessionId: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private examSessionResultService: ExamSessionResultService
  ) { }

  ngOnInit() {
    this.examSessionId = this.route.snapshot.paramMap.get('id');
    this.examSessionResultService.getExamSessionUsersWithResults(this.examSessionId).subscribe(result => {
      this.usersWithScore = result;
    });
  }

  userClicked(user: UserModel)
  {
    this.router.navigate(['/teacher/exam-student-result', this.examSessionId, user.id]);
  }

}
