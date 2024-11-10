namespace FilmFocusApi.Domain.Entities
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; } 
        public required string Email { get; set; }
        public required string GoogleId { get; set; }
        public required DateTime JoinDate   { get; set; }
        public  string? ProfileImageUrl { get; set; }


        public User(int id, string name, string email, string googleId, DateTime joinDate, string? profileImageUrl)
        {
            Id = id;
            Name = name;
            Email = email;
            GoogleId = googleId;
            JoinDate = joinDate;
            ProfileImageUrl = profileImageUrl;
        }


    }
}
