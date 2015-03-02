using System.Collections.Generic;

namespace Pixie.Data.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Value { get; set; }

        public virtual List<Note> Notes { get; set; }
        public virtual List<Character> Characters { get; set; }
    }
}
