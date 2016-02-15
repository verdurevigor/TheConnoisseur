using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheConnoisseur.Models
{
    public class Author
    {
        public virtual int AuthorID { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string EmailConfirm { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordConfirm { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string FavItem { get; set; }
        public virtual string Tagline { get; set; }
        public virtual string PrivacyType { get; set; }
        public virtual string AvatarPath { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
}