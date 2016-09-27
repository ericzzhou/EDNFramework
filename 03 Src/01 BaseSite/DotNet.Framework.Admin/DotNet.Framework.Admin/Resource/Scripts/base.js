
var MasterScript = {
    CurrentNav: $("#hid_CurrentNav").val(),
    Init: function () {
        this.SelectMenu();
        this.TableCheckBoxEvent();
    },
    SelectMenu: function () {
        $("#" + this.CurrentNav).addClass("active");
    },
    TableCheckBoxEvent: function () {
        $("span.icon input:checkbox, th input:checkbox").click(function () {
            var checkedStatus = this.checked;
            var checkbox = $(this).parents('.dataTable').find('tr td:first-child input:checkbox');
            checkbox.each(function () {
                this.checked = checkedStatus;
                

                //if (checkedStatus == this.checked) {
                //    $(this).closest('.checker > span').removeClass('checked');
                //}
                //if (this.checked) {
                //    $(this).closest('.checker > span').addClass('checked');
                //}
            });
        });
    }
};





$(function () {
    MasterScript.Init();
});
