import { RoleEnum } from "../enums/role.enum"

export class AuthUserModel {
    email: string;
    role: RoleEnum;
    token?: string;
}