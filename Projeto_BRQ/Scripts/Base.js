function showMessage(type, title, text) {
    Swal({
        type: type,
        title: title,
        text: text
    })
}

/// FUNÇÃO QUE PEGA URL DA PAGINA

$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}