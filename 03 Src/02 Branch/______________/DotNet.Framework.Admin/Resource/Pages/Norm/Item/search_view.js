$(function () {
    $("#txt_startTime").datepicker({ dateFormat: "yy-mm-dd", showAnim: "drop" });
    $("#txt_endTime").datepicker({ dateFormat: "yy-mm-dd", showAnim: "drop" });

    PageModel.Init();

});

var PageModel = {
    data: {},
    zNodes: {},
    GridID: "#grid_Item",
    LoadData: function () {
        this.data.categoryId = $.trim($("#categoryId").val());
        this.data.normOptions = document.getElementById("sel_normItem").options.length;
        this.data.startTime = $("#txt_startTime").val();
        this.data.endTime = $("#txt_endTime").val();
        this.data.dpartmentIDs = $("#hidDepartment").val();
        this.data.normID = $("#sel_normItem").val()
        this.data.normID = $("#sel_normItem").val()
    },
    Init: function () {
        _self = this;
        _self.LoadData();
        //读取科室（部门）
        _self.LoadTreeNodes();


        //读取分类下医疗指标

        if (_self.data.categoryId && _self.data.categoryId != "" && Number(_self.data.categoryId) > 0)
        {

            $.AjaxGet("ajax.ashx?ajax=getnorms", false, { categoryId: _self.data.categoryId }, function (data) {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
                for (var i = 0; i < data.length; i++)
                {
                    var item = eval(data[i]);
                    $("#sel_normItem").append("<option value=\"" + item.ID + "\">" + item.ItremName + "</option>")

                }
            });
        }
        else
        {
            alert("分类下医疗指标读取错误");
        }

        $("#btn_Search").click(function () {
            _self.LoadData();
            var deps = $.trim($("#hidDepartment").val());
            if (!deps || deps == "" || deps == "0")
            {
                $.ShowMessage("请先选择科室", "alert-error");
                return;
            }

            var normalId = $.trim($("#sel_normItem").val());
            if (!normalId || normalId == "" || normalId == "0")
            {
                $.ShowMessage("请先选择指标目录", "alert-error");
                return;
            }
            if (_self.data.normOptions == 1 || !_self.zNodes || _self.zNodes.length <= 0)
            {
                $.ShowMessage("此分类下暂未分配医疗指标", "alert-error");
                return;
            }
            _self.LoadGrid();

        });

        $("#showDepartment").click(function () {
            _self.showMenu();
        });
        $("#menuBtn").click(function () {
            _self.showMenu();
        });

    },
    LoadGrid: function () {
        var startTime = $("#txt_startTime").val();
        var endTime = $("#txt_endTime").val();
        var departmentID = $("#hidDepartment").val();
        var normID = $("#sel_normItem").val()
        _self = this;
        //var startTime = this.data.startTime;
        //var endTime = this.data.endTime;
        //var departmentID = this.data.dpartmentIDs;
        //var normID = this.data.normID;
        if (startTime == "" && endTime == "")
        {
            $.ShowMessage("请设置检索时间范围", "alert-error");
            return;
        }
        if (startTime == "" && endTime != "")
        {
            $.ShowMessage("不能单独设置结束时间", "alert-error");
            return;
        }

        if (startTime && startTime != "")
        {
            startTime += " 00:00:00";
        }
        if (endTime && endTime != "")
        {
            endTime += " 23:59:59";
        }
        if (startTime != "" && endTime != "" && startTime > endTime)
        {
            $.ShowMessage("结束时间不能小于起始时间", "alert-error");
            return;
        }
        var url = "?ajax=formatsearchtablehtml";
        var ajaxData = {
            startTime: (startTime),
            endTime: (endTime),
            categoryId: escape(this.data.categoryId),
            normId: escape(normID),
            departmentId: departmentID,
            normName: $("#sel_normItem").find("option:selected").text()
        };
        $.ajax({
            url: "search_view.aspx?ajax=formatsearchtablehtml",
            data: ajaxData,
            cache: false,
            //dataType: "JSON",
            success: function (msg) {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
                $("#grid_Item > table > tbody").html(msg);
            }
        });
    },
    LoadTreeNodes: function () {
        _self = this;
        $.AjaxGet('../../Account/Department/default.aspx?ajax=getdepartmentfortree', false, {}, function (data) {
            _self.zNodes = data;
            //$("#menuContent").html(JSON.stringify(data));
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            $.fn.zTree.init($("#departmentMenu"), PageModel.TreeSetting, PageModel.zNodes);
        });

    },
    TreeSetting: {
        check: {
            enable: true,
            chkboxType: { "Y": "", "N": "" }
        },
        view: {
            dblClickExpand: false
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        callback: {
            beforeClick: function (treeId, treeNode) {
                var zTree = $.fn.zTree.getZTreeObj("departmentMenu");
                zTree.checkNode(treeNode, !treeNode.checked, null, true);
                return false;
            },
            onCheck: function (e, treeId, treeNode) {
                var zTree = $.fn.zTree.getZTreeObj("departmentMenu"),
                nodes = zTree.getCheckedNodes(true),
                v = "";
                var value = "";
                for (var i = 0, l = nodes.length; i < l; i++)
                {
                    v += nodes[i].name + ",";
                    value += nodes[i].id + ",";
                }
                if (v.length > 0) v = v.substring(0, v.length - 1);
                if (value.length > 0) value = value.substring(0, value.length - 1);
                var departmentObj = $("#showDepartment");
                departmentObj.attr("value", v);
                $("#hidDepartment").val(value);
            }
        }
    },
    onBodyDown: function (event) {
        if (!(event.target.id == "menuBtn" || event.target.id == "showDepartment" || event.target.id == "menuContent" || $(event.target).parents("#menuContent").length > 0))
        {
            PageModel.hideMenu();
        }
    },
    showMenu: function () {
        var departmentObj = $("#showDepartment");
        var departmentOffset = $("#showDepartment").offset();
        $("#menuContent").css({ left: departmentOffset.left + "px", top: departmentOffset.top + departmentObj.outerHeight() + "px" }).slideDown("fast");

        $("body").bind("mousedown", PageModel.onBodyDown);
    },
    hideMenu: function () {
        $("#menuContent").fadeOut("fast");
        $("body").unbind("mousedown", PageModel.onBodyDown);
    }
};