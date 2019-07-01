;;;
//var ArchivesOBJECT = {
//};



function clickForChilds(id) {
    clickForChildsWithCallback(id,null);
}

function clickForChildsWithCallback(id,callback) {

    let childs = document.getElementById("OneSectionChilds_" + id);
    if ($("#checkboxOpend_" + id).prop("checked")) {
        $('#checkboxOpend_' + id).prop('checked', false);
        childs.style.display = 'none';
    }
    else {
        $('#checkboxOpend_' + id).prop('checked', true);

        childs.style.display = 'block';

        if (!childs.innerHTML.trim()) {
            childs.innerHTML = '<div class="text-center" ><div class="spinner-border text-primary square-100-100" role="status"><span class="sr-only">Загрузка...</span></div></div>';
            let dt = {
                idSection: id
            };

            goAjaxRequest({
                url: "/Archives/GetSectionChilds",
                data: dt,
                func_success: function (xhr, status, jqXHR) {
                    childs.innerHTML = xhr;
                    if (callback)
                        callback();

                },
                func_error: function (xhr, status, error) {
                    childs.innerHTML = '';
                }
            });
        }
    }
}


function goSearch() {
    let dt = {
        str: document.getElementById('searchStr').value,
        email: document.getElementById('searchEmail').value,
        type: 1
    };
        let preload = document.getElementById('searchResultPreload');
        preload.style.display = 'block';
        goAjaxRequest({
            url: "/Archives/Search",
            data: dt,
            func_success:function (xhr, status, jqXHR) {
                document.getElementById('searchResult').innerHTML = xhr;
                //ArchivesOBJECT.SearchPageIsLoad = true;
                
            },
                func_complete: function(xhr, status, jqXHR) {
                    preload.style.display = 'none';
                }
        });
}


function getForeign() {
    let dt = {
        email: document.getElementById('foreignEmail').value
    };
        let preload=document.getElementById('ForeignResultPreload');
        preload.style.display = 'block';
        goAjaxRequest({
            url: "/Archives/ForeignDatas",
            data: dt,
            func_success:function (xhr, status, jqXHR) {
                document.getElementById('ForeignResult').innerHTML = xhr;
            },
            func_complete: function (xhr, status, jqXHR) {
                preload.style.display = 'none';
            }
        });
}



function actionsSection(id) {
    let actions = document.getElementById('sectionActions_' + id);
    let button = document.getElementById('actionsSectionButton_' + id);


    if (actions.style.height) {
        actions.style.height = '';
        button.innerHTML = '<small class="text-muted">Скрыть действия</small>';
    }
    else {
        actions.style.height = '0';
        button.innerHTML = '<small class="text-muted">Показать действия</small>';
    }

}




function addSection(id) {
    let shown=$("#checkboxOpend_" + id).prop("checked");
    let strappend = '<p>Меня тут не было!</p>';
    if (shown) {
        $('#OneSectionChildsSections_' + id).append(strappend);
    }
    else {
        clickForChildsWithCallback(id, function () {
            $('#OneSectionChildsSections_' + id).append(strappend);
        });
    }
}

function addArticle(id) {
    let shown = $("#checkboxOpend_" + id).prop("checked");
    let strappend = '<p>Меня тут не было!</p>';
    if (shown) {
        $('#OneSectionChildsArticles_' + id).append(strappend);
    }
    else {
        clickForChildsWithCallback(id, function () {
            $('#OneSectionChildsArticles_' + id).append(strappend);
        });
    }
}

function changeSection(id) {
    let head = document.getElementById('oneSectionHead_' + id);
    let headLabel = document.getElementById('oneSectionHeadLabel_' + id);
    if (!headLabel)
        return;
    let headStr = headLabel.innerHTML.trim();
    let str = '<input id="inputChangeHead_' + id + '" value="' + headStr +'" type="text"/>\
        <input id="changeSectionOldHidden_'+id+'" value="' + headStr + '" id = "inputChangeOldHead_' + id +'" type = "hidden" />\
            <button onclick="saveChangeSection(\''+ id +'\')">Изменить</button>\
            <button onclick="cancelChangeSection(\''+id+'\')">Отменить</button>';
    head.innerHTML = str;
}

function saveChangeSection(id) {
    let newHead = document.getElementById('inputChangeHead_' + id).value.trim();
    let headDiv = document.getElementById('oneSectionHead_' + id);
    actionsSectionsPreloadOn(id);
    let dt = {
        idSection: id,
        head: newHead,

    };

    goAjaxRequest({
        url: "/Archives/ChangeSection",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            if (xhr) {
                headDiv.innerHTML = '<label id="oneSectionHeadLabel_'+id+'">' + newHead +'</label>';//
            }
            else {//#TODO тут через push сделать
                alert('Что то пошло не так');
            }
        },
        func_complete: function (xhr, status, jqXHR) {
           // preload.style.display = 'none';
            actionsSectionsPreloadOf(id);
        },
        dataType: 'json'
    });


}


function cancelChangeSection(id) {
    let oldvalue = document.getElementById('changeSectionOldHidden_' + id).value;
    let head = document.getElementById('oneSectionHead_' + id);
    head.innerHTML = '<label id="oneSectionHeadLabel_' + id+'">' + oldvalue + '</label>';
}


function deleteSection(id) {

    // childs.innerHTML = '<div class="text-center" ><div class="spinner-border text-primary square-100-100" role="status"><span class="sr-only">Загрузка...</span></div></div>';
    actionsSectionsPreloadOn(id);
    let dt = {
        idSection: id
    };
    
    goAjaxRequest({
        url: "/Archives/DeleteSection",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            switch (xhr) {
                case 0:
                    document.getElementById('OneSectionChilds_' + id).innerHTML='';//очищена
                    break;
                case 1:
                    document.getElementById('OneSectionFull_' + id).remove();//удалена
                    break;
                case 2:
                    alert('Ошибка');//#TODO тут через push сделать
                    break;
            }
            //if (xhr) {
            //    document.getElementById('OneSectionFull_' + id).remove();
            //}
            //else {//#TODO тут через push сделать
            //    alert('Что то пошло не так');
            //}
        },
        func_complete: function (xhr, status, jqXHR) {
            //preload.style.display = 'none';
            actionsSectionsPreloadOf(id);
        },
        dataType: 'json'
    });

}


function actionsSectionsPreloadOn(id) {
    let div = document.getElementById('sectionActions_' + id);
    div.innerHTML = '<div class="text-center" >\
        <div class="spinner-border text-primary square-100-100" role = "status" >\
            <span class="sr-only">Загрузка...</span></div ></div >';
    
}

function actionsSectionsPreloadOf(id) {
    let div = document.getElementById('sectionActions_' + id);
    div.innerHTML = '<div class="row"><div class="col-6">\
        <button onclick = "addSection('+ id+')" class="btn-block btn btn-secondary" > Добавить секцию</button ></div >\
            <div class="col-6"> <button onclick="addArticle('+ id +')" class="btn-block btn btn-secondary">Добавить статью</button>\
            </div></div > <div class="p-1"></div> <div class="row"><div class="col-6">\
                <button onclick="changeSection('+ id +')" class="btn-block btn btn-secondary">Изменить секцию</button></div>\
                <div class="col-6"><button onclick="deleteSection('+ id +')" class="btn-block btn btn-secondary">Удалить секцию</button>\
                </div></div>';

}
















;;;