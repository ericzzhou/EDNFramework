<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Layout.Default" %>

<!DOCTYPE html>
<html lang="zh-cn">
<head>
    <title>TCMM</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <!-- Bootstrap -->
    <link rel="stylesheet" href="Resource/Style/bootstrap.min.css">
    <link rel="stylesheet" href="Resource/Style/bootstrap.extends.css">
    <link rel="stylesheet" href="Resource/Style/bootstrap-theme.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="http://cdn.bootcss.com/html5shiv/3.7.0/html5shiv.min.js"></script>
        <script src="http://cdn.bootcss.com/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <div class="container">
        <div class="navbar-header">
            <a class="navbar-brand" href="/">TCMM 工时管理系统</a>
        </div>
        <nav role="navigation" class="collapse navbar-collapse bs-navbar-collapse">
            <ul class="nav navbar-nav">

                <li>
                    <img src="Resource/Images/photo.png" alt="头像">
                </li>


            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li class="active">
                    <a>欢迎您，超级管理员</a>
                </li>
                <li>
                    <div class="btn-group">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            消息 <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </div>
                </li>
                <li>
                    <div class="btn-group">
                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                            设置 <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="#">Action</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </div>
                </li>
                <li>
                    <a href="#">退出</a>
                </li>
            </ul>
        </nav>
        
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="Resource/Scripts/jquery-1.7.2.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="Resource/Scripts/bootstrap.min.js"></script>
        <script src="Resource/Scripts/bootstrap.extends.js"></script>
</body>
</html>

