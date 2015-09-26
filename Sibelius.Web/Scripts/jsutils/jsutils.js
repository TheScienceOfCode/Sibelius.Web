// Hides elements if the result of the call is the expected
// Html use:
//  Define an a element with:
//      data-hideable: css selector indicating what are you going to hide     
//      data-callable-url: url that ajax will call using post
//      expected-result: a string representing the value to hide
$(function () {
    $('a[data-hideable]').click(function () {
        var tohide = $(this).data('hideable');
        var expected = $(this).data('expected-result');
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: $(this).data('callable-url'),
            success: function (response) {
                if (response == expected) $(tohide).fadeOut('fast');
            }
        });
    });
});