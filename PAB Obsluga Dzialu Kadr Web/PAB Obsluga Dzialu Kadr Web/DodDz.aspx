<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DodDz.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.DodDz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV">
            <asp:Label ID="Label1" runat="server" Text="Dodawanie nowego działu"></asp:Label>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label2" class="CentrowaneLewe" runat="server" Text="Nazwa Działu: "></asp:Label>
                <asp:TextBox ID="TextBox1" class="CentrowanePrawe" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonDodawanieDz1" class="CentrowaneLewe" runat="server" Text="Wróć" OnClick="ButtonDodawanieDz1_Click" />
                <asp:Button ID="ButtonDodawanieDz2" class="CentrowanePrawe" runat="server" Text="Dodaj" OnClick="ButtonDodawanieDz2_Click" />
            </div>
        </div>
        <div class="custompopup" id="divThankYou" runat="server">
        <p>
            <asp:Label ID="lblmessage" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp_Click1" />
    </div>
    </form>
</body>
</html>
