<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SSO.Application.Configuration.Web.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .header {
            overflow: hidden;
            background-color: #f1f1f1;
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
    </style>
    <title>Main Menu</title>

</head>
<body>
    <header>
        <div class="header">
            <a href="/main.aspx" class="logo">
                <img style="width: 115px; height: 75px" src="/Content/img/SSO.PNG" /></a>
            <h2 style="padding-top: 13px; font-family: OCR A Std, monospace;">SSO WEB APP</h2>
            <div class="header-right" style="padding-top: -90px">
                <a class="active" href="/main.aspx">Home</a>
                <a href="/index.aspx">Application</a>
                <a href="/settings.aspx">Change Settings</a>
            </div>
        </div>
    </header>
</body>
</html>
