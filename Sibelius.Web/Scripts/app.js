/// Toogleable elements with fixed menu
var fixed_menu = -1;
var fixed_status = false;
$(function () {
    if ($('#fixed-menu').offset() == undefined) return;
    fixed_menu = $('#fixed-menu').offset().top - 30;
    $(window).scroll(function () {
        if ($(window).scrollTop() > fixed_menu) {
            if (fixed_status) return;
            fixed_status = true;
            $('#fixed-menu').fadeOut('fast', function () {
                $('#fixed-menu-empty').fadeIn('fast');
                $('#fixed-menu').addClass('fixed');
                $('#fixed-menu').addClass('well');
                $('#fixed-menu').addClass('well-sm');
                $('a[data-toggle]').removeClass('btn-primary');
                $('a[data-toggle]').addClass('btn-default');
                $('#fixed-menu').fadeIn('fast');                
            });            
        } else {
            if (!fixed_status) return;
            fixed_status = false;
            $('#fixed-menu').fadeOut('fast', function () {                
                $('#fixed-menu').removeClass('fixed');
                $('#fixed-menu').removeClass('well');
                $('#fixed-menu').removeClass('well-sm');
                $('a[data-toggle]').removeClass('btn-default');
                $('a[data-toggle]').addClass('btn-primary');
                $('#fixed-menu-empty').fadeOut('fast', function () {
                    $('#fixed-menu').fadeIn('fast');
                });                
            });
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
        var current = $(this);
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
function updateSectionMenu() {
    $('.posts-menu a').removeClass('active');

    // Activate Posts->all
    var loc = $(location).attr('pathname').toLowerCase();
    if (loc === '/posts')/*CHECK SIMILAR!!!!*/ {
        $('.posts-menu-all').addClass('active');
        return;
    }
    
    // Activate sections
    var params = ($(location).attr('href').toLowerCase()+'&').split("?")[1].split("&");
    for(var p in params){
        var data = params[p].split('=');
        if (data[0] === 'name') {
            $('.posts-menu-' + data[1]).addClass('active');
            return;
        }
    }
}

function loadPosts(e) {
    alert('asd');
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: $(e).data('url'),
        success: function (response) {
            $('#posts-body').html(response);
        }
    });
}

function setOnclickSectionMenu() {
    $('#posts-menu-lg a').on('click', function () {
        window.history.pushState("", "", $(this).data('url'));
        updateSectionMenu();
        loadPosts($(this));
    });
}

$(function () {
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: $('#posts-sections').data('url'),
        success: function (response) {            
            $('#posts-sections').html(response);            
            updateSectionMenu();            
            setOnclickSectionMenu();
            loadPosts($('#posts-body'));
        }
    });
});