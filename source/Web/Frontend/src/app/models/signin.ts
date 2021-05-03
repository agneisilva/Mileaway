export class SignIn {
    login!: string;
    password!: string;

    public constructor(init?:Partial<SignIn>) {
        Object.assign(this, init);
    }
}
