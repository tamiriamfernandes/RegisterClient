using System;
using System.ComponentModel.DataAnnotations;

namespace RegisterClient.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display (Name = "Tipo Cliente")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        [Display(Name = "Razão Social / Nome")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        [Display(Name = "Nome Fantasia / Sobrenome")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        [Display(Name = "CNPJ / CPF")]
        public string Cpf_Cnpj { get; set; }

        [Required(ErrorMessage = "Informe a {0}!")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o {0}!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe a {0}!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe a {0}!")]
        [Display(Name = "Estado")]
        public string Uf { get; set; }
    }
}
