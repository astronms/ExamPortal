import { CourseModel } from "../teacher/models/course.model";

export interface ExamSessionModel {
    sessionId: number;
    sessionResultId?: number;
    name: string;
    startDate: Date;
    endDate: Date;
    courseId?: number;
    course?: CourseModel;
    totalMembers?: number;
    participatedMembers?: number;
    score?: number;
    maxScore?: number;
}