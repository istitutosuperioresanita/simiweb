<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="AgenteVeicolo.aspx.vb" Inherits="Admin_Config_AgenteVeicolo" %>

<%@ Register src="~/Admin/_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
 <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Configura Veicolo
        </div >
        <p>
        <br />
          <label class="label" style="width:400px"><i>Gli esami configurati saranno disponibili nelle notifiche in base alla seguente successione <b>Agente Eziologico -> Veicolo</b></i></label>  
        </p> 
        <br />
        <p>
        <asp:Label ID="agenteLabel" runat="server" AssociatedControlID="agente" CssClass="label">Agente</asp:Label>
        <asp:DropDownList ID="agente" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p>
        <asp:Label ID="veicoloLabel" runat="server" AssociatedControlID="veicolo" CssClass="label">Veicolo</asp:Label>
        <asp:DropDownList ID="veicolo" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p style="padding-left:450px">
        <asp:Button  ID="btnSalva" runat="server" Text="Salva" />
        </p>
        <hr />
        <label class="sezione">Lista associazioni</label>
        <asp:ListView ID="lstEsami" runat="server" DataKeyNames="id" >
            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
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
                        <asp:Label ID="VeicoloLabel" runat="server" Text='<%# Eval("Veicolo") %>' />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table2" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                <tr id="Tr2" runat="server" style="">
                                    <th id="Th1" runat="server">
                                        id</th>
                                    <th id="Th2" runat="server">
                                        Agente</th>
                                    <th id="Th3" runat="server">
                                        Veicolo</th>
                                    <th id="Th6" runat="server">
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

