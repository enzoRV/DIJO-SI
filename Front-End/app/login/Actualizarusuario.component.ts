import { Usuario } from "./usuario";
import { Subscription } from "rxjs/Subscription";
import { Component } from "@angular/core";
import { UsuarioService } from "./usuario.service";
import { Router, ActivatedRoute } from "@angular/router";


@Component({
    selector: 'lista-app',
    templateUrl: 'app/login/Actualizarusuario.component.html'
})

export class ActualizarUsuarioComponent {
    usuario: Usuario = null;
    private sub: Subscription
    id: string

    constructor(private _usuarioService: UsuarioService,
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
        this._usuarioService.getUsuario(id)
            .subscribe(usuario => {
                this.usuario = usuario
            })
    }

    actualizar(): void {
        this._usuarioService.updateUsuario(this.usuario)
        .subscribe(usuario => {
            this.usuario = usuario;
            this._router.navigate(['usuarios/']);
        })
    }


}