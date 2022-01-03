import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {

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

}
