namespace SGL.Resource.Domain.ValueObjects
{
    public class Email
    {
        public string? EnderecoEmail { get; set; }

        public Email(string? enderecoEmail)
        {
            EnderecoEmail = enderecoEmail;
        }
    }
}
