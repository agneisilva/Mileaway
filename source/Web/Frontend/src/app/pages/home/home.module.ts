import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { AppButtonModule } from "src/app/components/button/button.module";
import { AppHomeComponent } from "./home.component";

const ROUTES: Routes = [
    { path: "", component: AppHomeComponent }
];

@NgModule({
    declarations: [AppHomeComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(ROUTES),
        AppButtonModule
    ]
})

export class AppHomeModule { }
