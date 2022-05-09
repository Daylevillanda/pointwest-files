import { inherits } from "util";

export class UserAuthBase {
    userName: string = "";
    bearerToken: string = "";
    isAuthenticated: boolean = false;

    init(): void {
        this.userName = "";
        this.bearerToken = "";
        this.isAuthenticated = false;
    }
}

