import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})

export class CoursesListComponent implements OnInit {

  public courses: CourseModel[];
  public displayedColumns: string[] = ['id', 'title', 'studentsNumber', 'creationDate', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-exam" },
    {actionType: "edit", tooltip: "Edytuj", url: "\\" },
    {actionType: "delete", tooltip: "Kasuj", url: "\\" }
  ];

  constructor(private courseService: CourseService, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {
    const datePipe: DatePipe = new DatePipe(this.locale);
    
    this.courseService.getListOfCourses().subscribe(result => {
      result.forEach( exam => {
        exam.creationDate =  datePipe.transform(exam.creationDate, 'dd-MMM-yyyy HH:mm');
      });

      this.courses = result;
    });
  }

}
