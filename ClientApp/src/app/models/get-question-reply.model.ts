import { QuestionModel } from "./question.model";

export interface GetQuestionReplyModel {
    examQuestionQuantity: number;
    currentQuestionNumber: number;
    leftTime: number;
    question: QuestionModel;
  }