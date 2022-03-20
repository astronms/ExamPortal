import { ExamTypesEnum } from "../teacher/enums/exam-types.enum";
import { CourseModel } from "../teacher/models/course.model";

export interface ExamSessionModel {
    sessionId: number;
    sessionResultId?: number;
    name: string;
    startDate: Date;
    endDate: Date;
    courseId?: number;
    course?: CourseModel;
    type?: ExamTypesEnum;
    totalMembers?: number;
    participatedMembers?: number;
    score?: number;
    maxScore?: number;
}