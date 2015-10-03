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
    // No fixeable menu?
    if ($('#fixeable-menu').offset() == undefined) return;

    // Set position
    fixed_menu = $('#fixeable-menu').offset().top - 45;
    // Copy menu
    $('#fixed-menu').html($('#fixeable-menu').html());

    // Hide and show fixed menu!
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

/// Sets on click for all a[data-url]    
/// 
/// options.load: determines if a gif is showed when loading (by default is a nested <img>).
/// options.push: determines if url must be pushed into history.
/// options.top: position to scroll to.
/// options.div: div to replace result.
/// options.func: handler.
/// options.precall: a function to call before ajax.
/// options.postcall: a function to call after ajax.
/// options.method: GET or POST for ajax call.
/// options.contentType: for ajax result.
/// options.getCall: default URL getter.
/// options.updateMetadata: a function to update metadata.
/// options.metadataDesc: id that contains new desc info.
/// options.metadataKeywords: id that contains new keywords info.

function setOnClickDataUrl(o) {
    var options = o || {};
    options.load = options.load || false;
    options.push = options.push || false;
    options.top = options.top || 0;
    options.div = options.div || '';
    options.func = options.func || defaultLoad;
    options.precall = options.precall || undefined;
    options.postcall = options.postcall || undefined;
    options.method = options.method || 'POST';
    options.contentType = options.contentType || 'text/html; charset=utf-8';
    options.getCall = options.getCall || function (id) { return $(id).data('url'); };
    options.updateMetadata = options.updateMetadata || updateMetadata;
    options.metadataDesc = options.metadataDesc || '#desc';
    options.metadataKeywords = options.metadataKeywords || '#keywords';

    if (options.updateMetadata) {
        window.onpopstate = function (event) {
            // Trigger url load
            document.location = document.location;
        };
    }

    $('[data-url]').unbind('click');
    $('[data-url]').on('click', function () {
        // History
        if (options.push) window.history.pushState("", "", $(this).data('url'));
        // Precall
        if (options.precall) options.precall();

        // Scroll
        $('html, body').animate({
            scrollTop: options.top
        });

        // Call
        options.func($(this), options);

        // Postcall
        if (options.postcall) options.postcall();
    });
}


/// Default a[data-url] handler
/// If push is on, calls a default metadata update, that takes info from #desc and #keyword
var reqs = [];
function defaultLoad(e, options) {
    // Abort pending reqs
    for (i = 0; i < reqs.length; i++) {
        reqs[i].abort();
    }
    reqs.length = 0;

    // Show loading gif
    if (options.load) jQuery(e).find("img").addClass('visible');    

    // Ajax call
    var r = $.ajax({
        // Config
        type: options.method,
        contentType: options.contentType,
        url: options.getCall(e),
        success: function (response) {
            // Show
            $(options.div).html(response);

            // Reconfigure buttons
            setOnClickDataUrl(options);

            // History
            if (options.push) options.updateMetadata(options.metadataDesc, options.metadataKeywords);
            // Hide loading gif
            if (options.load) jQuery(e).find("img").removeClass('visible');

            // Force FB & TW
            try {
                FB.XFBML.parse();
                twttr.widgets.load();
            } catch (ex) { }
        }
    });
    reqs.push(r);
}

function updateMetadata(desc, keywords) {
    $('meta[name=description]').remove();
    $('head').append('<meta name="description" content="' + $(desc).html() + '" />');
    $('meta[name=keywords]').remove();
    $('head').append('<meta name="keywords" content="' + $(keywords).html() + '" />');
}

// Smoth scrolling
// Tutorial from: http://www.paulund.co.uk/smooth-scroll-to-internal-links-with-jquery
$(document).ready(function () {
    $('a[href^="#"]').on('click', function (e) {
        e.preventDefault();

        var target = this.hash;
        var $target = $(target);

        $('html, body').stop().animate({
            'scrollTop': $target.offset().top - 55 /* target - fixed menu*/
        }, 900, 'swing', function () {
            window.location.hash = target;
        });
    });
});