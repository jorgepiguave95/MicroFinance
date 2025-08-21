using Microsoft.AspNetCore.Mvc;

namespace ClientGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public CustomerController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var baseUrl = _config["CUSTOMERS_BASEURL"];
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{baseUrl}/api/Customer");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var baseUrl = _config["CUSTOMERS_BASEURL"];
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{baseUrl}/api/Customer/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] object customerDto)
        {
            var baseUrl = _config["CUSTOMERS_BASEURL"];
            var client = _httpClientFactory.CreateClient();
            var contentToSend = new StringContent(customerDto.ToString() ?? string.Empty, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/api/Customer", contentToSend);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] object customerDto)
        {
            var baseUrl = _config["CUSTOMERS_BASEURL"];
            var client = _httpClientFactory.CreateClient();
            var contentToSend = new StringContent(customerDto.ToString() ?? string.Empty, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/api/Customer/{id}", contentToSend);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var baseUrl = _config["CUSTOMERS_BASEURL"];
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{baseUrl}/api/Customer/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}
