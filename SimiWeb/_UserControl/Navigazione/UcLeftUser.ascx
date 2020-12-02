<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcLeftUser.ascx.vb" Inherits="_UserControl_Navigazione_UcLeftUser" %>
    <div class="split2">
         <div class="left-column_t">Menu Precedente</div>
         <div class="left-column">
              <p><asp:LinkButton ID="lnkNotifiche" runat="server" Text="Gestione notifiche"></asp:LinkButton></p>
        </div >
    </div>
    <div class="split2">
         <div class="left-column_t">Messaggi</div>
         <div class="left-column">
              <p><asp:LinkButton ID="LnkNuovoMessaggio" runat="server" Text="Nuovo messaggio" ></asp:LinkButton></p>
              <p><asp:LinkButton ID="lnkMailRicevute" runat="server" Text="Posta arrivata"></asp:LinkButton></p>
              <p><asp:LinkButton ID="lnkMailInviate" runat="server" Text="Posta inviata"></asp:LinkButton></p>
              <p><asp:LinkButton ID="LinkRubrica" runat="server" Text="Rubrica"></asp:LinkButton></p> 
        </div >
    </div>
    <div class="split2">
         <div class="left-column_t">Impostazioni</div>
         <div class="left-column">
              <p><asp:LinkButton ID="lnkProfilo" runat="server" Text="Profilo personale"></asp:LinkButton></p>
              <p><asp:LinkButton ID="lnkPreferiti" runat="server" Text="Preferiti"></asp:LinkButton></p>
        </div >
    </div>
