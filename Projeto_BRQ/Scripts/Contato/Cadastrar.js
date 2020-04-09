
function montarObjetoCadastrar() {
    return {
        'Nome': ($("#txtNome").val()),
        'Email': ($("#txtEmail").val()),
        'Telefone': ($("#txtTelefone").val())        
    }
}


function CadastrarContato() {
    if (validarFormulario())
        postCadastrar(montarObjetoCadastrar(), '/Contato/CadastrarContato')
}

function postCadastrar(data, url) {
    $.ajax({
        url: url,
        data: JSON.stringify(data),
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (json) {

            swal.close();
            if (json.status) {

                showMessage('success', 'Sucesso', 'Contato foi cadastrada!')
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro ao cadastrar, entre em contato com o suporte!')
            }
            LimparCampos();
        },
        error: function (json) {

            showMessage('error', 'Oops...', 'Ocorreu um erro, entre em contato com o suporte!')

        }

    })
}


function montarObjetoEditar() {
    return {
        'Id': ($("#Id").val()),
        'Nome': ($("#txtNome").val()),
        'Email': ($("#txtEmail").val()),
        'Telefone': ($("#txtTelefone").val())
    }
}


function EditarContato() {
    if (validarFormulario())
        postEditar(montarObjetoEditar(), '/Contato/EditarContato')
}

function postEditar(data, url) {

    $.ajax({
        url: url,
        data: JSON.stringify(data),
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (json) {

            swal.close();
            if (json.status) {

                Swal.fire({
                    title: 'Sucesso',
                    text: "Contato Alterado!",
                    type: 'success',

                    confirmButtonColor: '#3085d6',

                    confirmButtonText: 'OK!'
                }).then((result) => {
                    if (result.value) {
                        window.location.replace("/Contato/Consultar");
                    }
                })
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro ao ediatar, entre em contato com o suporte!')
            }
            LimparCampos();
        },

        error: function (json) {
           
           showMessage('error', 'Oops...', 'Ocorreu um erro, entre em contato com o suporte!')

        }
    })
}
      


function validarFormulario() {
    var mensagem = '';

    if ($('#txtNome').val() == '') {
        mensagem += ' Nome';
    }

    if (mensagem == '')
        return true;

    showMessage('warning', 'Ops! Favor preencher o campo.', mensagem)
}



function LimparContato() {
    $("#btnLimpar").click(function () {
        LimparCampos();
    })
}

function LimparCampos() {
    $("#txtNome").val("");
    $("#txtEmail").val("");
    $("#txtTelefone").val("");
}


function ValidarEmail(email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var emailaddress = email.value
    console.log(emailaddress);
    if (!emailReg.test(emailaddress)) {
        showMessage('warning', 'Alerta', 'Email digitado incorreto!')
        $("#txtEmail").val("");
    }
    else {
        return true;
    }
}


function CarregarContatoEditar(idNovo) {

    $.ajax({
        url: "/Contato/ConsultarContatoByID",
        async: false,
        data: { 'ID': idNovo },

        success: function (json) {

            swal.close();
            if (json.status) {
                CarregarEdicao(json);             
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro  ao carregar dados, entre em contato com o suporte!')
            }
        }
    });
}

function CarregarEdicao(json) {
    $("#Id").val(json.response.Id)
    $("#txtNome").val(json.response.Nome);
    $("#txtEmail").val(json.response.Email);
    $("#txtTelefone").val(json.response.Telefone);
  
}


function MascaraCampos() {

    $("#txtTelefone").mask("(00)00000-0000")
  
}

var id_tela = 0;
window.onload = () => {

    MascaraCampos();
    LimparContato();

    var url = new URL(window.location);
    var titulo = "";

    var sp = new URLSearchParams(url.search);
    if (sp.get('id')) {
        id_tela = $.urlParam('id');
    }

    if (id_tela == 0) {
        titulo = "Cadastrar Contato";

        $("#btnSalvar").css('display', 'block');
        $("#btnEditar").css('display', 'none');
    }
    else {
        titulo = "Editar Contato";

        $("#btnSalvar").css('display', 'none');
        $("#btnEditar").css('display', 'block');
        CarregarContatoEditar(id_tela);
       
    }

    $("#lbl_titulo").html(titulo);
}
