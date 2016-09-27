var reg = {
    rule: {
        email: /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/
        , number: /^-?\d+$/
        , decimal2: /^[0-9]+(.[0-9]{0,2})?$/
    },
    message: {
        require: '必须输入值'
        , email: '电子邮件格式错误。'
        , number: '整数数字格式验证失败'
        , decimal2: '格式错误，小数点后最多保留两位'

    },
    appendError: function (obj, message) {
        $(obj).attr("title", message);
        //$(obj).parent().append("&nbsp;<span class='alert alert-error'>" + message + "</span>");

        $(obj).addClass("error");
    }

};

///<summary>
///实体数据绑定
///bindform:绑定form数据源
///getformdata：获取form数据源
///bindselect:绑定select数据源 ,json 格式属性必须指定 keyName valueName，
///比如：{{\"Key\":\"视频\",\"Value\":\"致青春\"},{\"Key\":\"图片\",\"Value\":\"万马奔腾\"}}
///</summary>
///<param name="element" type="String">要绑定的表单容器 #table，
///form模式目前仅仅支持text，hidden，checkbox，select-one</param>
///<param name="datasource" type="json">绑定到表单容器的Json,Json属性需要和表单元素Name对应</param>
function bind(element, datasource) {
    if (!element) {
        return;
    }
    var inputs = $(element + " :input");
    this.bindform = function () {
        if (!datasource) {
            return;
        }
        if (inputs.length <= 0) {
            return;
        }
        inputs.each(function (i) {
            switch (this.type) {
                case "text":
                case "hidden":
                case "select-one":
                case "textarea":
                    this.value = $.trim(datasource[this.name]);
                    break;
                case "checkbox":
                    var value = $.trim(datasource[this.name]);
                    if (value && (value == "1" || value == 1 || value == true || value == 'true' || value == 'True')) {
                        this.checked = true;
                    }
                    else {
                        this.checked = false;
                    }
                    break;
                case "radio":
                    var value = $.trim(datasource[this.name]);
                    $('input[name="' + this.name + '"][value=' + value + ']').attr('checked', 'checked');
                    break;

                default:
                    break;
            }
        });
    };
    this.getformdata = function () {
        var data = {};
        if (inputs.length <= 0) {
            return;
        }
        inputs.each(function (i) {
            if (!this.name || this.name == "") {
                return;
            }
            switch (this.type) {
                case "text":
                case "hidden":
                case "select-one":
                case "textarea":
                    data[this.name] = $.trim(this.value);
                    break;
                case "checkbox":
                    data[this.name] = this.checked;
                    break;
                case "radio":
                    data[this.name] = $.trim($('input[name="' + this.name + '"]:checked').val());
                    break;

                default:
                    break;
            }
        });
        return data;
    };
    this.bindselect = function (keyName, valueName, selectKey, defaultKey, defaultValue) {
        if (!datasource) {
            return;
        }
        $(element).empty();
        var options = "";
        if (defaultKey && defaultKey != "") {
            options += "<option value=\"" + $.trim(defaultValue) + "\">" + $.trim(defaultKey) + "</option>";
        }

        $.each(datasource, function (key, val) {
            var k = $.trim(val[keyName]);
            var v = $.trim(val[valueName]);
            options += "<option value=\"" + v + "\">" + k + "</option>";
        });

        $(element).append(options);
        if (selectKey) {
            $(element).val(selectKey);
        }
    }
    this.form = function () {
        if (inputs.length <= 0) {
            return;
        }
        inputs.each(function (i) {
            $(this).keyup(function () {
                switch (this.type) {
                    case "text":
                    case "select-one":
                    case "textarea":
                        var inp_value = $.trim(this.value);
                        if ((inp_value != "" || reg.email.test(reg.email)) && $(this).hasClass("error")) {
                            $(this).removeClass("error");
                        }
                        break;
                    case "checkbox":

                        break;
                    case "radio":
                        break;

                    default:
                        break;
                }
            });
        });

    };
    this.valid = function () {
        if (inputs.length <= 0) {
            return true;
        }
        var hasError = false;
        inputs.each(function (i) {
            switch (this.type) {
                case "text":
                case "select-one":
                case "textarea":
                    var inp_value = $.trim(this.value);
                    if ($(this).hasClass("require")) {
                        //$(this).attr("title", this.name + "是必填项");
                        if (inp_value == "") {
                            reg.appendError($(this), reg.message.require);
                            hasError = true;
                        }
                    }
                    if ($(this).hasClass("email")) {
                        if (inp_value != "" && !reg.rule.email.test(inp_value)) {
                            reg.appendError($(this), reg.message.email);
                            hasError = true;
                        }
                    }
                    if ($(this).hasClass("number")) {
                        if (inp_value != "" && !reg.rule.number.test(inp_value)) {
                            reg.appendError($(this), reg.message.number);
                            hasError = true;
                        }
                    }
                    if ($(this).hasClass("decimal2")) {
                        if (inp_value != "" && !reg.rule.decimal2.test(inp_value)) {
                            reg.appendError($(this), reg.message.decimal2);
                            hasError = true;
                        }
                    }
                    break;
                case "checkbox":

                    break;
                case "radio":
                    break;

                default:
                    break;
            }
        });

        return !hasError;
    };

};

