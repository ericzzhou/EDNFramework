$(function () {
    ExamScript.Init();

});


var ExamScript = {
    Init: function () {
        $("#btn_dialog").click(function () {
            $.RemoteDialog("首页", "index.aspx", {
                height: 600,
                width: 1200,
                buttons: {
                    '关闭': function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    //alert("关闭了")
                }
            });
        });
       
    },
};