import { Local } from "./local";
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";
import { Distrito } from "./distrito";


@Injectable()
export class LocalService {

    private _getLocalesURL: string = "http://localhost:54116/api/Locales/ListarLocales";
    //private _deleteLocalesURL: string = "http://localhost:54116/api/Locales/EliminarLocal";
    private _createLocalesURL: string = "http://localhost:54116/api/Locales/RegistrarLocales";
    private _getDistritosURL: string = "http://localhost:54116/api/Locales/ListadoDistritos";
    private _deleteLocalURL: string = "http://localhost:54116/api/Locales/EliminarLocal?id=";
    private _updateLocalURL: string = "http://localhost:54116/api/Locales/ActualizarLocal";
    private _getLocalbyIDURL: string = "http://localhost:54116/api/Locales/ObtenerLocales?id=";


    constructor(private _http: Http) {

    }

    locales: Local[];
    distritos: Distrito[];

    getLocales(): Observable<Local[]> {
        return this._http.get(this._getLocalesURL)
            .map((Response: Response) => <Local[]>Response.json())
            .catch(this.controlarException);
    }

    getDistritos(): Observable<Distrito[]> {
        return this._http.get(this._getDistritosURL)
            .map((Response: Response) => <Local[]>Response.json())
            .catch(this.controlarException);
    }


    private handleError(error: Response) {
        return Observable.throw(error.json().error || "server error");
    }
    deleteLocal(id: string): Observable<Local> {
        var url = this._deleteLocalURL + id
        var req = this._http.delete(url);
        return req.map((response: Response) => <Local>response.json()).
            catch(this.handleError);
    }

    createLocal(local: Local): Observable<Local> {
        var body = {
            nomLocal: local.nomLocal,
            cantLocal: local.cantLocal,
            idDistrito: local.idDistrito,
            dirLocal: local.dirLocal,
            telfLocal: local.telfLocal
        }

        var req = this._http.post(this._createLocalesURL, body);
        return req.map((response: Response) => <Local>response.json())
            .catch(this.controlarException);

    }

    private controlarException(error: Response) {
        return Observable.throw(error.json().error || "Server Error");
    }

    getLocal(id: string): Observable<Local> {

        let url = this._getLocalbyIDURL + id;
        var req = this._http.get(url);
        return req.map((response: Response) => <Local>response.json()).
            catch(this.handleError)
    }

    updateLocal(local: Local): Observable<Local> {
        var body = {
            idLocal: local.idLocal,
            nomLocal: local.nomLocal,
            dirLocal: local.dirLocal,
            telfLocal: local.telfLocal,
            cantLocal: local.cantLocal,
            idDistrito: local.idDistrito
            
        }
        var req = this._http.post(this._updateLocalURL, body);
        return req.map((response: Response) => <Local>response.json())
            .catch(this.handleError);
    }



}