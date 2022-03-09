import { UserModel } from "./user.model";

export interface ExamResultModel {
    examResultId: number;
    task: TaskResultModel[];
    finalScore: number;
    maxScore: number;
    userId: number;
    user?: UserModel;
    examId: number;
    sessionResultId: number;
}

export interface TaskResultModel {
    taskResultId: number;
    title: string;
    image?: any;
    sortId: any;
    resultValues: TaskResultModel[];
    taskScore: number;
    taskMaxScore: number;

}

export interface TaskResultModel {
    resultValueId: number;
    actual: string;
    correct: string;
    score: number;
    maxScore: number;
}