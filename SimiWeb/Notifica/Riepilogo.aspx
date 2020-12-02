<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Riepilogo.aspx.vb" Inherits="Notifica_Riepilogo" %>
<%@ Register src="../_UserControl/Applicazione/UcAnagrafica.ascx" tagname="UcAnagrafica" tagprefix="uc1" %>
<%@ Register src="../_UserControl/Applicazione/UcClinici.ascx" tagname="UcClinici" tagprefix="uc2" %>
<%@ Register src="../_UserControl/Applicazione/ViewEsami.ascx" tagname="ViewEsami" tagprefix="uc3" %>
<%@ Register src="../_UserControl/Applicazione/UcSegnalazione.ascx" tagname="UcSegnalazione" tagprefix="uc5" %>
<%@ Register src="../_UserControl/Applicazione/UcTubercolosi.ascx" tagname="UcTubercolosi" tagprefix="uc6" %>
<%@ Register src="../_UserControl/Applicazione/ViewModalitaTrasmissione.ascx" tagname="ViewModalitaTrasmissione" tagprefix="uc4" %>
<%@ Register src="../_UserControl/Applicazione/UcMalaria.ascx" tagname="UcMalaria" tagprefix="uc10" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../_UserControl/Applicazione/UcTubercolosiFattori.ascx" tagname="UcTubercolosiFattori" tagprefix="uc7" %>
<%@ Register src="../_UserControl/Applicazione/UcStato.ascx" tagname="UcStato" tagprefix="uc8" %>
<%@ Register src="../_UserControl/Applicazione/UcMib.ascx" tagname="UcMib" tagprefix="uc9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.min.js" type="text/javascript"></script>


    

    
<%--      <script type="text/javascript">
          $(document).ready(function () {
              $("#progressbar").progressbar({ value: 37 });
              $("#progressbar").css({ 'background': 'LightYellow' });
              $("#progressbar > div").css({ 'background': 'Orange' }); 
          });
     </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
<asp:ScriptManager ID="mng" runat="server"></asp:ScriptManager>

 

<div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica ->   <b>Riepilogo dati</b>
            
        </div >
            <p style="text-align:center">  
            <label class="sezione"><b>Notifica di: </b> </label>
            <asp:Label ID="malattiaLabel" runat="server" CssClass="alert"></asp:Label>
            </p> 
                <div>
                    <div style="float:left;width:300px">
                <p>              
                <label class="sezione"><b>Nome: </b> </label>
                <asp:Label ID="nome" runat="server" CssClass="alert"></asp:Label>
                <br />
                <label class="sezione"><b>Cognome: </b> </label>
                <asp:Label ID="cognome" runat="server" CssClass="alert"></asp:Label>
                </p>
<%--                <p>
                <label class="sezione"  style="width:100px">Classificazione:</label> 
                <asp:Label ID="Classificazione" runat="server" CssClass="alert"></asp:Label>                                                       
                </p> --%>
                <p>
                <label class="sezione"  style="width:100px">Stato Notifica:</label> 
                <asp:Label ID="stato" runat="server" CssClass="alert"></asp:Label>                                                       
                </p>                       
                    </div>          
                    <div style="float:left">
                          <div style="margin-left:80px;width:400px">
                                <asp:Panel ID="pnlNotifica" runat="server">
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="notifica" runat="server" ImageUrl="~/_Styles/All/images/pending.png" />
                                    <br />
                                    <label class="labelImage">Notifica</label>
                                </p>
                                </div>
                                </asp:Panel>
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="messaggio" runat="server" ImageUrl="~/_Styles/All/images/email.png" />
                                    <br />
                                    <label class="labelImage">messaggio</label>
                                </p>
                                </div>
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="stampa" runat="server" 
                                        ImageUrl="~/_Styles/All/images/printer.png" style="height: 16px" />
                                    <br />
                                    <label class="labelImage">stampa</label>
                                </p>
                                </div>
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="storico" runat="server" ImageUrl="~/_Styles/All/images/calendar.png" />
                                    <br />
                                    <label class="labelImage">Storico</label>
                                </p>
                                </div>
                                <asp:Panel ID="pnlInvalida" runat="server">
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="invalida" runat="server" ImageUrl="~/_Styles/All/images/delete.png" />
                                    <br />
                                    <label class="labelImage">invalida</label>
                                </p>
                                </div>
                                </asp:Panel>
                                <div style="float:none">
                                </div>
                                
                            </div>   
                    </div>
                    <div style="clear:both">
                    <asp:Label ID="message" runat="server" Visible="false" Width="400px" CssClass="alert"></asp:Label>
                    </div>    
                </div>
        <asp:TabContainer ID="TabContainer1" runat="server">
            <asp:TabPanel ID="tabStato" runat="server" HeaderText="Stato" TabIndex="0">
                <ContentTemplate>                   
                    <uc8:UcStato ID="UcStato1" runat="server" /></ContentTemplate>
            
</asp:TabPanel>
            <asp:TabPanel ID="tabAnagrafica" runat="server" HeaderText="Anagrafica" TabIndex="1">
                <ContentTemplate><uc1:UcAnagrafica ID="UcAnagrafica1" runat="server" /></ContentTemplate>
            
</asp:TabPanel>
            <asp:TabPanel ID="TabClinici" runat="server" HeaderText="Clinici" TabIndex="2">
                <ContentTemplate><uc2:UcClinici ID="UcClinici1" runat="server" /></ContentTemplate>
            
</asp:TabPanel>
            <asp:TabPanel ID="TabSpecifico" runat="server" HeaderText="Specifiche" TabIndex="3">
                <ContentTemplate><uc6:UcTubercolosi ID="UcTubercolosi" runat="server" /></ContentTemplate>            
            
</asp:TabPanel>
            <asp:TabPanel ID="TabFattoriTbc" runat="server" HeaderText="Fattori Tbc" TabIndex="4">
                <ContentTemplate><uc7:UcTubercolosiFattori ID="UcTubercolosiFattori1" runat="server" /></ContentTemplate>
            
</asp:TabPanel>
            <asp:TabPanel ID="TabMalaria" runat="server" HeaderText="Specifiche" TabIndex="5">
                <ContentTemplate><uc10:UcMalaria ID="UcTabMalaria" runat="server" /></ContentTemplate>
            
</asp:TabPanel>
<%--            <asp:TabPanel ID="TabEsami" runat="server" HeaderText="Esami" TabIndex="5">
            <ContentTemplate>
            <p style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" CssClass="funzioni" Text="Aggiorna questa sezione"  >
                </asp:LinkButton>
            </p>
            <fieldset>
                <legend><label class="sezione">Esami</label></legend>
                 <hr /><uc3:ViewEsami ID="ViewEsami1" runat="server" />
            </fieldset>
            </ContentTemplate>
            
</asp:TabPanel>--%>
<asp:TabPanel ID="TabMib" runat="server" HeaderText="Mib" TabIndex="6">
            <ContentTemplate>
                <uc9:UcMib ID="UcMib1" runat="server" />
            </ContentTemplate>
</asp:TabPanel>
        </asp:TabContainer>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

