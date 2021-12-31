export interface ExamModel {
    id: number;
    title: string;
    duration: number;
    questionsNumber: number;
    startDate: string;
    available: boolean;
}

export interface ExamViewModel {
  no: number;
  title: string;
  duration: number;
  questionsNumber: number;
  startDate: string;
  available: boolean;
}