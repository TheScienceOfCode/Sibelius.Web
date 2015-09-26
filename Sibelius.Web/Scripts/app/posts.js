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

var reqs = [];
function loadPosts(e, options) {
    updateSectionMenu();
    if (options.load) jQuery(e).find("img").addClass('visible');
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
            setOnClickDataUrl(loadPosts, options);
            updateMetadata();
            
            if (options.load) jQuery(e).find("img").removeClass('visible');
            try {
                FB.XFBML.parse();
                twttr.widgets.load(); 
            } catch (ex) { }
        }
    });
    reqs.push(r);
}

function setOnclickSectionMenu() {
    $('#posts-menu-sm a').on('click', function () {
        $('#posts-menu-sm').removeClass('in');
        $('#posts-menu-sm').addClass('collapse');
    });

    
}

$(function () {
    updateSectionMenu();
    setOnclickSectionMenu();
    setOnClickDataUrl(loadPosts, { load: true, push: true });
});