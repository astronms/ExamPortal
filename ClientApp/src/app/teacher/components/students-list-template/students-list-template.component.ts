import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
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
  @Input("selectedUsers") selectedUsers: UserModel[];
  @Input("users") users: UserModel[];
  @Output("selectedUsersChange") selectedUsersChange : EventEmitter<UserModel[]> = new EventEmitter<UserModel[]>();


  constructor(
    private courseService: CourseService
  ) { }

  ngOnInit(): void {
    if(this.users == null)
    {
      this.courseService.getListOfStudents()
        .subscribe(result => {
          this.dataSource = new MatTableDataSource<UserModel>(result);
        }
      );
    }
    else
    {
      this.dataSource = new MatTableDataSource<UserModel>(this.users);
    }
  }

  get isSelectable() : boolean{
    return this.selectedUsersChange.observers.length > 0;
  }

  userRowClicked(user: UserModel)
  {
    if(this.selectedUsers.includes(user))
      this.selectedUsers = this.selectedUsers.filter(item => item != user);
    else
      this.selectedUsers.push(user);

    this.selectedUsersChange.emit(this.selectedUsers);
  }

}
