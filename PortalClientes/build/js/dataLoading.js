function openLoading() {
    lPanel.Show();
}

function closeLoading() {
    lPanel.Hide();
}

function LoadingTime(timer) {
    lPanel.Show();
    setTimeout(() => {
        lPanel.Hide();
    }, timer*1000);
   
}

function closeSession() {
    window.setTimeout(function () {
        let url = window.location.href;

        if(url.includes('localhost')){
            window.location.pathname = "/frmLogin.aspx";
        }else{
            window.location.pathname = "/PortalClientes/frmLogin.aspx";
        }
        
    }, 5000);
}

var menuLat = document.getElementsByClassName("item");
var matriculas = document.getElementsByClassName("dropdown-item");
var dropDown = document.getElementsByClassName("ddl");
var botonesExportar = document.getElementsByClassName("rpt");

for (var i = 0; i < menuLat.length; i++) {
    menuLat[i].addEventListener('click', openLoading , false);
}

for (var i = 0; i < matriculas.length; i++) {
    matriculas[i].addEventListener('click', openLoading , false);
}

for (var i = 0; i < dropDown.length; i++) {
    dropDown[i].addEventListener('change', openLoading , false);
}

for (var i = 0; i < botonesExportar.length; i++) {
    botonesExportar[i].addEventListener('click', ShowLoadingPanel , false);
}

function ShowLoadingPanel() {     
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_initializeRequest(prm_InitializeRequest);
    prm.add_endRequest(prm_EndRequest);
}
function prm_InitializeRequest(sender, args) {
    lPanel.Show();
}
function prm_EndRequest(sender, args) {
    lPanel.Hide();
}

console.log('si exta jalando este archivo');

function onItemClick(s, e) {
    if (e.item.name == "matriculas")  {
        e.processOnServer = false;  
        // const htmlElement = e.htmlElement;
        // const style = htmlElement.style;
        // style.visibility = "visible";
        // style.display = "block";

        // var element = document.getElementsByClassName("dpmain");
        // element.className += " show";

        // var element = document.getElementsByClassName("dropdown-usermenu");
        // element.className += " show";

    }
}