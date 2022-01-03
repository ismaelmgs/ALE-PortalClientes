function openLoading() {
    lPanel.Show();
}

function closeLoading() {
    //window.setTimeout(function () {
    //    lPanel.Hide();
    //}, 750);
   lPanel.Hide();
}

function closeSession() {
    window.setTimeout(function () {
        let url = window.location.href;

        if(url.includes('localhost')){
            window.location.pathname = "/frmLogin.aspx";
        }else{
            window.location.pathname = "/PortalClientes/Views/frmLogin.aspx";
        }
        
    }, 5000);
}