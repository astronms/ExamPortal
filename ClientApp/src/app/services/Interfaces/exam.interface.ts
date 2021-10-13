import { Observable } from "rxjs";
import { QuestionModel } from "src/app/models/question.model";

export interface IExam{

    isPendingExam() : boolean;
    getQuestion() : Observable<QuestionModel>;
    sendAnswers() : void;
    getLeftTime() : number;
    removeTimer() : void;
}