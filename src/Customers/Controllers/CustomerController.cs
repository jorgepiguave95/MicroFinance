using Microsoft.AspNetCore.Mvc;
using Customers.Services;
using Contracts.Customers;

namespace Customers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
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
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            var response = await _service.Create(dto);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDto dto)
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
