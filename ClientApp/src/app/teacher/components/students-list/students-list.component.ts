import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserModel } from 'src/app/models/user.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {

  dataSource: MatTableDataSource<UserModel>
  columnsToDisplay: string[] = ['index', 'firstName', 'lastName', 'studentIndex'];

  constructor(
    private courseService: CourseService
  ) { }

  ngOnInit(): void {
    this.courseService.getListOfStudents()
      .subscribe(result => {
        this.dataSource = new MatTableDataSource<UserModel>(result);
      }
    );
  }

}
