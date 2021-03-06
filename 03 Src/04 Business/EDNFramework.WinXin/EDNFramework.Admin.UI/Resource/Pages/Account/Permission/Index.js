﻿$(function () {
    PageModel.LoadData();
    PageModel.Init();
});

var PageModel = {
    data: {},
    zNode: {},
    zMenuNode: {},
    Init: function () {
        _self = this;
        $(".btn-add").click(function () {
            _self.AddControl();
        });
        $(".btn-clear").click(function () {
            _self.ClearControl();
        });

        $(".btn-modal-delete").click(function () {
            if ($.confirm("确定要删除吗？")) {
                _self.DeleteData();
            }
        });

        $(".btn-modal-save").click(function () {
            _self.Model_Save();
        });

        $(".btn-modal-reset").click(function () {
            _self.InitForm();
        });
    },
    Model_Save: function () {
        _self = this;
        _self.LoadFormData();
        $.AjaxPostCall('?ajax=savedata', true, _self.data, function (data) {
            $.RemoveBodyLoading();
            $.RemoveButtonLoading();
           

            _self.LoadData();
            _self.ClearControl();
            $.ShowMessage("Success!");
        });

    },
    LoadFormData: function () {
        _self = this;
        _self.data.ID = $("#ID").val();
        _self.data.CategoryID = $("#CategoryID").val();
        _self.data.ParentID = $("#ParentID").val();
        _self.data.PermissionCode = $("#PermissionCode").val();
        _self.data.PermissionName = $("#PermissionName").val();
        _self.data.Sequence = $("#Sequence").val();
        _self.data.RequestUrl = $("#RequestUrl").val();
        _self.data.Description = $("#Description").val();
    },
    DeleteData: function () {
        _self = this;
        var id = $("#ID").val();

        $.AjaxPostCall('?ajax=deletedata', true, { id: id }, function (data) {
            $.RemoveBodyLoading();
            $.RemoveButtonLoading();
            $.ShowMessage("Success!删除成功");

            _self.LoadData();
            _self.ClearControl();
        });


    },
    EditData: function (id, ParentName) {
        _self = this;
        if (id) {
            $.AjaxGet('?ajax=getmodel', true, { id: id }, function (data) {
                $("#CategoryID").val(data.CategoryID);
                $("#ParentID").val(data.ParentID);
                $("#ParentName").val(data.ParentName);
                $("#PermissionCode").val(data.PermissionCode);
                $("#PermissionName").val(data.PermissionName);
                $("#Sequence").val(data.Sequence);
                $("#RequestUrl").val(data.RequestUrl);
                $("#Description").val(data.Description);
                $("#ID").val(data.ID);

                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
            });
            _self.UpdateControl();
        }
        else {
            _self.ClearControl();
            $.Alert("不能编辑Root节点");
        }
    },
    InitForm: function () {
        $("#ID").val("");
        $("#CategoryID").val("");
        $("#ParentID").val("");
        $("#ParentName").val("");
        $("#PermissionCode").val("");
        $("#PermissionName").val("");
        $("#Sequence").val(0);
        $("#RequestUrl").val("");
        $("#Description").val("");

    },
    ClearControl: function () {
        _self = this;
        $(".btn-modal-save").attr('disabled', "disabled");
        $(".btn-modal-save").hide();
        $(".btn-modal-delete").hide();
        $.HideMessage();
        _self.InitForm();
    },
    AddControl: function () {
        _self = this;
        $(".btn-modal-save").removeAttr('disabled');
        $(".btn-modal-save").val("添加");
        $(".btn-modal-save").show();
        $(".btn-modal-delete").hide();
        $.HideMessage();
        _self.InitForm();
    },
    UpdateControl: function () {
        $(".btn-modal-save").removeAttr('disabled');
        $(".btn-modal-save").val("保存");
        $(".btn-modal-save").show();
        $(".btn-modal-delete").show();
        $.HideMessage();
    },
    LoadData: function () {
        _self = this;
        $.AjaxGet('?ajax=gettreedata', true, {}, function (data) {
            _self.zNode = data;
            _self.BindTree();
            _self.BindTextTree();
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
        });

        _self.SetCategory();


    },
    BindTextTree: function () {
        _self = this;
        $.fn.zTree.init($("#treemenu"), _self.TreeSettingMenu, _self.zNode);

        $("#parent_select").click(function () {
            var cityObj = $("#parent_select");
            var cityOffset = $("#parent_select").offset();
            $("#menuContent").css({ left: cityOffset.left + "px", top: cityOffset.top + cityObj.outerHeight() + "px" }).slideDown("fast");

            $("body").bind("mousedown", _self.onBodyDown);
        });


    },
    onBodyDown: function (event) {

        if (!(event.target.id == "parent_select" || event.target.id == "menuContent" || $(event.target).parents("#menuContent").length > 0)) {
            PageModel.hideMenu();
        }
    },
    hideMenu: function () {
        _self = this;
        $("#menuContent").fadeOut("fast");
        $("body").unbind("mousedown", _self.onBodyDown);
    },
    SetCategory: function () {
        _self = this;
        $.AjaxGet('ajax.ashx?ajax=getcategories', false, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                $("#CategoryID").append('<option value="' + item.CategoryID + '">' + item.Description + '</option>');
            }
        });
    },
    BindTree: function () {
        _self = this;

        var t = $("#tree");
        t = $.fn.zTree.init(t, _self.TreeSetting, _self.zNode);

        var zTree = $.fn.zTree.getZTreeObj("tree");
        zTree.selectNode(zTree.getNodeByParam("id", 0));
    },
    TreeSettingMenu: {
        view: {
            dblClickExpand: function (treeId, treeNode) {
                return treeNode.level > 0;
            },
            showLine: true,
            selectedMulti: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: "id",
                pIdKey: "pid",
                rootPId: "-1"
            }
        },
        callback: {
            onClick: function (e, treeId, treeNode) {

                //alert(treeNode.id)
                //alert(treeNode.name);
                var currentId = $("#ID").val();
                if (currentId && currentId == treeNode.id) {
                    $.Alert("不能选择自己作为上级权限");
                }
                else {
                    $("#ParentName").val(treeNode.name);
                    $("#ParentID").val(treeNode.id);
                    PageModel.hideMenu();
                }
            }
        }
    },
    TreeSetting: {
        view: {
            dblClickExpand: function (treeId, treeNode) {
                return treeNode.level > 0;
            },
            showLine: true,
            selectedMulti: false
        },
        data: {
            simpleData: {
                enable: true,
                idKey: "id",
                pIdKey: "pid",
                rootPId: "-1"
            }
        },
        callback: {
            beforeClick: function (treeId, treeNode) {
                var zTree = $.fn.zTree.getZTreeObj("tree");
                //PageModel.SetParentInfo(treeNode.pid, treeNode.name);
                PageModel.EditData(treeNode.id, treeNode.name);
                if (treeNode.isParent) {
                    return true;
                } else {
                    return true;
                }
            }
        }
    },
    SetParentInfo: function (id, name) {
        if (id)
            $("#ParentID").val(id);

        if (name)
            $("#ParentName").val(name);
    }

};