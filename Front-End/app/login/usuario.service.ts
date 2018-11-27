import { Usuario } from "./usuario";
import { Injectable } from "@angular/core";
import { Http } from "@angular/http"
import { Response } from "@angular/http/src/static_response";
import { Observable } from "rxjs/Observable";

@Injectable()
export class UsuarioService {
    private _getUsuariosURL: string = "http://localhost:54116/api/Usuario/ListarUsuarios";
    private _Login: string = "http://localhost:54116//api/Usuario/Login";
    private _createUser: string = "http://localhost:54116/api/Usuario/Registra";
    private _getUsuariobyIDURL: string = "http://localhost:54116/api/Usuario/ObtenerUsuarios?id=";
    private _deleteUsuarioURL: string = "http://localhost:54116/api/Usuario/EliminarUsuarios?id=";
    private _updateUsuarioURL: string = "http://localhost:54116/api/Usuario/ActualizarUsuarios";
    usuario: Usuario = null;

    constructor(private _http: Http) {

    }

    login(usuario: Usuario): Observable<Usuario> {

        var body = {
            loginUsuario: usuario.loginUsuario,
            passUsuario: usuario.passUsuario

        };

        var req = this._http.post(this._Login, body);
        return req.map((response: Response) => <Usuario>response.json())
            .catch(this.handleError);

    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || "server error");
    }

    getUsuarios(): Observable<Usuario[]> {
        return this._http.get(this._getUsuariosURL)
            .map((Response: Response) => <Usuario[]>Response.json())
            .catch(this.handleError);

        ///return this.usuario;

    }

    getUsuario(id: string): Observable<Usuario> {

        let url = this._getUsuariobyIDURL + id;
        var req = this._http.get(url);
        return req.map((response: Response) => <Usuario>response.json()).
            catch(this.handleError)

    }



    /////////listado //////////////////
    getListadoUsuario(): Observable<Usuario[]> {
        return this._http.get(this._getUsuariobyIDURL)
            .map((Response: Response) => <Usuario[]>Response.json())
            .catch(this.handleError);
    }





    /////////////////Eliminar //////////////////


    deleteUsuario(id: string): Observable<Usuario> {
        var url = this._deleteUsuarioURL + id

        var req = this._http.delete(url);
        return req.map((response: Response) => <Usuario>response.json()).
            catch(this.handleError);
    }


    createUsuario(usuario: Usuario): Observable<Usuario> {
        var body = {
            nomUsuario: usuario.nomUsuario,
            apePatUsuario: usuario.apePatUsuario,
            apeMatUsuario: usuario.apeMatUsuario,
            dniUsuario: usuario.dniUsuario,
            telfUsuario: usuario.telfUsuario,
            dirUsuario: usuario.dirUsuario,
            emailUsuario: usuario.emailUsuario,
            loginUsuario: usuario.loginUsuario,
            passUsuario: usuario.passUsuario,
        }

        var req = this._http.post(this._createUser, body);
        return req.map((response: Response) => <Usuario>response.json())
            .catch(this.handleError);
    }


    updateUsuario(usuario: Usuario): Observable<Usuario> {
        var body = {
            idUsuario: usuario.idUsuario,
            telfUsuario: usuario.telfUsuario,
            dirUsuario: usuario.dirUsuario,
            emailUsuario: usuario.emailUsuario,
            passUsuario: usuario.passUsuario
        }
        var req = this._http.post(this._updateUsuarioURL, body);
        return req.map((response: Response) => <Usuario>response.json())
            .catch(this.handleError);
    }


}