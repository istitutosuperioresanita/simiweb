<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Esami.aspx.vb" Inherits="Admin_Config_Esami" %>
<%@ Register src="~/Admin/_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Configura Esami
        </div >
        <p>
        <br />
          <label class="label" style="width:400px"><i>Gli esami configurati saranno disponibili nelle notifiche in base alla seguente successione <b>Agente Eziologico -> Materiale -> Metodo</b></i></label>  
        </p> 
        <br />
        <p>
        <asp:Label ID="agenteLabel" runat="server" AssociatedControlID="agente" CssClass="label">Agente</asp:Label>
        <asp:DropDownList ID="agente" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p>
        <asp:Label ID="materialeLabel" runat="server" AssociatedControlID="materiale" CssClass="label">Materiale</asp:Label>
        <asp:DropDownList ID="materiale" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p>
        <asp:Label ID="MetodoLabel" runat="server" AssociatedControlID="metodo" CssClass="label">Metodo</asp:Label>
        <asp:DropDownList ID="metodo" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p style="padding-left:450px">
        <asp:Button  ID="btnSalva" runat="server" Text="Salva" />
        </p>
        <hr />
        <label class="sezione">Lista associazioni</label>
        <asp:ListView ID="lstEsami" runat="server" DataKeyNames="id"  >
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            Nessuna combinazione inserita</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AgenteLabel" runat="server" Text='<%# Eval("Agente") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MaterialeLabel" runat="server" Text='<%# Eval("Materiale") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MetodoLabel" runat="server" Text='<%# Eval("Metodo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MalattiaLabel" runat="server" Text='<%# Eval("Malattia") %>' />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="aggiorna" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                <tr runat="server" style="">
                                    <th runat="server">
                                        id</th>
                                    <th runat="server">
                                        Agente</th>
                                    <th runat="server">
                                        Materiale</th>
                                    <th runat="server">
                                        Metodo</th>
                                    <th runat="server">
                                        Malattia</th>
                                    <th runat="server">
                                                </th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>                
        </asp:ListView>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

