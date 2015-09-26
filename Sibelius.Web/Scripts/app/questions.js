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

$(function () {
    $('#send-question-submit').click(function () {
        sendQuestion();
    });

    setOnClickDataUrl({
        top: $('#questions-list').offset().top,
        method: 'get', div: '#questions-list',
        load: false,
        push: false
    });
});