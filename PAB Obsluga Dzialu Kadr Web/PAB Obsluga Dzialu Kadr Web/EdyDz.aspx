<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdyDz.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.EdyDz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV">
            <asp:Label ID="Label1" runat="server" Text="Edytowanie działu"></asp:Label>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label2" class="CentrowaneLewe" runat="server" Text="Nazwa Działu: "></asp:Label>
                <asp:TextBox ID="TextBox1" class="CentrowanePrawe" runat="server"></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonDodawanieDz1" class="CentrowaneLewe" runat="server" Text="Wróć" OnClick="ButtonDodawanieDz1_Click" />
                <asp:Button ID="ButtonUsuwanieDz1" class="CentrowaneLewe" runat="server" Text="Usun" OnClick="ButtonUsuwanieDz1_Click" />
                <asp:Button ID="ButtonDodawanieDz2" class="CentrowanePrawe" runat="server" Text="Edytuj" OnClick="ButtonDodawanieDz2_Click" />
            </div>
        </div>
        <div class="custompopup" id="divThankYou1" runat="server">
        <p>
            <asp:Label ID="lblmessage1" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp_Click1" />
    </div>
        <div class="custompopup" id="divThankYou2" runat="server">
        <p>
            <asp:Label ID="lblmessage2" runat="server"></asp:Label>
        </p>
        <asp:Button ID="Buttonpopup2" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp_Click1" />
    </div>
    </form>
</body>
</html>
