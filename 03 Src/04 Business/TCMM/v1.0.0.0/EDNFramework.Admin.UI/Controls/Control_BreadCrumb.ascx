<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_BreadCrumb.ascx.cs" Inherits="DotNet.Framework.Admin.UI.Controls.Control_BreadCrumb" %>
<style>
    .BreadCrumb
    {
        height: 30px;
        line-height: 30px;
        border-top-color: #d5d5d5;
        border-left-color: #d5d5d5;
        border-right-color: #d5d5d5;
        border-bottom-color: #d5d5d5;
        border-top-width: 1px;
        border-left-width: 1px;
        border-right-width: 1px;
        border-bottom-width: 1px;
        border-right-style: solid;
        border-bottom-style: solid;
        border-left-style: solid;
        border-top-style: solid;
        filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#FAFAFA', endColorstr='#E9E9E9', GradientType=0) background: -moz-linear-gradient(center top, #FAFAFA 0%, #E9E9E9 100%) repeat scroll 0 0 rgba(0, 0, 0, 0);
        border: 1px solid #D5D5D5;
        border-top-left-radius: 4px;
        border-top-right-radius: 4px;
        position: relative;
        background-image: none;
        background-attachment: scroll;
        background-repeat: repeat;
        background-position-x: 0%;
        background-position-y: 0%;
        background-color: rgb(233, 233, 233);
        background: -moz-linear-gradient(center top, #FAFAFA 0%, #E9E9E9 100%) repeat scroll 0 0 rgba(0, 0, 0, 0);
        margin-bottom: 1px;
        padding-left: 10px;
        font-weight: bold;
        font-family: 'Adobe Heiti Std';
    }
</style>
<div class="BreadCrumb"><%=BreadCrumbContent %></div>