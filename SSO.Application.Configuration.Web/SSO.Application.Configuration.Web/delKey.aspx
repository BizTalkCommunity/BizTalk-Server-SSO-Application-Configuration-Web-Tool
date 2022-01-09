<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delKey.aspx.cs" Inherits="SSO.Application.Configuration.Web.delKey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title></title>

</head>
<body>
    <form id="form1" runat="server">
         <div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            if (document.getElementById('hfposted').value != '1') {
                if (confirm("Do you want to delete the key?")) {
                    document.getElementById('hidField').value = "Yes";
                } else {
                    document.getElementById('hidField').value = "No";
                }
                document.forms[0].submit();
            }
        });
    </script>
    <asp:HiddenField ID="hidField" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="hfposted" Value="0" runat="server" />
</div>
    </form>
</body>
</html>
