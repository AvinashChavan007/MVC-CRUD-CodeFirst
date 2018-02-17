var buildMsg = function (msg, error) {
    if (msg !== '') {
        if (error) {
            toastError(msg);
        } else {
            toastSuccess(msg);
        }
    }
}

var toastSuccess = function(msg) {
    toastr.options = {
        "progressBar": true
    }
    toastr.success(msg);
}

var toastError = function(msg) {
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "timeOut": 0
    }
    toastr.error(msg);
    $(".toast").off();
}

var toastWarningYesNo = function (title, msg, yesCallback, noCallback) {
    if ($('div.toast-warning').length === 0) {
        var htmlMsg = msg + '<br /><br /><button style="margin-left: 15px;" type="button" data-btn-toastr="yes" class="pull-right clear btn btn-success">Yes</button><button type="button" data-btn-toastr="no" class="pull-right clear btn btn-danger">No</button>';
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": 0,
            "extendedTimeOut": 0,
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut",
            "tapToDismiss": false
        }

        title != null ? toastr.warning(htmlMsg, title) : toastr.warning(htmlMsg);
        // wire up events
        $('button[data-btn-toastr]').on('click', function () {
            toastr.remove();
            toastr.clear();
            if ($(this).data('btn-toastr') === 'yes')
                yesCallback();
            if (noCallback != null && $(this).data('btn-toastr') === 'no')
                noCallback();
        });
    }
    $('#toast-container').addClass('backdrop');
}