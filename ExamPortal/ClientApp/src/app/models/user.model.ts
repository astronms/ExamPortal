import { RoleEnum } from "../enums/role.enum";

export interface UserModel {
    id?: number;
    email: string;
    password?: string;
    firstName: string;
    lastName: string;
    studentInfo?: StudentInfoModel;
    role?: RoleEnum;
    token?: string;
}

export interface StudentInfoModel {
    index: number;
}