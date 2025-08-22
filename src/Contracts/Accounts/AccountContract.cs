namespace Contracts.Accounts
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public decimal Balance { get; set; }
    }

    public class AccountResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public AccountDto? Data { get; set; }
    }

    public class AccountListResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<AccountDto>? Data { get; set; }
    }
}
