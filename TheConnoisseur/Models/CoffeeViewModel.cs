using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheConnoisseur.Models
{
    public class CoffeeViewModel
    {
        // To reduce the need to set an extra property, the JType is set here.
        private string jType = "co";
       // Journal properties here.
        public virtual int JournalID { get; set; }
        public virtual int AuthorID { get; set; }
        public virtual string Maker { get; set; }
        public virtual string Title { get; set; }
        public virtual string JType
        {
            get { return jType; }
        }
        public virtual string ImagePath { get; set; }
        public virtual int Rating { get; set; } // 1-5
        public virtual string Description { get; set; }      // Should this have a max? Yes, but what max?
        public virtual DateTime Date { get; set; }
        public virtual string Location { get; set; }
        public virtual int PrivacyType { get; set; }     // Two char string: pu (public), pr (private), fo (friends only)

        // Coffee specific properties here
        public virtual int CoffeeID { get; set; }
        public virtual string RoastType { get; set; }
        public virtual string Origin { get; set; }
        public virtual string FoodPairing { get; set; }
    }
}