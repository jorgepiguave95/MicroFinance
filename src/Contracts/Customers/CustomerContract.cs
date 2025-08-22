namespace Contracts.Customers
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

    public class CustomerResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public CustomerDto? Data { get; set; }
    }
}
