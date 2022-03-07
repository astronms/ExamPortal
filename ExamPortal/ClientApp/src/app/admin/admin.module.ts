import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { TeacherCreatorComponent } from './components/teacher-creator/teacher-creator.component';



@NgModule({
  declarations: [
    TeacherCreatorComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class AdminModule { }
