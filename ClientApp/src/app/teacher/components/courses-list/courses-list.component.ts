import { Component, OnInit } from '@angular/core';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseViewModel } from '../../models/course.model';
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

  constructor(private courseService: CourseService) { }

  ngOnInit() {
    
    this.courseService.getListOfCourses().subscribe(result => {
      this.courses = this.courseService.mapArrayDataFromBackendToViewModel(result);
    });
  }

}
