<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcLeftAdmin.ascx.vb" Inherits="_UserControl_Navigazione_UcLeftAdmin" %>
    <div class="split2">
         <div class="left-column_t">UTENTI</div>
         <div class="left-column">
              <p><asp:HyperLink ID="lnkNuovoUtente" runat="server" Text="Nuovo Utente" NavigateUrl="~/Admin/User/Add.aspx"></asp:HyperLink></p>              
              <p><asp:HyperLink ID="LinkReportUtenti" runat="server" Text="Elenco utenti" NavigateUrl="~/Admin/User/Lista.aspx"></asp:HyperLink></p>
              <p><asp:HyperLink ID="ImportaUtenti" runat="server" Text="Importa Utenti" NavigateUrl="~/Admin/User/bulkuser.aspx"></asp:HyperLink></p>              
    </div >
    </div >
    <div class="split2">
        <div class="left-column_t">CONFIGURA</div>
            <div class="left-column">
                <p><asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/Admin/Config/Referenti/Lista.aspx">Medici Referenti</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkGruppiMalattie"  runat="server" NavigateUrl="~/Admin/Config/Malattie/Gruppi.aspx">Gruppi Malattie</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkEsami"  runat="server" NavigateUrl="~/Admin/Config/Esami.aspx" >Tipo Esami</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkAgenteVeicolo"  runat="server" NavigateUrl="~/Admin/Config/AgenteVeicolo.aspx" >Agente-Veicolo</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkAgenteMalattia"  runat="server" NavigateUrl="~/Admin/Config/AgenteMalattia.aspx" >Agente-Malattia</asp:HyperLink></p>
            </div >
    </div >
    <div class="split2">
        <div class="left-column_t">TABELLE</div>
            <div class="left-column">
                <p><asp:HyperLink ID="lnkMalattia"  runat="server" NavigateUrl="~/Admin/Tabelle/Malattie/Lista.aspx" >Malattie</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkMateriale"  runat="server" NavigateUrl="~/Admin/Tabelle/Esami/Tabelle.aspx?tipo=Materiale" >Materiale</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkMetodo"  runat="server" NavigateUrl="~/Admin/Tabelle/Esami/Tabelle.aspx?tipo=Metodo" >Metodo</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkAgente"  runat="server" NavigateUrl="~/Admin/Tabelle/Esami/Tabelle.aspx?tipo=AgenteEziologico" >Agente Eziologico</asp:HyperLink></p>            
                <p><asp:HyperLink ID="lnkVeicolo"  runat="server" NavigateUrl="~/Admin/Tabelle/Esami/Tabelle.aspx?tipo=Veicolo" >Veicolo</asp:HyperLink></p>            
                <p><asp:HyperLink ID="lnkComunita"  runat="server" NavigateUrl="~/Admin/Tabelle/Accesorie/Tabelle.aspx?tipo=Comunita" >Comunita</asp:HyperLink></p>            
                <p><asp:HyperLink ID="lnkProfessione"  runat="server" NavigateUrl="~/Admin/Tabelle/Accesorie/Tabelle.aspx?tipo=Professione" >Professione</asp:HyperLink></p>  
                <p><a href="" target="_blank"></a></p>
            </div >
    </div >
<%--    <div class="split2">
      <div class="left-column_t">GEOGRAFICHE</div>
      <div class="left-column">
                <p><asp:HyperLink ID="lnkNazione"  runat="server" NavigateUrl="" >Nazioni</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkAsl"  runat="server" NavigateUrl="" >Asl</asp:HyperLink></p>
                <p><asp:HyperLink ID="lnkComune"  runat="server" NavigateUrl="" >Comune</asp:HyperLink></p>
      </div >
    </div >--%>