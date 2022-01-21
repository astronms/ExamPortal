import { UserModel } from "src/app/models/user.model";

export interface CourseModel {
    courseId: number;
    name: string;
    creationDate: string;
    sessions: string[];
    users: {user: UserModel}[];
}