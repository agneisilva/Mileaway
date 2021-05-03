import { Roles } from './roles';

export class Auth {
    login!: string;
    senha!: string;
    roles!: Roles;

    public constructor(init?:Partial<Auth>) {
        Object.assign(this, init);
    }
}
