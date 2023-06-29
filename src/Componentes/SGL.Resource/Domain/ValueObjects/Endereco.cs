namespace SGL.Resource.Domain.ValueObjects
{
    public sealed class Endereco
    {
        public string? Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? CEP { get; private set; }
        public string? Estado { get; private set; }

        public Endereco() { }

        public Endereco(string? logradouro, string? numero, string? complemento, string? bairro, string? cidade, string? cEP, string? estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cEP;
            Estado = estado;
        }
    }
}
