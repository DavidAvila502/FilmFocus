using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Adapters.Output.ExternalServices.CloudinaryExternalServices;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class CreateMovieService:ICreateMovieService
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IUploadImageCloudinaryExternalService _uploadImageCloudinaryExternalService;

        public CreateMovieService(IMovieRepository movieRepository, IUploadImageCloudinaryExternalService uploadImageCloudinaryExternalService)
        {
            _movieRepository = movieRepository;
            _uploadImageCloudinaryExternalService = uploadImageCloudinaryExternalService;

        }

        public async Task<Movie> CreateMovie(MovieInsertDTO movieInsertDTO)
        {
            // New Movie object to register
            Movie newMovie = new Movie()
            {
                Name = movieInsertDTO.Name,
                ReleaseDate = movieInsertDTO.ReleaseDate,
                Score = movieInsertDTO.Score,
                Synopsis = movieInsertDTO.Synopsis,
                ImageUrl = null,
            };

            // Validate Movie Image
            if (movieInsertDTO.Image == null || movieInsertDTO.Image.Length == 0)
            {
                throw new KeyNotFoundException("The image file is required.");
            }

            // Try to upload the image on cloudinary
            try
            {
                newMovie.ImageUrl = await _uploadImageCloudinaryExternalService.UploadImageAsync(movieInsertDTO.Image);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error trying to upload the image at external service.");
            }


            // Trying to Register a new Movie
            try 
            { 
                Movie newMovieRegistered = await _movieRepository.CreateMovie(newMovie);

                //Return movie
                return newMovieRegistered;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something was wrong trying to register the movie");
            }


         

        }

    }
}
