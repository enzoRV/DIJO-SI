import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Regalo } from "./regalo";
import { RegaloService } from "./regalo.service"

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Regalo/ListaRegalo.component.html'
})

export class ListaRegaloComponent {
    regalos: Regalo[];

    constructor(private _regaloService: RegaloService) {
        this._regaloService.getRegalos()
            .subscribe(
            regaloReponse => this.regalos = regaloReponse
            )
    }

}