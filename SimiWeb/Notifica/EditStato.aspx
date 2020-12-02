<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
CodeFile="EditStato.aspx.vb" 
Inherits="Notifica_EditStato" 
EnableEventValidation="false"
 ClientIDMode="Static"%>



<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
         <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
         <script src="Js/stato.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->

           Simiweb -> Notifica -> <b>Informazioni stato notifica</b>
             
        </div >        
        <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
      
        <br />
        <label class="sezione">Stato segnalazione/notifica</label>
        <hr />
        <p style="text-align:right; padding-right:50px">
            <b> * Campi obbligatori </b>
        </p>
        <asp:Panel ID="pnlRegione" runat="server">
        <p>
            <label class="label">Asl di notifica</label>
            <asp:DropDownList ID="aslnotifica" runat="server" CssClass="dropdown">
            </asp:DropDownList>
        </p>        
        </asp:Panel>
        <p>
            <label class="label">malattia</label>
            <asp:DropDownList ID="malattia" runat="server" CssClass="dropdown">
            </asp:DropDownList>            
        </p>
        <p>
             <asp:HiddenField ID="dataprimisintomi" runat="server" />            
            <asp:Label ID="statoSchedaLabel"  runat="server" AssociatedControlID="statoScheda"  CssClass="label">Segnalazione o notifica</asp:Label>
            <asp:DropDownList ID="statoScheda" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Segnalazione" Text="Segnalazione" ></asp:ListItem>
                <asp:ListItem Value="Notifica" Text="Notifica" ></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lbldatasegnalazione"  runat="server" AssociatedControlID="datasegnalazione"  CssClass="label" Width="150px">Data prima segnalazione</asp:Label>
            <asp:TextBox ID="datasegnalazione" runat="server" CssClass="textBox"></asp:TextBox> &nbsp;* 
            <asp:RequiredFieldValidator ID="reqDataSegnalazione"  runat="server" InitialValue="" Text="*" ControlToValidate="datasegnalazione" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
        </p>
        <p>
            <asp:Label ID="datanotificaLabel"  runat="server" AssociatedControlID="datanotifica"  CssClass="label" Width="150px">Data notifica</asp:Label>
            <asp:TextBox ID="datanotifica" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="ReferenteUlssLabel" runat="server" AssociatedControlID="ReferenteUlss" CssClass="label" Width="150px">Referente Ulss</asp:Label>
            <asp:DropDownList ID="ReferenteUlss" runat="server" CssClass="dropdown">
            </asp:DropDownList> &nbsp;* 
            <asp:RequiredFieldValidator ID="ReqReferenteUlss"  runat="server" InitialValue="" Text="*" ControlToValidate="ReferenteUlss" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
        </p>
        <p>
            <asp:Label ID="AltroMEdicoLbl"  runat="server" AssociatedControlID="MedicoSegnalatore"  CssClass="label" Width="150px">Medico segnalatore</asp:Label>
            <asp:TextBox ID="MedicoSegnalatore" runat="server" CssClass="textBox"></asp:TextBox> &nbsp;* 
            <asp:RequiredFieldValidator ID="ReqMedicoSegnalatore"  runat="server" InitialValue="" Text="*" ControlToValidate="MedicoSegnalatore" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
            <asp:Label ID="origineSegnalazioneLabel"  runat="server" AssociatedControlID="origineSegnalazione"  CssClass="label" Width="150px">origine segnalatore</asp:Label>
            <asp:DropDownList ID="origineSegnalazione" runat="server">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="MMG" Value="MMG"></asp:ListItem>
                <asp:ListItem Text="PLS" Value="PLS"></asp:ListItem>
                <asp:ListItem Text="Medico segnalatore" Value="Medico segnalatore"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p  style="padding-left:600px">
            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" ValidationGroup="form"  CausesValidation="false"  UseSubmitBehavior="false"  CssClass="button"/>    
            <asp:Button ID="btn" runat="server" Text="Salva" ValidationGroup="form" CssClass="button" UseSubmitBehavior="false"/>                
        </p>    
        <div id="allerta">
        <label class="alert">La malattia è stata cambiata, in caso di salvataggio eventuali informazioni specifiche saranno eliminate </label>
        </div>
        <p>
        <asp:Label ID="message" runat="server" CssClass="alert"  Visible="false" Width="400px"></asp:Label>
        </p>
        <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />   
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
 <div class="dow-center">
    </div>
</asp:Content>

