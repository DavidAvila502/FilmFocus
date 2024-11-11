using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFocusApi.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Column("userId")]
        public  int Id { get; set; }
        [Column("userName")]
        public  string Name { get; set; }
        [Column("email")]
        public  string Email { get; set; }
        [Column("googleId")]
        public  string GoogleId { get; set; }
        [Column("joinDate")]
        public  DateTime? JoinDate   { get; set; }
        [Column("profileImageUrl")]
        public  string? ProfileImageUrl { get; set; }


        //public User(int id, string name, string email, string googleId, DateTime? joinDate, string? profileImageUrl)
        //{
        //    Id = id;
        //    Name = name;
        //    Email = email;
        //    GoogleId = googleId;
        //    JoinDate = joinDate;
        //    ProfileImageUrl = profileImageUrl;
        //}


    }
}
