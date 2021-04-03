using System;
using System.ComponentModel.DataAnnotations;

namespace RegisterClient.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display (Name = "Tipo Cliente")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [Display(Name = "Razão Social / Nome")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [Display(Name = "Nome Fantasia / Sobrenome")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [Display(Name = "CNPJ / CPF")]
        [RegularExpression(@"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2}|\d{3}\.?\d{3}\.?\d{3}-?\d{2})$", ErrorMessage =
            "{0} inválido")]
        public string Cpf_Cnpj { get; set; }

        [Required(ErrorMessage = "{0} inválida")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage =
            "{0} inválido")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "{0} inválida")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} inválido")]
        [Display(Name = "Estado")]
        public string Uf { get; set; }
    }
}
