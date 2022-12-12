namespace DeckofCards.Models
{
    public class CardAPI
    {
        // This is the DAL for the API calls
        // Let's encapsulate the API calls into easy-to-use methods
        // We'll have two methods
        // GetNewDeck()
        // Get Cards(count)
        public static HttpClient Web = new HttpClient();

        public static HttpClient Init()
        {
            // We call this concept a "singleton"

            // First see if we already have an HttpClient
            // if so, return that one
            // else create one and return that one
            // or, flip the logic

            // First, see if we already have an HttpClient
            // if not, create one
            // then regardless return it

            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            return web;
        }
        public async Task<string> GetNewDeck()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");

            // First use of our HttpClient instance
            var request = await client.GetAsync("new/shuffle/?deck_count=1");
            CardResponse response = await request.Content.ReadAsAsync<CardResponse>();
            return response.deck_id;
        }
    }
}
