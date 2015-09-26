// Hides elements if the result of the call is the expected
// Html use:
//  Define an a element with:
//      data-hideable: css selector indicating what are you going to hide     
//      data-callable-url: url that ajax will call using post
//      expected-result: a string representing the value to hide
// Example:
//  Code: ~/Views/Shared/_LegalInfo.cshtml

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


/// Defines a fixeable menu that toggles elements
/// Html use:
///  1. For the menu:
///      Define two divs one with id="fixeable-menu" and another
///      with id="fixed-menu". The first one contains the menu.
///      The other one is empty.
///      The links must have a data-toggle tag indicating what divs
///      they will toggle.
///  2. For the contents:
///      Inside a div with a property data-showable="true" put all
///      the contents with hidden (display:none) divs and a
///      data-hide-me="true" to allow toggling after each click.
/// Example: 
///  Live: http://thescienceofcode.azurewebsites.net/Courses (and open a course)
///  Code: ~/Views/Courses/Show.cshtml

// This part controls the fixable menu
var fixed_menu = -1;
var fixed_status = false;
$(function () {
    if ($('#fixeable-menu').offset() == undefined) return;
    fixed_menu = $('#fixeable-menu').offset().top - 45;
    $('#fixed-menu').html($('#fixeable-menu').html());
    $(window).scroll(function () {
        if ($(window).scrollTop() > fixed_menu) {
            if (fixed_status) return;
            fixed_status = true;
            $('#fixed-menu').slideDown('fast');
            $('a[data-toggle]').removeClass('btn-primary');
            $('a[data-toggle]').addClass('btn-default');
        } else {
            if (!fixed_status) return;
            fixed_status = false;
            $('#fixed-menu').fadeOut('fast');
            $('a[data-toggle]').removeClass('btn-default');
            $('a[data-toggle]').addClass('btn-primary');
        }
    });
});

// This part controls the toggleable elements
var called = false;
$(function () {
    $('a[data-toggle]').click(function () {
        // Sets a min-h for the first time that content is showed
        if (!called) {
            called = true;
            $('[data-showable="true"]').addClass('min-h-content');
        }
        var current = $('a[data-toggle=' + $(this).data('toggle') + ']');

        // Update menu
        var show = true;
        if (current.hasClass('active')) {
            current.removeClass('active');
            show = false;
        }
        $('a[data-toggle]').removeClass('active');

        // Go to top
        $('html, body').animate({
            scrollTop: fixed_menu - 40
        });
        // And toggle contents
        $.when($('[data-hide-me="true"]').fadeOut('fast')).then(function () {
            if (!show) return;

            var element = current.attr('data-toggle');
            current.addClass('active');
            $(element).fadeIn('fast');
        });
    });
});
