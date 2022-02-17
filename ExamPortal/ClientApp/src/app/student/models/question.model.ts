export interface QuestionModel {
  taskId: number;
  title: string;
  type: string;
  time: number;
  imageType: string;
  image: string;
  values: QuestionValue[];
}

export interface QuestionValue {
  sortId: number;
  regex: string;
  text: string;
}