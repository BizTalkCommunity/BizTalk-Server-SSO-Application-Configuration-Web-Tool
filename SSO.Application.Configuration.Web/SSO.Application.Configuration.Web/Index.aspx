<%@ Page Title="Index" Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SSO.Application.Configuration.Web.Index1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url(https://fonts.googleapis.com/css?family=Open+Sans);

        html,
        body {
            height: 100%;
        }
        /* start da css for da buttons */
        .btn {
            font-size: 14px;
            text-decoration: none;
            margin: 5px;
            color: #fff;
            position: relative;
            display: inline-block;
        }

        /* .btn:active {
                transform: translate(0px, 5px);
                -webkit-transform: translate(0px, 5px);
                box-shadow: 0px 1px 0px 0px;
            }*/

        .blue {
            background-color: #2E5A65;
        }

            .blue:hover {
                background-color: #3d7489;
            }

        .tbldef {
            text-align: center;
        }

        #Table1 {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #Table1 td, #Table1 th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #Table1 tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #Table1 tr:hover {
                background-color: #ddd;
            }

            #Table1 th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #04AA6D;
                color: white;
            }

        #Table2 {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #Table2 td, #Table2 th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #Table2 tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #Table2 tr:hover {
                background-color: #ddd;
            }

            #Table2 th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #04AA6D;
                color: white;
            }

        #Table3 {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #Table3 td, #Table3 th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #Table3 tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #Table3 tr:hover {
                background-color: #ddd;
            }

            #Table3 th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #04AA6D;
                color: white;
            }

        .header {
            overflow: hidden;
            background-color: #2E5A65;
            width: 100%;
        }

            /* Style the header links */
            .header a {
                float: left;
                color: black;
                text-align: center;
                padding: 12px;
                text-decoration: none;
                font-size: 18px;
                line-height: 25px;
                border-radius: 4px;
            }

                /* Style the logo link (notice that we set the same value of line-height and font-size to prevent the header to increase when the font gets bigger */
                .header a.logo {
                    font-size: 25px;
                    font-weight: bold;
                }

                /* Change the background color on mouse-over */
                .header a:hover {
                    background-color: #2E5A65;
                    color: black;
                }

                /* Style the active/current link*/
                .header a.active {
                    background-color: #2E5A65;
                    color: white;
                }

        /* Float the link section to the right */
        .header-right {
            float: right;
            position: relative;
            margin-top: -57px;
            font-size: 12px;
            padding-right: 15px;
            font-family: OCR A Std, monospace;
            font-weight: bold;
        }

        /* Add media queries for responsiveness - when the screen is 500px wide or less, stack the links on top of each other */
        @media screen and (max-width: 500px) {
            .header a {
                float: none;
                display: block;
                text-align: left;
            }

            .header-right {
                float: none;
            }
        }

        .Background {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-style: none;
            border-color: none;
            width: 605px;
            height: 270px;
        }

        .Background2 {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup2 {
            background-color: #FFFFFF;
            border-style: none;
            border-color: none;
            width: 605px;
            height: 345px;
        }
        .Background3 {
            background-color: black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup3 {
            background-color: #FFFFFF;
            border-style: none;
            border-color: none;
            width: 505px;
            height: 315px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
        /* Main Footer */
        footer .main-footer {
            padding: 20px 0;
            background: white;
        }

        footer ul {
            padding-left: 0;
            list-style: none;
        }

        /* Copy Right Footer */
        .footer-copyright {
            background: #2E5A65;
            padding: 5px 0;
            text-align:center;
            font-family: OCR A Std, monospace;
        }

            .footer-copyright .logo {
                display: inherit;
            }

            .footer-copyright nav {
                float: right;
                margin-top: 5px;
            }

                .footer-copyright nav ul {
                    list-style: none;
                    margin: 0;
                    padding: 0;
                }

                    .footer-copyright nav ul li {
                        border-left: 1px solid #505050;
                        display: inline-block;
                        line-height: 12px;
                        margin: 0;
                        padding: 0 8px;
                    }

                        .footer-copyright nav ul li a {
                            color: #969696;
                        }

                        .footer-copyright nav ul li:first-child {
                            border: medium none;
                            padding-left: 0;
                        }

            .footer-copyright p {
                color: white;
                margin: 2px 0 0;
            }
    </style>
    <title>Applications</title>
</head>
<body>
    <header>
        <div class="header" style="width: 100%">
            <a href="index.aspx" class="logo">
                <img style="width: 115px; height: 75px" src="Content/img/SSO.PNG" /></a>
            <h2 style="padding-top: 13px; font-family: OCR A Std, monospace; color: white">SSO Application Configuration</h2>
            <div class="header-right">
                <h2 style="font-family: OCR A Std, monospace; color: white">Application Menu</h2>

            </div>
        </div>
    </header>
    <br />
    <form runat="server" method="POST">
         <table border="1" id="Table3" style="text-align: center">
            <tr>
                <td>
                    <asp:Button ID="AddApp" CssClass="btn blue" runat="server" OnClick="btnadd_Click" Text="Add Application" /></td>
                <td>
                    <asp:Button ID="ImportA" CssClass="btn blue" runat="server" OnClick="btnimport_Click" Text="Import Application" /></td>
                <td>
                    <asp:Button ID="Settings" CssClass="btn blue" runat="server" OnClick="btnChange_Click" Text="Change Settings" /></td>
            </tr>
        </table>
        <br />
        <br />
       
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="AddApp"
            CancelControlID="ClsAddApp" BackgroundCssClass="Background">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: inline-block">
            <iframe style="width: 600px; height: 220px;" id="irm1" src="AddApp.aspx" runat="server"></iframe>
            <asp:Button ID="ClsAddApp" CssClass="btn blue" runat="server" Text="Close" />
        </asp:Panel>
        <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panl2" TargetControlID="Settings"
            CancelControlID="ClsSet" BackgroundCssClass="Background2">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="Panl2" runat="server" CssClass="Popup2" align="center" Style="display: inline-block">
            <iframe style="width: 600px; height: 300px;" id="Iframe1" src="settings.aspx" runat="server"></iframe>
            <asp:Button ID="ClsSet" CssClass="btn blue" runat="server" Text="Close" />
        </asp:Panel>
         <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="Panl3" TargetControlID="ImportA"
            CancelControlID="ClsImport" BackgroundCssClass="Background3">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="Panl3" runat="server" CssClass="Popup3" align="center" Style="display: inline-block">
            <iframe style="width: 500px; height: 270px;" id="Iframe2" src="ImportApp.aspx" runat="server"></iframe>
            <asp:Button ID="ClsImport" CssClass="btn blue" runat="server" Text="Close" />
        </asp:Panel>

        <br />
        <br />
        <asp:Table ID="Table1" BorderColor="Black" BorderWidth="1px" ForeColor="Black" GridLines="Both" BorderStyle="Solid" CssClass="tbldef" runat="server">
        </asp:Table>
    </form>
    <div class="container body-content">
        <footer id="footer" class="footer-1">
            <div class="main-footer widgets-dark typo-light">
                <div class="footer-copyright">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12 text-center">
                                <p>Copyright DevScope © 2021. All rights reserved.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </div>
</body>
</html>
