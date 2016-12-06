!function ($) {
    "use strict"; var toggle = '[data-toggle="dropdown"]', Dropdown = function (element) {
        var $el = $(element).on('click.dropdown.data-api', this.toggle)
        $('html').on('click.dropdown.data-api', function () { $el.parent().removeClass('open') })
    }
    Dropdown.prototype = {
        constructor: Dropdown, toggle: function (e) {
            var $this = $(this), $parent, selector, isActive
            if ($this.is('.disabled, :disabled')) return
            selector = $this.attr('data-target')
            if (!selector) {
                selector = $this.attr('href')
                selector = selector && selector.replace(/.*(?=#[^\s]*$)/, '')
            } $parent = $(selector)
            $parent.length || ($parent = $this.parent())
            isActive = $parent.hasClass('open')
            clearMenus()
            if (!isActive) $parent.toggleClass('open')
            return false
        }
    }
    function clearMenus() { $(toggle).parent().removeClass('open') } $.fn.dropdown = function (option) {
        return this.each(function () {
            var $this = $(this), data = $this.data('dropdown')
            if (!data) $this.data('dropdown', (data = new Dropdown(this)))
            if (typeof option === 'string') data[option].call($this)
        })
    }
    $.fn.dropdown.Constructor = Dropdown
    $(function () {
        $('html').on('click.dropdown.data-api', clearMenus)
        $('body').on('click.dropdown', '.dropdown form', function (e) { e.stopPropagation() }).on('click.dropdown.data-api', toggle, Dropdown.prototype.toggle)
    })
}(window.jQuery);

$('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
    event.preventDefault();
    event.stopPropagation();
    $(this).parent().addClass('open');
    var menu = $(this).parent().find("ul");
    var menupos = menu.offset();
    var newpos;
    if ((menupos.left + menu.width()) + 30 > $(window).width()) {
        newpos = -menu.width();
    } else {
        newpos = $(this).parent().width();
    }
    menu.css({ left: newpos });
});