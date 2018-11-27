import { Component } from "@angular/core";
import { Usuario } from "./usuario";
import { UsuarioService } from "./usuario.service";
import { Router } from "@angular/router";

@Component({
    selector: 'lista-app',
    templateUrl: 'app/login/ListaUsuario.component.html'
})

export class ListaUsuarioComponent {
    usuarios: Usuario[];
    usuario: Usuario = null;

    constructor(private _usuarioService: UsuarioService, private _router: Router) {

    }

    ngOnInit(): void {
        this.listar();
    }

    listar(): void {
        this._usuarioService.getUsuarios()
            .subscribe(
                usuarioResponse => this.usuarios = usuarioResponse
            )
    }


    eliminarUsuario(id: string) {
        var response = confirm("Esta seguro que desea eliminar el registro?")
        if (response) {
            this._usuarioService.deleteUsuario(id)
                .subscribe(usuario => {
                    this.usuario = usuario
                    alert("Se elimino Registro")
                    this.listar()
                });


        }
    }


}