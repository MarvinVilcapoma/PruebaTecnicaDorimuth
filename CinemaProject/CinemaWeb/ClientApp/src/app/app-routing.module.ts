import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MoviesComponent } from './modules/movies/movies.component';
import { MoviesDetailComponent } from './modules/movies-detail/movies-detail.component';

const routes: Routes = [
  {
    path: 'movies',
    component: MoviesComponent
  },
  {
    path: 'movies-detail/:id',
    component: MoviesDetailComponent
  },
  { path: '**', redirectTo: 'movies', pathMatch:'full'}
];
@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
