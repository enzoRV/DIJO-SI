import { Fotografo } from "./fotografo";
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";
import { Router } from "@angular/router/src/router";


@Injectable()
export class FotografoService {

    private _getFotografosURL: string = "http://localhost:54116/api/Fotografos/ListarFotografos";
    private _createFotografoURL: string = "http://localhost:54116/api/Fotografos/RegistrarFotografos";
    private _updateFotografoURL: string = "http://localhost:54116/api/Fotografos/ActualizarFotografos";
    private _getFotografobyIDURL: string = "http://localhost:54116/api/Fotografos/ObtenerFotografos?id=";
    private _deleteFotografoURL: string = "http://localhost:54116/api/Fotografos/EliminarFotografos?id=";
    fotografo: Fotografo = null;

    constructor(private _http: Http) {
    }

    fotografos: Fotografo[];

    getFotografos(): Observable<Fotografo[]> {
        return this._http.get(this._getFotografosURL)
            .map((Response: Response) => <Fotografo[]>Response.json())
            .catch(this.handleError);
    }

    createFotografo(fotografo: Fotografo): Observable<Fotografo> {
        var body = {
            NomFotografo: fotografo.nomFotografo,
            telfFotografo: fotografo.telfFotografo,
            dirFotografo: fotografo.dirFotografo
        }

        var req = this._http.post(this._createFotografoURL, body);
        return req.map((response: Response) => <Fotografo>response.json())
            .catch(this.handleError);

    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || "server error");
    }

    updateFotografo(fotografo: Fotografo): Observable<Fotografo> {
        var body = {
            idFotografo: fotografo.idFotografo,
            telfFotografo: fotografo.telfFotografo,
            dirFotografo: fotografo.dirFotografo
        }
        var req = this._http.post(this._updateFotografoURL, body);
        return req.map((response: Response) => <Fotografo>response.json())
            .catch(this.handleError);
    }

    getFotografo(id: string): Observable<Fotografo> {

        let url = this._getFotografobyIDURL + id;
        //console.log(url)
        var req = this._http.get(url);
        return req.map((response: Response) => <Fotografo>response.json()).
            catch(this.handleError)
    }

    deleteFotografo(id: string): Observable<Fotografo> {
        var url = this._deleteFotografoURL + id
        var req = this._http.delete(url);
        return req.map((response: Response) => <Fotografo>response.json()).
            catch(this.handleError);
    }


}