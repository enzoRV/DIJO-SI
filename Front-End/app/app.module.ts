import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ListaFotografoComponent } from './Fotografo/Listafotografo.component';
import { FotografoService } from './Fotografo/fotografo.service';
import { HttpModule } from '@angular/http';
import { ListaRegaloComponent } from './Regalo/Listaregalo.componet';
import { RegaloService } from './Regalo/regalo.service';
import { ListaBuffetComponent } from './Buffet/ListaBuffet.component';
import { BuffetService } from './Buffet/buffet.service';
import { ListaLocalComponent } from './Local/ListaLocal.component';
import { LocalService } from './Local/local.service';
import { LoginComponent } from './login/login.coponent';
import { UsuarioService } from './login/usuario.service';
import { FormsModule } from '@angular/forms';
import { RegistrarFotografoComponent } from './Fotografo/Registrafotografo.component'
import { ActualizarFotografoComponent } from './Fotografo/Actualizafotografo.component'
import { RegistrarRegaloComponent } from './Regalo/Registrarregalo.component'
import { RegistrarLocalComponent } from './Local/RegistraLocal.component'
import { RegistrarBuffetComponent } from './Buffet/RegistrarBuffet.component'
import { RegistrarUsuarioComponent } from './login/RegistraUsuario.component'
import { ListaUsuarioComponent } from './login/ListaUsuario.component';
import { ActualizarbuffetComponent } from './Buffet/Actualizarbuffet.component';
import { ActualizarUsuarioComponent } from './login/Actualizarusuario.component';
import { ActualizarLocalComponent } from './Local/Actualizalocal.component';

@NgModule({
  declarations: [
    AppComponent,
    ListaFotografoComponent,
    ListaRegaloComponent,
    ListaBuffetComponent,
    ListaLocalComponent,
    ListaUsuarioComponent,
    LoginComponent,
    RegistrarFotografoComponent,
    ActualizarFotografoComponent,
    RegistrarRegaloComponent,
    RegistrarLocalComponent,
    ActualizarbuffetComponent,
    RegistrarBuffetComponent,
    RegistrarUsuarioComponent,
    ActualizarUsuarioComponent,
    ActualizarLocalComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'fotografos', component: ListaFotografoComponent },
      { path: 'regalos', component: ListaRegaloComponent },
      { path: 'buffets', component: ListaBuffetComponent },
      { path: 'locales', component: ListaLocalComponent },
      { path: 'usuarios', component: ListaUsuarioComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registrarFotografo', component: RegistrarFotografoComponent },
      { path: 'actualizarFotografo/:id', component: ActualizarFotografoComponent },
      { path: 'registrarRegalo', component: RegistrarRegaloComponent },
      { path: 'registrarLocal', component: RegistrarLocalComponent },
      { path: 'registrarBuffet', component: RegistrarBuffetComponent },
      { path: 'actualizarBuffet/:id', component: ActualizarbuffetComponent },
      { path: 'actualizarUsuario/:id', component: ActualizarUsuarioComponent },
      { path: 'registrarse', component: RegistrarUsuarioComponent },
      { path: 'actualizarLocal/:id', component: ActualizarLocalComponent}
    ])
  ],
  providers: [
    FotografoService,
    RegaloService,
    BuffetService,
    LocalService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
})


export class AppModule { }
