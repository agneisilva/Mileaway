import { Routes } from "@angular/router";
import { AppGuard } from "./app.guard";
import { AppLayoutMainComponent } from "./layouts/layout-main/layout-main.component";
import { AppLayoutComponent } from "./layouts/layout/layout.component";

export const ROUTES: Routes = [
    {
        path: "",
        component: AppLayoutComponent,
        children: [
            { path: "", loadChildren: () => import("./pages/home/home.module").then((module) => module.AppHomeModule) }
        ]
    },
    {
        path: "main",
        component: AppLayoutMainComponent,
        canActivate: [AppGuard],
        children: [
            { path: "files", loadChildren: () => import("./pages/main/files/files.module").then((module) => module.AppFilesModule) },
            { path: "form", loadChildren: () => import("./pages/main/form/form.module").then((module) => module.AppFormModule) },
            { path: "home", loadChildren: () => import("./pages/main/home/home.module").then((module) => module.AppHomeModule) },
            { path: "list", loadChildren: () => import("./pages/main/list/list.module").then((module) => module.AppListModule) },
            { path: "perfil", loadChildren: () => import("./pages/perfil/perfil.module").then((module) => module.AppPerfilModule) }
        ]
    },
    {
        path: "cadastro",
        component: AppLayoutMainComponent,
        canActivate: [AppGuard],
        children: [
            { path: "cartao", loadChildren: () => import("./pages/cadastros/cartao/cartao.module").then((module) => module.AppFilesModule) },
        ]
    },
    {
        path: "seguranca",
        component: AppLayoutComponent,
        children: [
            { path: "logar", loadChildren: () => import("./pages/seguranca/signin/signin.module").then((module) => module.AppSigninModule) },
            { path: "cadastrar", loadChildren: () => import("./pages/seguranca/signup/signup.module").then((module) => module.AppSignupModule) },
            { path: "esqueci-minha-senha", loadChildren: () => import("./pages/seguranca/esqueceu-senha/esqueceu.senha.module").then((module) => module.AppEsqueceuSenhaModule) },
            { path: "resetar-minha-senha", loadChildren: () => import("./pages/seguranca/resetar-senha/resetar.senha.module").then((module) => module.AppResetarSenhaModule) }
        ]
    },
    {
        path: "**",
        redirectTo: ""
    }
];
