import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { GridParameters } from "src/app/components/grid/grid-parameters";
import { GridService } from "src/app/components/grid/grid.service";
import { User } from "src/app/models/user";

@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(
        private readonly http: HttpClient,
        private readonly gridService: GridService) { }

    add = (user: User) => this.http.post<number>("user", user);

    delete(){
        return this.http.delete("user");
    }

    get = (id: number) => this.http.get<User>(`user/${id}`);

    grid = (parameters: GridParameters) => this.gridService.get<User>(`user/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`user/${id}/inactivate`, {});

    list = () => this.http.get<User[]>("user");

    update = (user: User) => this.http.put(`user/${user.id}`, user);
}
