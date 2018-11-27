import { Component, OnInit } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Fotografo } from "./fotografo";
import { FotografoService } from "./fotografo.service"
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';


@Component({
    selector: 'lista-app',
    templateUrl: 'app/Fotografo/Actualizafotografo.component.html'
})

export class ActualizarFotografoComponent {
    fotografo: Fotografo = null;
    private sub: Subscription
    id : string

    constructor(private _fotografoService: FotografoService, 
                private _router: Router,     
                private _route: ActivatedRoute) {   
    }

    ngOnInit(){
        this._route.params.subscribe( params => {
            this.id = params['id'];
            this.obtener(this.id)
        });
    }

    obtener(id: string) {
        this._fotografoService.getFotografo(id)
            .subscribe(fotografo => {
                this.fotografo = fotografo
            })
    }

    actualizar(): void {

        this._fotografoService.updateFotografo(this.fotografo)
            .subscribe(fotografo => {
                this.fotografo = fotografo;
                this._router.navigate(['fotografos/']);
            });



    }




}