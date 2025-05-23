using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CustomerManagement.Models
{
    public class Customer
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        [Required(ErrorMessage = "FirstName is required")]

        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyName("LastName")]
        [Required(ErrorMessage = "LastName is required")]

        public string LastName { get; set; } = string.Empty;
    }
}
