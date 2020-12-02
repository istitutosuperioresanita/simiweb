<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Tubercolosi.master" AutoEventWireup="false" CodeFile="Dettaglio.aspx.vb" Inherits="Tubercolosi_Dettaglio" %>

<%@ Register src="_UserControl/UcLeftTubercolosi.ascx" tagname="UcLeftTubercolosi" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register src="../_UserControl/Applicazione/UcAnagrafica.ascx" tagname="UcAnagrafica" tagprefix="uc2" %>

<%@ Register src="_UserControl/ViewControlliTubercolosi.ascx" tagname="ViewControlliTubercolosi" tagprefix="uc3" %>

<%@ Register src="_UserControl/ViewContattiTubercolosi.ascx" tagname="ViewContattiTubercolosi" tagprefix="uc4" %>

<%@ Register src="../_UserControl/Applicazione/UcClinici.ascx" tagname="UcClinici" tagprefix="uc5" %>

<%@ Register src="_UserControl/ViewFattoriRischio.ascx" tagname="ViewFattoriRischio" tagprefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
    <asp:ScriptManager ID="scrptManager" runat="server"></asp:ScriptManager>
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Tubercolosi -> Dettaglio
        </div >       
            <br />
                <br />
                <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="cognome" CssClass="label" Width="150px" >Cognome paziente</asp:Label>
                <asp:Label ID="cognome" runat="server" CssClass="Label" Text="Bianchi" Font-Bold="true"></asp:Label>
                </p>
                <p>
                <asp:Label ID="nomeLabel" runat="server" AssociatedControlID="nome" CssClass="label" Width="150px" >Nome paziente</asp:Label>
                <asp:Label ID="nome" runat="server" CssClass="Label" Text="Paolo" Font-Bold="true"></asp:Label>
                </p>
                <p>
                <asp:Label ID="dataNascitaLabel" runat="server" AssociatedControlID="dataNascita" CssClass="label" Width="150px">Data di nascita</asp:Label>
                <asp:Label ID="dataNascita" runat="server" CssClass="Label" Font-Bold="true" Text="12/01/1940"></asp:Label>
                </p>
            <br />            
            <hr />
                        <asp:TabContainer ID="TabContainer1" runat="server">
                            <asp:TabPanel ID="Dettaglio" HeaderText="Dettaglio" runat="server">
                                <ContentTemplate>                                                     
                                    <uc2:UcAnagrafica ID="UcAnagrafica1" runat="server" />
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="cliniche" HeaderText="Cliniche" runat="server">
                                <ContentTemplate>
                                    <uc5:UcClinici ID="UcClinici1" runat="server" />
                                </ContentTemplate>                   
                            </asp:TabPanel>
                            <asp:TabPanel ID="Fattori" HeaderText="Fattori di Rischio" runat="server">
                                <ContentTemplate>     
                                    <uc6:ViewFattoriRischio ID="ViewFattoriRischio1" runat="server" />                                               
                                </ContentTemplate>            
                            </asp:TabPanel>
                            <asp:TabPanel  ID="Contatti" HeaderText="Contatti" runat="server">
                                <ContentTemplate>
                                        <uc4:ViewContattiTubercolosi ID="ViewContattiTubercolosi1" runat="server" />                    
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel  ID="Controlli"  HeaderText="Controlli" runat="server">
                                <ContentTemplate>                                  
                                 <uc3:ViewControlliTubercolosi ID="ViewControlliTubercolosi1" runat="server" />
                                </ContentTemplate>                                
                            </asp:TabPanel>
                            <asp:TabPanel ID="followUp" HeaderText="FollowUp" runat="server">
                                <ContentTemplate>
                                </ContentTemplate>
                                
                            </asp:TabPanel>
                        </asp:TabContainer>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftTubercolosi ID="UcLeftTubercolosi1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

