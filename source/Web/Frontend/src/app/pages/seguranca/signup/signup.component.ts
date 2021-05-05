import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Auth } from "src/app/models/auth";
import { SignIn } from "src/app/models/signin";
import { Roles } from "src/app/models/roles";
import { User } from "src/app/models/user";
import { AppAuthService } from "src/app/services/auth.service";
import { AppUserService } from "src/app/services/user.service";

@Component({
    selector: "app-signup",
    templateUrl: "./signup.component.html"
})
export class AppSignupComponent {
    form = this.formBuilder.group({
        nome: ["", Validators.required],
        email: ["", Validators.required],
        sobrenome: ["", Validators.required],
        senha: ["", Validators.required]
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly userService: AppUserService,
        private readonly authService: AppAuthService) {
    }

    register() {

        const auth = new Auth({
            login: this.form.value.email,
            senha: this.form.value.senha,
            roles: Roles.User | Roles.Admin
        });

        const user = new User({
            nome: this.form.value.nome,
            sobrenome: this.form.value.sobrenome,
            email: this.form.value.email,
            auth: auth
        });

        this.userService.add(user)
            .subscribe((userId: number) => {
                if (userId)
                    this.authService.login(new SignIn({login: auth.login, 
                                                       password: auth.senha }));
            });
    }
}

