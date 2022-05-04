using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}