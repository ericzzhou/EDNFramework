﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Style/pages/dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="main-inner">
        <div class="container">
            <div class="row">
                <div class="span6">
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-star"></i>
                            <h3>Quick Stats</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <div class="stats">
                                <div class="stat">
                                    <span class="stat-value">12,386</span>
                                    Site Visits
                                </div>
                                <!-- /stat -->
                                <div class="stat">
                                    <span class="stat-value">9,249</span>
                                    Unique Visits
                                </div>
                                <!-- /stat -->
                                <div class="stat">
                                    <span class="stat-value">70%</span>
                                    New Visits
                                </div>
                                <!-- /stat -->
                            </div>
                            <!-- /stats -->
                            <div id="chart-stats" class="stats">
                                <div class="stat stat-chart">
                                    <div id="donut-chart" class="chart-holder"></div>
                                    <!-- #donut -->
                                </div>
                                <!-- /substat -->
                                <div class="stat stat-time">
                                    <span class="stat-value">00:28:13</span>
                                    Average Time on Site
                                </div>
                                <!-- /substat -->
                            </div>
                            <!-- /substats -->
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                    <div class="widget widget-nopad">
                        <div class="widget-header">
                            <i class="icon-list-alt"></i>
                            <h3>Recent News</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <ul class="news-items">
                                <li>
                                    <div class="news-item-detail">
                                        <a href="javascript:;" class="news-item-title">Duis aute irure dolor in reprehenderit</a>
                                        <p class="news-item-preview">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore.</p>
                                    </div>
                                    <div class="news-item-date">
                                        <span class="news-item-day">08</span>
                                        <span class="news-item-month">Mar</span>
                                    </div>
                                </li>
                                <li>
                                    <div class="news-item-detail">
                                        <a href="javascript:;" class="news-item-title">Duis aute irure dolor in reprehenderit</a>
                                        <p class="news-item-preview">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore.</p>
                                    </div>

                                    <div class="news-item-date">
                                        <span class="news-item-day">08</span>
                                        <span class="news-item-month">Mar</span>
                                    </div>
                                </li>
                                <li>
                                    <div class="news-item-detail">
                                        <a href="javascript:;" class="news-item-title">Duis aute irure dolor in reprehenderit</a>
                                        <p class="news-item-preview">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore.</p>
                                    </div>

                                    <div class="news-item-date">
                                        <span class="news-item-day">08</span>
                                        <span class="news-item-month">Mar</span>
                                    </div>
                                </li>
                            </ul>

                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-file"></i>
                            <h3>Content</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                            <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                </div>
                <!-- /span6 -->
                <div class="span6">
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-bookmark"></i>
                            <h3>Quick Shortcuts</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <div class="shortcuts">
                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-list-alt"></i>
                                    <span class="shortcut-label">Apps</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-bookmark"></i>
                                    <span class="shortcut-label">Bookmarks</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-signal"></i>
                                    <span class="shortcut-label">Reports</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-comment"></i>
                                    <span class="shortcut-label">Comments</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-user"></i>
                                    <span class="shortcut-label">Users</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-file"></i>
                                    <span class="shortcut-label">Notes</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-picture"></i>
                                    <span class="shortcut-label">Photos</span>
                                </a>

                                <a href="javascript:;" class="shortcut">
                                    <i class="shortcut-icon icon-tag"></i>
                                    <span class="shortcut-label">Tags</span>
                                </a>
                            </div>
                            <!-- /shortcuts -->
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-signal"></i>
                            <h3>Chart</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <div id="area-chart" class="chart-holder"></div>
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-th-list"></i>
                            <h3>Table</h3>
                        </div>
                        <!-- /widget-header -->
                        <div class="widget-content">
                            <table class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Engine</th>
                                        <th>Browser</th>
                                        <th class="td-actions"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 4.0</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 5.0</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 5.5</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 5.5</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 5.5</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Trident</td>
                                        <td>Internet
										 Explorer 5.5</td>
                                        <td class="td-actions">
                                            <a href="javascript:;" class="btn btn-small btn-warning">
                                                <i class="btn-icon-only icon-ok"></i>
                                            </a>

                                            <a href="javascript:;" class="btn btn-small">
                                                <i class="btn-icon-only icon-remove"></i>
                                            </a>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                        <!-- /widget-content -->

                    </div>
                    <!-- /widget -->

                </div>
                <!-- /span6 -->

            </div>
            <!-- /row -->

        </div>
        <!-- /container -->

    </div>
    <!-- /main-inner -->
</asp:Content>
