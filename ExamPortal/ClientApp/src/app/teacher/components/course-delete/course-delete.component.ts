import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-course-delete',
  templateUrl: './course-delete.component.html',
  styleUrls: ['./course-delete.component.css']
})
export class CourseDeleteComponent implements OnInit {

  course: CourseModel;

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

  deleteClick()
  {
    this.courseService.deleteCourse(this.course);
    this.router.navigate(["/teacher/courses-list"]);
  }

}
