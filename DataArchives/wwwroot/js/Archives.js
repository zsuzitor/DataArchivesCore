;;;
var ArchivesOBJECT = {
    //OwnDatasPageIsLoad: true,
    //SearchPageIsLoad: false,
    //ForeignDatasPageIsLoad: false
};



function clickForChilds(id) {



}


function goSearch() {
    let dt = {
        str: document.getElementById('searchStr').value,
        email: document.getElementById('searchEmail').value,
        type: 1
    };
    //if (!ArchivesOBJECT.SearchPageIsLoad) {
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
    //}
}


function getForeign() {
    let dt = {
        email: document.getElementById('foreignEmail').value
    };
    //if (!ArchivesOBJECT.ForeignDatasPageIsLoad) {
        let preload=document.getElementById('ForeignResultPreload');
        preload.style.display = 'block';
        goAjaxRequest({
            url: "/Archives/ForeignDatas",
            data: dt,
            func_success:function (xhr, status, jqXHR) {
                document.getElementById('ForeignResult').innerHTML = xhr;
                //ArchivesOBJECT.ForeignDatasPageIsLoad = true;
                
            },
            func_complete: function (xhr, status, jqXHR) {
                preload.style.display = 'none';
            }
        });
    //}
}


//function mainHeaderChangeSel(type) {
//    switch (type) {
//        case "OwnDatas":
//            //
//            break;
//        case "Search":
            
            
//            break;
//        case "ForeignDatas":
           
            
//            break;
//    }

//}


;;;