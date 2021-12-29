import { Component, OnInit, Input } from '@angular/core';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'app-exam-table',
  templateUrl: './exam-table.component.html',
  styleUrls: ['./exam-table.component.css']
})
export class ExamTableComponent implements OnInit {

  @Input() columnsToDisplay : string[];
  @Input() data;
  @Input() actions: TableActionsModel[];

  constructor() { }

  ngOnInit() {
  }

}
