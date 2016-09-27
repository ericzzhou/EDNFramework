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

            _self.Save_Item();
        });
    },
    LoadForm: function () {
        _self = this;
        _self.data.ID = $("#ID").val();
        _self.data.ItemCode = $("#ItemCode").val();
        _self.data.ItremName = $("#ItremName").val();
        _self.data.ItemStatus = $("#ItemStatus").is(':checked');
        _self.data.ItemCategory = $("#ItemCategory").val();
    },
    Save_Item: function () {
        this.LoadForm();
        $.AjaxPost('ajax.aspx?ajax=edit', false, JSON.stringify(_self.data));
    },
    LoadData: function () {
        _self = this;
        $.AjaxGet('../Category/ajax.aspx?ajax=gettreedata', false, {}, function (data) {
            _self.zNode = data;
            _self.BindTextTree();
            $.RemoveButtonLoading();
        });
        this.LoadForm();
        $.AjaxGet('ajax.aspx?ajax=getmodel&id=' + _self.data.ID, false, {}, function (data) {
            $.RemoveButtonLoading();
            $("#ItemCategoryName").val(data.ItemCategoryName);

            $("#ItemStatus").attr('checked', data.ItemStatus == "Y" ? true : false);

            $("#ItemCode").val(data.ItemCode);
            $("#ItremName").val(data.ItremName);
            $("#ItemCategory").val(data.ItemCategory);

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
                    $("#ItemCategoryName").val(treeNode.name);
                    $("#ItemCategory").val(treeNode.id);
                    PageModel.hideMenu();
                }
            }
        }
    },
};