import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppFormModule } from "./form/form.module";
import { AppListModule } from "./list/list.module";


@NgModule({
    declarations: [],
    imports: [
        AppFormModule, 
        AppListModule
    ]
})
export class AppCartaoModule { }
