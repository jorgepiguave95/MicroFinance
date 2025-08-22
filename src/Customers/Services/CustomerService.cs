
using Contracts.Customers;
namespace Customers.Services
{
    public class CustomerService
    {
        public async Task<CustomerResponse> GetAll()
        {
            var customers = new List<CustomerDto> {
                new CustomerDto { Id = 1, Name = "Cliente 1", Email = "cliente1@mail.com" },
                new CustomerDto { Id = 2, Name = "Cliente 2", Email = "cliente2@mail.com" }
            };
            return await Task.FromResult(new CustomerResponse
            {
                Success = true,
                Message = "Listado de clientes",
                Data = null // Puedes crear una CustomerListResponse si lo deseas
            });
        }

        public async Task<CustomerResponse> GetById(int id)
        {
            var customer = new CustomerDto { Id = id, Name = $"Cliente {id}", Email = $"cliente{id}@mail.com" };
            return await Task.FromResult(new CustomerResponse
            {
                Success = true,
                Message = "Cliente encontrado",
                Data = customer
            });
        }

        public async Task<CustomerResponse> Create(CustomerDto dto)
        {
            dto.Id = 99; // Simulación
            return await Task.FromResult(new CustomerResponse
            {
                Success = true,
                Message = "Cliente creado exitosamente",
                Data = dto
            });
        }

        public async Task<CustomerResponse> Update(int id, CustomerDto dto)
        {
            dto.Id = id;
            return await Task.FromResult(new CustomerResponse
            {
                Success = true,
                Message = "Cliente actualizado",
                Data = dto
            });
        }

        public async Task<CustomerResponse> Delete(int id)
        {
            return await Task.FromResult(new CustomerResponse
            {
                Success = true,
                Message = $"Cliente con id {id} eliminado",
                Data = null
            });
        }
    }
}
