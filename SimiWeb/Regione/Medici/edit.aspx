<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="Regione_Medici_edit" %>

<%@ Register src="../_UserControl/Uc_LeftRegione.ascx" tagname="Uc_LeftRegione" tagprefix="uc1" %>

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
<%--            <p>
                <label class="label">Asl</label>
                <asp:DropDownList ID="asl" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>--%>
            <p>
                <label class="label">nome</label>
                <asp:TextBox ID="nome" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
                <label class="label">cognome</label>
                <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
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
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>


