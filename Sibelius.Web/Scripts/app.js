﻿/// Toogleable elements with fixed menu
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

$(document).ready(
    function(){
        setTimeout(checkAds(), 5000);
    }
);

function checkAds() {
    var ad = document.querySelector("ins.adsbygoogle");
    if (ad && ad.innerHTML.replace('/\s / g', "").length == 0)
    {
        $('#pubadv').show('slow');
        $('.pubdiv').html('<div class="alert alert-info"><h3>¡Tú puedes ayudarnos!</h3><h4>Desactivando tu AdBlock nos apoyas para que podamos liberar más contenidos gratuitos.</h4></div>');
    }
}