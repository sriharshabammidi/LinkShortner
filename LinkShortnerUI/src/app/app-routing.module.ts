import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UrlShortnerComponent } from './url-shortner/url-shortner.component';

const routes: Routes = [
  { path: '', component: UrlShortnerComponent },
  {
    path: ':id',
    component: UrlShortnerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
