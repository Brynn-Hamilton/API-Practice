using DeckofCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckofCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private string DeckId = "";
        //in index -----v
        //DeckId = resp.deck_id;
        //connection = await web.GetAsync($"{DeckId}/draw/?count=5");
        // resp = await connection.Content.ReadAsAsync<CardResponse>();
        // return View(resp);
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            var requestDeck = await web.GetAsync("new/shuffle/?deck_count=1");
            Shuffle deck = await requestDeck.Content.ReadAsAsync<Shuffle>();

            var requestCard = await web.GetAsync($"{deck.deck_id}/draw/?count=5");
            CardResponse cards = await requestCard.Content.ReadAsAsync<CardResponse>();
            return View(cards.cards);
        }

        // with this set up, how do I make sure it's the same deck id from the original 5?
        public async Task<IActionResult> DrawFive(string deck_id)
        {
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            var requestCard = await web.GetAsync($"{deck_id}/draw/?count=5");
            CardResponse cards = await requestCard.Content.ReadAsAsync<CardResponse>();
            return View(cards.cards);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}