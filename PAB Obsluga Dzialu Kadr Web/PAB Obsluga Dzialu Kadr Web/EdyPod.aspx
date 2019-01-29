<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdyPod.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.EdyPod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="CentrujacyDIV2">
            <asp:Label ID="Label7" runat="server" Text="Edytowanie Podań"></asp:Label>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label2" class="CentrowaneLewe" runat="server" Text="Stanowisko: "></asp:Label>
                <asp:TextBox ID="TextBox1" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label1" class="CentrowaneLewe" runat="server" Text="Imię: "></asp:Label>
                <asp:TextBox ID="TextBox2" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label3" class="CentrowaneLewe" runat="server" Text="Nazwisko: "></asp:Label>
                <asp:TextBox ID="TextBox3" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label4" class="CentrowaneLewe" runat="server" Text="Wiek: "></asp:Label>
                <asp:TextBox ID="TextBox4" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label5" class="CentrowaneLewe" runat="server" Text="Rodzaj Wykształcenia: "></asp:Label>
                <asp:TextBox ID="TextBox5" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label6" class="CentrowaneLewe" runat="server" Text="Miejsce_zamieszkania: "></asp:Label>
                <asp:TextBox ID="TextBox6" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label8" class="CentrowaneLewe" runat="server" Text="Długość stażu: "></asp:Label>
                <asp:TextBox ID="TextBox7" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label9" class="CentrowaneLewe" runat="server" Text="Data otrzymania: "></asp:Label>
                <asp:TextBox ID="TextBox8" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label10" class="CentrowaneLewe" runat="server" Text="Stan: "></asp:Label>
                <asp:TextBox ID="TextBox9" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Label ID="Label11" class="CentrowaneLewe" runat="server" Text="Telefon: "></asp:Label>
                <asp:TextBox ID="TextBox10" class="CentrowanePrawe" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="PrzerwaMiedzyLiniami">
                <asp:Button ID="ButtonPodWroc" runat="server" Text="Wróć" OnClick="ButtonPodWroc_Click" />
                <asp:Button ID="ButtonPodOcz" runat="server" Text="Zawieś" OnClick="ButtonPodOcz_Click" />
                <asp:Button ID="ButtonPodAkc" runat="server" Text="Akceptuj" OnClick="ButtonPodAkc_Click" />
                <asp:Button ID="ButtonPodUsu" runat="server" Text="Usuń" OnClick="ButtonPodUsu_Click" />
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
