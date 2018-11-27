import { Local } from "./local";
import { Subscription } from "rxjs/Subscription";
import { Component } from "@angular/core";
import { LocalService } from "./local.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: 'lista-app',
    templateUrl: 'app/Local/Actualizalocal.component.html'
})

export class ActualizarLocalComponent {
    local: Local = null;
    private sub: Subscription
    id: string

    constructor(private _localService: LocalService,
        private _router: Router,
        private _route: ActivatedRoute) {
    }

    ngOnInit() {
        this._route.params.subscribe(params => {
            this.id = params['id'];
            this.obtener(this.id)
        });
    }

    obtener(id: string) {
        this._localService.getLocal(id)
            .subscribe(local => {
                this.local = local
            })
    }


    actualizar(): void {

        this._localService.updateLocal(this.local)
            .subscribe(local => {
                this.local = local;
                this._router.navigate(['locales/']);
            });



    }



}