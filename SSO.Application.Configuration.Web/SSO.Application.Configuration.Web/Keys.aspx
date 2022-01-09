<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Keys.aspx.cs" Inherits="SSO.Application.Configuration.Web.Keys" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Open+Sans);

        /* start da css for da buttons */
        .btn {
            font-size: 14px;
            text-decoration: none;
            margin: 5px;
            color: #fff;
            position: relative;
            display: inline-block;
        }

            .btn:active {
                transform: translate(0px, 5px);
                -webkit-transform: translate(0px, 5px);
                box-shadow: 0px 1px 0px 0px;
            }

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

            #Table2 td, #Table1 th {
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
    <title><% Response.Write(Request.QueryString["application"].ToString()); %> - Keys</title>
</head>
<body>
     <header>
        <div class="header" style="width: 100%">
            <a href="index.aspx" class="logo">
                <img style="width: 115px; height: 75px" src="Content/img/SSO.PNG" /></a>
            <h2 style="padding-top: 13px; font-family: OCR A Std, monospace; color: white">SSO Application Configuration</h2>
            <div class="header-right">
                <h2 style="font-family: OCR A Std, monospace; color: white">Keys Menu</h2>

            </div>
        </div>
    </header>
    <br />
        <br />
    <form id="form1" runat="server">
        <table border="1" id="Table2" style="text-align: center">
            <tr>
                <td>
                    <asp:Label ID="keyname" runat="server" Text="Key Name"></asp:Label>&#160;
                    <asp:TextBox ID="keynametxt" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Label ID="keyvalue" runat="server" Text="Key Value"></asp:Label>&#160;
                    <asp:TextBox ID="keyvaluetxt" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Button1" runat="server" class="btn blue" OnClick="btnaddkey_Click" Text="Add Key" /></td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <asp:Table ID="Table1" BorderColor="Black" BorderWidth="1px" ForeColor="Black" GridLines="Both" BorderStyle="Solid" CssClass="tbldef" runat="server"></asp:Table>
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
