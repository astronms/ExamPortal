export interface QuestionModel {
  title: string;
  type: string;
  time: number;
  image: string;
  values: QuestionValue[];
}

export interface QuestionValue {
  sortId: number;
  regex: string;
  text: string;
}