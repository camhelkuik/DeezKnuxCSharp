using JsonApiDotNetCore.Models;

namespace DeezKnuxApi.Models
{
    public class KnuxPhrase : Identifiable
    {
        [Attr("knuxvalue")]
        public string KnuxValue { get; set; }
        public string OwnerId { get; set; }
        [HasOne("owner")]
        public virtual ApplicationUser Owner { get; set; }        
    }
}