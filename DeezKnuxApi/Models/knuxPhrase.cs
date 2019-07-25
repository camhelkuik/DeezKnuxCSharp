using JsonApiDotNetCore.Models;

namespace DeezKnuxApi.Models
{
    public class KnuxPhrase : Identifiable
    {
        [Attr("knuxvalue")]
        public string KnuxValue { get; set; }
        public int OwnerId { get; set; }
        [HasOne("person")]
        public virtual Person Owner { get; set; }        
    }
}