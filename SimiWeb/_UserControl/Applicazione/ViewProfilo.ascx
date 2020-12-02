<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewProfilo.ascx.vb" Inherits="_UserControl_Applicazione_ViewProfilo" %>
<br />
    <label  class="sezione">Dati Personali</label>                
<hr />
<p>
    <label class="label">Nome</label>
    <asp:label ID="nome" runat="server" CssClass="label" Enabled="false"></asp:label>
</p>
<p>
    <label class="label">Cognome</label>
    <asp:label ID="Cognome" runat="server" CssClass="label" Enabled="false"></asp:label>
</p>
<p>
    <label class="label">Telefono</label>
    <asp:label ID="Telefono" runat="server" CssClass="label"></asp:label>
</p>
<p>
    <label class="label">Mail</label>
    <asp:label ID="Mail" runat="server" CssClass="label"></asp:label>
</p>       
<p>
    <label class="label">Regione</label>
    <asp:label ID="Regione" runat="server" CssClass="label" Enabled="false"></asp:label>
</p>
<p>
    <label class="label">Asl</label>
    <asp:label ID="Asl" runat="server" CssClass="label" Enabled="false"></asp:label>
</p>