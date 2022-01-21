export interface UserModel {
    id?: number;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    studentInfo: StudentInfoModel;
}

export interface StudentInfoModel {
    index: number;
}