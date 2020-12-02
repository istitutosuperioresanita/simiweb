<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Focolaio.aspx.vb" 
EnableEventValidation="false"
EnableViewState="true"
ClientIDMode="Static"
Inherits="Focolaio_Focolaio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/Geografiche.js"  type="text/javascript"></script>
    <script src="Js/Focolaio.js" type="text/javascript"></script>

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
   <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Focolaio -> <b>Nuovo Focolaio (2 di 2)</b>
        </div >    
            <br />
            <br />
            <p style="text-align:center">
            <label class="sezione"><b>Focolaio di </b> </label>
            <asp:Label ID="focolaioLabel" runat="server" CssClass="alert"></asp:Label>
            </p>
            <br />
            <label class="sezione">Informazione focolaio</label>
            <hr />
               <p><asp:Label ID="lblErrore" runat="server"  Visible="false" CssClass="alert"></asp:Label></p>
           <p>  
                    <asp:Label ID="lblCodiceFocolaio" runat="server" AssociatedControlID="CodiceFocolaio" CssClass="label"  >Codice focolaio:</asp:Label>
                    <asp:TextBox ID="CodiceFocolaio" runat="server" CssClass="textBox"></asp:TextBox>
                    (codice per l'identificazione a livello regionale del focolaio, se disponibile)
           </p>
           <p>
                    <asp:Label ID="RegioneLabel" runat="server" AssociatedControlID="Regione" CssClass="label"  >Regione:</asp:Label>
                    <asp:DropDownList ID="Regione" runat="server"  CssClass="dropdown">
                    </asp:DropDownList>    
                     <asp:RequiredFieldValidator ID="reqRegione"  runat="server" InitialValue="" Text="*" ControlToValidate="Regione" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
    
          </p>
          <p>
                    <asp:Label ID="ProvinciaLabel" runat="server" AssociatedControlID="Provincia" CssClass="label"  >Provincia:</asp:Label>
                    <asp:DropDownList ID="Provincia" runat="server"  CssClass="dropdown">
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqProvincia"  runat="server" InitialValue="" Text="*" ControlToValidate="Provincia" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
          </p>
          <p>
                    <asp:Label ID="ComuneLabel" runat="server" AssociatedControlID="Comune" CssClass="label"  >Comune:</asp:Label>
                    <asp:DropDownList ID="Comune" runat="server"  CssClass="dropdown">
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqComune"  runat="server" InitialValue="" Text="*" ControlToValidate="Comune" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
          </p>
          <p>
                    <asp:Label ID="ComunitaLabel" runat="server" AssociatedControlID="Comunita" CssClass="label" >Comunita:</asp:Label>
                    <asp:DropDownList ID="Comunita" runat="server"  CssClass="dropdown">
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqComunita"  runat="server" InitialValue="" Text="*" ControlToValidate="Comunita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
    
          </p>
          <p>
                <asp:Label ID="PersoneRischioLabel" runat="server" AssociatedControlID="PersoneRischio" CssClass="label">Numero persone a rischio:</asp:Label>
                <asp:TextBox ID="PersoneRischio" runat="server" CssClass="textBox"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="ReqNumero_persone"  runat="server" InitialValue="" Text="*" ControlToValidate="PersoneRischio" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
            </p>
            <p>
                <asp:Label ID="IndirizzoLabel" runat="server" AssociatedControlID="Indirizzo" CssClass="label">Indirizzo:</asp:Label>
                <asp:TextBox ID="Indirizzo" runat="server" CssClass="textBox"></asp:TextBox> 
             </p>
            <p>
                <asp:Label ID="TelefonoLabel" runat="server" AssociatedControlID="Telefono" CssClass="label" >Telefono:</asp:Label>
                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox"></asp:TextBox> 
             </p>
            <p>                                    
                    <asp:Label ID="AgenteLabel" runat="server" AssociatedControlID="Agente" CssClass="label"  >Agente:</asp:Label>
                    <asp:DropDownList ID="Agente" runat="server"  CssClass="dropdown"></asp:DropDownList>
                    <asp:RadioButtonList ID="AgenteStato" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="identificato"  Value="identificato">
                                        </asp:ListItem>
                                        <asp:ListItem  Text="sospetto"  Value="sospetto">
                                        </asp:ListItem>
                    </asp:RadioButtonList> 
                    <asp:RequiredFieldValidator ID="reqAgente"  runat="server" InitialValue="" Text="*" ControlToValidate="Agente" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
            </p>
            <p>
                    <asp:Label ID="VeicoloLabel" runat="server" AssociatedControlID="Veicolo" CssClass="label">Veicolo:</asp:Label>
                    <asp:DropDownList ID="Veicolo" runat="server"  CssClass="dropdown"  Visible="false">                        
                    </asp:DropDownList>
                    <asp:TextBox ID="VeicoloTesto" runat="server" CssClass="textBox"></asp:TextBox>
                    <asp:RadioButtonList ID="VeicoloStato" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="identificato"  Value="identificato">
                                        </asp:ListItem>
                                        <asp:ListItem  Text="sospetto"  Value="sospetto">
                                        </asp:ListItem>
                    </asp:RadioButtonList>    
<%--                    <asp:RequiredFieldValidator ID="reqVeicolo"  runat="server" InitialValue="" Text="*" ControlToValidate="Veicolo" CssClass="alert" ValidationGroup="form">
                    </asp:RequiredFieldValidator>                              
    --%>
          </p>
          <p>
                <asp:Label ID="dataInizioLabel" runat="server" AssociatedControlID="dataInizio" CssClass="label" Width="200px">Data di inizio epidemia:</asp:Label>
                <asp:TextBox ID="dataInizio" runat="server" CssClass="textBox"></asp:TextBox><label class="label">(gg/mm/aaaa)</label>
                <asp:RequiredFieldValidator ID="reqdataInizio" runat="server" ControlToValidate="dataInizio" Text="*" CssClass="alert" ValidationGroup="form" InitialValue=""></asp:RequiredFieldValidator>
          </p>
          <p>
                <asp:Label ID="durataLabel" runat="server" AssociatedControlID="durata" CssClass="label">Durata:</asp:Label>
                <asp:TextBox ID="durata" runat="server" CssClass="textBox"></asp:TextBox> 
          </p>
          <p>
                <asp:Label ID="numeroCasiLabel" runat="server" AssociatedControlID="numeroCasi" CssClass="label">Numero di casi:</asp:Label>
                <asp:TextBox ID="numeroCasi" runat="server" CssClass="textBox"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="reqNumeroCasi" runat="server" ControlToValidate="numerocasi" Text="*" ValidationGroup="form" InitialValue="" CssClass="alert"></asp:RequiredFieldValidator>
          </p>
          <p>
                <asp:Label ID="LuogoOrigineLabel" runat="server" AssociatedControlID="LuogoOrigineLabel" CssClass="label">Presunto luogo origine:</asp:Label>
                <asp:DropDownList ID="LuogoOrigine" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="non indicato/non noto" Value="ni"></asp:ListItem>
                <asp:ListItem Text="Regione" Value="Regione"></asp:ListItem>
                <asp:ListItem Text="Altra regione" Value="Altra regione"></asp:ListItem>
                <asp:ListItem Text="Estero" Value="Estero"></asp:ListItem>
                </asp:DropDownList> 
          </p>
          <p>
                <asp:Label ID="noteLabel" runat="server" AssociatedControlID="note" CssClass="label"  >Note:</asp:Label>
                <asp:TextBox ID="note" runat="server" CssClass="textBox" Width="400px" Height="150px" ></asp:TextBox> 
          </p>
            <hr />
          <p>
                <asp:Label ID="dataSegnalazioneLabel" runat="server" AssociatedControlID="dataSegnalazioneLabel" CssClass="label" Width="150px">Data prima segnalazione:</asp:Label>
                <asp:TextBox ID="datasegnalazione" runat="server" CssClass="textBox" ></asp:TextBox><label class="label">(gg/mm/aaaa)</label> 
                <asp:RequiredFieldValidator ID="reqdataSegnalazione" runat="server" Text="*" CssClass="alert" ControlToValidate="dataSegnalazione" InitialValue="" ValidationGroup="form"></asp:RequiredFieldValidator>
          </p>
          <p>
                <asp:Label ID="statoLabel" runat="server" AssociatedControlID="stato" CssClass="label">Stato:</asp:Label>
                    <asp:DropDownList ID="stato" runat="server"  CssClass="dropdown">
                                <asp:ListItem Text="Segnalazione" Value="Segnalazione"></asp:ListItem>
                                <asp:ListItem Text="Notifica" Value="Notifica"></asp:ListItem>
                    </asp:DropDownList>
<%--                    <asp:RequiredFieldValidator ID="reqStato"  runat="server" InitialValue="" Text="*" ControlToValidate="stato" CssClass="alert" ValidationGroup="form">
                    </asp:RequiredFieldValidator> --%>
          </p>
          <p>
                <asp:Label ID="dataNotificaLabel" runat="server" AssociatedControlID="dataNotifica" CssClass="label" Width="150px">Se notifica, data notifica:</asp:Label>
                <asp:TextBox ID="datanotifica" runat="server" CssClass="textBox" ></asp:TextBox><label class="label">(gg/mm/aaaa)</label>                
          </p>
          <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />
            <p style="padding-left:450px">
            <asp:Button  ID="btnAnnulla" runat="server" Text="Annulla"  ValidationGroup="form"  CausesValidation="false" UseSubmitBehavior="false" />
            <asp:Button  ID="btnSalva" runat="server" Text="Salva"  ValidationGroup="form"  UseSubmitBehavior="false" />
            </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

