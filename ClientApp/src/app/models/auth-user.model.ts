import { RoleEnum } from "../enums/role.enum"

export interface AuthUserModel {
    email: string;
    role: RoleEnum;
    token?: string;
}