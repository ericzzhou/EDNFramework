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
            $("#p_title").html("指标查询 - " + ParentName + "[" + id + "]");

            $("#frame_page").attr("src", "search_view.aspx?categoryid=" + id);

        }
    },
    LoadTreeData: function () {
        _self = this;
        $.AjaxGet('../Category/ajax.aspx?ajax=gettreedata', false, {}, function (data) {
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
    }
};