import { Component } from '@angular/core';
import { flatten } from '@angular/compiler';
import { Usuario } from "./usuario";
import { UsuarioService } from "./usuario.service"
import { Router } from '@angular/router';

@Component({
    selector: 'lista-app',
    templateUrl: 'app/login/RegistrarUsuario.component.html'
})

export class RegistrarUsuarioComponent {
    usuario: Usuario = null;

    constructor(private _usuarioService: UsuarioService, private _router: Router) {
        this.usuario = <Usuario>{
            nomUsuario: "",
            apePatUsuario: "",
            apeMatUsuario: "",
            dniUsuario: "",
            telfUsuario: "",
            dirUsuario: "",
            emailUsuario: "",
            loginUsuario: "",
            passUsuario: "",
            ConfirmaContrasena: ""
        };
    }

    registrarUsuario(): void {

        if (this.usuario.nomUsuario == "") {
            alert("Ingrese Nombre")
        }
        else if (this.usuario.apePatUsuario == "") {
            alert("Ingrese Apellido Paterno")
        }
        else if (this.usuario.apeMatUsuario == "") {
            alert("Ingrese Apellido Materno")
        }
        else if (this.usuario.dniUsuario == "") {
            alert("Ingrese DNI")
        }
        else if (this.usuario.telfUsuario == "") {
            alert("Ingrese Numero de Celular")
        }
        else if (this.usuario.dirUsuario == "") {
            alert("Ingrese una Direccion")
        }
        else if (this.usuario.emailUsuario == "") {
            alert("Ingrese una Email")
        }
        else if (this.usuario.loginUsuario == "") {
            alert("Ingrese Usuario")
        }
        else if (this.usuario.passUsuario == "") {
            alert("Ingrese Contraseña")
        }
        else if (this.usuario.ConfirmaContrasena == "") {
            alert("Las Contraseñas no Coindicen")
        }
        else {
            this._usuarioService.createUsuario(this.usuario)
                .subscribe(usuario => {
                    this.usuario = usuario;
                    alert("Verifique su cuenta para la activacion")
                    this._router.navigate(['login/']);
                });

        }
    }

}