<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcLeftMessaggi.ascx.vb" Inherits="_UserControl_Navigazione_UcLeftMessaggi" %>
    <div class="split2">
         <div class="left-column_t">Messaggi</div>
         <div class="left-column">
              <p><asp:LinkButton ID="LnkNuovoMessaggio" runat="server" Text="Nuovo messaggio"></asp:LinkButton></p>
              <p><asp:LinkButton ID="lnkMailRicevute" runat="server" Text="Posta arrivata"></asp:LinkButton></p>
              <p><asp:LinkButton ID="lnkMailInviate" runat="server" Text="Posta inviata"></asp:LinkButton></p>
              <p><asp:LinkButton ID="LinkRubrica" runat="server" Text="Rubrica"></asp:LinkButton></p> 
        </div >

    </div>