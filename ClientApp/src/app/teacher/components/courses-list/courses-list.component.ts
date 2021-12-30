import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseModel, CourseViewModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.css']
})

export class CoursesListComponent implements OnInit {

  public courses: CourseViewModel[];
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
      this.courses = this.mapDataFromBackendToViewModel(result);
    });
  }

  private mapDataFromBackendToViewModel(data: CourseModel[]) : CourseViewModel[]
  {
    const datePipe: DatePipe = new DatePipe(this.locale);

    return data.map( (course, index) => <CourseViewModel>{
      no: index + 1,
      title: course.name,
      creationDate: datePipe.transform(course.creationDate, 'dd-MMM-yyyy HH:mm'),
      studentsNumber: course.users.length
    });
  } 

}
