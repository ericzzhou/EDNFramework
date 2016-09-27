
$(document).ready(function () {

    $("#form-wizard").formwizard({
        formPluginEnabled: true,
        validationEnabled: true,
        focusFirstInput: true,

        formOptions: {
            success: function (data) {
                $("#status").fadeTo(500, 1, function () {
                    $(this).html("<span>Form was submitted!</span>").fadeTo(5000, 0);
                })
            },
            beforeSubmit: function (data) {
                $("#submitted").html("<span>Form was submitted with ajax. Data sent to the server: " + $.param(data) + "</span>");
            },
            dataType: 'json',
            resetForm: true
        },
        validationOptions: {
            rules: {
                serverName: "required",
                userName: "required",
                password: "required"
            },
            messages: {
                serverName: "请输入服务器名称",
                userName: "请输入数据库登录名",
                password: '请输入数据库登录密码'
            },
            errorClass: "help-inline",
            errorElement: "span",
            highlight: function (element, errorClass, validClass) {
                $(element).parents('.control-group').addClass('error');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).parents('.control-group').removeClass('error');
            }
        }
    });
});
