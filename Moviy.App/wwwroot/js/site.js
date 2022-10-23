//Funcao de buscar CEP
function BuscaCep() {
    $(document).ready(function () {

        function limpa_formulário_cep() {
            // Limpa valores do formulário de cep.
            $("#Code").val("");
            $("#Country").val("");
            $("#City").val("");
            $("#State").val("");
            $("#District").val("");
            $("#Street").val("");
            $("#Number").val("");
        }

        //Quando o campo cep perde o foco.
        $("#Code").blur(function () {

            //Nova variável "cep" somente com dígitos.
            var cep = $(this).val().replace(/\D/g, '');

            //Verifica se campo cep possui valor informado.
            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    $("#Country").val("...");
                    $("#State").val("...");
                    $("#City").val("...");
                    $("#District").val("...");
                    $("#Street").val("...");

                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#Country").val("Brazil");
                                $("#State").val(dados.uf);
                                $("#City").val(dados.localidade);
                                $("#District").val(dados.bairro);
                                $("#Street").val(dados.logradouro);
                            } //end if.
                            else {
                                //CEP pesquisado não foi encontrado.
                                limpa_formulário_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                } //end if.
                else {
                    //cep é inválido.
                    limpa_formulário_cep();
                    alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                limpa_formulário_cep();
            }
        });
    });
}


function AjaxModal() {
    $(document).ready(function () {

        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal({
                                keyboard: true
                            },
                                'show');
                            bindForm(this);
                        });
                    return false;
                });
        });

        function bindForm(dialog) {
            $('form', dialog).submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (result) {
                        if (result.success) {
                            $('#myModal').modal('hide');
                            $('#LocalTarget').load(result.url);
                        }
                        else {
                            $('#myModalContent').html(result);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
});