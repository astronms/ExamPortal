import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamResultModel } from 'src/app/models/exam-result-model';
import { UserModel } from 'src/app/models/user.model';
import { ExamSessionResultService } from '../../services/exam-session-result.service';
import { StudentsService } from '../../services/students.service';

@Component({
  selector: 'app-exam-session-student-result',
  templateUrl: './exam-session-student-result.component.html',
  styleUrls: ['./exam-session-student-result.component.css']
})
export class ExamSessionStudentResultComponent implements OnInit {

  examResult: ExamResultModel;
  student: UserModel;
  examSessionId

  constructor(
    private route: ActivatedRoute,
    private examSessionResultService: ExamSessionResultService,
    private studentsService: StudentsService
  ) { }

  ngOnInit(): void {
    this.examSessionId = this.route.snapshot.paramMap.get('id');
    var userId = this.route.snapshot.paramMap.get('userId');
    this.examSessionResultService.getExamSessionUserResult(this.examSessionId, userId).subscribe(res => {
      this.examResult = res;
    })
    this.studentsService.getStudent(userId).subscribe(res => {
      this.student = res;
    })
  }

}
