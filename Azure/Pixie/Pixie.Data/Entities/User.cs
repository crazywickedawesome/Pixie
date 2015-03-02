using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pixie.Data.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Username { get; set; }

        public virtual List<Character> Characters { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
