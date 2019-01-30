<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DodPr.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.DodPr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV2">
            <asp:Label ID="Label2" runat="server" Text="Dodawanie Pracownika"></asp:Label>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label1" class="CentrowaneLewe" runat="server" Text="Dział"></asp:Label>
                <asp:DropDownList ID="DropDownListPodania2" class="CentrowanePrawe" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPodania2_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label4" class="CentrowaneLewe" runat="server" Text="Stanowisko"></asp:Label>
                <asp:DropDownList ID="DropDownList1" class="CentrowanePrawe" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPodania3_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label3" class="CentrowaneLewe" runat="server" Text="Imię pracownika: "></asp:Label>
                <asp:TextBox ID="TextBox1" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label5" class="CentrowaneLewe" runat="server" Text="Nazwisko pracownika: "></asp:Label>
                <asp:TextBox ID="TextBox2" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label6" class="CentrowaneLewe" runat="server" Text="E-mail: "></asp:Label>
                <asp:TextBox ID="TextBox3" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label7" class="CentrowaneLewe" runat="server" Text="Hasło: "></asp:Label>
                <asp:TextBox ID="TextBox4" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonDodPrW" runat="server" Text="Wróć" OnClick="ButtonDodPrW_Click" />
                <asp:Button ID="ButtonDodPrD" runat="server" Text="Dodaj" OnClick="ButtonDodPrD_Click" />
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
