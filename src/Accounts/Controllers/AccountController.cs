using Microsoft.AspNetCore.Mvc;
using Accounts.Services;
using Contracts.Accounts;

namespace Accounts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        [HttpGet]


        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]


        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        [HttpPost]


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountDto dto)
        {
            var response = await _service.Create(dto);
            return Ok(response);
        }

        [HttpPut("{id}")]


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AccountDto dto)
        {
            var response = await _service.Update(dto.Id, dto);
            return Ok(response);
        }

        [HttpDelete("{id}")]


        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);
            return Ok(response);
        }
    }
}
