import { Buffet } from "./buffet";
import { Http, Response } from '@angular/http';
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { error } from "util";
import { Categoria } from "./Categoria";


@Injectable()
export class BuffetService {

    private _getBuffetsURL: string = "http://localhost:54116/api/Buffets/ListarBuffets";
    private _getCategoriasURL: string = "http://localhost:54116/api/Buffets/ListarCategorias";
    private _createBuffetURL: string = "http://localhost:54116/api/Buffets/RegistrarBuffets";
    private _getBuffetbyIDURL: string = "http://localhost:54116/api/Buffets/ObtenerBuffets?id=";
    private _deleteBuffetURL: string = "http://localhost:54116/api/Buffets/EliminarBuffets?id=";
    private _updateBuffetURL: string = "http://localhost:54116/api/Buffets/ActualizarBuffets";
    
    
    constructor(private _http: Http) {

    }

    buffets: Buffet[];


    private handleError(error: Response) {
        return Observable.throw(error.json().error || "server error");
    }

    getBuffets(): Observable<Buffet[]> {
        return this._http.get(this._getBuffetsURL)
            .map((Response: Response) => <Buffet[]>Response.json())
            .catch(this.controlarException);
    }

    getCategorias(): Observable<Categoria[]> {
        return this._http.get(this._getCategoriasURL)
            .map((Response: Response) => <Categoria[]>Response.json())
            .catch(this.controlarException);
    }

    deleteBuffet(id: string): Observable<Buffet> {
       
        var url = this._deleteBuffetURL + id
        //console.log(url)
        var req = this._http.delete(url);
        return req.map((response: Response) => <Buffet>response.json()).
            catch(this.handleError);



       // var body = {
         //   idBuffet: buffet.idBuffet}
        //var req = this._http.post(this._deleteBuffetURL, body);
        //return req.map((response: Response) => <Buffet>response.json())
         //   .catch(this.controlarException);
           
    }

    createBuffet(buffet: Buffet): Observable<Buffet> {
        var body = {
            nomprovBuffet: buffet.nomprovBuffet,
            nomBuffet: buffet.nomBuffet,
            desBuffet: buffet.desBuffet,
            preBuffet: buffet.preBuffet,
            idCategoria: buffet.idCategoria
        }

        var req = this._http.post(this._createBuffetURL, body);
        return req.map((response: Response) => <Buffet>response.json())
            .catch(this.controlarException);

    }

    private controlarException(error: Response) {
        return Observable.throw(error.json().error || "Server Error");
    }


    updateBuffet(buffet: Buffet): Observable<Buffet>{
        var body = {
            idBuffet: buffet.idBuffet,
            preBuffet: buffet.preBuffet
        }
        var req = this._http.post(this._updateBuffetURL, body);
        return req.map((response: Response) => <Buffet>response.json())
            .catch(this.handleError);

    }
    getBuffet(id: string): Observable<Buffet> {

        let url = this._getBuffetbyIDURL + id;
        var req = this._http.get(url);
        return req.map((response: Response) => <Buffet>response.json()).
            catch(this.handleError)
    }


}