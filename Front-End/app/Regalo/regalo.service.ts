import { Regalo } from "./regalo";
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";


@Injectable()
export class RegaloService {

    private _getRegalosURL: string = "http://localhost:54116/api/Regalos/ListarRegalos";
    private _createRegaloURL: string = "http://localhost:54116/api/Regalos/RegistrarRegalos";

    constructor(private _http: Http) {

    }

    regalos: Regalo[];

    getRegalos(): Observable<Regalo[]> {
        return this._http.get(this._getRegalosURL)
            .map((Response: Response) => <Regalo[]>Response.json())
            .catch(this.controlarException);
    }

    createRegalo(regalo: Regalo): Observable<Regalo> {
        var body = {
            desRegalo: regalo.desRegalo,
        }

        var req = this._http.post(this._createRegaloURL, body);
        return req.map((response: Response) => <Regalo>response.json())
            .catch(this.controlarException);

    }

    private controlarException(error: Response) {
        console.log("error", error);
        return Observable.throw(error.json().error || "Server Error");
    }
}