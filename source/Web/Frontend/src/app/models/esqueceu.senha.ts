export class EsqueceuSenha {
    email!: string;
    redirectRoute!: string;
    
    public constructor(init?:Partial<EsqueceuSenha>) {
        Object.assign(this, init);
    }
}
