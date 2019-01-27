<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin1.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.Admin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 825px; height: 357px;" class="CentrujacyDIV" id="DivPaneluAdmina">
            <div id="AdminTytul1"> 
                <asp:Label ID="LabelTytuluAdmina" runat="server" Text="Panel Administratora" Font-Size="Larger"></asp:Label>
            </div>
            <div>
                <asp:Button ID="ButtonAdmin1Nawigacja1" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Pracownicy" OnClick="ButtonAdmin1Nawigacja1_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja2" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Stanowiska" OnClick="ButtonAdmin1Nawigacja2_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja3" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Podania" OnClick="ButtonAdmin1Nawigacja3_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja4" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Oferty" OnClick="ButtonAdmin1Nawigacja4_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja5" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Działy" OnClick="ButtonAdmin1Nawigacja5_Click" />
            </div>
            <br/>
            
            <div id="DivAdminPracownika" runat="server">
                <asp:Label ID="LabelAdminPrac" runat="server" Text="Pracownicy"></asp:Label>
            </div>
            <div id="DivAdminStanowiska" runat="server">
                <asp:Label ID="LabelAdminStan" runat="server" Text="Stanowiska"></asp:Label>
            </div>
            <div id="DivAdminPodania" runat="server">
                <asp:Label ID="LabelAdminPod" runat="server" Text="Podania"></asp:Label>
            </div>
            <div id="DivAdminOferty" runat="server">
                <asp:Label ID="LabelAdminOf" runat="server" Text="Oferty"></asp:Label>
            </div>
            <div id="DivAdminDzialu" runat="server">
                <asp:Label ID="LabelAdminDz" runat="server" Text="Działy"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
