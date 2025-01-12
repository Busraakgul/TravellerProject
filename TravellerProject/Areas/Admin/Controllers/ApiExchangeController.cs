using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravellerProject.Areas.Admin.Models;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class ApiExchangeController : Controller
    {
        private readonly HttpClient _httpClient;

        public ApiExchangeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var requestUri = "https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb";
                _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "cb5ee15da1mshb46d59d679af3abp1fe84cjsn167590fdc0cc");
                _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "booking-com.p.rapidapi.com");

                var response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();
                var exchangeData = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);

                return View(exchangeData.exchange_rates);
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using ILogger)
                ViewData["Error"] = "Failed to fetch exchange rates. Please try again later.";
                return View(Enumerable.Empty<BookingExchangeViewModel2.Exchange_Rates>());
            }
        }
    }
}


