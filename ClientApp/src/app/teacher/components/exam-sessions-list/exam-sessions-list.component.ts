import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { ExamModel, ExamViewModel } from 'src/app/models/exam.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseService } from '../../services/course.service';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-sessions-list',
  templateUrl: './exam-sessions-list.component.html',
  styleUrls: ['./exam-sessions-list.component.css']
})
export class ExamSessionsListComponent implements OnInit {

  public examSessions: ExamViewModel[];
  public displayedColumns: string[] = ['id', 'title', 'duration', 'questionsNumber', 'startDate', 'available', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-exam" },
    {actionType: "edit", tooltip: "Edytuj", url: "\\" },
    {actionType: "delete", tooltip: "Kasuj", url: "\\" }
  ];


  constructor(private examSessionService: ExamSessionService, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {

    const datepipe: DatePipe = new DatePipe(this.locale);
    
    this.examSessionService.getListOfExamSessions().subscribe(result => {
      this.examSessions = this.mapDataFromBackendToViewModel(result);
    });
  }

  private mapDataFromBackendToViewModel(data: ExamModel[]) : ExamViewModel[]
  {
    const datePipe: DatePipe = new DatePipe(this.locale);

    return data.map( (exam, index) => <ExamViewModel>{
      no: index + 1,
      title: exam.title,
      duration: exam.duration,
      questionsNumber: exam.questionsNumber,
      startDate: datePipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm'),
      available: exam.available
    });
  } 

}
