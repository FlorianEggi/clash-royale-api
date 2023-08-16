namespace ClashRoyaleApiBackend.Models
{
    public class Arena
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Item
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string lastSeen { get; set; }
        public int expLevel { get; set; }
        public int trophies { get; set; }
        public Arena arena { get; set; }
        public int clanRank { get; set; }
        public int previousClanRank { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
        public int clanChestPoints { get; set; }
    }

    public class Players
    {
        public List<Item> items { get; set; }
    }
}
