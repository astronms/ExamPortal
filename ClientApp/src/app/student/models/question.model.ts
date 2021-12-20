import { AnswerModel } from "./answer.model";

export interface QuestionModel {
    id: number;
    content: string;
    time: number;
    answers: AnswerModel[];
  }