$(document).ready(function () {
    
   
    $("#btn-addbook").on("click", function () {
        ValidateUser();
    })
});
//to check all fields where user enter correct or not
// if not entered correct ,it will prevent to sumbit form
function ValidateUser() {
    event = event || window.event || event.srcElement;
    var return_val = true;
    if ($('#Author').val().trim() == '') {
        $('#Author').next('span').show();
        return_val = false;
    } else {
        $('#Author').next('span').hide();
    }
    if ($('#Publisher').val().trim() == '') {
        $('#Publisher').next('span').show();
        return_val = false;
    } else {
        $('#Publisher').next('span').hide();
    }
    if ($('#Description').val().trim() == '') {
        $('#Description').next('span').show();
        return_val = false;
    } else {
        $('#Description').next('span').hide();
    }

   
    if ($(".field-validation-valid.text-danger").is(":visible")) {
        event.preventDefault();
    }
    else {
        $("#formAddBook").submit();
    }
}
