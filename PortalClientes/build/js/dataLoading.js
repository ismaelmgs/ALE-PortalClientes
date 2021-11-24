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
        window.location.pathname = "/frmLogin.aspx";
    }, 5000);
}