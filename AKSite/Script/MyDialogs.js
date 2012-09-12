$().ready(function () {
    $("#page").append('<div id="deletePanel"><div>Данные будут потеряны, вы точно хотите продолжить?</div></div>');
    $('#deletePanel').dialog({
        autoOpen: false,
        modal: true,
        resizable: false,
        bgiframe: true,
        title: "Вы точно уверенны?"
    });
});

function deleteAction(uniqueID) {

    $('#deletePanel').dialog('option', 'buttons',
{
    "Да": function () { __doPostBack(uniqueID, ''); $(this).dialog("close"); },
    "Нет": function () { $(this).dialog("close"); }
});

$('#deletePanel').dialog('open');

    return false;
}