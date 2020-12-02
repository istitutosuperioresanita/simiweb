<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Uc_LeftRegione.ascx.vb" Inherits="Regione__UserControl_Uc_LeftRegione" %>
    <div class="split2">
         <div class="left-column_t">GESTIONE MEDICI</div>
         <div class="left-column">
              <p><asp:HyperLink ID="lnkNuovoUtente" runat="server" Text="Nuovo Medico" NavigateUrl="~/Admin/User/Add.aspx"></asp:HyperLink></p>              
              <p><asp:HyperLink ID="LinkReportUtenti" runat="server" Text="Lista medici" NavigateUrl="~/Admin/User/Lista.aspx"></asp:HyperLink></p>
    </div >
    </div >