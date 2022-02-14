import { Component, Input, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'app-exam-sessions-table-template',
  templateUrl: './exam-sessions-table-template.component.html',
  styleUrls: ['./exam-sessions-table-template.component.css']
})
export class ExamSessionTableTemplateComponent implements OnInit {

  dataSource: MatTableDataSource<any>;
  @Input() columnsToDisplay : string[];
  @Input() set data(value) {
    this.dataSource = new MatTableDataSource<any>(value);
    if(this.dataSource)
      setTimeout(()=>{ this.dataSource.paginator = this.paginator }, 50); //remove this delay once examSessions will be taken from backend
  };
  @Input() actions: TableActionsModel[];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  ngOnInit() {
    
  }
}
