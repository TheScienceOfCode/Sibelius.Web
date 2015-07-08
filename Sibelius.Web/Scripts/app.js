﻿/// Toogleable elements with fixed menu
var fixed_menu = -1;
var fixed_status = false;
$(function () {
    if ($('#fixed-menu').offset() == undefined) return;
    fixed_menu = $('#fixed-menu').offset().top - 50;
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

$(function () {
    $('a[data-toggle]').click(function () {
        var current = $(this);
        var show = true;
        if (current.hasClass('active')) {
            current.removeClass('active');
            show = false;
        }

        $('a[data-toggle]').removeClass('active');
        $.when($('[data-hide-me="true"]').fadeOut('fast')).then(function () {
            if (!show)
                return;

            var element = current.attr('data-toggle');
            current.addClass('active');
            $(element).fadeIn('fast', function () {
                $('html, body').animate({
                    scrollTop: fixed_menu - 20
                });
            });
        });       
    });
});



