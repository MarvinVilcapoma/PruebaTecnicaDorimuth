import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { MovieSearchRequestV1 } from 'src/app/models/request/movieSearchRequestV1';
import { MovieGenreResponseV1 } from 'src/app/models/response/movieGenreResponseV1';
import { MovieResponseV1 } from 'src/app/models/response/movieResponseV1';
import { MovieService } from 'src/app/service/movie.service';
import { MovieGenreService } from 'src/app/service/movieGenre.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  movies: MovieResponseV1[] = [];

  movieGenres: MovieGenreResponseV1[] = [];

  itemsPerPage = 6;
  loadedMoviesCount = 0;


  movieName: string = '';
  selectedGenre: number = 0;
  movieSearchRequestV1: MovieSearchRequestV1 = new MovieSearchRequestV1();

  constructor(public movieService: MovieService, public movieGenreService: MovieGenreService) { }

  ngOnInit(): void {
    this.loadMovies();
    this.loadMovieGenres();

  }

  loadMovies() {
    this.movieService.getMovies().subscribe(
      (res) => {
        const startIndex = this.loadedMoviesCount * this.itemsPerPage;
        const newMovies = res.slice(startIndex, startIndex + this.itemsPerPage);
        this.movies = [...this.movies, ...newMovies];
        this.loadedMoviesCount++;
      },
      (error) => {
        console.error('Error loading movies:', error);
      }
    );
  }

  loadMoreMovies() {
    this.loadMovies();
  }

  moreMoviesAvailable(): boolean {
    const startIndex = this.loadedMoviesCount * this.itemsPerPage;
    return startIndex < this.movies.length;
  }

  loadMovieGenres(){
    this.movieGenreService.getMovieGenres().subscribe((res)=>{
        this.movieGenres = res;
    });
  }

  searchMovie() {
    this.loadedMoviesCount = 0;
    this.movies = [];
  
    this.movieSearchRequestV1.movieName = this.movieName;
    this.movieSearchRequestV1.movieGenreID = this.selectedGenre;
  
    this.loadMovies();
    this.movieService.searchMovie(this.movieSearchRequestV1).subscribe((res) => {
      this.movies = res;
    });
  }

}
