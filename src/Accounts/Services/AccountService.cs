using Contracts.Accounts;
using Accounts.Persistence;

namespace Accounts.Services
{
    public class AccountService
    {
        private readonly AccountRepository _repo;

        public AccountService(AccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<AccountListResponse> GetAll()
        {
            var entities = await _repo.GetAllAsync();
            var dtos = entities.Select(e => new AccountDto
            {
                Id = e.Id,
                Name = e.Name,
                Number = e.Number,
                Balance = e.Balance
            }).ToList();
            return new AccountListResponse
            {
                Success = true,
                Message = "Listado de cuentas",
                Data = dtos
            };
        }

        public async Task<AccountResponse> GetById(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
                return new AccountResponse { Success = false, Message = "No encontrado" };
            var dto = new AccountDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Number = entity.Number,
                Balance = entity.Balance
            };
            return new AccountResponse
            {
                Success = true,
                Message = "Cuenta encontrada",
                Data = dto
            };
        }

        public async Task<AccountResponse> Create(AccountDto dto)
        {
            var entity = new AccountEntity
            {
                Name = dto.Name,
                Number = dto.Number,
                Balance = dto.Balance
            };
            var created = await _repo.CreateAsync(entity);
            dto.Id = created.Id;
            return new AccountResponse
            {
                Success = true,
                Message = "Cuenta creada exitosamente",
                Data = dto
            };
        }

        public async Task<AccountResponse> Update(int id, AccountDto dto)
        {
            var entity = new AccountEntity
            {
                Id = id,
                Name = dto.Name,
                Number = dto.Number,
                Balance = dto.Balance
            };
            var updated = await _repo.UpdateAsync(entity);
            if (updated == null)
                return new AccountResponse { Success = false, Message = "No encontrado" };
            dto.Id = updated.Id;
            return new AccountResponse
            {
                Success = true,
                Message = "Cuenta actualizada",
                Data = dto
            };
        }

        public async Task<AccountResponse> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            return new AccountResponse
            {
                Success = deleted,
                Message = deleted ? $"Cuenta con id {id} eliminada" : "No encontrado",
                Data = null
            };
        }
    }
}
