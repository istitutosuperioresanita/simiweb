<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
CodeFile="EditEsami.aspx.vb" 
Inherits="Notifica_EditEsami"
 EnableViewState = "true"
EnableEventValidation="false"
ClientIDMode="Static" %>

<%@ Register src="../_UserControl/Applicazione/ViewEsami.ascx" tagname="ViewEsami" tagprefix="uc1" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Js/esami.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->

           Simiweb -> Notifica -> <b>Esami</b>
        </div >    
         <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
                    <br />
             <uc2:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />

             <uc1:ViewEsami ID="ViewEsami1" runat="server" />
<br />
<br />
<hr />
<p>
    <label class="label">Metodo</label>
    <asp:DropDownList ID="metodo" runat="server" CssClass="dropdown"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="ReqMetodo" runat="server" ControlToValidate="metodo" InitialValue="" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
</p>
<p>
    <label class="label">Materiale</label>
    <asp:DropDownList ID="materiale" runat="server" CssClass="dropdown"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="reqMateriale" runat="server" ControlToValidate="materiale" InitialValue="" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
</p>
<p>
    <label class="label">Data</label>
    <asp:TextBox ID="data"  runat="server" CssClass="textBox"></asp:TextBox>
</p>
<p>
    <label class="label">Luogo</label>
    <asp:TextBox ID="luogo"  runat="server" CssClass="textBox"></asp:TextBox>
</p>
<p>
    <label class="label">Risultato</label>
    <asp:TextBox ID="risultato"  runat="server" CssClass="textBox"></asp:TextBox>
</p>
<p>
    <label class="label">Effetuato da</label>
    <asp:TextBox ID="effetuato"  runat="server" CssClass="textBox"></asp:TextBox>
</p>
<p>
    <label class="label">Note</label>
    <asp:TextBox ID="note"  runat="server" CssClass="textBox"></asp:TextBox>
</p>
<p  style="padding-left:600px">
    <asp:Button ID="annulla" runat="server" Text="Annulla"  Visible="true" CausesValidation="false"/> 
    <asp:Button ID="btnSalva" runat="server" Text="Salva"  Visible="true"/>                
</p> 

    </div >
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
 <div class="dow-center">
    </div>
</asp:Content>

