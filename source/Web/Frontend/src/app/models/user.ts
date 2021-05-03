import { Auth } from "./auth";

export class User {
    email!: string;
    nome!: string;
    id!: number;
    sobrenome!: string;
    auth!: Auth;

    public constructor(init?:Partial<User>) {
        Object.assign(this, init);
    }
}
