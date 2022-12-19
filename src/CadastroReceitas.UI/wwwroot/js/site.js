

function VisualizarReceita(idReceita) {

    $.ajax({
        type: "Get",
        url: "/Receita/Select",
        data: { id: idReceita },
        success: function (data) {
            $("#modalVisualizaReceita #idTitulo").text(data.titulo);
            $("#modalVisualizaReceita #idIngredientes").text(data.ingredientes);
            $("#modalVisualizaReceita #idModoPreparo").text(data.modoPreparo);
            $("#modalVisualizaReceita").modal('show');
        }
    });
}


$(".btn-hide-modal").click(function () {
    $('#modalVisualizaReceita').modal('hide');
});
