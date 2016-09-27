
function pageModel(formId, formData) {
    this.formId = formId;
    this.formData = formData;
    var form = new bind(this.formId, formData);
    this.bind = function () {
        form.form();
        form.bindform();
    };


    this.submit = function () {
        $("#btn_edit").click(function () {
            if (form.valid()) {
                var data = JSON.stringify(form.getformdata());
                $.AjaxPost('?ajax=edit', true, data);
            }
            else
                $.alert("验证失败，请检查必填项。");
        });
    };
};