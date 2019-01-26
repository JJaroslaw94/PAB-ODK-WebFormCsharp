<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PisaniePodaniaGoscia.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.PisaniePodaniaGoscia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id ="DivPodaniaGoscia">
            <asp:Label ID="Label1" runat="server" Text="Wypełnij Podanie!"></asp:Label>
            <br />
            <div class="PodaniaDIV1">
                <asp:Label ID="Label2" class="PodaniaLabelDIV1" runat="server" Text="Stanowisko"></asp:Label>
                <asp:DropDownList ID="DropDownListPodania1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPodania1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxPodania1" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:Label ID="LabelPodania1" runat="server" Text="Działu"></asp:Label>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label3" class="PodaniaLabelDIV1" runat="server" Text="Imię"></asp:Label>
                <asp:TextBox ID="TextBox2"  CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label4" class="PodaniaLabelDIV1" runat="server" Text="Nazwisko"></asp:Label>
                <asp:TextBox ID="TextBox3" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label5" class="PodaniaLabelDIV1" runat="server" Text="Wiek"></asp:Label>
                <asp:TextBox ID="TextBox4" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label6" class="PodaniaLabelDIV1" runat="server" Text="Wykształcenie"></asp:Label>
                <asp:TextBox ID="TextBox5" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label7" class="PodaniaLabelDIV1" runat="server" Text="Miejsce Zamieszkania"></asp:Label>
                <asp:TextBox ID="TextBox6" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label8" class="PodaniaLabelDIV1" runat="server" Text="Dlugość Stażu"></asp:Label>
                <asp:TextBox ID="TextBox7" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <div class="PodaniaDIV1">
                <asp:Label ID="Label9" class="PodaniaLabelDIV1" runat="server" Text="Telefon"></asp:Label>
                <asp:TextBox ID="TextBox8" CssClass="PodaniaTextBoxDIV1" runat="server"></asp:TextBox>
            </div>
            <br />
            <asp:Button ID="Button11" runat="server" Text="Wróć" OnClick="Button11_Click" />
            <asp:Button ID="Button12" runat="server" Text="Wyślij" OnClick="Button12_Click" />
        </div>
        <div class="custompopup" id="divThankYou" runat="server">
        <p>
            <asp:Label ID="lblmessage" runat="server"></asp:Label>
        </p>
        <asp:Button ID="ButtonExit" CssClass="classname leftpadding" runat="server" Text="Ok" OnClick="ButtonExit_Click1" />
    </div>
    </form>
</body>
</html>
