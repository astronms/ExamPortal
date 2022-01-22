import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-course-edit',
  templateUrl: './course-edit.component.html',
  styleUrls: ['./course-edit.component.css']
})
export class CourseEditComponent implements OnInit {

  course: CourseModel;
  redirect = "/teacher/courses-list";

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private courseService: CourseService
  ) { }

  ngOnInit(): void {
    var courseId = this.route.snapshot.paramMap.get('id');
    this.courseService.getCourse(courseId)
      .subscribe(result => {
        if(!result)
          this.router.navigate(["/404"]);
        this.course = result;
      });
  }
  
  saveClick(event) {
    this.courseService.modifyCourse(event).subscribe();
  }
}
