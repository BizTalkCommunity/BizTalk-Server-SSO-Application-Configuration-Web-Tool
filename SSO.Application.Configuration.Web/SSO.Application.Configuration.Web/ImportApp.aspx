<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportApp.aspx.cs" Inherits="SSO.Application.Configuration.Web.ImportApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
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
            background-color: #f1f1f1;
            width: 100%;
            text-align: center;
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
                    background-color: #ddd;
                    color: black;
                }

                /* Style the active/current link*/
                .header a.active {
                    background-color: dodgerblue;
                    color: white;
                }

        /* Float the link section to the right */
        .header-right {
            float: right;
            position: relative;
            margin-top: -60px;
        }

        /* Add media queries for responsiveness - when the screen is 500px wide or less, stack the links on top of each other */
        @media screen and (max-width: 100%) {
            .header a {
                float: none;
                display: block;
                text-align: left;
            }

            .header-right {
                float: none;
            }
        }
        .btn {
            font-size: 14px;
            text-decoration: none;
            margin: 5px;
            color: #fff;
            position: relative;
            display: inline-block;
        }

        .blue {
            background-color: #2E5A65;
        }

            .blue:hover {
                background-color: #3d7489;
            }
    </style>
    <title>Import Application</title>
</head>
<body>
    <form id="form1" runat="server">
         <table border="0" id="Table3" style="text-align: center">
            <tr style="background-color:#3d7489">
                <td>
                    <h1 style="color:white;">IMPORT SSO APPLICATION</h1>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                 </tr>
             <tr>
                <td>
                    <asp:Label ID="pass2" runat="server" Text="Pass"></asp:Label>&#160;<asp:TextBox ID="pass" type="password" runat="server"></asp:TextBox></td>
                  </tr>
             <tr>
                <td>
                    <asp:Button ID="Button1" CssClass="btn blue" runat="server" OnClick="btnimport_Click" Text="Import App" /></td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
