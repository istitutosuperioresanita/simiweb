<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master"  
AutoEventWireup="false" 
CodeFile="Tabelle.aspx.vb" 
Inherits="Admin_Tabelle_Esami_Tabelle" %>
<%@ Register src="~/Admin/_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Tabelle -> <b>Gestione Esami</b>
        </div >
 
        <p>
            <asp:Label ID="lblListaDescrizione" runat="server" CssClass="sezione"></asp:Label>
        </p>
        <hr />
        <br />
        <p style="padding-left:420px"><asp:Button ID="linkNuovo" runat="server"  Visible="false"  text="Nuovo Elemento"></asp:Button></p>
        <asp:Label ID="lblErrore" runat="server" CssClass="alert"></asp:Label>
        <p>
            <asp:ListView ID="lstTabelle" runat="server" DataKeyNames="Id"  >
                <EmptyDataTemplate>
                    <table id="Table1" runat="server" style="">
                        <tr>
                            <td>
                                Nessun Record Inserito</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>  
                            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                            <asp:Label ID="CodiceLabel" runat="server" Text='<%# Eval("Codice") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescrizioneBreveLabel" runat="server" 
                                Text='<%# Eval("DescrizioneBreve") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DescrizioneLabel" runat="server" 
                                Text='<%# Eval("Descrizione") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CodiceMinistero" runat="server" 
                                Text='<%# Eval("CodiceMinistero") %>' />
                        </td>
                        <td>
                            <asp:Label ID="HelpLabel" runat="server" 
                                Text='<%# Eval("Help") %>' />
                        </td>
                        <td>
                            <asp:ImageButton ID="btnUpdate" runat="server" CommandName="aggiorna" ImageUrl="~/_Styles/All/images/edit.png" />
     <%--                       <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />--%>
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table id="Table2" runat="server"  style="" >
                        <tr id="Tr1" runat="server">
                            <td id="Td1" runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                    <tr id="Tr2" runat="server" style="">
                                        <th id="Th1" runat="server">
                                            Codice</th>
                                        <th id="Th2" runat="server">
                                            Descrizione Breve</th>
                                        <th id="Th3" runat="server">
                                            Descrizione</th>
                                        <th id="Th4" runat="server">
                                            Codice Ministero</th>
                                        <th id="Th5"  runat="server">
                                            Help</th>
                                        <th id="Th6" runat="server">
                                            </th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="Tr3" runat="server">
                            <td id="Td2" runat="server" style="">
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </p>
        	<asp:Panel ID="datielemento" runat="server" CssClass="modalPopup" Width="400px">
        <p>
            <asp:Label ID="lblIntestazione" runat="server" CssClass="sezione"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblCodice" runat="server" AssociatedControlID="codice" CssClass="label">Codice</asp:Label>
            <asp:TextBox ID="Codice" runat="server"  CssClass="textBox" Enabled="true"></asp:TextBox>
            <br />
            <asp:Label ID="lblDescrizioneBreve" runat="server" CssClass="label" AssociatedControlID="DescrizioneBreve">Descrizione Breve</asp:Label>
            <asp:TextBox ID="DescrizioneBreve" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescrizioneBreve" runat="server"
                            Text="*"
                            CssClass="alert"
                            ControlToValidate="DescrizioneBreve"
                             ValidationGroup="Valpop"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblDescrizione" runat="server" CssClass="label" AssociatedControlID="Descrizione">Descrizione</asp:Label>
            <asp:TextBox ID="Descrizione" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescrizione" runat="server"
                            Text="*"
                            CssClass="alert"
                            ControlToValidate="Descrizione"
                            ValidationGroup="Valpop"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCodiceMinistero" runat="server" CssClass="label" AssociatedControlID="CodiceMinistero">Codice ministero</asp:Label>
            <asp:TextBox ID="CodiceMinistero" runat="server" CssClass="textBox" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqCodMinistero" runat="server"
                            Text="*"
                            CssClass="alert"
                            ControlToValidate="CodiceMinistero"
                            ValidationGroup="Valpop"></asp:RequiredFieldValidator>
            <br />      
            <asp:Label ID="lblhelp" runat="server" CssClass="label" AssociatedControlID="help">Help</asp:Label>
            <asp:TextBox ID="help" runat="server" CssClass="textBox" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            Text="*"
                            CssClass="alert"
                            ControlToValidate="CodiceMinistero"
                            ValidationGroup="Valpop"></asp:RequiredFieldValidator>
            <br />                       
        </p>
        <p>
            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" CssClass="button"/>
            <asp:Button ID="BtnSalva" runat="server" Text="Salva" CssClass="button" ValidationGroup="pop"/>
         </p>
         </asp:Panel>
         <asp:Button ID="btnFake"  runat="server"  style="display:none" />
</div>
<asp:ModalPopupExtender ID="Pop" runat="server"
                         PopupControlID="datielemento"
                         TargetControlID="btnFake"
                         BackgroundCssClass="modalBackground"
                         CancelControlID=""
                         DropShadow="true"
                         ></asp:ModalPopupExtender>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

