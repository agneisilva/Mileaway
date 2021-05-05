import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AppAuthService } from "src/app/services/auth.service";
import { EsqueceuSenha } from "src/app/models/esqueceu.senha";
import { FormsHelper } from "src/app/core/forms.helper";

@Component({
    selector: "app-esqueceu-senha",
    templateUrl: "./esqueceu.senha.component.html"
})
export class AppEsqueceuSenhaComponent {

    public successMessage: string = "";
    public errorMessage: string = "";
    public showSuccess: boolean = false;
    public showError: boolean = false;

    public forgotPasswordForm: FormGroup = this.formBuilder.group({
        email: ["", Validators.email]
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appAuthService: AppAuthService, 
        public readonly formsHelper: FormsHelper) {
    }

    public esqueceuSenha = () => {
        this.showError = this.showSuccess = false;

        const forgotPass = { ...this.forgotPasswordForm.value };

        this.appAuthService.esqueceuSenha(new EsqueceuSenha({
            email: forgotPass.email,
            redirectRoute: '/seguranca/resetar-minha-senha'
        }))
        .subscribe((_: any) => {
            this.showSuccess = true;
            this.successMessage = 'O Link foi enviado, por favor verifique seu email para resetar sua senha'
        },
        (err: any) => {
            this.showError = true;
            this.errorMessage = err;
        });
    }
}

