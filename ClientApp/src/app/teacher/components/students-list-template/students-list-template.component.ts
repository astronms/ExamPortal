import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UserModel } from 'src/app/models/user.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-students-list-template',
  templateUrl: './students-list-template.component.html',
  styleUrls: ['./students-list-template.component.css']
})
export class StudentsListTemplateComponent implements OnInit {

  dataSource: MatTableDataSource<UserModel>;
  columnsToDisplay: string[] = ['index', 'firstName', 'lastName', 'studentIndex'];
  private paginator: MatPaginator;
  @Input("selectedUsers") selectedUsers: UserModel[];
  @Input("users") users: UserModel[];
  @Output("selectedUsersChange") selectedUsersChange : EventEmitter<UserModel[]> = new EventEmitter<UserModel[]>();
  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    if(this.dataSource)
      this.dataSource.paginator = this.paginator;
  }


  constructor(
    private courseService: CourseService
  ) { }

  ngOnInit(): void {
    if(this.users == null)
    {
      this.courseService.getListOfStudents()
        .subscribe(result => {
          this.dataSource = new MatTableDataSource<UserModel>(result);
          this.dataSource.paginator = this.paginator;
        }
      );
    }
    else
      this.dataSource = new MatTableDataSource<UserModel>(this.users);
  }

  get isSelectable() : boolean
  {
    return this.selectedUsersChange.observers.length > 0;
  }

  isUserSelected(user: UserModel) : boolean
  {
    return this.selectedUsers.filter(item => item.email == user.email).length > 0;
  }

  userRowClicked(user: UserModel)
  {
    console.log(user);
    console.log(this.selectedUsers);
    if(this.isUserSelected(user))
      this.selectedUsers = this.selectedUsers.filter(item => item.email != user.email);
    else
      this.selectedUsers.push(user);

    this.selectedUsersChange.emit(this.selectedUsers);
  }

}
