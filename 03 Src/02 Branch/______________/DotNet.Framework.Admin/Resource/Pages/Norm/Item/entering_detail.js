$(function () {
    $("#OccurrenceTime").datepicker({ dateFormat: "yy-mm-dd", showAnim: "drop" });

    PageModel.CreateHtml();
    PageModel.Init();

});
var PageModel = {
    data: {},

    Init: function () {
        _self = this;
        $("#btn_Insert").click(function () {
            var inputs = document.getElementsByName("txt_norm");
            if (inputs.length > 0)
            {
                var OccurrenceTime = $("#OccurrenceTime").val();
                if (!OccurrenceTime || OccurrenceTime == "")
                {
                    alert("请选择指标发生时间");
                    $("#OccurrenceTime").focus();
                    return;
                }
                var jsonList = "[";
                var t_i = 0;
                try
                {
                    $.each(inputs, function (index, obj) {
                        var v = $.trim($(obj).val());
                        if (v && v != "")
                        {
                            if (isNaN(v))
                            {
                                alert("值‘"+v+"’格式错误");
                                return;
                            }
                            var item = {};
                            item.NormID = $(obj).attr("data-norm");
                            item.DepartmentID = $(obj).attr("data-Department");
                            item.Value = v;

                            if (t_i > 0)
                            {
                                jsonList += ",";
                            }
                            jsonList += JSON.stringify(item);

                            t_i++;
                        }
                    });
                }
                catch (e)
                {
                    alert(e);
                    return;
                }
                jsonList += "]";
                if (t_i > 0)
                {
                    //debugger;
                    $.AjaxPost('?ajax=addnormvalue&OccurrenceTime=' + OccurrenceTime, true, jsonList);
                }
                else
                {
                    alert("您没有输入任何内容");
                }
            }
            else
            {
                alert("没有数据，不能提交");
            }
        });
    },
    CreateHtml: function () {
        var cateid = $.trim($("#categoryId").val());
        $.AjaxGet("entering.aspx?ajax=getdata&categoryid=" + cateid, false, {}, function (msg) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            var d = msg;//JSON.stringify(msg);
            var html = "";
            html += "<table>"
            if (d.Norm.length == 0)
            {
                html += "<tr><td>暂无指标信息</td></tr>"
            }
            else
            {
                for (var i = -1; i < d.Department.length; i++)
                {
                    html += "<tr>"
                    var dep = eval(d.Department[i]);
                    for (var j = -1; j < d.Norm.length; j++)
                    {
                        html += "";
                        var item = eval(d.Norm[j]);
                        if (i == -1)
                        {
                            if (j == -1)
                            {
                                html += "<td></td>";
                            }
                            else
                            {

                                html += "<td>" + item.ItremName + "</td>";
                            }
                        }
                        else
                        {
                            if (j == -1)
                            {

                                html += "<td><input type='button' value='" + dep.Name + "'></input></td>";
                            }
                            else
                            {
                                html += "<td><input name=\"txt_norm\" data-norm=\"" + item.ID + "\" data-Department=\"" + dep.ID + "\" type=\"text\" style=\"width:100px;\" /></td>";
                            }
                        }
                        html += "";
                    }
                    html += "</tr>"
                }
            }

            html += "</table>"
            //}
            //else
            //{
            //    html = "没有数据";
            //}
            $("#grid_Item").html(html);


        });
        //$.ajax({
        //    url: "entering.aspx?ajax=getdata&categoryid=" + cateid,
        //    dataType: "JSON",
        //    success: function (msg) {


        //    }
        //});
    }
};