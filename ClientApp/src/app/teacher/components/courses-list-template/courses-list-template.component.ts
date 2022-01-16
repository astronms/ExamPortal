import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'app-courses-list-template',
  templateUrl: './courses-list-template.component.html',
  styleUrls: ['./courses-list-template.component.css']
})
export class CoursesListTemplateComponent implements OnInit {

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

  ngOnInit(): void {
  }

}