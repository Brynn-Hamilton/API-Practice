namespace CardPractice.Models
{
    public class Cards
    {
        public bool success { get; set; }
        public int deck_count { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
        public string code { get; set; }
        public string image { get; set; }
        public string images { get; set; }
        public int value { get; set; }
        public string suit { get; set; }

    }
}
