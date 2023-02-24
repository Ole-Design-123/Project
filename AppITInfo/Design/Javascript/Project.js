function jQueryAjaxPostImage(form) {
    var ajaxConfig = {
        type: 'POST',
        url: form.action,
        data: new FormData(form),
        success: function (response) {
            if (response.Result == "Submitted") {
                alert(response.message);
                window.location.replace(response.Message);
            }
            if (response.success) {
                Success_Alert(response.message);
            }
            else {
                Error_Alert(response.message);
            }
        }
    }
    if ($(form).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);
    return false;
}

function Success_Alert(MSG) {
    Swal.fire({
        icon: 'success',
        title: MSG,
        showConfirmButton: false,
        timer: 3000
    })
}
function Error_Alert(MSG) {
    Swal.fire({
        icon: 'error',
        title: MSG,
        showConfirmButton: false,
        timer: 3000
    })
}