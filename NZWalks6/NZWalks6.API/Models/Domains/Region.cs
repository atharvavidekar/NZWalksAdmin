using System.Text.Json.Serialization;

namespace NZWalks6.API.Models.Domains
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }    

        public double Area { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public long Population { get; set; }

        [JsonIgnore]
        public IEnumerable<Walk> Walks { get; set; }

        // another approach to solve the cyclic dependencies
        //internal virtual IEnumerable<Walk> Walks { get; set; }




    }
}
