/// QUESTION
function sendQuestion() {
    var form = $('#send-question');
    $('#questions-action').hide('fast', function () {
        $.ajax({
            type: 'POST',
            url: form.attr('action'),
            data: form.serialize(),
            success: function (response) {
                $('#questions-action').html(response);
                $('#questions-action').show('fast');
                $('#send-question-submit').click(function () {
                    sendQuestion();
                });
            }
        });
    });
}

function pagAnswers(e, o) {
    $.ajax({
        type: 'GET',
        contentType: 'text/html; charset=utf-8',
        url: e.data('url'),
        success: function (response) {
            $('#questions-list').html(response);
            setOnClickDataUrl(pagAnswers, o);
        }
    });
}

$(function () {
    $('#send-question-submit').click(function () {
        sendQuestion();
    });

    setOnClickDataUrl(pagAnswers, {top: $('#questions-list').offset().top});
});