$(function () {
    PageModel.LoadTreeData();
    PageModel.Init();
});

var selectedNodeID = 0;
var PageModel = {
    data: {},
    zNode: {},
    zMenuNode: {},
    Init: function () {
        _self = this;

    },
    NodeSelected: function (id, ParentName) {
        _self = this;
        selectedNodeID = id;
        if (id > 0)
        {
            $("#p_title").html("指标目录 - " + ParentName + "[" + id + "]");
            $("#frame_page").attr("src", "Item/default.aspx?categoryid=" + id);
        }
    },
    LoadTreeData: function () {
        _self = this;
        $.AjaxGet('Category/ajax.aspx?ajax=gettreedata', false, {}, function (data) {
            _self.zNode = data;
            _self.BindTree();
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
        });
    },
    BindTree: function () {
        _self = this;

        var t = $("#tree");
        t = $.fn.zTree.init(t, _self.TreeSetting, _self.zNode);

        var zTree = $.fn.zTree.getZTreeObj("tree");
        zTree.selectNode(zTree.getNodeByParam("id", 0));
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
                PageModel.NodeSelected(treeNode.id, treeNode.name);
                if (treeNode.isParent)
                {
                    return true;
                } else
                {
                    return true;
                }
            }
        }
    },

    AddCategory: function () {

        _self = this;
        $.RemoteDialog("添加指标分类", "Category/add.aspx", {
            height: 360,
            width: 800,
            buttons: {
                '关闭': function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                //alert("关闭了")
                _self.LoadTreeData();
            }
        });
    },
    EditCategory: function () {
        if (this.CheckSelected())
        {
            _self = this;
            $.RemoteDialog("修改指标分类", "Category/edit.aspx?id=" + selectedNodeID, {
                height: 360,
                width: 800,
                buttons: {
                    '关闭': function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    //alert("关闭了")
                    _self.LoadTreeData();
                }
            });
        }
    },
    DeleteCategory: function () {
        _self = this;
        if (this.CheckSelected())
        {
            if ($.Confirm("删除后不可恢复，确定继续吗？"))
            {
                $.AjaxPostCall('Category/ajax.aspx?ajax=delete', false, { id: selectedNodeID }, function (data) {
                    if (data.result && data.result.error)
                    {
                        alert(data.result.error);
                        $.AlertAutoClose(data.result.error);
                    }
                    else
                    {
                        _self.LoadTreeData();
                    }
                });
            }
        }
    },
    CheckSelected: function () {
        if (selectedNodeID > 0)
        {
            return true;
        }
        else
        {
            $.Alert("请选择要操作的指标分类");
            return false;
        }
    }
};