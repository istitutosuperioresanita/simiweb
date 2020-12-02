<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcFocolaio.ascx.vb" Inherits="_UserControl_Applicazione_UcFocolaio" %>
            <label class="sezione">Informazioni focolaio</label>
            <hr />
        <p  style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
        </p>
                    <asp:Label ID="lblCodiceFocolaio" runat="server" CssClass="labelbold"  >Codice focolaio:</asp:Label>
                    <asp:Label ID="CodiceFocolaio" runat="server"></asp:Label>
        <p>
        </p>
           <p>
                    <asp:Label ID="AslNotificaLabel" runat="server"  CssClass="labelbold"  >Asl notifica:</asp:Label>
                    <asp:Label ID="AslNotifica" runat="server" CssClass="label"  ></asp:Label>
    
          </p>
           <p>
                    <asp:Label ID="RegioneLabel" runat="server"  CssClass="labelbold"  >Regione:</asp:Label>
                    <asp:Label ID="Regione" runat="server" CssClass="label"  ></asp:Label>
    
          </p>
          <p>
                    <asp:Label ID="ProvinciaLabel" runat="server" CssClass="labelbold"  >Provincia:</asp:Label>
                    <asp:Label ID="provincia" runat="server" CssClass="label"  ></asp:Label>    
          </p>
          <p>
                    <asp:Label ID="ComuneLabel" runat="server"  CssClass="labelbold"  >Comune:</asp:Label>
                    <asp:Label ID="comune" runat="server" CssClass="label"  ></asp:Label>   
    
          </p>
          <p>
                    <asp:Label ID="ComunitaLabel" runat="server"  CssClass="labelbold" >Comunita:</asp:Label>
                    <asp:Label ID="comunita" runat="server" CssClass="label"  ></asp:Label>   
          </p>
          <p>
                <asp:Label ID="NumeroPersoneLabel" runat="server" CssClass="labelbold">Persone rischio:</asp:Label>
                <asp:Label ID="numeropersone" runat="server" CssClass="label"  ></asp:Label>   
            </p>
            <p>
                <asp:Label ID="IndirizzoLabel" runat="server"  CssClass="labelbold">Indirizzo:</asp:Label>
                <asp:Label ID="Indirizzo" runat="server" CssClass="label"></asp:Label> 
             </p>
            <p>
                <asp:Label ID="TelefonoLabel" runat="server"  CssClass="labelbold" >Telefono:</asp:Label>
                <asp:Label ID="Telefono" runat="server" CssClass="label"></asp:Label> 
             </p>
            <p>
               <asp:Label ID="agenteIdentificatoLabel" runat="server"  CssClass="labelbold"  >Agente identificato:</asp:Label>
               <asp:Label ID="agenteIdentificato" runat="server" CssClass="label"></asp:Label>     
               <asp:Label ID="AgenteLabel" runat="server"  CssClass="labelbold"  >Agente:</asp:Label>
               <asp:Label ID="Agente" runat="server" CssClass="label" Width="200px"></asp:Label>     
          </p>
          <p>
               <asp:Label ID="veicoloIdentificatoLabel" runat="server"  CssClass="labelbold"  >Veicolo identificato:</asp:Label>
               <asp:Label ID="veicoloIdentificato" runat="server" CssClass="label"></asp:Label> 
               <asp:Label ID="VeicoloLabel" runat="server" CssClass="labelbold"  >Veicolo:</asp:Label>
               <asp:Label ID="Veicolo" runat="server" CssClass="label" Width="200px"></asp:Label>         
          </p>
          <p>
                <asp:Label ID="dataInizioLabel" runat="server"  CssClass="labelbold" Width="200px">Data di inizio epidemia:</asp:Label>
                <asp:Label ID="dataInizio" runat="server" CssClass="label"></asp:Label> 
          </p>
          <p>
                <asp:Label ID="durataLabel" runat="server" CssClass="labelbold">Durata:</asp:Label>
                <asp:Label ID="durata" runat="server" CssClass="label"></asp:Label> 
          </p>
          <p>
                <asp:Label ID="numeroCasiLabel" runat="server"  CssClass="labelbold">Numero di casi:</asp:Label>
                <asp:Label ID="numeroCasi" runat="server" CssClass="label"></asp:Label> 
          </p>
          <p>
                <asp:Label ID="LuogoOrigineLabel" runat="server"  CssClass="labelbold">Presunto luogo origine:</asp:Label>
                <asp:Label ID="LuogoOrigine" runat="server" CssClass="label" Width="200px"></asp:Label> 
          </p>
          <p>
                <asp:Label ID="noteLabel" runat="server" AssociatedControlID="note" CssClass="labelbold"  >Note:</asp:Label>
                <asp:Label ID="note" runat="server" CssClass="label" Width="400px" Height="100px" ></asp:Label> 
          </p>
          <p>
                <asp:Label ID="dataSegnalazioneLabel" runat="server"  CssClass="labelbold">Data segnalazione:</asp:Label>
                <asp:Label ID="dataSegnalazione" runat="server" CssClass="label" ></asp:Label> 
          </p>
          <p>
                <asp:Label ID="dataNotificaLabel" runat="server" CssClass="labelbold">Data notifica:</asp:Label>
                <asp:Label ID="dataNotifica" runat="server"  CssClass="label"></asp:Label> 
          </p>
          <p>
                <asp:Label ID="inseritoDaLabel" runat="server" CssClass="labelbold">Inserito da:</asp:Label>
                <asp:Label ID="inseritoDa" runat="server"  CssClass="label"></asp:Label> 
          </p>
