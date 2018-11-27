import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import { FotografoService } from "./fotografo.service"
import { Router } from '@angular/router';
import { Console } from '@angular/core/src/console';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/Registrafografo.component.html'
})

export class RegistrarFotografoComponent {
    fotografo: Fotografo = null;

    constructor(private _fotografoService: FotografoService, private _router: Router) {
        this.fotografo = <Fotografo>{
            nomFotografo: "",
            telfFotografo: "",
            dirFotografo: ""
        };
    }

    registrar(): void {

        if (this.fotografo.nomFotografo == "") {
            alert("Ingrese Nombre")
        } else if (this.fotografo.telfFotografo == "") {
            alert("Ingrese Telefono")
        }
        else if (this.fotografo.dirFotografo == "") {
            alert("Ingrese Direccion")
        }
        else {
            this._fotografoService.createFotografo(this.fotografo)
                .subscribe(fotografo => {
                    this.fotografo = fotografo;
                    alert("Se agrego el fotografo")
                    this._router.navigate(['fotografos/']);
                });
        }


    }

}