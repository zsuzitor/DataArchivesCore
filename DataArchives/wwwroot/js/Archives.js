;;;
//var ArchivesOBJECT = {
//};


//$('.sectionAddSubmit').on('click', function () {
//    var form = this.form;
//    alert('Имя ' + form.name.value + ', Телефон: ' + form.phone.value);
//});
//$('.sectionCancelAddSubmit').click( function () {
//    var form = this.form;
//    form.remove();
//    return false;
//});
//function cancelAdd(button) {
//    var form = button.form;
//    form.remove();
//    return false;
//}


//$('.articleAddSubmit').on('click', function () {
//    var form = this.form;
//    alert('Имя ' + form.name.value + ', Телефон: ' + form.phone.value);
//});





function clickForChilds(id) {
    clickForChildsWithCallback(id,null);
}

function clickForChildsWithCallback(id,callback) {

    let childs = document.getElementById("OneSectionChilds_" + id);
    if ($("#checkboxOpend_" + id).prop("checked")) {
        $('#checkboxOpend_' + id).prop('checked', false);
        $("#buttonShowChildsSection_" + id).removeClass("bg-primary");
        $("#buttonShowChildsSection_" + id).addClass("bg-info")

        childs.style.display = 'none';
    }
    else {
        $('#checkboxOpend_' + id).prop('checked', true);
        
        $("#buttonShowChildsSection_" + id).removeClass("bg-info");
        $("#buttonShowChildsSection_" + id).addClass("bg-primary")


        childs.style.display = 'block';

        if (!childs.innerHTML.trim()) {
            childs.innerHTML = GetHtmlPreloader100On100();
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
        actionsSectionsPreloadOf(id);
    }
    else {
        actions.style.height = '0';
        button.innerHTML = '<small class="text-muted">Показать действия</small>';
        actionsSectionsPreloadOf(id);
    }

}

function actionsArticle(id) {
    let actions = document.getElementById('articleActions_' + id);
    let button = document.getElementById('actionsArticleButton_' + id);


    if (actions.style.height) {
        actions.style.height = '';
        button.innerHTML = '<small class="text-muted">Скрыть действия</small>';
        actionsArticlePreloadOf(id);
    }
    else {
        actions.style.height = '0';
        button.innerHTML = '<small class="text-muted">Показать действия</small>';
        actions.innerHTML = '';
    }

}





function addSection(id) {
    //let shown=$("#checkboxOpend_" + id).prop("checked");
    //let strappend = '<form><input name="parentSectionId" type="hidden" value="'+id+'"/>\
    //    <textarea name = "sectionHead" > Новая запись еще не сохранена</textarea>\
    //        <button type="submit" class="sectionAddSubmit">Сохранить</button><button type="button" onclick="cancelAdd(this)" class="sectionCancelAddSubmit">Удалить</button></form>';
    //if (shown) {
    //    $('#OneSectionChildsSections_' + id).append(strappend);
    //}
    //else {
    //    clickForChildsWithCallback(id, function () {
    //        $('#OneSectionChildsSections_' + id).append(strappend);
    //    });
    //}

    let modelHead = document.getElementById('mainModalLabel');
    modelHead.innerHTML = 'Добавление секции';
    let modelBody = document.getElementById('mainModalBodyId');
    //<input id="AddNewSectionParentId" type = "hidden" value = "' + id +'" />
    modelBody.innerHTML = '<div><textarea id="addNewSectionHead"></textarea><button onclick="saveAddSection('+id+')">Добавить</button></div >';
    let modelFooter = document.getElementById('mainModalFooterId');
    modelFooter.innerHTML = 'Подтвердите добавление';
    $('#mainModal').modal()
}

function addArticle(id) {
    //let shown = $("#checkboxOpend_" + id).prop("checked");
    //let strappend = '<p>Меня тут не было!</p>';
    //if (shown) {
    //    $('#OneSectionChildsArticles_' + id).append(strappend);
    //}
    //else {
    //    clickForChildsWithCallback(id, function () {
    //        $('#OneSectionChildsArticles_' + id).append(strappend);
    //    });
    //}

    let modelHead = document.getElementById('mainModalLabel');
    modelHead.innerHTML = 'Добавление статьи';
    let modelBody = document.getElementById('mainModalBodyId');
    //<input id="AddNewSectionParentId" type = "hidden" value = "' + id +'" />
    modelBody.innerHTML = '<div><textarea id="addNewArticleHead"></textarea><button onclick="saveAddArticle(' + id + ')">Добавить</button></div>';
    let modelFooter = document.getElementById('mainModalFooterId');
    modelFooter.innerHTML = 'Подтвердите добавление';
    $('#mainModal').modal()


}


function saveAddSection(idParent) {
    let dt = {
        idParentSection: idParent,
        head: document.getElementById('addNewSectionHead').value.trim()

    };
    let modelBody = document.getElementById('mainModalBodyId');
    modelBody.innerHTML = GetHtmlPreloader100On100();

    goAjaxRequest({
        url: "/Archives/CreateSection",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            //let shown = $("#checkboxOpend_" + idParent).prop("checked");

            if ($("div").is("#OneSectionChildsSections_" + idParent)) {
                $('#OneSectionChildsSections_' + idParent).append(xhr);
            }
            modelBody.innerHTML = 'Сохранено';
        },
        func_error: function (xhr, status, jqXHR) {
            modelBody.innerHTML = 'Произошла ошибка';
           
        }
    });
}



function saveAddArticle(idParent) {
    let dt = {
        idParentSection: idParent,
        head: document.getElementById('addNewArticleHead').value.trim()
    };
    let modelBody = document.getElementById('mainModalBodyId');
    modelBody.innerHTML = GetHtmlPreloader100On100();

    goAjaxRequest({
        url: "/Archives/CreateArticle",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            //let shown = $("#checkboxOpend_" + idParent).prop("checked");

            if ($("div").is("#OneSectionChildsArticles_" + idParent)) {
                $('#OneSectionChildsArticles_' + idParent).append(xhr);
            }
            modelBody.innerHTML = 'Сохранено';//<a href="/Archives/ArticleRecord/'++'"></a> //#TODO
        },
        func_error: function (xhr, status, jqXHR) {
            modelBody.innerHTML = 'Произошла ошибка';

        }
    });
}




function changeSection(id) {
    let head = document.getElementById('oneSectionHead_' + id);
    let headLabel = document.getElementById('oneSectionHeadLabel_' + id);
    if (!headLabel)
        return;
    let headStr = headLabel.innerHTML.trim();
    let str = '<input id="inputChangeHeadSection_' + id + '" value="' + headStr +'" type="text"/>\
        <input id="changeSectionOldHidden_'+id+'" value="' + headStr + '" type = "hidden" />\
            <button onclick="saveChangeSection(\''+ id +'\')">Изменить</button>\
            <button onclick="cancelChangeSection(\''+id+'\')">Отменить</button>';
    head.innerHTML = str;
}

function changeArticleHead(id) {
    let head = document.getElementById('oneArticleHead_' + id);
    let headLabel = document.getElementById('oneArticleHeadLabel_' + id);
    if (!headLabel)
        return;
    let headStr = headLabel.innerHTML.trim();
    let str = '<input id="inputChangeHeadArticle_' + id + '" value="' + headStr + '" type="text"/>\
        <input id="changeArticleOldHidden_'+ id + '" value="' + headStr + '" type = "hidden" />\
            <button onclick="saveChangeArticle(\''+ id + '\')">Изменить</button>\
            <button onclick="cancelChangeArticle(\''+ id + '\')">Отменить</button>';
    head.innerHTML = str;
}


//deleteArticle

function saveChangeSection(id) {
    let newHead = document.getElementById('inputChangeHeadSection' + id).value.trim();
    let headDiv = document.getElementById('oneSectionHead_' + id);
    actionsSectionsPreloadOn(id);
    let dt = {
        idSection: id,
        head: newHead

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

function saveChangeArticle(id) {
    let newHead = document.getElementById('inputChangeHeadArticle_' + id).value.trim();
    let headDiv = document.getElementById('oneArticleHead_' + id);
    actionsArticlePreloadOn(id);
    let dt = {
        idArticle: id,
        head: newHead

    };

    goAjaxRequest({
        url: "/Archives/ChangeArticle",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            if (xhr) {
                headDiv.innerHTML = '<label id="oneArticleHeadLabel_' + id + '">' + newHead + '</label>';//
            }
            else {//#TODO тут через push сделать
                alert('Что то пошло не так');
            }
        },
        func_complete: function (xhr, status, jqXHR) {
            // preload.style.display = 'none';
            actionsArticlePreloadOf(id);
        },
        dataType: 'json'
    });


}


function cancelChangeSection(id) {
    let oldvalue = document.getElementById('changeSectionOldHidden_' + id).value;
    let head = document.getElementById('oneSectionHead_' + id);
    head.innerHTML = '<label id="oneSectionHeadLabel_' + id+'">' + oldvalue + '</label>';
}

function cancelChangeArticle(id) {
    let oldvalue = document.getElementById('changeArticleOldHidden_' + id).value;
    let head = document.getElementById('oneArticleHead_' + id);
    head.innerHTML = '<label id="oneArticleHeadLabel_' + id + '">' + oldvalue + '</label>';
}

function deleteSection(id) {
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
        },
        func_complete: function (xhr, status, jqXHR) {
            //preload.style.display = 'none';
            actionsSectionsPreloadOf(id);
        },
        dataType: 'json'
    });

}

function deleteArticle(id) {
    actionsArticlePreloadOn(id);
    let dt = {
        idArticle: id
    };

    goAjaxRequest({
        url: "/Archives/DeleteArticle",
        data: dt,
        func_success: function (xhr, status, jqXHR) {
            switch (xhr) {
                //case 0:
                //    document.getElementById('OneArticleChilds_' + id).innerHTML = '';//очищена
                //    break;
                case 1:
                    document.getElementById('OneArticleFull_' + id).remove();//удалена
                    break;
                case 2:
                    alert('Ошибка');//#TODO тут через push сделать
                    break;
            }
        },
        func_complete: function (xhr, status, jqXHR) {
            //preload.style.display = 'none';
            actionsArticlePreloadOn(id);
        },
        dataType: 'json'
    });

}


function GetHtmlPreloader100On100() {
    return '<div class="text-center" >\
        <div class="spinner-border text-primary square-100-100" role = "status" >\
            <span class="sr-only">Загрузка...</span></div ></div >';
} 

function actionsSectionsPreloadOn(id) {
    let div = document.getElementById('sectionActions_' + id);
    div.innerHTML = GetHtmlPreloader100On100();
    
}

function actionsArticlePreloadOn(id) {
    let div = document.getElementById('articleActions_' + id);
    div.innerHTML = GetHtmlPreloader100On100();

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


function actionsArticlePreloadOf(id) {
    let div = document.getElementById('articleActions_' + id);
    div.innerHTML = '<div class="row"><div class="col-6">\
                <button onclick="changeArticleHead('+ id + ')" class="btn-block btn btn-secondary">Изменить заголовок статьи</button></div>\
                <div class="col-6"><button onclick="deleteArticle('+ id + ')" class="btn-block btn btn-secondary">Удалить статью</button>\
                </div>';

}


function OpenArticlePage(id){
    window.open('/Archives/ArticleRecord/'+id);
}








;;;