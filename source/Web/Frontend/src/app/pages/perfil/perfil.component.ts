import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { AppAuthService } from "src/app/services/auth.service";
import { AppUserService } from "src/app/services/user.service";

@Component({
    selector: "app-perfil",
    templateUrl: "./perfil.component.html"
})
export class AppPerfilComponent {
    form = this.formBuilder.group({
        login: ["admin", Validators.required],
        password: ["admin", Validators.required]
    });

    constructor(
        private readonly formBuilder: FormBuilder, 
        private readonly userService: AppUserService, 
        private readonly appAuthService: AppAuthService) {
    }

    signout() {
        this.appAuthService.signout();
    }

    deletar(){
        this.userService.delete().subscribe(_ => {
            this.signout();
        });
    }
}

