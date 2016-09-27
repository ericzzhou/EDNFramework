$(function () {

    jQuery.support.placeholder = false;
    test = document.createElement('input');
    if ('placeholder' in test) jQuery.support.placeholder = true;

    if (!$.support.placeholder) {

        $('.field').find('label').show();

    }
 
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;

        _self.data.UserName = $("#username").val();
        _self.data.AutoLogin = $("#autoLogin").is(':checked');
        _self.data.Password = $("#password").val();

    },
    ApplyEvent: function () {
        _self = this;
        $(".btn_singin").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=singin', true, JSON.stringify(_self.data));

        });
    },
    Init: function () {
        this.ApplyEvent();
    }
};