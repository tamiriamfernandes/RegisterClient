using System;

namespace RegisterClient.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
