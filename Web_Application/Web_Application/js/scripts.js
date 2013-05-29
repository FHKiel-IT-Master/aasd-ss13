include("js/html5.js");
include("js/jquery.animate-colors-min.js");
include("js/jquery.backgroundpos.min.js");
include("js/jquery.easing.js");
include("js/jquery.fancybox-1.3.4.pack.js");
include("js/jquery.mousewheel.js");
include("js/jquery-ui-1.8.11.custom.min.js");
include("js/cScroll.js");
include("js/superfish.js");
include("js/switcher.js");

function include(url) {
    document.write('<script type="text/javascript" src="' + url + '"></script>');
}

var MSIE = false;
var menuOpen = false;
var content;

function setCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    document.cookie = c_name + "=" + c_value;
}

function getCookie(c_name) {
    var c_value = document.cookie;
    var c_start = c_value.indexOf(" " + c_name + "=");
    if (c_start == -1) {
        c_start = c_value.indexOf(c_name + "=");
    }
    if (c_start == -1) {
        c_value = null;
    }
    else {
        c_start = c_value.indexOf("=", c_start) + 1;
        var c_end = c_value.indexOf(";", c_start);
        if (c_end == -1) {
            c_end = c_value.length;
        }
        c_value = unescape(c_value.substring(c_start, c_end));
    }
    return c_value;
}

function showMenu(h, time, ease) {
    $('#menu_block').stop().animate({ 'height': h }, { duration: time, easing: ease, complete: function () { } });
    $('#menu_header').stop().animate({ top: -38 }, { duration: time, easing: ease });
    $('.menu').stop().animate({ 'top': -2 }, { duration: time, easing: ease });
    $('#menu').stop().animate({ 'top': 0 }, { duration: time, easing: ease });
}

function hideMenu(h, time, ease) {
    $('#menu_header').stop().animate({ top: 0 }, { duration: time, easing: ease });
    $('#menu_block').stop().animate({ 'height': 38 }, { duration: time, easing: ease, complete: function () { } });
    $('.menu').stop().animate({ 'top': -h + 36 }, { duration: time, easing: ease });
    $('#menu').stop().animate({ 'top': -30 }, { duration: time, easing: ease });
}

function addAllListeners() {
    /// drop-down menu
    var h = $('.menu').height();
    $('.menu').css({ 'top': (-$('.menu').height() + 36) });
    $('#menu').css({ 'top': -30 });

    $('#menu_header').bind('mouseenter', menuShowHide);
    $('.menu').bind('mouseleave', menuShowHide);

    function menuShowHide(e) {
        menuOpen = !menuOpen;
        if (!menuOpen) {
            hideMenu(h, 400, 'easeInOutExpo');
        } else {
            showMenu(h, 700, 'easeOutExpo');
        }
    }
    /////// listeners
    if (!MSIE) {
        $('.submenu_1 li>span').css({ 'opacity': '0', 'right': 0 });
    }
    $('.submenu_1 li>a').hover(
    function () {
        var li = $(this).parent();
        $('>span', li).stop().css({ 'display': 'inline-block' });
        if (!MSIE) {
            $('>span', li).stop().animate({ 'opacity': '1', 'right': 17 }, 400, 'easeOutExpo');
        }
    },
        function () {
            var li = $(this).parent();
            if ((!li.hasClass('with_ul')) || (!li.hasClass('sfHover'))) {
                if (!MSIE) {
                    $('>span', li).stop().animate({ 'opacity': '0', 'right': 0 }, 600, 'easeInOutExpo');
                } else {
                    $('>span', li).stop().css({ 'display': 'none' });
                }
            }
        }
    );
    $('.list3 a').attr({ 'rel': 'appendix' }).prepend('<span class="sitem_over"><strong></strong></span>')
    .hover(
        function () {
            if (!MSIE) {
                $(this).children('.sitem_over').css({ display: 'block', opacity: '0' }).stop().animate({ 'opacity': 1 });
            } else {
                $(this).children('.sitem_over').stop().show();
            }
            $(this).find('strong').css({ top: '-350px' }).stop().animate({ 'top': 0 }, 350, 'easeInOutExpo');
        },
        function () {
            if (!MSIE) {
                $(this).children('.sitem_over').stop().animate({ 'opacity': 0 }, function () { $(this).children('.sitem_over').css({ display: 'none' }) });
            } else {
                $(this).children('.sitem_over').stop().hide();
            }
            $(this).find('strong').stop().animate({ 'top': '-100px' }, 600, 'easeInOutExpo');
        }
    );
    $('.list1 a').hover(
        function () {
            $(this).parent().addClass('list1_hover');
        },
        function () {
            $(this).parent().removeClass('list1_hover');
        }
    );
    $('.scrollDown, .scrollUp').hover(
        function () {
            if (!MSIE) {
                $(this).stop().animate({ 'backgroundPosition': 'center bottom' }, 400, 'easeOutExpo');
            } else {
                $(this).css({ 'backgroundPosition': 'center bottom' });
            }
        },
        function () {
            if (!MSIE) {
                $(this).stop().animate({ 'backgroundPosition': 'center top' }, 400, 'easeOutQuad');
            } else {
                $(this).css({ 'backgroundPosition': 'center top' });
            }
        }
    );
    $('.soc_icons>li>a').hover(
        function () {
            $(this).children('img').stop().animate({ 'marginTop': -34 }, 400, 'easeOutExpo');
        },
        function () {
            $(this).children('img').stop().animate({ 'marginTop': 0 }, 400, 'easeOutExpo');
        }
    );
}

$(document).ready(function () {
    /*SUPERFISH MENU*/
    $('.menu #menu').superfish({
        delay: 800,
        animation: {
            opacity: 'show'
        },
        speed: 'slow',
        autoArrows: false,
        dropShadows: false
    });
});

function ON_LOAD() {
        MSIE = ($.browser.msie) && ($.browser.version <= 8);
        //$('.spinner').fadeOut();
        setTimeout(function () { $('body').css({ 'overflow': 'visible' }); }, 300);

        $('.scroll').cScroll({
            duration: 500,
            easing: 'easeOutExpo',
            step: '190px',
            useTrack: false
        });
        $('.scrollUp').click(function () {
            $('.scroll').cScroll('up')
            return false
        });
        $('.scrollDown').click(function () {
            $('.scroll').cScroll('down')
            return false
        });


        if (getCookie("loadpage") == null)
        {
            setCookie("loadpage", "true");
            ////////// show site //////////////
            var _delay = 1800;
            var _time = 1000;
            var _h = parseInt($('#content>ul').css('height'));
            $('#content>ul').css({ 'top': (_h / 2 - 63) + 'px', 'height': '0' });
            $('#content>ul').animate({ 'height': _h, 'top': '-63px' }, _time, 'easeInOutExpo');

            $('#bg_holder').css({ 'top': (74) + 'px', 'height': '100%' });
            $('#bg_holder').animate({ 'height': 0, 'top': (74 + _h * .5) + 'px' }, _time, 'easeInOutExpo').animate({ 'height': _h, 'top': '74px' }, _time, 'easeInOutExpo');

            $('header').css('top', -_h / 2).animate({ 'top': _h / 2 }, _time, 'easeInOutExpo').animate({ 'top': 0 }, _time, 'easeInOutExpo');
            $('footer').css('bottom', -_h / 2).animate({ 'bottom': _h / 2 }, _time, 'easeInOutExpo').animate({ 'bottom': 0 }, _time, 'easeInOutExpo');
            $('header h3').css({ 'display': 'none' }).delay(_time * 2).fadeIn(1000);
            $('footer>div').css({ 'display': 'none' }).delay(_time * 2).fadeIn(1000);
            $('#menu_block').css('left', '-2000px').delay(_time * 1.3).animate({ 'left': '0px' }, { duration: 500, easing: 'easeInOutExpo', complete: function () { _delay = 0; } });
            ///////////////////////////////////
        }

        //content switch
        content = $('#content');
        content.tabs({
            show: 0,
            preFu: function (_) {
                _.li.css({ 'display': 'none' });
            },
            actFu: function (_) {
                if (_.curr) {
                    if (_.n == 0) {
                        _.curr
                        .css({ 'left': '-2000px' }).stop(true).show().delay(_delay).animate({ 'left': '0px' }, { duration: 900, easing: 'easeOutExpo' });
                    } else {
                        _.curr
                        .css({ 'top': '-1000px' }).stop(true).show().delay(_delay).animate({ 'top': '0px' }, { duration: 900, easing: 'easeOutExpo' });
                    }
                }
                if (_.prev) {
                    if (_.pren != 0) {
                        _.prev
                        .show().stop(true).animate({ 'top': '1000px' }, {
                            duration: 400, easing: 'easeInOutExpo', complete: function () {
                                if (_.prev) {
                                    _.prev.css({ 'display': 'none' });
                                }
                            }
                        });
                    } else {
                        _.prev
                        .show().stop(true).animate({ 'left': '-2000px' }, {
                            duration: 600, easing: 'easeInOutExpo', complete: function () {
                                if (_.prev) {
                                    _.prev.css({ 'display': 'none' });
                                }
                            }
                        });
                    }
                }
            }
        });
        if (!MSIE) {
            $('#menu>li>span').css({ 'opacity': '0', 'right': 0 });
        }
        var nav = $('.menu');
        nav.navs({
            useHash: true,
            defHash: '#!/page_home',
            hoverIn: function (li) {
                $('>span', li).stop().css({ 'display': 'inline-block' });
                if (!MSIE) {
                    $('>span', li).stop().animate({ 'opacity': '1', 'right': 17 }, 400, 'easeOutExpo');
                }
            },
            hoverOut: function (li) {
                if ((!li.hasClass('with_ul')) || (!li.hasClass('sfHover'))) {
                    if (!MSIE) {
                        $('>span', li).stop().animate({ 'opacity': '0', 'right': 0 }, 600, 'easeInOutExpo');
                    } else {
                        $('>span', li).stop().css({ 'display': 'none' });
                    }
                }
            }
        })
        .navs(function (n) {
            $('#content').tabs(n);
        });
        addAllListeners();
}

function listen(evnt, elem, func) {
    if (elem.addEventListener)  // W3C DOM
        elem.addEventListener(evnt, func, false);
    else if (elem.attachEvent) { // IE DOM
        var r = elem.attachEvent("on" + evnt, func);
        return r;
    }
}
listen("load", window, ON_LOAD);