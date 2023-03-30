using System.ComponentModel.DataAnnotations;

namespace EventsApp.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele tagului este obligatoriu")]
        public string TagName { get; set; }

        public virtual ICollection<Event>? Events { get; set; }
    }
}

