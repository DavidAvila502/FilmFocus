using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class GetAllMoviesService:IGetAllMoviesService
    {
        public readonly IMovieRepository _repository;

        public GetAllMoviesService(IMovieRepository repository)
        {
            _repository = repository;

        }


        public async Task<List<Movie>> GetAllMovies()
        {
            try
            {
                return await _repository.GetAllMovies();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Something went wrong trying to get the movies.");

            }
        }

    }
}
