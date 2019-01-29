<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin1.aspx.cs" Inherits="PAB_Obsluga_Dzialu_Kadr_Web.Admin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 899px; height: 800px;" class="CentrujacyDIV" id="DivPaneluAdmina">
            <div id="AdminTytul1"> 
                <asp:Label ID="LabelTytuluAdmina" runat="server" Text="Panel Administratora" Font-Size="Larger"></asp:Label>
            </div>
            <div style="height: 38px">
                <asp:Button ID="ButtonAdmin1Nawigacja1" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Pracownicy" OnClick="ButtonAdmin1Nawigacja1_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja2" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Stanowiska" OnClick="ButtonAdmin1Nawigacja2_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja3" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Podania" OnClick="ButtonAdmin1Nawigacja3_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja4" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Oferty" OnClick="ButtonAdmin1Nawigacja4_Click" />
                <asp:Button ID="ButtonAdmin1Nawigacja5" CssClass="AdminPrzyciskiNawigacji" runat="server" Text="Działy" OnClick="ButtonAdmin1Nawigacja5_Click" />
            </div>
            <br/>
            <div style="height: 38px">
                <asp:Button ID="ButtonAdminBack1" runat="server" Text="Wróć" OnClick="ButtonAdminBack1_Click" />
            </div>
            
            <div id="DivAdminPracownika" runat="server">
                <asp:Label ID="LabelAdminPrac" runat="server" Text="Pracownicy"></asp:Label>
                <br />
                <asp:GridView ID="GridViewPrac" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ID_STANOWISKA" HeaderText="Stanowisko" />
                        <asp:BoundField DataField="ID_DZIALU" HeaderText="Dział" />
                        <asp:BoundField DataField="IMIE_PRACOWNIKA" HeaderText="Imię" />
                        <asp:BoundField DataField="NAZWISKO_PRACOWNIKA" HeaderText="Nazwisko" />
                        <asp:BoundField DataField="E_MAIL_PRACOWNIKA" HeaderText="E-mail" />
                        <asp:BoundField DataField="HASLO_PRACOWNIKA" HeaderText="Hasło" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranyPracownik" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_PRACOWNIKA") %>' OnClick="WybranyPracownik_Click" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                <asp:Button ID="ButtonDodajPracownika" runat="server" Text="Dodaj" OnClick="ButtonDodajPracownika_Click" />
            </div>
            <div id="DivAdminStanowiska" runat="server">
                <asp:Label ID="LabelAdminStan" runat="server" Text="Stanowiska"></asp:Label>
                <br />
                <asp:GridView ID="GridViewStan" runat="server" AutoGenerateColumns="false">
                    <Columns>                        
                        <asp:BoundField DataField="ID_DZIALU" HeaderText="Dział" />
                        <asp:BoundField DataField="NAZWA_STANOWISKA" HeaderText="Stanowisko" />
                        <asp:BoundField DataField="MIEJSCA" HeaderText="Miejsca" />
                        <asp:BoundField DataField="Uprawnienia" HeaderText="Uprawnienia" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybraneStanowisko" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_STANOWISKA") %>' OnClick="WybraneStanowisko_Click"/> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                <asp:Button ID="ButtonDodajStanowisko" runat="server" Text="Dodaj" OnClick="ButtonDodajStanowisko_Click" />
            </div>
            <div id="DivAdminPodania" runat="server">
                <asp:Label ID="LabelAdminPod" runat="server" Text="Podania"></asp:Label>
                <br />
                <asp:GridView ID="GridViewPod" runat="server" AutoGenerateColumns="false">
                    <Columns>                        
                        <asp:BoundField DataField="ID_STANOWISKA" HeaderText="Stanowisko" />
                        <asp:BoundField DataField="IMIE_PRACOWNIKA" HeaderText="Imię" />
                        <asp:BoundField DataField="NAZWISKO_PRACOWNIKA" HeaderText="Nazwisko" />
                        <asp:BoundField DataField="WIEK" HeaderText="Wiek" />
                        <asp:BoundField DataField="RODZAJ_WYKSZTALCENIA" HeaderText="Wykształcenie" />
                        <asp:BoundField DataField="MIEJSCE_ZAMIESZKANIA" HeaderText="Miejsce Zamieszkania" />
                        <asp:BoundField DataField="DLUGOSC_STAZU" HeaderText="Długość Stażu" />
                        <asp:BoundField DataField="DATA_OTRZYMANIA" HeaderText="Data otrzymania" />
                        <asp:BoundField DataField="STAN" HeaderText="Stan" />
                        <asp:BoundField DataField="TELEFON" HeaderText="Telefon" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranePodanie" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_PODANIA") %>' OnClick="WybranePodanie_Click"/> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
            </div>
            <div id="DivAdminOferty" runat="server">
                <asp:Label ID="LabelAdminOf" runat="server" Text="Oferty"></asp:Label>
                <br />
                <asp:GridView ID="GridViewOferty" runat="server" AutoGenerateColumns="false">
                    <Columns>                        
                        <asp:BoundField DataField="ID_STANOWISKA" HeaderText="Stanowisko" />
                        <asp:BoundField DataField="OPIS" HeaderText="Opis" />
                        <asp:BoundField DataField="WYMOGI" HeaderText="Wymagania" />
                        <asp:BoundField DataField="WYNAGRODZENIE" HeaderText="Wynagrodzenie" />
                        <asp:BoundField DataField="DOSTEPNE_MIEJSCA" HeaderText="Miejsca" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranaOferta" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID__OFERTY") %>' OnClick="WybranaOferta_Click"/> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                <asp:Button ID="ButtonDodajOferte" runat="server" Text="Dodaj" OnClick="ButtonDodajOferte_Click" />
            </div>
            <div id="DivAdminDzialu" runat="server">
                <asp:Label ID="LabelAdminDz" runat="server" Text="Działy"></asp:Label>
                <br />
                <asp:GridView ID="GridViewDz" runat="server" AutoGenerateColumns="false">
                    <Columns>                        
                        <asp:BoundField DataField="NAZWA_DZIALU" HeaderText="Nazwa" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranyDzial" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_DZIALU") %>' OnClick="WybranyDzial_Click"/> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                <asp:Button ID="ButtonDodajDzial" runat="server" Text="Dodaj" OnClick="ButtonDodajDzial_Click" />
            </div>
        </div>
    </form>
</body>
</html>
