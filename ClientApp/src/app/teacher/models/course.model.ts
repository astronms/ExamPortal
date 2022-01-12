import { UserModel } from "src/app/models/user.model";

export interface CourseModel {
    courseId: number;
    name: string;
    creationDate: string;
    sessions: string[];
    users: UserModel[];
}

export interface CourseViewModel {
    id: number;
    no: number;
    title: string;
    creationDate: string;
    studentsNumber: number;
}