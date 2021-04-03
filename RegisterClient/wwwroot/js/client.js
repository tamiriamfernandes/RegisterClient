
$(document).ready(function () {
    TrataTipo($("#Tipo"));

    $("#cadCliente").on("submit", function () {
        if (Validacao())
            return true;
        else
            return false;
    })

    $("#Tipo").change(function () {
        TrataTipo($(this));
    });

    $("#Cep").blur(function () {
        var cep = $(this).val().replace(/[^0-9]/, '');
        if (cep) {
            var url = 'https://viacep.com.br/ws/' + cep + '/json/?callback=?';

            $.ajax({
                url: url,
                dataType: 'jsonp',
                crossDomain: true,
                contentType: "application/json",
                success: function (json) {
                    if (json.logradouro) {
                        $("#Logradouro").val(json.logradouro);
                        $("#Bairro").val(json.bairro);
                        $("#Cidade").val(json.localidade);
                        $("#Uf").val(json.uf);
                    }
                }
            });
        }
    });

    function TrataTipo(element) {
        $("#Cep").mask("99999-999");

        // Tipo Cliente
        var tipo = $(element).val();

        if (tipo == "F") {
            $("#lblRazaoSocial").html("Nome");
            $("#lblNomeFantasia").html("Sobrenome");
            $("#lblCpf_Cnpj").html("CPF");
            $("#lblDataNasc").show();
            $("#DataNasc").show();

            $("#NomeFantasia").attr('maxlength', '15');
            $("#Cpf_Cnpj").mask("999.999.999-99");
        } else {
            $("#lblRazaoSocial").html("Razão Social");
            $("#lblNomeFantasia").html("Nome Fantasia");
            $("#lblCpf_Cnpj").html("CNPJ");
            $("#lblDataNasc").hide();
            $("#DataNasc").hide();

            $("#NomeFantasia").removeAttr('maxlength');
            $("#Cpf_Cnpj").mask("99.999.999/9999-99");
        }
    }

    function Validacao() {
        var datanasc = $('#DataNasc').val();
        datanasc = new Date(datanasc);
        if (datanasc != '') {
            var data = new Date();
            var idade = Math.floor((data - datanasc) / (365.25 * 24 * 60 * 60 * 1000));

            if (idade <= 19) {
                alert("A idade permitida para cadastro deve ser no mínimo 19 anos.");
                return false;
            }
            return true;
        }
    }
});