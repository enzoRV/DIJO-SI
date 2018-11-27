import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Regalo } from "./regalo";
import { RegaloService } from "./regalo.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Regalo/Registrarregalo.component.html'
})

export class RegistrarRegaloComponent {
    regalo: Regalo = null;

    constructor(private _regaloService: RegaloService, private _router: Router) {
        this.regalo = <Regalo>{
            desRegalo: ""
        };
    }

    registrar(): void {
        if (this.regalo.desRegalo == "") {
            alert("Debe Ingresar un Regalo")
        }
        else {
            this._regaloService.createRegalo(this.regalo)
                .subscribe(regalo => {
                    this.regalo = regalo;
                    alert("Se agrego Regalo")
                    this._router.navigate(['regalos/']);
                });

        }
    }

}