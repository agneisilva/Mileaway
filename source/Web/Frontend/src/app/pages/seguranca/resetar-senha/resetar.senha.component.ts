import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { FormsHelper } from "src/app/core/forms.helper";
import { ResetarSenha } from "src/app/models/resetar.senha";
import { AppAuthService } from "src/app/services/auth.service";

@Component({
    selector: "app-resetar-senha",
    templateUrl: "./resetar.senha.component.html"
})
export class AppResetarSenhaComponent {
    
    public showSuccess: boolean = false;
    public showError: boolean = false;
    public errorMessage: string = "";

    private _token: string = "";
    private _email: string = "";

    public resetPasswordForm: FormGroup = this.formBuilder.group({
        senha: ["", Validators.required]
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appAuthService: AppAuthService, 
        private readonly route: ActivatedRoute, 
        public readonly formsHelper: FormsHelper) {

        this._token = this.route.snapshot.queryParams['token'];
        this._email = this.route.snapshot.queryParams['email'];
    }

    public resetarSenha = () => {
        this.showError = this.showSuccess = false;
    
        const resetPass = { ... this.resetPasswordForm.value };
        const resetPassDto = new ResetarSenha({
          novaSenha: resetPass.senha,
          token: this._token,
          email: this._email
        });
    
        this.appAuthService
        .resetarSenha(resetPassDto)
        .subscribe((_: any) => {
          this.showSuccess = true;
        },
        (error: any) => {
          this.showError = true;
          this.errorMessage = error.error;
        })
      }
}

