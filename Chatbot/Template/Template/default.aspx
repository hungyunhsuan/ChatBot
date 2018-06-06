<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Template._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Push Text Message" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Push Sticker Message" />
    
    </div>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Buttons" Width="178px" />
        </p>
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Confirm" Width="173px" />
        <p>
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Column" Width="169px" />
        </p>
    </form>
</body>
</html>
