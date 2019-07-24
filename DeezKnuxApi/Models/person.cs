using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace DeezKnuxApi.Models
{
    public class Person : Identifiable
    {
        [Attr("first-name")]
        public string FirstName { get; set; }
        [Attr("last-name")]
        public string LastName { get; set; }       

        [HasMany("knux-phrases")]
        public virtual List<KnuxPhrase> KnuxPhrases { get; set; } 
    }
}