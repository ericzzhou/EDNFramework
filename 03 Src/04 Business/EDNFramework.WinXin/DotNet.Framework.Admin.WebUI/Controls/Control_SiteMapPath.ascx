<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_SiteMapPath.ascx.cs" Inherits="DotNet.Framework.Admin.WebUI.Controls.Control_SiteMapPath" %>
<!-- RIBBON -->
<div id="ribbon">

    <span class="ribbon-button-alignment"><span id="refresh" class="btn btn-ribbon" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true"><i class="fa fa-refresh"></i></span></span>

    <!-- breadcrumb -->
    <ol class="breadcrumb">
        <li>Home</li>
        <li>Dashboard</li>
    </ol>
    <!-- end breadcrumb -->

    <!-- You can also add more buttons to the
				ribbon for further usability

				Example below:

				<span class="ribbon-button-alignment pull-right">
				<span id="search" class="btn btn-ribbon hidden-xs" data-title="search"><i class="fa-grid"></i> Change Grid</span>
				<span id="add" class="btn btn-ribbon hidden-xs" data-title="add"><i class="fa-plus"></i> Add</span>
				<span id="search" class="btn btn-ribbon" data-title="search"><i class="fa-search"></i> <span class="hidden-mobile">Search</span></span>
				</span> -->


    <!--主题 样式 配置 开始  （此处隐藏，只显示橘黄色主题）-->
    <div class="demo">
        <span id="demo-setting"><i class="fa fa-cog txt-color-blueDark"></i></span>
        <form>
            <legend class="no-padding margin-bottom-10">Layout Options</legend>
            <section>
                <label>
                    <input name="subscription" id="smart-fixed-nav" type="checkbox" class="checkbox style-0">
                    <span>Fixed header</span>
                </label>
                <label>
                    <input type="checkbox" name="terms" id="smart-fixed-ribbon" class="checkbox style-0">
                    <span>Fixed Ribbon</span>
                </label>
                <label>
                    <input type="checkbox" name="terms" id="smart-fixed-navigation" class="checkbox style-0">
                    <span>Fixed Navigation</span>
                </label>
                <label>
                    <input type="checkbox" name="terms" id="smart-fixed-container" class="checkbox style-0">
                    <span>Inside <b>.container</b><div class="font-xs text-right">(non-responsive)</div>
                    </span>
                </label>
                <label style="display: none;">
                    <input type="checkbox" name="terms" id="smart-rtl" class="checkbox style-0">
                    <span>Right to left <b>(rtl)</b></span>
                </label>
                <span id="smart-bgimages"></span>
            </section>
            <section>
                <h6 class="margin-top-10 semi-bold margin-bottom-5">Clear Localstorage</h6>
                <a href="javascript:void(0);" class="btn btn-xs btn-block btn-primary" id="reset-smart-widget"><i class="fa fa-refresh"></i>Widget Reset</a>
            </section>
            <h6 class="margin-top-10 semi-bold margin-bottom-5">SmartAdmin Skins</h6>
            <section id="smart-styles">
                <a href="javascript:void(0);" id="smart-style-0" data-skinlogo="img/logo.png" class="btn btn-block btn-xs txt-color-white margin-right-5" style="background-color: #4E463F;">
                    <i class="fa fa-check fa-fw" id="skin-checked"></i>Smart Default</a>
                <a href="javascript:void(0);" id="smart-style-1" data-skinlogo="img/logo-white.png" class="btn btn-block btn-xs txt-color-white" style="background: #3A4558;">Dark Elegance</a>
                <a href="javascript:void(0);" id="smart-style-2" data-skinlogo="img/logo-blue.png" class="btn btn-xs btn-block txt-color-darken margin-top-5" style="background: #fff;">Ultra Light</a>
                <a href="javascript:void(0);" id="smart-style-3" data-skinlogo="img/logo-pale.png" class="btn btn-xs btn-block txt-color-white margin-top-5" style="background: #f78c40">Google Skin
                </a>
            </section>
        </form>
    </div>
    <!--主题 样式 配置 结束-->
</div>
<!-- END RIBBON -->
