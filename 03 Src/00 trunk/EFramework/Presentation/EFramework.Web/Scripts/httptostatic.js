﻿    $(function() {
     var isStatic = $("#ctl00_ContentPlaceHolder1_txtIsStatic").val();
    if (isStatic == "false") {
        $("#tabTask").hide();
        $("#txtRemain").hide();
         $("#ctl00_ContentPlaceHolder1_btnIndex").hide();
    } else {
                $.datepicker.setDefaults($.datepicker.regional['zh-CN']);
                $("[id$='from']").datepicker({
                    dateFormat: "yy-mm-dd",
                    yearRange: ("1949:"+new Date().getFullYear())
                });

                $("[id$='to']").datepicker({
                    dateFormat: "yy-mm-dd",
                    yearRange: ("1949:"+new Date().getFullYear())
                });

                var taskCount = $("#ctl00_ContentPlaceHolder1_txtTaskCount").val();
                if (taskCount > 0) {
                    $("#txtRemain").show();
                }
                //开始新的任务
                $("#btnToStatic").click(function() {
                    DisableBtn();
                    taskCount = $("#ctl00_ContentPlaceHolder1_txtTaskCount").val();
                    if (taskCount > 0) {
                        if (confirm("上次有未完成的任务,是否覆盖未完成的任务?")) {
                            RunTask();
                        }
                        else {
                            EnableBtn();
                        }
                    }
                    else {
                        RunTask();
                    }
                });
                //继续未完成的任务
                $("#btnContinue").click(function() {
                    DisableBtn();
                    ContinueTask(taskCount);
                })
                //清除未完成的任务
                $("#btnRemove").click(function() {
                  
                    RemoveTask();
                })
                 }
            });

            function doProgressbar(count, i) {
                $("#probar").show();
                $.ajax({
                    url: ("/HttpToStatic.aspx?timestamp={0}").format(new Date().getTime()),
                    type: 'POST',
                    dataType: 'json',
                    timeout: 10000,
                    data: {
                        action: "GenerateHtml",
                        TaskId: i
                    },
                    success: function(result) {
                        if (i <= count) {
                            $("#progressbar").progressbar({
                                value: i
                            });
                            $("#txtCount").text(i);
                            i++;
                            doProgressbar(count, i);
                        }
                        else {
                            alert("已全部生成成功");
                            EnableBtn();
                            RemoveTask();
                        }
                    }
                });
            }
            //执行新任务
            function RunTask() {
                $.ajax({
                    url: ("/HttpToStatic.aspx?timestamp={0}").format(new Date().getTime()),
                    type: 'POST',
                    dataType: 'json',
                    timeout: 10000,
                    data: {
                        action: "HttpToStatic",
                        Callback: "true",
                        Cid: $("#ctl00_ContentPlaceHolder1_dropParentID").val(),
                        From: $("#from").val(),
                        To: $("#to").val()
                    },
                    success: function(result) {
                        if (result.STATUS == "SUCCESS" && result.DATA > 0) {
                            $("#progressbar").progressbar({
                                max: result.DATA,
                                value: 0
                            });
                            $("#txtTotalCount").text(result.DATA);
                            $("#txtCount").text(0);
                            $("#probar").show();
                            doProgressbar(result.DATA, 1);
                        }
                    }
                });
            }

            //继续任务 断点续传功能
            function ContinueTask(taskCount) {
                $.ajax({
                    url: ("/HttpToStatic.aspx?timestamp={0}").format(new Date().getTime()),
                    type: 'POST',
                    dataType: 'json',
                    timeout: 10000,
                    data: {
                        action: "ContinueTask"
                    },
                    success: function(result) {
                        if (result.STATUS == "SUCCESS" && result.DATA > 0) {
                            $("#progressbar").progressbar({
                                max: taskCount,
                                value: result.DATA
                            });
                            $("#txtTotalCount").text(taskCount);
                            $("#txtCount").text(result.DATA);
                            $("#probar").show();
                            doProgressbar(taskCount, result.DATA);
                        }
                    }
                });
            }
            //清除任务
            function RemoveTask() {
                $.ajax({
                    url: ("/HttpToStatic.aspx?timestamp={0}").format(new Date().getTime()),
                    type: 'POST',
                    dataType: 'json',
                    timeout: 10000,
                    data: {
                        action: "DeleteTask"
                    },
                    success: function() {
                        $("#probar").hide();
                        $("#txtRemain").hide();
                        $("#ctl00_ContentPlaceHolder1_txtTaskCount").val(0);
                         EnableBtn();
                    }
                });
            }
            function DisableBtn() {
                $("#btnToStatic").attr("disabled", "disabled");
                $("#btnContinue").attr("disabled", "disabled");
                $("#btnRemove").attr("disabled", "disabled");
            }
            function EnableBtn() {
                $("#btnToStatic").removeAttr("disabled");
                $("#btnContinue").removeAttr("disabled");
                $("#btnRemove").removeAttr("disabled");
            }