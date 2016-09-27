/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

/*���𾫼�
  
  �ڲ���Web��������ʱ�������ļ��к��ļ�������ɾ����
    /_samples ��ʾ���ļ��У�
    /_source ��δѹ��Դ����
    /lang�ļ����³� zh-cn.js��en.js ������ļ���Ҳ���Ը�����Ҫ�������������ļ�����
    ��Ŀ¼�µ� changes.html(�����б�)��install.html(��װָ��)��license.html(ʹ�����)��
    /skins Ŀ¼�²���Ҫ��Ƥ����һ����V2(�򵥣�����) �����ֻ����V2�������config.js��ָ��Ƥ����
*/
CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-CN';
    // ������ɫ
    //config.uiColor = '#AADC6E';
    //config.width = 400;
    //config.height = 400; 
    config.skin = 'moonocolor';
    config.toolbar = 'Full';
    //config.toolbar = 'Basic';
    //�������Ƿ���Ա�����
    config.toolbarCanCollapse = false;
    //��������λ��
    config.toolbarLocation = 'top';//��ѡ��bottom 
    //������Ĭ���Ƿ�չ��(ò����Ч)
    config.toolbarStartupExpanded = true;
    //  ����ק�Ըı�ߴ硱���ܿ��� plugins/resize/plugin.js
    config.resize_enabled = true;
    //�ı��С�����߶�
    config.resize_maxHeight = 600;
    //�ı��С�������
    config.resize_maxWidth = 1200;
    //�ı��С����С�߶�
    config.resize_minHeight = 250;
    //�ı��С����С���
    config.resize_minWidth = 500;
    // ���ύ�����д˱༭���ı�ʱ���Ƿ��Զ�����Ԫ���ڵ�����
    config.autoUpdateElement = true;
    // ������ʹ�þ���Ŀ¼�������Ŀ¼��Ϊ��Ϊ���Ŀ¼
    config.baseHref = ''
    // �༭����z-indexֵ
    config.baseFloatZIndex = 10000;
    //�༭���лس������ı�ǩ
    config.enterMode = CKEDITOR.ENTER_BR; //��ѡ��CKEDITOR.ENTER_P��CKEDITOR.ENTER_DIV 
    //�����룺shift+Enterʱ����ı�ǩ
    config.shiftEnterMode = CKEDITOR.ENTER_P;  //��ѡ��CKEDITOR.ENTER_BR��CKEDITOR.ENTER_DIV 
    //ʹ������ʱ�ĸ���ɫ plugins/find/plugin.js
    config.find_highlight = {
        element: 'span',
        styles: { 'background-color': '#ff0', 'color': '#00f' }
    };
    //Ĭ�ϵ������� plugins/font/plugin.js
    config.font_defaultLabel = 'Arial';
    //����Ĭ�ϴ�С plugins/font/plugin.js
    config.fontSize_defaultLabel = '12px';
    //�Ƿ�ʹ��������html�༭ģʽ ��ʹ�ã���Դ�뽫������<html><body></body></html>�ȱ�ǩ
    config.fullPage = false;
    //�����ͼƬ���Կ��е���������ʱ �Ƿ�ͬʱ������ߵ�<a>��ǩ plugins/image/plugin.js
    config.image_removeLinkByEmptyURL = true;
    //���û�����TABʱ���༭���߹��Ŀո�����(&nbsp;) ��ֵΪ0ʱ�����㽫�Ƴ��༭�� plugins/tab/plugin.js
    config.tabSpaces = 3;
    //�����ļ�¼���� plugins/undo/plugin.js
    config.undoStackSize = 20;
    // �� CKEditor �м��� CKFinder��ע�� ckfinder ��·��ѡ��Ҫ��ȷ��
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

    /*ckeditor ��� ckfinder ʵ��ͼƬ�ϴ����� begin*/
    config.filebrowserBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html'; //�ϴ��ļ�ʱ��������ļ���
    config.filebrowserImageBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html?Type=Images'; //�ϴ�ͼƬʱ��������ļ���
    config.filebrowserFlashBrowseUrl = '/Resource/Libs/ckfinder/ckfinder.html?Type=Flash';  //�ϴ�Flashʱ��������ļ���
    config.filebrowserUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //�ϴ��ļ���ť(��ǩ)
    config.filebrowserImageUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //�ϴ�ͼƬ��ť(��ǩ)
    config.filebrowserFlashUploadUrl = '/Resource/Libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //�ϴ�Flash��ť(��ǩ)
    /*ckeditor ��� ckfinder ʵ��ͼƬ�ϴ����� end*/
};

