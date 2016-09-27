$(function () {
    PageModel.LoadData();
    PageModel.Init();
});

var PageModel = {
    data: {},
    InfoData: {},
    zNode: {},
    zMenuNode: {},
    Init: function () {
        _self = this;
        $("#btn_Insert").click(function () {

            _self.Save_Category();
        });
    },
    LoadForm: function () {
        _self = this;
        _self.data.CategoryName = $("#CategoryName").val();
        _self.data.CategoryCode = $("#CategoryCode").val();
        _self.data.ParentID = $("#ParentID").val();
    },
    Save_Category: function () {
        _self.LoadForm();
        $.AjaxPost('ajax.aspx?ajax=add', false, JSON.stringify(_self.data));
    },
    LoadData: function () {
        _self = this;
        $.AjaxGet('ajax.aspx?ajax=gettreedata', false, {}, function (data) {
            _self.zNode = data;
            _self.BindTextTree();
            $.RemoveButtonLoading();
        });



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

        if (!(event.target.id == "parent_select" || event.target.id == "menuContent" || $(event.target).parents("#menuContent").length > 0))
        {
            PageModel.hideMenu();
        }
    },
    hideMenu: function () {
        _self = this;
        $("#menuContent").fadeOut("fast");
        $("body").unbind("mousedown", _self.onBodyDown);
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
                if (currentId && currentId == treeNode.id)
                {
                    $.Alert("不能选择自己作为上级权限");
                }
                else
                {
                    $("#ParentName").val(treeNode.name);
                    $("#ParentID").val(treeNode.id);
                    PageModel.hideMenu();
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