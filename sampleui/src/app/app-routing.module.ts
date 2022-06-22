import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersondetailsComponent } from './persondetails/persondetails.component';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'details', component:PersondetailsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
