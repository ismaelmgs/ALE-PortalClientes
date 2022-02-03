function openLoading() {
    lPanel.Show();
}

function closeLoading() {
   lPanel.Hide();
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
// var botonesExportar = document.getElementsByClassName("btn");

for (var i = 0; i < menuLat.length; i++) {
    menuLat[i].addEventListener('click', openLoading , false);
}

for (var i = 0; i < matriculas.length; i++) {
    matriculas[i].addEventListener('click', openLoading , false);
}

for (var i = 0; i < dropDown.length; i++) {
    dropDown[i].addEventListener('change', openLoading , false);
}

// for (var i = 0; i < botonesExportar.length; i++) {
//     botonesExportar[i].addEventListener('click', openLoading , false);
// }

console.log('si exta jalando este archivo');