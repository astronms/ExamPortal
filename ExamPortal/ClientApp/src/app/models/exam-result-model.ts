export interface ExamResultModel {
    sessionResultId: number;
    resultTasks: TaskResultModel[];
    finalScore: number;
    maxScore: number;
}

export interface TaskResultModel {
    title: string;
    type: string;
    image?: any;
    imageType: any;
    sortId: any;
    resultValues: ResultValueModel[];
    taskScore: number;
    taskMaxScore: number;
}

export interface ResultValueModel {
    value: string;
    actual: string;
    correct: string;
    score: number;
    maxScore: number;
}
