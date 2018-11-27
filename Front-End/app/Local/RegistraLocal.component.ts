import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Local } from "./local";
import { LocalService } from "./local.service"
import { Router } from '@angular/router';
import { Distrito } from './distrito';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/RegistraLocal.component.html'
})

export class RegistrarLocalComponent {
    local: Local = null;
    distritos: Distrito[]

    constructor(private _localService: LocalService, private _router: Router) {
        this._localService.getDistritos()
            .subscribe(
            localReponse => this.distritos = localReponse

            )
        this.local = <Local>{
            nomLocal: "",
            dirLocal: "",
            telfLocal: "",
            cantLocal: 0,
            idDistrito: ""
        };
        console.log(this.distritos)
    }

    registrar(): void {
        if (this.local.nomLocal == "") {
            alert("Ingrese Nombre del Local")
        }
        else if (this.local.telfLocal == "") {
            alert("Ingrese Numero de Contacto del Local")
        }
        else if (this.local.idDistrito == "") {
            alert("Seleccione Distrito")
        }
        else if (this.local.idDistrito == "-1") {
            alert("Seleccione Distrito")
        }
        else if (this.local.dirLocal == "") {
            alert("Ingrese Direccion del Local")
        }
        else if (this.local.cantLocal < 0) {
            alert("Ingrese la Cantidad Maxima de Invitados")
        }
        else {
            this._localService.createLocal(this.local)
                .subscribe(local => {
                    this.local = local;
                    alert("Se Registro Local")
                    this._router.navigate(['locales/']);
                });
        }

    }

}