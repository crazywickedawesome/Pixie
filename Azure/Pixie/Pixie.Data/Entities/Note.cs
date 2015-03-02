using System;
using System.Collections.Generic;

namespace Pixie.Data.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }

        public virtual Character Character { get; set; }
        public int? CharacterId { get; set; }

        public virtual List<User> Users { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
