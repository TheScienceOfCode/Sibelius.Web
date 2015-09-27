/// POSTS
function postsCall(id) {
    var d = $(id).data('url');
    if (d === null)
        return '';
    else
        return d.replace('Posts', 'PostsInternal');
}

function updateSectionMenu() {
    $('.posts-menu a').removeClass('active');
    $('#posts-menu-sm').removeClass('in');
    $('#posts-menu-sm').addClass('collapse');

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

$(function () {
    updateSectionMenu();
    setOnClickDataUrl({
        div: '#posts-body',
        load: true,
        push: true,
        precall: updateSectionMenu,
        getCall: postsCall
    });
});