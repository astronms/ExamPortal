import { UserModel } from "src/app/models/user.model";

export interface ExamSessionResultsModel {
    sessionResultId: number;
    sessionId: number;
    usersScore: {
        user: UserModel;
        score: number;
        maxScore: number;
    }[];
}