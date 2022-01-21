import { Component } from '@angular/core';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-course-creator',
  templateUrl: './course-creator.component.html',
  styleUrls: ['./course-creator.component.css']
})
export class CourseCreatorComponent{

  redirect = '/teacher/courses-list';

  constructor(private courseService: CourseService) { }

  saveClick(event) {
    this.courseService.addCourse(event).subscribe();
  }
  
}
