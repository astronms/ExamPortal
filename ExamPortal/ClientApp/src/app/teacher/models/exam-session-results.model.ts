import { ExamResultModel } from "src/app/models/exam-result-model";

export interface ExamSessionResultsModel {
    sessionResultId: number;
    exams: ExamResultModel[];
}