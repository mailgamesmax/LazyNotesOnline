using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazyNotesOnline.Models
{
    public class NoteContent
    {
        [Key]
        public Guid Content_Id { get; set; } = Guid.NewGuid();
        
        public DateTime ContentCreationTime { get; set; }

        [Column("Turinys")]
        public string Content { get; set; }

        public List<NoteContent> AllNotes { get; set; } = new List<NoteContent>();

        [ForeignKey("Cat_ID")]
        public Guid Cat_Id { get; set; }
        public NoteCategory NoteCategory { get; set; }
    }
}
