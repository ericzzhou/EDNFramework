function FlashPic(obj, delay, container,item) {
    this.delay = delay != undefined ? delay : 3000;
    this.timer = null;
    this.index = 0;
    this.el = obj != undefined ? obj : null;
    //this.page = this.el.find('.pageW');
    this.size = this.el.find(item).size();
    this.h = this.el.height();
    this.container = container;//容器
    this.item = item;//变换项
    //this.next = this.el.find('#next');
    //this.prev = this.el.find('#prev');
}
FlashPic.prototype = {
    auto: function () {
        var _this = this;
        this.timer = setInterval(function () {
            _this.index++;
            if (_this.index > _this.size - 1) {
                _this.index = 0;
            }
            _this.updateNum(_this.index);
            _this.change(_this.index);
        }, this.delay);
    },
    pause: function () {
        clearInterval(this.timer);
    },
    change: function (curIndex) {
        //this.page.children().eq(curIndex).addClass('cur').siblings().removeClass();
        //this.el.find(".boxW").css({ marginTop: -this.h * curIndex }).fadeOut(0, function () { $(this).fadeIn(600) });
        this.el.find(this.container).fadeOut(0, function () { $(this).fadeIn(1000) });
        this.el.find(this.item).each(function (index) {
            if (index == curIndex) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });

    },
    updateNum: function (num) { this.index = num },
    //clickEvent: function (objA) {
    //    var _this = this;
    //    objA.each(function (i) {
    //        $(this).click(function () {
    //            _this.change(i);
    //            _this.updateNum(i);
    //        });
    //    });
    //},

    init: function () {
        var _this = this;
        for (var i = 1; i <= this.size; i++) {
            //if (i == 1) {
            //    this.page.append('<a class="cur" href="javascript:void(0)">' + i + '</a>')
            //} else {
            //    this.page.append('<a href="javascript:void(0)">' + i + '</a>');
            //}
        }
        this.auto();
        //this.clickEvent(this.page.children());
        this.el.hover(function () {
            _this.pause();
        }, function () {
            _this.auto();
        });
        //_this.next.click(function () { _this.nextClick(); });
        //_this.prev.click(function () { _this.prevClick(); });
    }
};