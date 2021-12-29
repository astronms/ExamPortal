import { RoleEnum } from "../enums/role.enum"

export class UserModel {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    index: number;
    role: RoleEnum;
    token?: string;
}