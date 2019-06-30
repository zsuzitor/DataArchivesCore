;;

function goAjaxRequest(obj) {
    if (!obj.type)
        obj.type = 'GET';
    if (!obj.dataType)
        obj.dataType = 'html';
    $.ajax(
        {
            type: obj.type,
            data: obj.data,
            url: obj.url,
            success: function (xhr, status, jqXHR) {
                if (obj.func_success) {
                    try {
                        obj.func_success(xhr, status, jqXHR);
                    }
                    catch (e) {
                        console.log('Ошибка ' + e.name + ":" + e.message + "\n" + e.stack);
                    }

                }
            },
            error: function (xhr, status, error) {
                alert("ошибка загрузки");
                if (obj.func_error)
                    obj.func_error(xhr, status, error);
            },
            // shows the loader element before sending.
            beforeSend: function () {
                if (obj.func_beforeSend)
                    obj.func_beforeSend();
              //  PreloaderShowChange(true);
            },
            // hides the loader after completion of request, whether successfull or failor.             
            complete: function (xhr, status, jqXHR) {
                if (obj.func_complete) {
                    try {
                        obj.func_complete(xhr, status, jqXHR);
                    }
                    catch (e) {
                        console.log('Ошибка ' + e.name + ":" + e.message + "\n" + e.stack);
                    }
                }

                //PreloaderShowChange(false);
            },
            dataType: obj.dataType//'html'
        });
}










;;;