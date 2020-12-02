<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Lista.aspx.vb" Inherits="Admin_User_Lista" %>
<%@ Register src="../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Admin -> Utenti -> <b>Lista Utenti</b>
        </div >
                <p>
                    <label class="sezione"><b>Utenti del sistema </b> </label>
                </p>
                <hr />
                <br />
                <fieldset style="margin-right:20px">
                    <legend><label class="Subsezione">Criteri di ricerca</label></legend>
                <p>
                    <label class="label">Regione</label>
                    <asp:DropDownList ID="regione" runat="server" CssClass="dropdown"></asp:DropDownList>
                </p>
                <p>
                    <label class="label">Nome</label>
                    <asp:TextBox ID="nome" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <label class="label">Cognome</label>
                    <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <label class="label">email</label>
                    <asp:TextBox ID="email" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <label class="label">Ruolo</label>
                    <asp:DropDownList ID="ruolo" runat="server"  CssClass="dropdown"></asp:DropDownList>
                </p>
                <p style="padding-left:500px">
                <asp:Button ID="cerca" runat="server" Text="Cerca" />
                </p>
                </fieldset>
                <hr />
                <asp:ListView ID="lstUtenti" runat="server" DataKeyNames="username" >
                    <EmptyDataTemplate>
                        <table runat="server" style="">
                            <tr>
                                <td>
                                    Nessun utente</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="usernamelabel" runat="server" Text='<%# Eval("username") %>' Visible="false" />
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                                <br />
                                <asp:Label ID="CognomeLabel" runat="server" Text='<%# Eval("Cognome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                            </td>
                            <td style="width:100px">
                                <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                            </td>
                            <td>
                                <asp:Label ID="regioneLabel" runat="server" Text='<%# Eval("regione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="aslLabel" runat="server" Text='<%# Eval("asl") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ruoloLabel" runat="server" Text='<%# Eval("rolename") %>' />
                            </td>
                            <td>
                                <asp:ImageButton ID="imgUpdate" runat="server" CommandName="aggiorna" CausesValidation="false" ImageUrl="~/_Styles/All/images/edit.png"   />
                                <asp:ImageButton ID="imgDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png"   />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                        <tr runat="server" style="">
                                            <th runat="server">
                                                Utente</th>
                                            <th runat="server">
                                                Email</th>
                                            <th runat="server">
                                                Telefono</th>
                                            <th runat="server">
                                                regione</th>
                                            <th runat="server">
                                                asl</th>
                                            <th  runat="server">
                                                ruolo</th>                                                
                                            <th runat="server">
                                            </th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                    </LayoutTemplate>
        </asp:ListView>
        <p style="text-align:center">
        <asp:DataPager ID="pager" runat="server" PagedControlID="lstUtenti" PageSize="25">
            <Fields>
                <asp:NextPreviousPagerField 
                        ButtonType="image" 
                        ShowFirstPageButton="True" 
                        ShowNextPageButton="False" 
                        ShowPreviousPageButton="True" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />

                <asp:NumericPagerField />
                <asp:NextPreviousPagerField                        
                        ButtonType="image" 
                        ShowLastPageButton="True" 
                        ShowNextPageButton="True" 
                        ShowPreviousPageButton="False" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />
            </Fields>
        </asp:DataPager>
        </p>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

