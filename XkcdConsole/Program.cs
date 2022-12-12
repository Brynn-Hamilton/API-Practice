

// https://xkcd.com/info.0.json

Console.WriteLine("Which comic number would you like to see?");
string entry = Console.ReadLine();


// ===============================================

//create instance of an httpclient
HttpClient web = new HttpClient();

// connect to an API server
web.BaseAddress = new Uri("https://xkcd.com/");
var connection = await web.GetAsync($"{entry}/info.0.json");

// Get back an instance of our class


// =========================================================

//string result = await connection.Content.ReadAsStringAsync();
//Console.WriteLine(result);

try
{
    Comic com = await connection.Content.ReadAsAsync<Comic>();
    Console.WriteLine(com.alt);
    Console.WriteLine(com.img);
}
catch(Exception e)
{
    Console.WriteLine("Sorry, I could not find that comic.");
}


class Comic
{
    public int month { get; set; }
    public int num { get; set; }
    public string link { get; set; }
    public int year { get; set; }
    public string news { get; set; }
    public string safe_title { get; set; }
    public string transcript { get; set; }
    public string alt { get; set; }
    public string img { get; set; }
    public string title { get; set; }
    public int day { get; set; }
}