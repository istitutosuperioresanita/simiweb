<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Rubrica.aspx.vb" Inherits="Messaggi_Rubrica" %>

<%@ Register src="../_UserControl/Navigazione/UcLeftMessaggi.ascx" tagname="UcLeftMessaggi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../_Styles/Iss/Template.css" rel="stylesheet" type="text/css" />
<link href="../_Styles/Field.css" rel="stylesheet" type="text/css" />
<link href="../_Styles/Liste/Viste.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd">
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Messaggi -> <b>Rubrica</b>
        </div >         
         <p>
             <label class="sezione"> Rubrica</label></p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
            <legend>Nominativi</legend>
            <br />
            <asp:Listview id="lstRubrica" runat="server" >
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>
                                </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="cognomeLabel" runat="server" Text='<%# Eval("cognome") %>' />
                        </td>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                        </td>
                        <td>
                            <asp:Label ID="RegioneLabel" runat="server" Text='<%# Eval("Regione") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AslLabel" runat="server" Text='<%# Eval("Asl") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class="yui-grid">
                                    <tr runat="server" style="">
                                        <th runat="server">
                                            nome</th>
                                        <th runat="server">
                                            cognome</th>
                                        <th runat="server">
                                            Email</th>
                                        <th runat="server">
                                            Telefono</th>
                                        <th runat="server">
                                            Regione</th>
                                        <th runat="server">
                                            Asl</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                </LayoutTemplate>
            </asp:Listview>
        </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
  <uc1:UcLeftMessaggi ID="UcLeftMessaggi1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

