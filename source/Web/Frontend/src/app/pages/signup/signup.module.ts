import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { AppButtonModule } from "src/app/components/button/button.module";
import { AppInputPasswordModule } from "src/app/components/input/password/password.module";
import { AppInputTextModule } from "src/app/components/input/text/text.module";
import { AppLabelModule } from "src/app/components/label/label.module";
import { AppSignupComponent } from "./signup.component";

const ROUTES: Routes = [
    { path: "", component: AppSignupComponent }
];

@NgModule({
    declarations: [AppSignupComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES),
        AppButtonModule,
        AppInputPasswordModule,
        AppInputTextModule,
        AppLabelModule
    ]
})
export class AppSignupModule { }
