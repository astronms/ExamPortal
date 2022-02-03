import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { CourseModel } from '../../models/course.model';

@Component({
  selector: 'app-courses-list-template',
  templateUrl: './courses-list-template.component.html',
  styleUrls: ['./courses-list-template.component.css']
})
export class CoursesListTemplateComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @Input("columnsToDisplay") columnsToDisplay : string[];
  @Input("data") set data(value) {
    this.dataSource = new MatTableDataSource<any>(value);
    if(this.dataSource)
      this.dataSource.paginator = this.paginator;
  };
  @Input("actions") actions: TableActionsModel[];
  @Input("isSelectable") isSelectable: boolean = false;
  @Input("selectedCourse") selectedCourse: CourseModel;
  @Output("selectedCourseChange") selectedUsersChange : EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  ngOnInit(): void {
  }

  courseClicked(course)
  {
    if(this.selectedCourse == course)
      this.selectedCourse = null;
    else
      this.selectedCourse = course;

    this.selectedUsersChange.emit(this.selectedCourse);
  }

}
