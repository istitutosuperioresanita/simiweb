<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="Admin_Config_Referenti_edit" %>

<%@ Register src="../../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Regione -> Medici -> <b>Gestione</b>
        </div >  
        <asp:Label ID="errore" runat="server" CssClass="alert" Visible="false"></asp:Label>
        <label class="sezione">Medico</label>
        <hr />
        <br />
        <fieldset>
            <legend><label class="Subsezione">Dati generali</label></legend>
            <p>
                <label class="label">Regione</label>
                <asp:DropDownList ID="regione" runat="server" CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqRegione" runat="server" CssClass="alert" Text="*" ControlToValidate="regione"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="label">Asl</label>
                <asp:DropDownList ID="asl" runat="server" CssClass="dropdown"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqAsl" runat="server" CssClass="alert" Text="*" ControlToValidate="asl"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="label">nome</label>
                <asp:TextBox ID="nome" runat="server" CssClass="textBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqNome" runat="server" CssClass="alert" Text="*" ControlToValidate="nome"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="label">cognome</label>
                <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqCognome" runat="server" CssClass="alert" Text="*" ControlToValidate="cognome"></asp:RequiredFieldValidator>
            </p>
            <p>
                <label class="label">email</label>
                <asp:TextBox ID="email" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
                <label class="label">Telefono</label>
                <asp:TextBox ID="telefono" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p style="padding-left:500px">
                <asp:Button ID="salva" runat="server" Text="salva" />
            </p>
            <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori"  ShowSummary="false" />
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
<uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>


