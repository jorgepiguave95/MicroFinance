using Microsoft.AspNetCore.Mvc;

namespace ClientGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var baseUrl = _config["ACCOUNTS_BASEURL"] ?? "http://accounts:8080";
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{baseUrl}/api/Account");
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener cuentas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var baseUrl = _config["ACCOUNTS_BASEURL"];
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{baseUrl}/api/Account/{id}");
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener cuenta: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount()
        {
            try
            {
                var baseUrl = _config["ACCOUNTS_BASEURL"];
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsync($"{baseUrl}/api/Account", null);
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear cuenta: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id)
        {
            try
            {
                var baseUrl = _config["ACCOUNTS_BASEURL"];
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsync($"{baseUrl}/api/Account/{id}", null);
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar cuenta: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var baseUrl = _config["ACCOUNTS_BASEURL"];
                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"{baseUrl}/api/Account/{id}");
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar cuenta: {ex.Message}");
            }
        }
    }
}
