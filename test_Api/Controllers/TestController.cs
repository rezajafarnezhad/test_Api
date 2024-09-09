using Microsoft.AspNetCore.Mvc;
using test_Api.Strategy;

namespace test_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IHttpClientFactory httpClientFactory, IPaymentFactory PaymentFactory) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var httpClient = httpClientFactory.CreateClient("pinball");
            var result = await httpClient.GetAsync("character/330");

            if (!result.IsSuccessStatusCode)
                return BadRequest(result.RequestMessage);


            var data = result.Content.ReadFromJsonAsync<Root>();

            return Ok(data.Result);
        }


        [HttpPost("Payment")]
        public async Task<IActionResult> Payment([FromForm] PaymentType paymentType)
        {
            var str = PaymentFactory.GetStrategy(paymentType);
            var data = await str.ExecutionPayment(1200);
            return Ok(data);
        }

    }

}

public class Location
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Origin
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Root
{
    public int id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string species { get; set; }
    public string type { get; set; }
    public string gender { get; set; }
    public Origin origin { get; set; }
    public Location location { get; set; }
    public string image { get; set; }
    public List<string> episode { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
}
