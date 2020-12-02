<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcLeftMenu.ascx.vb" Inherits="_UserControl_Navigazione_UcLeftMenu" %>
    <div class="split2">
         <div class="left-column_t">NOTIFICA</div>
        <div class="left-column">
              <p><asp:HyperLink ID="lnkNuovaNotifica" runat="server" Text="Nuova notifica" NavigateUrl="~/Notifica/Malattia.aspx"  ></asp:HyperLink></p>
              <p><asp:HyperLink ID="lnkNotificheInserite" runat="server" Text="Notifiche inserite" NavigateUrl="~/Notifica/Lista.aspx"></asp:HyperLink></p>
              <p><asp:HyperLink ID="lnkNotificaEsporta" runat="server" Text="Elenchi notifica" NavigateUrl="~/Notifica/Elenchi.aspx"></asp:HyperLink></p>
              <p><asp:HyperLink ID="lnkAnalisiAdv" runat="server" Text="Analisi" NavigateUrl="~/Notifica/Analisi.aspx"></asp:HyperLink></p>
              <p><asp:HyperLink ID="lnkMod16" runat="server" Text="Mod.16" NavigateUrl="~/Notifica/Mod16.aspx"></asp:HyperLink></p>
              
    </div >
    </div >
    <div class="split2">
        <div class="left-column_t">FOCOLAIO</div>
            <div class="left-column">
                <p><asp:HyperLink ID="lnkNuovoFocolaio" runat="server" NavigateUrl="~/Focolaio/Malattia.aspx" Text="Nuovo Focolaio"></asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkListaFocolaio" runat="server" NavigateUrl="~/Focolaio/Lista.aspx" Text="Focolai inseriti"></asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkEsportaFocolaio" runat="server" Text="Elenchi focolaio" NavigateUrl="~/Focolaio/Elenchi.aspx"></asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkFocolaioAnalisi" runat="server" Text="Analisi" NavigateUrl="~/Focolaio/Analisi.aspx"></asp:HyperLink></p>
<%--                <p><asp:HyperLink ID="lnkStampaFocoaio" runat="server" Text="Stampe" NavigateUrl="~/Focolaio/Print.aspx"></asp:HyperLink></p>--%>
            </div >
    </div >
      <div class="split2">
      <div class="left-column_t">UTILITY</div>
      <div class="left-column">           
             <p><asp:HyperLink ID="lnkEsporta" runat="server" Text="Esporta tabelle" NavigateUrl="~/Utility/EsportaTabelle.aspx"></asp:HyperLink></p>
             <p><asp:HyperLink ID="lnkEsportaMinistero" runat="server" Text="Esportazioni x Ministero" NavigateUrl="~/Utility/EsportaMinistero.aspx"></asp:HyperLink></p>
             <p><asp:HyperLink ID="lnkGestioneMedici" runat="server" Text="Gestione Medici" NavigateUrl="~/Regione/Medici/Lista.aspx"></asp:HyperLink></p>            
             <p><asp:HyperLink ID="LnkDashBoard" runat="server" Text="Esporta tabelle" NavigateUrl=""></asp:HyperLink></p>
      </div >
    </div >
      <div class="split2">
      <div class="left-column_t">Guide</div>
      <div class="left-column">           
             <p><asp:HyperLink ID="lnkManuale" runat="server" Text="Manuale" NavigateUrl="~/_manuale/manuale.docx"></asp:HyperLink></p>
             <p><asp:HyperLink ID="lnkVideoguide" runat="server" Text="VideoGuide" NavigateUrl="~/guide/guide.aspx"></asp:HyperLink></p>
      </div >
    </div >
<%--     <div class="split2">
      <div class="left-column_t">SORVEGLIANZE SPECIALI</div>
      <div class="left-column">
                <p><asp:HyperLink ID="lnkTubercolosi" runat="server" NavigateUrl="~/Tubercolosi/Lista.aspx" Text="Tubercolosi"></asp:HyperLink></p>
                <p><a href="" target="_blank">Mal. batterico Invasive</a></p>
      </div >
    </div >--%>
