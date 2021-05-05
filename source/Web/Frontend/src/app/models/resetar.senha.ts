export class ResetarSenha {
    novaSenha!: string;
    email!: string;
    token!: string
    
    public constructor(init?: Partial<ResetarSenha>) {
        Object.assign(this, init);
    }
}
