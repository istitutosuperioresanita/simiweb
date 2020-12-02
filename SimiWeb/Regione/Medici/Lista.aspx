<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Lista.aspx.vb" Inherits="Regione_Medici_Lista" %>

<%@ Register src="../_UserControl/Uc_LeftRegione.ascx" tagname="Uc_LeftRegione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Regione -> Medici -> <b>Lista</b>
        </div >  
        <label class="sezione">Lista Medici</label>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
        <legend><label class="Subsezione">Criteri di ricerca</label></legend>
        <p>
            <label class="label">Cognome</label>
            <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
        </p>       
        <p style="margin-left:500px">
            <asp:Button ID="cerca" runat="server" Text="cerca" />
        </p>
        </fieldset>
        <p>
            <asp:Button ID="nuovo" runat="server" Text="Nuovo medico" />
        </p>
        <fieldset>
        <legend><label class="Subsezione">Lista</label></legend>


            <asp:ListView ID="lstMedici" runat="server" DataKeyNames="id">
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>
                               Nessun medico inserito</td>
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
                            <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                        </td>
                        <td>
                            <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                        </td>
                        <td>
                             <asp:ImageButton ID="btnUpdate" runat="server" CommandName="aggiorna" ImageUrl="~/_Styles/All/images/edit.png" />
                             <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
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
                                            email</th>
                                        <th runat="server">
                                            telefono</th>
                                        <th id="Th1" runat="server">
                                            </th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                </LayoutTemplate>    
            </asp:ListView>
        </fieldset>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

