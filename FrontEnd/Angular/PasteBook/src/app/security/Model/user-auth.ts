import { UserAuthBase } from "./user-auth-base";

export interface UserAuth extends UserAuthBase {
    userId?: number;
    firstName?: string;
    lastName?: string;
}
