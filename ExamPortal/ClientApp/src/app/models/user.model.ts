import { RoleEnum } from "../enums/role.enum";
import { ExamResultModel } from "./exam-result-model";

export interface UserModel {
    id?: number;
    email: string;
    password?: string;
    firstName: string;
    lastName: string;
    studentInfo?: StudentInfoModel;
    role?: RoleEnum;
    token?: string;
    score?: number;
    maxScore?: number;
}

export interface StudentInfoModel {
    index: number;
    examResult?: ExamResultModel;
}