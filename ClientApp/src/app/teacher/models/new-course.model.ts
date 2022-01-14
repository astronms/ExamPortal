import { UserModel } from "src/app/models/user.model";

export interface NewCourse {
    name: string;
    creationDate: Date;
    users: UserModel[];
}
