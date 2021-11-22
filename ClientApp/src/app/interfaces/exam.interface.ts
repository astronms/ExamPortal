import { Observable } from "rxjs";
import { QuestionModel } from "src/app/models/question.model";

export interface ExamInterface{

    examStatusObservable : Observable<any>;

    isPendingExam() : boolean;
    getQuestion() : Observable<QuestionModel>;
    sendAnswers() : void;
    getLeftTime() : number;
}