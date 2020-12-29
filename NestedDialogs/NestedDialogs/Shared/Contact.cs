using System.ComponentModel.DataAnnotations;

namespace NestedDialogs.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(160)]
        public string FirstName { get; set; }
        [MaxLength(160)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(160)]
        public string LastName { get; set; }

        public bool Active { get; set; } = true;
    }
}
