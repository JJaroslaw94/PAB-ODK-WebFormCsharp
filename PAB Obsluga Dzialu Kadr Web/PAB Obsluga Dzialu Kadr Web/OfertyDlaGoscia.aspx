<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfertyDlaGoscia.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.OfertyDlaGoscia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .CentrujacyDIV {
            width: 522px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV">
            <asp:Label ID="Label1" runat="server" Text="Oferty!"></asp:Label>
            <br />
            <div class="OfertyDIV1">
                <asp:Label ID="Label2" CssClass="OfertyLabelDIV1" runat="server" Text="Stanowisko"></asp:Label>
                <asp:TextBox ID="TextBox1" class="OfertyTextBoxDIV1" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="OfertyDIV1">
                <asp:Label ID="Label3" CssClass="OfertyLabelDIV1" runat="server" Text="Opis"></asp:Label>
                <asp:TextBox ID="TextBox2" class="OfertyTextBoxDIV1" runat="server" Height="66px" ReadOnly="True" Rows="3" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </div>
            <div class="OfertyDIV1">
                <asp:Label ID="Label4" CssClass="OfertyLabelDIV1" runat="server" Text="Wymagania"></asp:Label>
                <asp:TextBox ID="TextBox3" class="OfertyTextBoxDIV1" runat="server" Height="66px" ReadOnly="True" Rows="3" TextMode="MultiLine" Width="290px"></asp:TextBox>
            </div>
            <div class="OfertyDIV1">
                <asp:Label ID="Label5" CssClass="OfertyLabelDIV1" runat="server" Text="Wynagrodzenie"></asp:Label>
                <asp:TextBox ID="TextBox4" class="OfertyTextBoxDIV1" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="OfertyDIV1">
                <asp:Label ID="Label6" CssClass="OfertyLabelDIV1" runat="server" Text="Ilość miejsc"></asp:Label>
                <asp:TextBox ID="TextBox5" class="OfertyTextBoxDIV1" runat="server" ReadOnly="True"></asp:TextBox>
            </div>

            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Wróć" />
            <asp:Button ID="Button1" runat="server" Text="Poprzednie" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Następne" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Napisz Podanie" OnClick="Button3_Click" />

        </div>
    </form>
</body>
</html>
