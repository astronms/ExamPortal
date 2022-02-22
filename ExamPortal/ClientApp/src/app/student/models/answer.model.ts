export interface AnswerModel {
    taskId: number;
    values: AnswerValueModel[];
}

export interface AnswerValueModel {
    sortId: number;
    answer: string;
}