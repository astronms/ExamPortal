import { Observable } from "rxjs";
import { QuestionModel } from "src/app/models/question.model";

export interface ExamInterface{

    isPendingExam() : boolean;
    getQuestion() : Observable<QuestionModel>;
    sendAnswers() : void;
    getLeftTime() : number;
    removeTimer() : void;
}