function ajax(route,onSuccess,onError,type) {
        $.ajax({
            url: window.location.href,
            type: type,
            context: this,
            data: route,
            success: function (data) {
                onSuccess(data);
            },
            error: function (data) {
                onError(data);
            }
        });
}
function getSelected(name) {
    var selected = [];
    var result = [];
    document.getElementsByName(name).forEach(x => {
        result.push(x.getAttribute("data-value"));
        if (x.checked) {
            selected.push(x.getAttribute("data-value"));
        }
    });
    var isEmpty = selected.length == 0;
    result = isEmpty ? undefined : selected;
    return {
        result: result,
        isEmpty: isEmpty
    };
}
function showSearchFilter(id) {
    var display = document.getElementById(id).style.display;
    console.log(display);
    display = display === "none" ? "block" : "none";
    console.log(display);
    document.getElementById(id).style.display = display;
}
function goToPage(page) {
    ajax({
        scController: "Portfolio",
        scAction: "Search",
        query: document.getElementById("textQuery").value,
        categories: getSelected("categoriesList").result,
        tags: getSelected("tagsList").result,
        page: page
    }, (data) => {
        document.getElementById("projectsList").outerHTML = data;
    }, (data) => console.log(data), "POST");
}
function search() {
    ajax({
        scController: "Portfolio",
        scAction: "Search",
        query: document.getElementById("textQuery").value,
        categories: getSelected("categoriesList").result,
        tags: getSelected("tagsList").result,
        page: 1
    }, (data) => {
        document.getElementById("projectsList").outerHTML = data;
    }, (data) => console.log(data), "POST");
}