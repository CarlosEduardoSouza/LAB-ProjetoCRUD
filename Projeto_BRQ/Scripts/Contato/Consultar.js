function CancelarContato() {
    LimparContato();
    OcultarGrid();
}

function MostrarGrid() {
    $("#Grid").css('display', 'block');
}

function OcultarGrid() {
    $("#Grid").css('display', 'none');
}

function montarObjetoConsultar() {
    return {
        'Nome': ($("#txtNome").val()),
        'Email': ($("#txtEmail").val()),
        'Telefone': ($("#txtTelefone").val())
    }
}

function LimparContato() {  
        LimparCampos(); 
}

function LimparCampos() {
    $("#txtNome").val("");
    $("#txtEmail").val("");
    $("#txtTelefone").val("");
}

function Pesquisar() {

    CarregarGrid();
}

var oTable;
var teste = 0;

function CarregarGrid() {
    MostrarGrid();
    if (teste == 1) {
        oTable.destroy();
    }
    teste = 1;
    oTable = $("#myDataTable").DataTable({

        "language": {
            "lengthMenu": "Exibe _MENU_ Registros por página",
            "search": "Procurar",
            "paginate": { "previous": "Retorna", "next": "Avança" },
            "zeroRecords": "Nenhum registro foi encontrado",
            "info": "Exibindo página _PAGE_ de _PAGES_",
            "infoEmpty": "Sem registros",
            "infoFiltered": "(filtrado de _MAX_ regitros totais)"
        },
        "processing": true, // mostrar a progress bar
        //"serverSide": true, // processamento no servidor
        "filter": true, // habilita o filtro(search box)
        "lengthMenu": [[3, 5, 10, 25, 50, -1], [3, 5, 10, 25, 50, "Todos"]],
        "pageLength": 10, // define o tamanho da página
        "ajax": {
            "url": "/Contato/ConsultarContato",
            "type": "GET",
            "dataType": "json",
            "data": montarObjetoConsultar(),
        },


        "columns": [
            { "data": "Id", "title": "Id" },
            { "data": "Nome", "title": "Nome" },
            { "data": "Email", "title": "Email" },
            { "data": "Telefone", "title": "Telefone" },
            {
                "data": function (data) {
                    return '<a href="/Contato/Cadastrar?id=' + data.Id + '" class="btn-primary btn-sm"><span class="glyphicon glyphicon-pencil" title="Editar"></span><a/>&nbsp' +
                        '<a href="#" class="btn-danger btn-sm"><span class="glyphicon glyphicon-remove" onclick="DeletarContato(' + data.Id + ');" title="Excluir"></span><a/>';
                }
            }
        ]

    })

}


function DeletarContato(id) {
    Swal.fire({
        title: 'Atenção!',
        text: "Deseja excluir esse registro id: " + id,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#00CD00',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Deletar'
    }).then((result) => {
        if (result.value) {
            ExcluirRegistro(id);
        }
    })
}

function ExcluirRegistro(id) {
    $.ajax({
        url: "/Contato/ExcluirContato",
        async: false,
        data: { 'ID': id },

        success: function (json) {

            swal.close();
            if (json.status) {
                CarregarGrid();
            }
            else {
                showMessage('error', 'Oops...', 'Ocorreu um erro  ao carregar dados, entre em contato com o suporte!')
            }
        }
    });
}

window.onload = function () {
    OcultarGrid();
};