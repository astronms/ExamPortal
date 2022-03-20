import { Component, Input, ViewChild, OnInit, Output, EventEmitter } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'app-exam-sessions-table-template',
  templateUrl: './exam-sessions-table-template.component.html',
  styleUrls: ['./exam-sessions-table-template.component.css']
})
export class ExamSessionTableTemplateComponent {

  dataSource: MatTableDataSource<any>;
  @Input() set data(value) {
    this.dataSource = new MatTableDataSource<any>(value);
    if(this.dataSource)
      this.dataSource.paginator = this.paginator;
  };
  @Input() columnsToDisplay : string[];
  @Input() actions: TableActionsModel[];
  @Output() actionClick = new EventEmitter<{action: string; id: string}>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  onActionClick(actionClicked: string, rowId: string) : void
  {
    this.actionClick.emit({
      action: actionClicked,
      id: rowId
    });
  }
}
