import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseModel } from '../../models/course.model';

@Component({
  selector: 'app-courses-list-template',
  templateUrl: './courses-list-template.component.html',
  styleUrls: ['./courses-list-template.component.css']
})
export class CoursesListTemplateComponent {

  dataSource: MatTableDataSource<any>;
  @Input() columnsToDisplay : string[];
  @Input() set data(value) {
    this.dataSource = new MatTableDataSource<any>(value);
    if(this.dataSource){
      this.dataSource.paginator = this.paginator;
    } 
  };
  @Input() actions: TableActionsModel[];
  @Input() isSelectable: boolean = false;
  @Input() selectedCourse: CourseModel;
  @Output() selectedUsersChange : EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
  ) { }

  courseClicked(course)
  {
    if(this.selectedCourse && this.selectedCourse.courseId == course.courseId)
      this.selectedCourse = null;
    else
      this.selectedCourse = course;

    this.selectedUsersChange.emit(this.selectedCourse);
  }

}
