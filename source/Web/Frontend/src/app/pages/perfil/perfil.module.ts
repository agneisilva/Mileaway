import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { AppButtonModule } from "src/app/components/button/button.module";
import { AppPerfilComponent } from "./perfil.component";

const ROUTES: Routes = [
    { path: "", component: AppPerfilComponent }
];

@NgModule({
    declarations: [AppPerfilComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES), 
        AppButtonModule
    ]
})
export class AppPerfilModule { }
