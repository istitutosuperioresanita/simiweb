<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
 ClientIDMode="Static"
CodeFile="EditTubercolosiFattori.aspx.vb" Inherits="Notifica_EditTubercolosi" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Js/Clinici.js" type="text/javascript"></script>
    <script src="Js/tbc.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Tubercolosi Fattori Rischio</b>
        </div >  
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <asp:HiddenField ID="dataWeb" runat="server" />   
        <br />
         <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
        <br />
            <hr />
            <div style="width:100%">
               <div style="float:left">
            <p>
            <asp:Label ID="esitiradiograficiLabel"  runat="server" Text="esiti radiografici di tbc" Width="150px" AssociatedControlID="esitiradiografici"  CssClass="label"></asp:Label>
            <asp:DropDownList ID="esitiradiografici" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="graveimmudeficenzaLabel" runat="server" Text="grave immunodeficienza acquisita" Width="150px" AssociatedControlID="graveimmudeficenza" CssClass="label"></asp:Label>
            <asp:DropDownList ID="graveimmudeficenza" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="terapiaImmunosoppresivaLabel" runat="server" Text="terapia immunosopressiva" Width="150px" AssociatedControlID="terapiaImmunosoppresiva" CssClass="label"></asp:Label>
            <asp:DropDownList ID="terapiaImmunosoppresiva" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="deperimentoOrganicoLabel" runat="server" Text="deperimento organico grave" Width="150px" AssociatedControlID="deperimentoOrganico" CssClass="label"></asp:Label>
            <asp:DropDownList ID="deperimentoOrganico" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="recenteViaggioTbcLabel" runat="server" Text="recente viraggio tubercolinico" Width="150px" AssociatedControlID="recenteViaggioTbc" CssClass="label"></asp:Label>
            <asp:DropDownList ID="recenteViaggioTbc" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="diabeteScarsamenteControllatoLabel" runat="server" Text="diabete scarsamente controllato" Width="150px"     AssociatedControlID="diabeteScarsamenteControllato" CssClass="label"></asp:Label>
            <asp:DropDownList ID="diabeteScarsamenteControllato" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="silicosiLabel" runat="server"  Text="silicosi" Width="150px" AssociatedControlID="silicosi" CssClass="label"></asp:Label>
            <asp:DropDownList ID="silicosi" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="insufficenzaRenaleLabel" runat="server" Text="insufficienza renale cronica" Width="150px" AssociatedControlID="insufficenzaRenale" CssClass="label"></asp:Label>
            <asp:DropDownList ID="insufficenzaRenale" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="gastrectomiaLabel" runat="server" Text="gastrectomia" Width="150px"  AssociatedControlID="gastrectomia" CssClass="label"></asp:Label>
            <asp:DropDownList ID="gastrectomia" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            </div>
               <div style="float:left;margin-left:80px">               
            <p>
            <asp:Label ID="ContattoMalatoLabel" runat="server" Text="contatto con malato" Width="150px" AssociatedControlID="ContattoMalato" CssClass="label"></asp:Label>
            <asp:DropDownList ID="ContattoMalato" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="tossicodipendenzaLabel" runat="server"  Text="tossicodipendenza" Width="150px" AssociatedControlID="tossicodipendenza" CssClass="label"></asp:Label>
            <asp:DropDownList ID="tossicodipendenza" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="ImmigrazioneLabel" runat="server"  Text="immigrazione" Width="150px" AssociatedControlID="Immigrazione" CssClass="label"></asp:Label>
            <asp:DropDownList ID="Immigrazione" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="carcereLabel" runat="server"  Text="carcere" Width="150px" AssociatedControlID="carcere" CssClass="label"></asp:Label>
            <asp:DropDownList ID="carcere" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="alcolismoLabel" runat="server" Text="alcolismo" Width="150px" AssociatedControlID="alcolismo" CssClass="label"></asp:Label>
            <asp:DropDownList ID="alcolismo" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="senzaFissaDimoraLabel" runat="server" Text="senzaFissaDimora" Width="150px" AssociatedControlID="senzaFissaDimora" CssClass="label"></asp:Label>
            <asp:DropDownList ID="senzaFissaDimora" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="personaleSanitarioLabel" runat="server" Text="personaleSanitario" Width="150px" AssociatedControlID="personaleSanitario" CssClass="label"></asp:Label>
            <asp:DropDownList ID="personaleSanitario" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="AltroLabel" runat="server" Text="altro" Width="150px"  AssociatedControlID="altro" CssClass="label"></asp:Label>
            <asp:DropDownList ID="altro" runat="server">
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="non indicato" Value="ni"></asp:ListItem>
            </asp:DropDownList>
            </p>
            </div>
            
            </div>
            <div style="float:none"></div>
            <br />
            <p  style="padding-left:600px">
                <asp:Button ID="BtnAnnulla" runat="server" Text="Annulla"  CausesValidation="false" UseSubmitBehavior="false" Visible="true"/>
                <asp:Button ID="btnSalva" runat="server" Text="Salva"  Visible="true" UseSubmitBehavior="false"/>                
            </p>



</div>         
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

