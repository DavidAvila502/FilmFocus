using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class GetMovieByIdService:IGetMovieByIdService
    {

        private readonly IMovieRepository _repository;

        public GetMovieByIdService(IMovieRepository repository)
        {
            _repository = repository;

        }


        public async Task<Movie?> GetMovieById(int id)
        {
            try
            {
                return await _repository.GetMovieById(id);

            }
            catch (Exception ex) {

                throw new ApplicationException("Something went wrong trying to get the movie.");
            
            }

        }

    }
}
