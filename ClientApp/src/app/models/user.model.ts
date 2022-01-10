export interface UserModel {
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    studentInfo: StudentInfoModel;
}

export interface StudentInfoModel {
    index: number;
}