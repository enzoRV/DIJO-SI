import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Buffet } from "./buffet";
import { BuffetService } from "./buffet.service"
import { Router } from '@angular/router';
import { Categoria } from './Categoria';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Buffet/RegistrarBuffet.component.html'
})

export class RegistrarBuffetComponent {
    buffet: Buffet = null;
    buffets: Buffet[]
    categorias: Categoria[]

    constructor(private _buffetService: BuffetService, private _router: Router) {
        this._buffetService.getCategorias()
            .subscribe(
            localReponse => this.categorias = localReponse

            )
        this.buffet = <Buffet>{
            nomprovBuffet: "",
            nomBuffet: "",
            desBuffet: "",
            preBuffet: 0.0,
            idCategoria: ""
        };
    }

    registrar(): void {

        if (this.buffet.nomprovBuffet == "") {
            alert("Ingrese Nombre del Proveedor")
        }
        else if (this.buffet.nomBuffet == "") {
            alert("Ingrese Nombre del Platillo")
        }
        else if (this.buffet.idCategoria == "") {
            alert("Seleccione Categoria")
        }
        else if (this.buffet.idCategoria == "-1") {
            alert("Seleccione Categoria")
        }
        else if (this.buffet.desBuffet == "") {
            alert("Ingrese una breve descripcion del platillo")
        }
        else if (this.buffet.preBuffet == 0) {
            alert("Ingrese el precio del platillo")
        }
        else {
            this._buffetService.createBuffet(this.buffet)
                .subscribe(buffet => {
                    this.buffet = buffet;
                    alert("Se Registro Buffet")
                    this._router.navigate(['buffets/']);
                });
        }

    }

}