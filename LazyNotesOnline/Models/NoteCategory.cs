using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyNotesOnline.Models
{
    public class NoteCategory
    {
        public int Cat_Id { get; set; }

        [Column("Įrašo kategorija")]
        [MaxLength(150)]
        public string Cat_Title { get; set; }
        [Required]

        // [Column("Ownet of notification")]
        //public string Name { get; set; }

        [ForeignKey("OwnerID")]
        public Guid Id { get; set; }
        public User User { get; set; }        
    }
}
