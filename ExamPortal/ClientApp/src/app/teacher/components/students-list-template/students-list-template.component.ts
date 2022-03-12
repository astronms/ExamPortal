import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UserModel } from 'src/app/models/user.model';
import { StudentsService } from '../../services/students.service';

@Component({
  selector: 'app-students-list-template',
  templateUrl: './students-list-template.component.html',
  styleUrls: ['./students-list-template.component.css']
})
export class StudentsListTemplateComponent implements OnInit {

  dataSource: MatTableDataSource<UserModel>;
  private paginator: MatPaginator;
  @Input() columnsToDisplay: string[] = ['index', 'firstName', 'lastName', 'studentIndex'];
  @Input() selectedUsers: UserModel[] = [];
  @Input() users: UserModel[];
  @Output() selectedUsersChange : EventEmitter<UserModel[]> = new EventEmitter<UserModel[]>();
  @Output() userClicked : EventEmitter<UserModel> = new EventEmitter<UserModel>();
  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    if(this.dataSource)
      this.dataSource.paginator = this.paginator;
  }


  constructor(
    private studentsService: StudentsService
  ) { }

  ngOnInit(): void {
    if(this.users == null)
    {
      this.studentsService.getListOfStudents()
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

  get isClickable() : boolean
  {
    return this.userClicked.observers.length > 0;
  }

  isUserSelected(user: UserModel) : boolean
  {
    return this.selectedUsers.filter(item => item.email == user.email).length > 0;
  }

  userRowClicked(user: UserModel)
  {
    if(this.isUserSelected(user))
      this.selectedUsers = this.selectedUsers.filter(item => item.email != user.email);
    else
      this.selectedUsers.push(user);

    this.selectedUsersChange.emit(this.selectedUsers);
    this.userClicked.emit(user);
  }

}
