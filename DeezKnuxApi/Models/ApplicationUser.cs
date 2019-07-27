using System.Collections.Generic;
using JsonApiDotNetCore.Models;
using Microsoft.AspNetCore.Identity;

namespace DeezKnuxApi.Models
{
    public class ApplicationUser : IdentityUser, IIdentifiable<string>
    {
        // object IIdentifiable.Id
        // {
        //     get { return Id;}
        //     set { Id = value.ToString(); }
        // }

        [Attr("first-name")]
        public string FirstName { get; set; }
        [Attr("last-name")]
        public string LastName { get; set; }       

        [HasMany("knux-phrases")]
        public virtual List<KnuxPhrase> KnuxPhrases { get; set; }
        string IIdentifiable<string>.Id { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        string IIdentifiable.StringId { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}