import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Local } from "./local";
import { LocalService } from "./local.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/ListaLocal.component.html'
})

export class ListaLocalComponent {
    locales: Local[];
    local: Local = null;

    constructor(private _localService: LocalService, private _router: Router) {
    
    }

    ngOnInit(): void{
        this.listar();
    }
    
    listar() : void {
        this._localService.getLocales()
        .subscribe(
        localReponse => this.locales = localReponse
        )
    }
    eliminarLocal(id: string) {
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if (response) {
            this._localService.deleteLocal(id)
                .subscribe(local => {
                    this.local = local
                    alert("Se elimino Registro")
                    this.listar()
                });


        }
    }

}