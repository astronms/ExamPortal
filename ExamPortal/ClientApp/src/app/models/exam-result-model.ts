export interface ExamResultModel {
    sessionResultId: number;
    resultTasks: TaskResultModel[];
    finalScore: number;
    maxScore: number;
}

export interface TaskResultModel {
    title: string;
    image?: any;
    sortId: any;
    resultValues: ResultValue[];
    taskScore: number;
    taskMaxScore: number;
}

export interface ResultValue {
    actual: string;
    correct: string;
    score: number;
    maxScore: number;
}
