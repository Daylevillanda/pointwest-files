import { UserAuthBase } from "../shared/security/user-auth-base";

export class AppUserAuth extends UserAuthBase{
    canAccessProducts: boolean = false;
    canAccessCategories: boolean = false;
    canAccessLogs: boolean = false;
    canAccessSettings: boolean = false;
    canAddProduct: boolean = false;
    canEditProduct: boolean = false;
    canDeleteProduct: boolean = false;

    init(): void {
        super.init();
        this.canAccessProducts = false;
        this.canAccessCategories = false;
        this.canAccessLogs = false;
        this.canAccessSettings = false;
        this.canAddProduct = false;
        this.canEditProduct = false;
        this.canDeleteProduct = false;
    }
}