/// Toogleable elements with fixed menu
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

var called = false;
$(function () {
    $('a[data-toggle]').click(function () {
        if (!called) {
            called = true;
            $('[data-showable="true"]').addClass('min-h-content');
        }
        var current = $('a[data-toggle='+$(this).data('toggle')+']');
        var show = true;
        if (current.hasClass('active')) {
            current.removeClass('active');
            show = false;
        }

        $('a[data-toggle]').removeClass('active');
        $('html, body').animate({
            scrollTop: fixed_menu - 40
        });
        $.when($('[data-hide-me="true"]').fadeOut('fast')).then(function () {
            if (!show)
                return;

            var element = current.attr('data-toggle');
            current.addClass('active');
            $(element).fadeIn('fast');
        });       
    });
});

$(function () {
    $('#legal-accept').click(function () {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: $('#legal-accept').data('url'),
            success: function (response) {                
                if(response == 'ok') $('#legal-info').fadeOut('fast');
            }
        });
    });

    $('#pubadv-accept').click(function () {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: $('#pubadv-accept').data('url'),
            success: function (response) {
                if (response == 'ok') $('#pubadv').hide('slow');
            }
        });
    });
});

/// POSTS
function getCall(id) {
    var d = $(id).data('url');
    if (d === null)
        return '';
    else
        return d.replace('Posts', 'PostsInternal');
}

function updateSectionMenu() {
    $('.posts-menu a').removeClass('active');

    // Activate Posts->all
    var loc = $(location).attr('pathname').toLowerCase();
    if (loc === '/posts' || loc === '/posts/' || loc == '/posts/index' || loc == '/posts/index/') {
        $('.posts-menu-all').addClass('active');
        return;
    }
    
    // Activate sections
    try {
        var params = ($(location).attr('href').toLowerCase() + '&').split("?")[1].split("&");
        for(var p in params){
            var data = params[p].split('=');
            if (data[0] === 'name') {
                $('.posts-menu-' + data[1]).addClass('active');
                return;
            }
        }
    } catch (e) {
        // Doesn't match with an existing section
        // This looks terrible, but it's better to avoid unexpected errors with Url's.
        return;
    }
}

function updateMetadata() {
    $('meta[name=description]').remove();
    $('head').append('<meta name="description" content="'+ $('#desc').html() +'" />');
    $('meta[name=keywords]').remove();
    $('head').append('<meta name="keywords" content="' + $('#keywords').html() + '" />');
}

function setOnClickDataUrl() {
    $('a[data-url]').on('click', function () {
        window.history.pushState("", "", $(this).data('url'));
        $('html, body').animate({
            scrollTop: 0
        });
        loadPosts($(this), true);
    });
}

var reqs = [];
function loadPosts(e, loading) {
    if (loading) jQuery(e).find("img").addClass('visible');
    for (i = 0; i < reqs.length; i++) {
        reqs[i].abort();        
    }
    reqs.length = 0;    
    
    var r = $.ajax({
        type: 'POST',
        contentType: 'text/html; charset=utf-8',
        url: getCall(e),
        success: function (response) {
            $('#posts-body').html(response);
            setOnClickPosts();
            updateMetadata();
            if (loading) jQuery(e).find("img").removeClass('visible');
            try {
                FB.XFBML.parse();
                twttr.widgets.load(); 
            } catch (ex) { }
        }
    });
    reqs.push(r);
}

window.onpopstate = function (event) {
    // Trigger url load
    document.location = document.location;
};



function menuAction(obj) {
    window.history.pushState("", "", obj.data('url'));
    updateSectionMenu();
    $('html, body').animate({
        scrollTop: fixed_menu - 40
    });
    loadPosts(obj, true);
}

function setOnclickSectionMenu() {
    $('#posts-menu-lg a').on('click', function () {
        menuAction($(this));
    });
    $('#posts-menu-sm a').on('click', function () {
        menuAction($(this));
        $('#posts-menu-sm').removeClass('in');
        $('#posts-menu-sm').addClass('collapse');
    });

    
}

$(function () {
    updateSectionMenu();
    setOnclickSectionMenu();
    setOnClickPosts();
});


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
});