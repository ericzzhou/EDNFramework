<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNet.Framework.Admin.WebUI.Pages.Account.Login" %>

<!DOCTYPE html>
<html lang="en-us">
<head>
    <meta charset="utf-8">
    <!--<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">-->

    <title>WXPMS 微信公众平台管理系统 - 系统登录</title>
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Use the correct meta names below for your web application
			 Ref: http://davidbcalhoun.com/2010/viewport-metatag 
			 
		<meta name="HandheldFriendly" content="True">
		<meta name="MobileOptimized" content="320">-->

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <!-- Basic Styles -->
    <link rel="stylesheet" type="text/css" media="screen" href="/resource/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" media="screen" href="/resource/css/font-awesome.min.css">

    <!-- SmartAdmin Styles : Please note (smartadmin-production.css) was created using LESS variables -->
    <link rel="stylesheet" type="text/css" media="screen" href="/resource/css/smartadmin-production.css">
    <link rel="stylesheet" type="text/css" media="screen" href="/resource/css/smartadmin-skins.css">

    <!-- SmartAdmin RTL Support is under construction
			<link rel="stylesheet" type="text/css" media="screen" href="/resource/css/smartadmin-rtl.css"> -->

    <!-- Demo purpose only: goes with demo.js, you can delete this css when designing your own WebApp -->
    <link rel="stylesheet" type="text/css" media="screen" href="/resource/css/demo.css">

    <!-- FAVICONS -->
    <link rel="shortcut icon" href="/resource/img/favicon/favicon.ico" type="image/x-icon">
    <link rel="icon" href="/resource/img/favicon/favicon.ico" type="image/x-icon">

    <!-- GOOGLE FONT -->
    <%--<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,300,400,700">--%>
</head>
<body id="login" class="animated fadeInDown">
    <!-- possible classes: minified, no-right-panel, fixed-ribbon, fixed-header, fixed-width-->
    <header id="header">
        <!--<span id="logo"></span>-->

        <div id="logo-group">
            <span id="logo">
                <img src="/resource/img/logo.png" alt="SmartAdmin">
            </span>

            <!-- END AJAX-DROPDOWN -->
        </div>

        <%--<span id="login-header-space">
            <span class="hidden-mobile">需要一个账号?</span>
            <a href="register.html" class="btn btn-danger">注册</a> 

        </span>--%>
    </header>

    <div id="main" role="main">

        <!-- MAIN CONTENT -->
        <div id="content" class="container">

            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-7 col-lg-8 hidden-xs hidden-sm">
                    <h1 class="txt-color-red login-header-big">WXPMS</h1>
                    <div class="hero">

                        <div class="pull-left login-desc-box-l">
                            <h4 class="paragraph-header">简单易用的微信公众管理平台</h4>
                            <%--<div class="login-app-icons">
									<a href="javascript:void(0);" class="btn btn-danger btn-sm">Frontend Template</a>
									<a href="javascript:void(0);" class="btn btn-danger btn-sm">Find out more</a>
								</div>--%>
                        </div>

                        <img src="/resource/img/demo/iphoneview.png" class="pull-right display-image" alt="" style="width: 210px">
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <h5 class="about-heading">关于 WXPMS</h5>
                            <p>
                                关于 WXPMS 的介绍文字。
                            </p>
                        </div>
                        <%--<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
								<h5 class="about-heading">Not just your average template!</h5>
								<p>
									Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi voluptatem accusantium!
								</p>
							</div>--%>
                    </div>

                </div>
                <div class="col-xs-12 col-sm-12 col-md-5 col-lg-4">
                    <div class="well no-padding">
                        <form action="#" id="login-form" method="post" class="smart-form client-form">
                            <header>
                                登 录
                            </header>

                            <fieldset>

                                <section>
                                    <label class="label">账号</label>
                                    <label class="input">
                                        <i class="icon-append fa fa-user"></i>
                                        <input type="text" name="username" id="username">
                                        <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i>请输入登录账号</b></label>
                                </section>

                                <section>
                                    <label class="label">密码</label>
                                    <label class="input">
                                        <i class="icon-append fa fa-lock"></i>
                                        <input type="password" name="password" id="password">
                                        <b class="tooltip tooltip-top-right"><i class="fa fa-lock txt-color-teal"></i>输入登录密码</b>
                                    </label>
                                    <div class="note">
                                        <a href="#">忘记密码?</a>
                                    </div>
                                </section>

                                <section>
                                    <label class="checkbox">
                                        <input type="checkbox" name="keeplogin" id="keeplogin">
                                        <i></i>保持登录</label>
                                </section>
                            </fieldset>
                            <footer>
                                <button type="submit" class="btn btn-primary" id="btnLogin">
                                    登录
                                </button>
                            </footer>
                        </form>

                    </div>

                    <%--<h5 class="text-center"> - Or sign in using -</h5>
															
										<ul class="list-inline text-center">
											<li>
												<a href="javascript:void(0);" class="btn btn-primary btn-circle"><i class="fa fa-facebook"></i></a>
											</li>
											<li>
												<a href="javascript:void(0);" class="btn btn-info btn-circle"><i class="fa fa-twitter"></i></a>
											</li>
											<li>
												<a href="javascript:void(0);" class="btn btn-warning btn-circle"><i class="fa fa-linkedin"></i></a>
											</li>
										</ul>--%>
                </div>
            </div>
        </div>

    </div>

    <!--================================================== -->

    <!-- PACE LOADER - turn this on if you want ajax loading to show (caution: uses lots of memory on iDevices)-->
    <script src="/resource/js/plugin/pace/pace.min.js"></script>

    <!-- Link to Google CDN's jQuery + jQueryUI; fall back to local -->
    <%--    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>--%>
    <script> if (!window.jQuery) { document.write('<script src="/resource/js/libs/jquery-2.0.2.min.js"><\/script>'); } </script>

    <%--    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>--%>
    <script> if (!window.jQuery.ui) { document.write('<script src="/resource/js/libs/jquery-ui-1.10.3.min.js"><\/script>'); } </script>

    <!-- JS TOUCH : include this plugin for mobile drag / drop touch events 		
		<script src="/resource/js/plugin/jquery-touch/jquery.ui.touch-punch.min.js"></script> -->

    <!-- BOOTSTRAP JS -->
    <script src="/resource/js/bootstrap/bootstrap.min.js"></script>

    <!-- CUSTOM NOTIFICATION -->
    <script src="/resource/js/notification/SmartNotification.min.js"></script>

    <!-- JARVIS WIDGETS -->
    <script src="/resource/js/smartwidgets/jarvis.widget.min.js"></script>

    <!-- EASY PIE CHARTS -->
    <script src="/resource/js/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js"></script>

    <!-- SPARKLINES -->
    <script src="/resource/js/plugin/sparkline/jquery.sparkline.min.js"></script>

    <!-- JQUERY VALIDATE -->
    <script src="/resource/js/plugin/jquery-validate/jquery.validate.min.js"></script>

    <!-- JQUERY MASKED INPUT -->
    <script src="/resource/js/plugin/masked-input/jquery.maskedinput.min.js"></script>

    <!-- JQUERY SELECT2 INPUT -->
    <script src="/resource/js/plugin/select2/select2.min.js"></script>

    <!-- JQUERY UI + Bootstrap Slider -->
    <script src="/resource/js/plugin/bootstrap-slider/bootstrap-slider.min.js"></script>

    <!-- browser msie issue fix -->
    <script src="/resource/js/plugin/msie-fix/jquery.mb.browser.min.js"></script>

    <!-- FastClick: For mobile devices -->
    <script src="/resource/js/plugin/fastclick/fastclick.js"></script>

    <script src="/Resource/js/json2.js"></script>
    <script src="/Resource/js/ednframework.lib.js"></script>
    <script src="/Resource/js/ednframework.lib.extend.js"></script>
    <script src="/Resource/js/ednframework.lib.bindhelper.js"></script>

    <!--[if IE 7]>
			
			<h1>Your browser is out of date, please update your browser by going to www.microsoft.com/download</h1>
			
		<![endif]-->

    <!-- MAIN APP JS FILE -->
    <script src="/resource/js/app.js"></script>

    <script type="text/javascript">
        runAllForms();

        $(function () {
            // Validation
            $("#login-form").validate({
                // Rules for form validation
                rules: {
                    email: {
                        required: true
                    },
                    password: {
                        required: true,
                        minlength: 3,
                        maxlength: 20
                    }
                },

                // Messages for form validation
                messages: {
                    email: {
                        required: '请输入账号'
                    },
                    password: {
                        required: '密码必须输入。'
                    }
                },

                // Do not change code below
                errorPlacement: function (error, element) {
                    error.insertAfter(element.parent());
                }
            });


            $("#login-form").submit(function () {
                var helper = new bind("#login-form");
                var data = helper.getformdata();
                //alert(JSON.stringify(data));
                $.ajax({
                    async: true,
                    dataType: "JSON",
                    type: "POST",
                    url: '/ajax/account/login.ashx?ajax=login',
                    data: data,
                    success: function (msg) {
                        if (!msg) {
                            alert("系统错误！");
                            return;
                        }
                        if (msg.code == 'y') {
                            //跳转
                            var ReturnUrl = '<%=ReturnUrl%>';
                            location.href = ReturnUrl;
                        }
                        else if(msg.message != ''){
                            alert(msg.message);
                        }
                        else {
                            alert("未知错误！");
                        }
                    }
                });
                return false;
            });

            //$("#btnLogin").click(function () {

            //});
        });
    </script>

</body>
</html>
