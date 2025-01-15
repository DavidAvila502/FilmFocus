using FilmFocusApi.Application.DTOs.Actors;
using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Adapters.Output.ExternalServices.CloudinaryExternalServices;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class CreateActorService:ICreateActorService
    {
        private readonly IActorRepository _repository;
        private readonly IUploadImageCloudinaryExternalService _uploadImageCloudinaryExternalService;

        public CreateActorService(
          IActorRepository repository,
            IUploadImageCloudinaryExternalService uploadImageCloudinaryExternalService
        )
        {
            _repository = repository;
            _uploadImageCloudinaryExternalService = uploadImageCloudinaryExternalService;
        }

        public async Task<Actor> CreateActor(ActorInsertDTO actorInsertDto)
        {
            //Create an actor object
            Actor actor = new Actor() { Id = actorInsertDto.ActorId, Name= actorInsertDto.ActorName };

            // If there is an image then try to upload
            if (actorInsertDto.Image != null) {
                try
                {
                    string stringActorImage = await _uploadImageCloudinaryExternalService.UploadImageAsync(actorInsertDto.Image);
                     actor.ImageUrl = stringActorImage;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error trying to upload the image");
                }
            }

            //try to register the actor in the db
            try
            {
                await _repository.CreateActor(actor);

                return actor;
            }
            catch (Exception ex) 
            {
                  throw new ApplicationException("Error trying to upload the image");
            }

        }


    }
}
