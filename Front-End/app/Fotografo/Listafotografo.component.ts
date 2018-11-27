import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import { FotografoService } from "./fotografo.service"
import { Router } from '@angular/router'

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/ListaFotografo.component.html'
})

export class ListaFotografoComponent {
    fotografos: Fotografo[];
    fotografo: Fotografo = null;

    constructor(private _fotografoService: FotografoService, private _router: Router) {
    
    }

    ngOnInit(): void{
        this.listar();
    }
    
    listar() : void {
        this._fotografoService.getFotografos()
        .subscribe(
        fotografoReponse => this.fotografos = fotografoReponse
        )
    }

    eliminarFotografo(id: string) {
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if (response) {
            this._fotografoService.deleteFotografo(id)
                .subscribe(fotografo => {
                    this.fotografo = fotografo
                    alert("Se elimino Registro")
                    //this._router.navigate(['fotografos/']);
                    this.listar()
                });


        }
    }



}