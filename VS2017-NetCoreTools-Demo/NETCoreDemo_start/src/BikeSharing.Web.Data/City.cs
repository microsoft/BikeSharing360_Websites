namespace BikeSharing.Web.Data
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public bool IsAvailable { get; set; }
        public bool Initial { get; set; }

        public string LocalizedName { get; set; }

    }
}