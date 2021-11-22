function openLoading() {
    lPanel.Show();
}

function closeLoading() {
    window.setTimeout(function () {
        lPanel.Hide();
    }, 750);
   
}

function myFuncionAlerta() {
    alert("Alerta JavaScript")
}