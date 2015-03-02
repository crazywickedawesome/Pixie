using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pixie.Data.Entities
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastModified { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual List<Note> Notes { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
