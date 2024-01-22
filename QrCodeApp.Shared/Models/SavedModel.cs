using System.ComponentModel.DataAnnotations;

namespace QrCodeApp.Shared.Models
{
    public class SavedModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public int CardId { get; set; }
    }
}