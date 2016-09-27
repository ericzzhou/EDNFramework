/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

/*部署精简
  
  在部署到Web服务器上时，下列文件夹和文件都可以删除：
    /_samples ：示例文件夹；
    /_source ：未压缩源程序；
    /lang文件夹下除 zh-cn.js、en.js 以外的文件（也可以根据需要保留其他语言文件）；
    根目录下的 changes.html(更新列表)，install.html(安装指向)，license.html(使用许可)；
    /skins 目录下不需要的皮肤，一般用V2(简单，朴素) ，如果只保留V2则必须在config.js中指定皮肤。
*/
CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-CN';
    // 背景颜色
    //config.uiColor = '#AADC6E';
    //config.width = 400;
    //config.height = 400; 
    config.skin = 'moonocolor';
    config.toolbar = 'Full';
    //config.toolbar = 'Basic';
    //工具栏是否可以被收缩
    config.toolbarCanCollapse = false;
    //工具栏的位置
    config.toolbarLocation = 'top';//可选：bottom 
    //工具栏默认是否展开(貌似无效)
    config.toolbarStartupExpanded = true;
    //  “拖拽以改变尺寸”功能开关 plugins/resize/plugin.js
    config.resize_enabled = true;
    //改变大小的最大高度
    config.resize_maxHeight = 600;
    //改变大小的最大宽度
    config.resize_maxWidth = 1200;
    //改变大小的最小高度
    config.resize_minHeight = 250;
    //改变大小的最小宽度
    config.resize_minWidth = 500;
    // 当提交包含有此编辑器的表单时，是否自动更新元素内的数据
    config.autoUpdateElement = true;
    // 设置是使用绝对目录还是相对目录，为空为相对目录
    config.baseHref = ''
    // 编辑器的z-index值
    config.baseFloatZIndex = 10000;
    //编辑器中回车产生的标签
    config.enterMode = CKEDITOR.ENTER_BR; //可选：CKEDITOR.ENTER_P或CKEDITOR.ENTER_DIV 
    //当输入：shift+Enter时插入的标签
    config.shiftEnterMode = CKEDITOR.ENTER_P;  //可选：CKEDITOR.ENTER_BR或CKEDITOR.ENTER_DIV 
    //使用搜索时的高亮色 plugins/find/plugin.js
    config.find_highlight = {
        element: 'span',
        styles: { 'background-color': '#ff0', 'color': '#00f' }
    };
    //默认的字体名 plugins/font/plugin.js
    config.font_defaultLabel = 'Arial';
    //字体默认大小 plugins/font/plugin.js
    config.fontSize_defaultLabel = '12px';
    //是否使用完整的html编辑模式 如使用，其源码将包含：<html><body></body></html>等标签
    config.fullPage = false;
    //在清除图片属性框中的链接属性时 是否同时清除两边的<a>标签 plugins/image/plugin.js
    config.image_removeLinkByEmptyURL = true;
    //当用户键入TAB时，编辑器走过的空格数，(&nbsp;) 当值为0时，焦点将移出编辑框 plugins/tab/plugin.js
    config.tabSpaces = 3;
    //撤销的记录步数 plugins/undo/plugin.js
    config.undoStackSize = 20;
    // 在 CKEditor 中集成 CKFinder，注意 ckfinder 的路径选择要正确。
    //CKFinder.SetupCKEditor(null, '/ckfinder/'); 
    config.chkFull = true;
    config.toolbar_Full = [
          ['Source', '-', /*'Save', 'NewPage', 'Preview',*/ '-', 'Templates']
        , ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript']
        , ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock']
        , ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote']
        , ['Link', 'Unlink', 'Anchor']
        , ['Cut', 'Copy', '-', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt']
        , '/'
        , ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat']
        /*, ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField']*/
        , ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak']
        //, '/'
        , ['Styles', 'Format', 'Font', 'FontSize']
        , ['TextColor', 'BGColor']
        , ['Maximize'/*, 'ShowBlocks'*/]
    ];
    config.toolbar_Basic = [
          ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript']
        , ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock']
        , ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote']
        , ['Styles', 'Format', 'Font', 'FontSize']
        , ['TextColor', 'BGColor']
        , ['Maximize'/*, 'ShowBlocks'*/]
       
    ];

    /*ckeditor 配合 ckfinder 实现图片上传功能 begin*/
    config.filebrowserBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹
    config.filebrowserImageBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹
    config.filebrowserFlashBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html?Type=Flash';  //上传Flash时浏览服务文件夹
    config.filebrowserUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签)
    config.filebrowserImageUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签)
    config.filebrowserFlashUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签)
    /*ckeditor 配合 ckfinder 实现图片上传功能 end*/
};

