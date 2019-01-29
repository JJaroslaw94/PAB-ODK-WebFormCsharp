<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdyOf.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.EdyOf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV2">
            <asp:Label ID="Label1" runat="server" Text="Edytowanie Oferty"></asp:Label>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label3" class="CentrowaneLewe" runat="server" Text="Stanowisko"></asp:Label>
                <asp:DropDownList ID="DropDownListPodania2" class="CentrowaneLewe" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPodania2_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxPodania1" Enabled="false" CssClass="CentrowanePrawe" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="LabelPodania1" CssClass="CentrowanePrawe" runat="server" Text="Działu"></asp:Label>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label4" class="CentrowaneLewe" runat="server" Text="Nazwa Stanowiska"></asp:Label>
                <asp:TextBox ID="TextBox1" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami2">
                <asp:Label ID="Label5" class="CentrowaneLewe" runat="server" Text="Opis"></asp:Label>
                <asp:TextBox ID="TextBox2" CssClass="CentrowanePraweOpisW" runat="server" Height="66px"  Rows="3" TextMode="MultiLine" Width="290px"></asp:TextBox>           
            </div>
            <div class="PrzerwaMiedzyLiniami2">
                <asp:Label ID="Label6" class="CentrowaneLewe" runat="server" Text="Wymogi"></asp:Label>
                <asp:TextBox ID="TextBox3" CssClass="CentrowanePraweOpisW" runat="server" Height="66px"  Rows="3" TextMode="MultiLine" Width="290px"></asp:TextBox>           
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label7" class="CentrowaneLewe" runat="server" Text="Wynagrodzenie"></asp:Label>
                <asp:TextBox ID="TextBox4" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label8" class="CentrowaneLewe" runat="server" Text="Dostępne miejsca"></asp:Label>
                <asp:TextBox ID="TextBox5" CssClass="CentrowanePrawe" runat="server" ></asp:TextBox>
            </div>
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonDodOfW" runat="server" Text="Wróć" OnClick="ButtonDodOfW_Click" />
                <asp:Button ID="ButtonDodOfU" runat="server" Text="Usun" OnClick="ButtonDodOfU_Click" />
                <asp:Button ID="ButtonDodOfE" runat="server" Text="Edytuj" OnClick="ButtonDodOfE_Click" />
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
