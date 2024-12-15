using FilmFocusApi.Application.DTOs.Movies;

namespace FilmFocusApi.Application.Interfaces.MovieInterfaces
{
    public interface IUpdateMovieService
    {

        public Task UpdateMovie(int id, MovieUpdateDTO movieUpdateDTO);

    }
}
