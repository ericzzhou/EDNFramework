<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.WebUI.Pages.Account.Permission.Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PH_Head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PH_TreeMenu" runat="server">
    <%-- <EDNFramework:TreeMenu ID="Treemenu1" runat="server" Menu="41" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PH_SiteMapPath" runat="server">
    <li>系统安全</li>
    <li>权限管理</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PH_Body" runat="server">
    <div class="inbox-nav-bar no-content-padding">

        <h1 class="page-title txt-color-blueDark hidden-tablet"><i class="fa fa-fw fa-inbox"></i>操作 &nbsp;
		    <div class="btn-group">
                <a href="#" data-toggle="dropdown" class="btn btn-default btn-xs dropdown-toggle"><span class="caret single"></span></a>
                <ul class="dropdown-menu">
                    <li>
                        <a href="javascript:void(0);" onclick="PageModel.AddControl()">新增</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);" onclick="PageModel.ClearControl()">清除</a>
                    </li>
                    <li class="divider"></li>
                </ul>
            </div>
        </h1>
        <div class="inbox-checkbox-triggered">

            <div class="btn-group">
                <a href="javascript:void(0);" onclick="PageModel.AddControl();" rel="tooltip" title="" data-placement="bottom" data-original-title="添加" class="btn btn-default"><strong><i class="fa fa-plus fa-lg text-danger"></i></strong></a>
                <a href="javascript:void(0);" rel="tooltip" title="" data-placement="bottom" data-original-title="保存" class="btn btn-default"><strong><i class="fa fa-save fa-lg"></i></strong></a>
                <a href="javascript:void(0);" rel="tooltip" title="" data-placement="bottom" data-original-title="删除" class="btn btn-default btn-modal-delete"><strong><i class="fa fa-trash-o fa-lg"></i></strong></a>
            </div>

        </div>


        <%--<div class="btn-group pull-right inbox-paging">
            <a href="javascript:void(0);" class="btn btn-default btn-sm"><strong><i class="fa fa-chevron-left"></i></strong></a>
            <a href="javascript:void(0);" class="btn btn-default btn-sm"><strong><i class="fa fa-chevron-right"></i></strong></a>
        </div>
        <span class="pull-right"><strong>1-30</strong> of <strong>3,452</strong></span>--%>
    </div>

    <div id="inbox-content" class="inbox-body no-content-padding">
        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
        <div class="inbox-side-bar">


            <h6>权限树 <a href="javascript:void(0);" onclick="PageModel.LoadTreeData();" rel="tooltip" title="" data-placement="right" data-original-title="刷新" class="pull-right txt-color-darken"><i class="fa fa-refresh"></i></a></h6>

            <div>
                <table border="0" height="405px" align="left">
                    <tr>
                        <td align="left" valign="top">
                            <ul id="tree" class="ztree" style="overflow: auto;"></ul>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
        <div class="table-wrap custom-scroll  fast " style="opacity: 1;">



           <%-- <article class="col-sm-12 col-md-12 col-lg-12">--%>

                <div class="jarviswidget" id="wid-id-0" data-widget-colorbutton="false" data-widget-editbutton="false">
                    <header>
                        <span class="widget-icon"><i class="fa fa-eye"></i></span>
                        <h2>权限维护</h2>
                    </header>
                    <div>
                        <div class="jarviswidget-editbox">
                        </div>
                        <div class="widget-body" id="info">
                            <form class="form-horizontal">
                                <fieldset>
                                    <input type="hidden" id="ID" name="ID" />
                                    <input type="hidden" id="ParentID" name="ParentID" />
                                    <input type="hidden" id="ico" name="ico" value="glyphicon glyphicon-adjust" />
                                    <div class="form-group">
                                        <label class="control-label col-md-1" for="CategoryID">权限类别</label>
                                        <div class="col-md-11">
                                            <div class="icon-addon addon-md">
                                                <select class="form-control" id="CategoryID" name="CategoryID">
                                                    <%-- <option>系统功能管理</option>
                                                    <option>主菜单管理</option>
                                                    <option>基础数据</option>--%>
                                                </select>
                                                <label for="CategoryID" class="glyphicon glyphicon-search" rel="tooltip" title="权限类别"></label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="control-label col-md-1" for="parent_select">上级权限</label>
                                        <div class="col-md-11">
                                            <div class="input-group input-group-md">
                                                <%--<span class="input-group-addon"><i class="glyphicon glyphicon-filter"></i></span>--%>
                                                <div class="icon-addon addon-md">
                                                    <input type="text" placeholder="请选择" id="ParentName" name="ParentName" class="form-control" disabled="disabled">
                                                    <label for="parent_select" class="glyphicon glyphicon-search" rel="tooltip" title="上级权限"></label>
                                                </div>
                                                <span class="input-group-btn">
                                                    <button class="btn btn-default" type="button" id="parent_select">选择</button>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">权限码</label>
                                        <div class="col-md-11">
                                            <input id="PermissionCode" name="PermissionCode" class="form-control" placeholder="权限码" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">权限名</label>
                                        <div class="col-md-11">
                                            <input id="PermissionName" name="PermissionName" class="form-control" placeholder="权限名" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-1" for="ico_selecter">图标</label>
                                        <div class="col-md-11">
                                            <div class="input-group input-group-md">
                                                <span class="input-group-addon"><i id="ico_show" class="glyphicon glyphicon-adjust"></i></span>
                                                <div class="icon-addon addon-md">
                                                    <EDNFramework:GlyphIcons runat="Server" ControlID="ico_selecter" TargetID="ico" ShowControlID="ico_show"></EDNFramework:GlyphIcons>
                                                    <label for="CategoryID" class="glyphicon glyphicon-search" rel="tooltip" title="图标"></label>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">权重</label>
                                        <div class="col-md-11">
                                            <input id="Sequence" name="Sequence" class="form-control" placeholder="权重" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">请求地址</label>
                                        <div class="col-md-11">
                                            <input id="RequestUrl" name="RequestUrl" class="form-control" placeholder="请求地址" type="text">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">子菜单</label>
                                        <div class="col-md-11">
                                            <label class="checkbox-inline">
                                                <input type="checkbox" class="checkbox style-0" id="HasSon" name="HasSon">
                                                <span>有</span>
                                            </label>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-md-1 control-label">描述</label>
                                        <div class="col-md-11">
                                            <textarea id="Description" name="Description" class="form-control" placeholder="Textarea" rows="4"></textarea>
                                            <p class="note"><strong>备注:</strong> 描述内容部能超过250字。</p>
                                        </div>
                                    </div>
                                </fieldset>
                                <div id="menuContent" class="menuContent" style="display: none; position: absolute;">
                                    <ul id="treemenu" class="ztree" style="margin-top: 0; width: 160px;"></ul>
                                </div>
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <button class="btn btn-default btn-modal-reset" type="button">
                                                重置
                                            </button>
                                            <button class="btn btn-default btn-modal-delete" type="button" style="display: none;">
                                                删除
                                            </button>
                                            <button class="btn btn-primary btn-modal-save" type="button" style="display: none;">
                                                <i class="fa fa-save"></i>
                                                保存
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            <%--</article>--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PH_Floor" runat="server">
    <script src="/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
    <script>
        var url = {
            ajaxUrl: '/Ajax/Account/Permission.ashx?ajax='
            , PermissionActionsUrl: '/Pages/Account/PermissionActions/index.aspx?PermissionCode='
        }
        $(function () {
            PageModel.Init();
        });
        var PageModel = {
            data: {},
            zNode: {},
            zMenuNode: {},
            Init: function () {
                _self = this;

                _self.LoadTreeData();
                _self.LoadCategory();
                _self.AddEvent();
            },
            LoadTreeData: function () {
                _self = this;

                $.AjaxGet(url.ajaxUrl + 'gettreedata', false, {}, function (data) {
                    _self.zNode = data;
                    _self.BindTree();
                    _self.BindTextTree();
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                });
            },
            LoadCategory: function () {
                _self = this;
                $("#CategoryID").empty();;
                $.AjaxGet(url.ajaxUrl + 'getcategories', false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    for (var i = 0; i < data.length; i++) {
                        var item = data[i];
                        $("#CategoryID").append('<option value="' + item.CategoryID + '">' + item.Description + '</option>');
                    }
                });
            },
            AddEvent: function () {
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
                    var helper = new bind("#info");
                    var v = helper.getformdata();
                    $.AjaxPostCall(url.ajaxUrl + 'savedata', false, v, function (data) {
                        $.RemoveBodyLoading();
                        $.RemoveButtonLoading();


                        _self.LoadTreeData();
                        _self.ClearControl();
                        $.ShowMessage("Success!");
                    });
                });

                $(".btn-modal-reset").click(function () {
                    _self.InitForm();
                });

                $("#btn__PermissionActions").click(function () {
                    var PermissionCode = $.trim($("#PermissionCode").val());
                    var PermissionName = $.trim($("#PermissionName").val());
                    if (PermissionCode === "") {
                        $.Alert("模块不存在.");
                        return;
                    }
                    $.RemoteDialog("[" + PermissionName + "]权限按钮", url.PermissionActionsUrl + PermissionCode, {
                        height: 300,
                        width: 450,
                        close: function () {
                            //pqGridRefresh(_self.GridID);
                        }
                    });
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

                $.AjaxPostCall(url.ajaxUrl + 'deletedata', false, { id: id }, function (data) {
                    $.RemoveBodyLoading();
                    $.RemoveButtonLoading();
                    $.ShowMessage("Success!删除成功");

                    _self.LoadTreeData();
                    _self.ClearControl();
                });


            },
            EditData: function (id, ParentName) {
                _self = this;
                if (id) {
                    $.AjaxGet(url.ajaxUrl + 'getmodel', false, { id: id }, function (data) {
                        //$("#CategoryID").val(data.CategoryID);
                        //$("#ParentID").val(data.ParentID);
                        //$("#ParentName").val(data.ParentName);
                        //$("#PermissionCode").val(data.PermissionCode);
                        //$("#PermissionName").val(data.PermissionName);
                        //$("#Sequence").val(data.Sequence);
                        //$("#RequestUrl").val(data.RequestUrl);
                        //$("#Description").val(data.Description);
                        //$("#ID").val(data.ID);
                        var helper = new bind("#info", data);
                        helper.bindform();
                        $.RemoveButtonLoading();
                        $.RemoveBodyLoading();
                    });
                    _self.UpdateControl();
                }
                else {
                    _self.ClearControl();
                    $.Alert("不能编辑Root节点");
                    return;
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
                $(".btn-modal-save").html("<i class=\"fa fa-save\"></i> 添加");
                $(".btn-modal-save").show();
                $(".btn-modal-delete").hide();
                $.HideMessage();
                _self.InitForm();
            },
            UpdateControl: function () {
                $(".btn-modal-save").removeAttr('disabled');
                $(".btn-modal-save").val("<i class=\"fa fa-save\"></i> 保存");
                $(".btn-modal-save").show();
                $(".btn-modal-delete").show();
                $.HideMessage();
            },

            BindTextTree: function () {

                _self = this;
                $.fn.zTree.init($("#treemenu"), _self.TreeSettingMenu, _self.zNode);

                $("#parent_select").click(function () {

                    var cityObj = $("#parent_select");
                    var cityOffset = $("#parent_select").offset();

                    $("#menuContent").css({ left: cityOffset.left - 650 + "px", top: cityOffset.top - cityObj.outerHeight() - 150 + "px" }).slideDown("fast");

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
                alert(id);
                alert(name);

                if (id)
                    $("#ParentID").val(id);

                if (name)
                    $("#ParentName").val(name);
            }

        };


    </script>





</asp:Content>
