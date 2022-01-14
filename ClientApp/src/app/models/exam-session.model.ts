import { CourseModel } from "../teacher/models/course.model";

export interface ExamSessionModel {
    sessionId: number;
    name: string;
    startDate: Date;
    endDate: Date;
    courseId: number;
    course: CourseModel;
}