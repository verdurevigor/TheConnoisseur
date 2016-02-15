using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheConnoisseur.Models
{
    public class Journal
    {
        public virtual int JournalID { get; set; }
        public virtual int AuthorID { get; set; }
        public virtual string Maker { get; set; }
        public virtual string Title { get; set; }
        public virtual string JType { get; set; }   // Two char string: cf, br
        public virtual string ImagePath { get; set; }
        public virtual int Rating { get; set; } // 1-5
        public virtual string Description { get; set; }      // Should this have a max? Yes, but what max?
        public virtual DateTime Date { get; set; }
        public virtual string Location { get; set; }
        public virtual string PrivacyType { get; set; }     // Two char string: pu (public), pr (private), fo (friends only)

    }
}