import { Component, Input, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'app-exam-table',
  templateUrl: './exam-table.component.html',
  styleUrls: ['./exam-table.component.css']
})
export class ExamTableComponent {

  dataSource: MatTableDataSource<any>;
  @Input() columnsToDisplay : string[];
  @Input() set data(value) {
    this.dataSource = new MatTableDataSource<any>(value);
    if(this.dataSource)
      this.dataSource.paginator = this.paginator;
  };
  @Input() actions: TableActionsModel[];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

}
