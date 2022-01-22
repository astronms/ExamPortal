import { UserModel } from "src/app/models/user.model";

export interface CourseModel {
    courseId: number;
    name: string;
    creationDate: Date;
    sessions: string[];
    users: UserModel[];
}