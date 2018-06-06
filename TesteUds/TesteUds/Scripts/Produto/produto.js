$(document).on("click", "[id^='linkExcluir']", function () {
    var id = $(this).attr("data-id");
    $("#removeConfirmation").dialog({
        autoOpen: true,
        resizable: false,
        title: 'Confirmar Exclusão',
        modal: true,
        buttons: {
            'Sim': function () {
                $.ajax({
                    method: 'POST',
                    url: '/Produto/Remover',
                    data: { id: id },
                    success: function () {
                        window.location.href = '/Produto';
                    }
                });
            },
            'Não': function () {
                $(this).dialog('close');
            }
        },
    });
});


$(document).on("click", "[id^='linkEditar']", function () {
    var id = $(this).attr("data-id");
    window.location.href = '/Produto/Editar/' + id;
});

