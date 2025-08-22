
using Contracts.Customers;
using Customers.Persistence;

namespace Customers.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerListResponse> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = entities.Select(e => new CustomerDto { Id = e.Id, Name = e.Name, Email = e.Email }).ToList();
            return new CustomerListResponse
            {
                Success = true,
                Message = "Listado de clientes",
                Data = dtos
            };
        }

        public async Task<CustomerResponse> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new CustomerResponse { Success = false, Message = "Cliente no encontrado", Data = null };
            }
            var dto = new CustomerDto { Id = entity.Id, Name = entity.Name, Email = entity.Email };
            return new CustomerResponse { Success = true, Message = "Cliente encontrado", Data = dto };
        }

        public async Task<CustomerResponse> Create(CustomerDto dto)
        {
            var entity = new CustomerEntity { Name = dto.Name, Email = dto.Email };
            var created = await _repository.CreateAsync(entity);
            dto.Id = created.Id;
            return new CustomerResponse { Success = true, Message = "Cliente creado exitosamente", Data = dto };
        }

        public async Task<CustomerResponse> Update(int id, CustomerDto dto)
        {
            var entity = new CustomerEntity { Id = id, Name = dto.Name, Email = dto.Email };
            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
            {
                return new CustomerResponse { Success = false, Message = "Cliente no encontrado", Data = null };
            }
            dto.Id = updated.Id;
            return new CustomerResponse { Success = true, Message = "Cliente actualizado", Data = dto };
        }

        public async Task<CustomerResponse> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return new CustomerResponse
            {
                Success = deleted,
                Message = deleted ? $"Cliente con id {id} eliminado" : "Cliente no encontrado",
                Data = null
            };
        }
    }
}
