loadingMsgs = ['¡Ya casi!', 'La conexión está lenta', 'Estos mensajes son divertidos', ':('];
var htmlLoading = null;
var curLoadingMsg = 0;
function changeMsg() {
    if (htmlLoading == null) {
        htmlLoading = $('.loading').html();
    }

    $('.loading-msg').text(loadingMsgs[curLoadingMsg]);
    if (++curLoadingMsg < loadingMsgs.length) setTimeout(changeMsg, 5000);
}
changeMsg();