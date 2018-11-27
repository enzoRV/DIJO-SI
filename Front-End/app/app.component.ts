import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FotografoService } from './Fotografo/fotografo.service';
import { UsuarioService } from './login/usuario.service';
import { Usuario } from './login/usuario';
@Component({
    selector: 'pm-app',
    templateUrl : 'app/app.component.html'
})
export class AppComponent {
    pageTitle: string = "Dijo Si!!!";
    usuario : Usuario;

    constructor(private _fotografoService : FotografoService,
        private _router : Router, private _usuarioService : UsuarioService){
        }
}
