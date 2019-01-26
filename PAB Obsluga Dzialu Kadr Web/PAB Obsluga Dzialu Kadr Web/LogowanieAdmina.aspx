<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogowanieAdmina.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.LogowanieAdmina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV">
            <asp:Label ID="Label1" runat="server" Text="Logowanie!"></asp:Label>
            <br />
            <br />
            <div class="LogowanieDIV1">
                <asp:Label ID="LabelLogowanie2" runat="server" Text="E-mail: "></asp:Label>
                <asp:TextBox ID="TextBoxLogowanie1" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="LogowanieDIV1">
                <asp:Label ID="LabelLogowanie3" runat="server" Text="Hasło: "></asp:Label>
                <asp:TextBox ID="TextBoxLogowanie2" runat="server"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="ButtonLogowanieWstecz" runat="server" Text="Wróć" OnClick="ButtonLogowanieWstecz_Click" />
            <asp:Button ID="ButtonLogowanieLogin" runat="server" Text="Zaloguj" OnClick="ButtonLogowanieLogin_Click" />
            <br />
            <br />
        </div>
        <div class="custompopup" id="divThankYou" runat="server">
        <p>
            <asp:Label ID="lblmessage" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp1" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp1_Click1" />
    </div>
        <div class="custompopup" id="divFailAut1" runat="server">
        <p>
            <asp:Label ID="Labelfailaut1" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp2" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp2_Click1" />
    </div>
        <div class="custompopup" id="divFailAut2" runat="server">
        <p>
            <asp:Label ID="Labelfailaut2" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonPopUp3" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonPopUp3_Click1" />
    </div>
    </form>
</body>
</html>
