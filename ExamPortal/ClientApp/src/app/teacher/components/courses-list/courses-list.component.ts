import { Component, OnInit } from '@angular/core';
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
  public displayedColumns: string[] = ['index', 'name', 'users', 'creationDate', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-course" },
    {actionType: "edit", tooltip: "Edytuj", url: "/teacher/edit-course/" },
    {actionType: "delete", tooltip: "Kasuj", url: "/teacher/delete-course/" }
  ];

  constructor(private courseService: CourseService) { }

  ngOnInit() {
    
    this.courseService.getListOfCourses().subscribe(result => {
      this.courses = result;
    });
  }

}
