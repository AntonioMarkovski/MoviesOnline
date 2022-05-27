using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Entities.Logger
{
    public class LoggerMessageDisplay
    {
        // Movies Messages
        public const string MoviesListed = "All Movies listed successfully!";
        public const string NoMoviesInDB = "There is no Movies in the DB!";
        public const string MovieFoundDisplayDetails = "Movie was found in the DB, show the details of the Movie";
        public const string NoMovieFound = "This is no Movie found in the DB!";
        public const string MovieCreated = "New Movie is created in the DB";
        public const string MovieNotCreatedModelStateInvalid = "New Movie is NOT created in the DB, ModelState is not valid";
        public const string MovieEdited = "Movie is edited successfully";
        public const string MovieEditNotFound = "Movie for editting is not found in the DB";
        public const string MovieEditErrorModelStateInvalid = "Movie is not edited, ModelState is not valid";
        public const string MovieDeleted = "Movie is deleted successfully";
        public const string MovieDeletedError = "Movie is NOT deleted, error happend in process of deletion";

        // Publisher Messages
        public const string PublishersListed = "All publishers listed successfully!";
        public const string NoPublishersInDB = "There is no publishers in the DB!";
        public const string PublisherFoundDisplayDetails = "Publisher was found in the DB, show the details of the publisher";
        public const string NoPublisherFound = "This is no publisher found in the DB!";
        public const string PublisherCreated = "New publisher is created in the DB";
        public const string PublisherNotCreatedModelStateInvalid = "New publisher is NOT created in the DB, ModelState is not valid";
        public const string PublisherEdited = "Publisher is edited successfully";
        public const string PublisherEditNotFound = "Publisher for editting is not found in the DB";
        public const string PublisherEditErrorModelStateInvalid = "Publisher is not edited, ModelState is not valid";
        public const string PublisherDeleted = "Publisher is deleted successfully";
        public const string PublisherDeletedError = "Publisher is NOT deleted, error happend in process of deletion";

        // Actor Messages
        public const string ActorsListed = "All Actors listed successfully!";
        public const string NoActorsInDB = "There is no Actors in the DB!";
        public const string ActorFoundDisplayDetails = "Actor was found in the DB, show the details of the Actor";
        public const string NoActorFound = "This is no author found in the DB!";
        public const string ActorCreated = "New Actor is created in the DB";
        public const string ActorNotCreatedModelStateInvalid = "New Actor is NOT created in the DB, ModelState is not valid";
        public const string ActorEdited = "Actor is edited successfully";
        public const string ActorEditErrorModelStateInvalid = "Actor is not edited, ModelState is not valid";
        public const string ActorDeleted = "Actor is deleted successfully";
        public const string ActorDeletedError = "Actor is NOT deleted, error happend in process of deletion";

        // Category Messages
        public const string CategoriesListed = "All categories listed successfully!";
        public const string NoCategoriesInDB = "There is no categories in the DB!";
        public const string CategoryFoundDisplayDetails = "Category was found in the DB, show the details of the category";
        public const string NoCategoryFound = "This is no category found in the DB!";
        public const string CategoryCreated = "New category is created in the DB";
        public const string CategoryNotCreatedModelStateInvalid = "New category is NOT created in the DB, ModelState is not valid";
        public const string CategoryEdited = "Category is edited successfully";
        public const string CategoryEditErrorModelStateInvalid = "Category is not edited, ModelState is not valid";
        public const string CategoryDeleted = "Category is deleted successfully";
        public const string CategoryDeletedError = "Category is NOT deleted, error happend in process of deletion";

       
        // User Messages
        public const string UsersListed = "All users listed successfully!";
        public const string NoUsersInDB = "There is no user in the DB!";
        public const string UserFoundDisplayDetails = "User was found in the DB, show the details of the user";
        public const string NoUserFound = "There is no user found in the DB!";
        public const string UserCreated = "New user is created in the DB";
        public const string UserNotCreatedModelStateInvalid = "New user is NOT created in the DB, ModelState is not valid";
        public const string UserEdited = "User is edited successfully";
        public const string UserEditErrorModelStateInvalid = "User is not edited, ModelState is not valid";
        public const string UserDeleted = "User is deleted successfully";
        public const string UserDeletedError = "User is NOT deleted, error happend in process of deletion";
        public const string UserAddedRole = "User added to Role";

        // Upload Photo Messages
        public const string PhotoUploaded = "Photo is successfully uploaded";
        public const string PhotoUploadedError = "Photo is NOT uploaded";
        public const string PhotosListed = "All Photos listed successfully!";
        public const string NoPhotosInDB = "There is no Photos in the DB!";
        public const string PhotoFoundDisplayDetails = "Photo was found in the DB, show the details of the photo";
        public const string NoPhotoFound = "This is no Photo found in the DB!";
        public const string PhotoCreated = "New Photo is created in the DB";
        public const string PhotoNotCreatedModelStateInvalid = "New Photo is NOT created in the DB, ModelState is not valid";
        public const string PhotoEdited = "Photo is edited successfully";
        public const string PhotoEditErrorModelStateInvalid = "Photo is not edited, ModelState is not valid";
        public const string PhotoDeleted = "Photo is deleted successfully";
        public const string PhotoDeletedError = "Photo is NOT deleted, error happend in process of deletion";


    }
}
