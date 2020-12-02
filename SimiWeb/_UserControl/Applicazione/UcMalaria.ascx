<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcMalaria.ascx.vb" Inherits="_UserControl_Applicazione_UcMalaria" %>
   <p  style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
            </p>
<fieldset style="padding-right:30px">
    <legend><label class="sezione">Malaria Informazioni aggiuntive</label></legend>
            <hr />

            <div style="width:100%">
               <div style="float:left">
          <p>
            <label class="labelBold">Tipo Malaria</label>
            <asp:label ID="tipo" runat="server" CssClass="label">
             </asp:label>
            </p>
            <p>
             <label class="labelBold">Data diagnosi clinica</label>
             <asp:label ID="DataClinica" runat="server" CssClass="label"></asp:label>
            </p>
            <p>
             <label class="labelBold">Data Emoscopia</label>
             <asp:label ID="dataEmoscopia" runat="server" CssClass="label"></asp:label>
            </p>
            <p>
             <label class="labelBold">Specie plasmodio</label>
             <asp:Label ID="speciePlasmodio" runat="server" CssClass="label">
             </asp:Label>
             <label class="labelBold" style="width:200px">Se Forme miste, specificare: </label>
             <asp:Label ID="formeMisteSpecificare" runat="server" CssClass="Label"></asp:Label>
            </p>
            <p>
               <label class="labelBold">Terapia</label>
               <asp:Label ID="terapia" runat="server" CssClass="label">
               </asp:Label>
               <label class="labelBold" style="width:150px">Se altra, specificare</label>
               <asp:Label ID="altraTerapia" runat="server" CssClass="Label"></asp:Label>
            </p>
            <p>
               <label  class="labelBold">Farmaco resistenza a:</label> 
               <asp:Label ID="faramcoResistenza" runat="server" Width="500px" Height="100px" CssClass="Label" TextMode="MultiLine"></asp:Label>
            </p>
            <p>
                <label class="labelBold" style="width:300px">Da chi ha ricevuto informazioni sulla prevenzione della malaria ?</label>
                        <asp:label ID="prevenzioneRicevuta" runat="server" CssClass="label" >
                </asp:label>
                <label class="labelBold" style="width:150px">se altro, specificare:</label>
                <asp:label ID="AltroEnte" runat="server" CssClass="label"></asp:label>
            </p>
             <label class="sezione">Chemioprofilassi</label>
             <hr />
            <p>
            <label class="labelBold"  style="width:180px">Chemioprofilassi effettuata ?</label>
            <asp:label ID="chemioprofilassi" runat="server" CssClass="label">
            </asp:label>
            <label class="labelBold">se si, specificare</label>
            <asp:label ID="farmaciChemioprofilassi" runat="server" CssClass="label" >
            </asp:label>            
            </p>
            <p>
            <label class="labelBold" style="width:300px">Durante il periodo sono saltate alcune assunzioni ?</label>
            <asp:label ID="assunzioniInterrotte" runat="server" CssClass="label">
            </asp:label>
            </p>
            <p>
            <label class="labelBold" style="width:450px">La chemioprofilassi è stata completata per 4 settimane dopo il rientro ?</label>
            <asp:label ID="chemioProfilassiCompletata" runat="server" CssClass="label">
            </asp:label>
            </p>
            <p>
            <label class="labelBold" style="width:200px">Se no, specificare il motivo:</label>
                <asp:label ID="motivoInterruzione" runat="server" CssClass="label">
            </asp:label>
            </p>
            <p>
            <label class="labelBold" style="width:160px">Effetto collaterale 1</label>
            <asp:label ID="Effetto1" runat="server" CssClass="label"  Width="250px" >              
            </asp:label>
            <label class="labelBold" style="width:150px"> Se altro, specificare</label>
            <asp:label ID="altroEffetto1Specificare" runat="server" CssClass="label"></asp:label>
            </p>
            <p>
            <label class="labelBold" style="width:160px">Effetto collaterale 2</label>
            <asp:label ID="Effetto2" runat="server" CssClass="label" Width="250px" >      
            </asp:label>
            <label class="labelBold" style="width:150px"> Se altro, specificare</label>
            <asp:label ID="altroEffetto2Specificare" runat="server" CssClass="label"></asp:label>
            </p>
             <label class="sezione">Misure di prevenzione</label>
             <hr />
            <p>
            <label class="labelBold" style="width:430px">le hanno consigliato misure di protezione contro le punture di zanzare ? </label>
            <asp:label ID="protezionePunture" runat="server" CssClass="label">
            </asp:label>            
            </p>
            <p>
            <label class="labelBold" style="width:400px">Ha dormito protetto da zanzariere nelle zone a rischio ?</label>
            <asp:label ID="zanzareZoneRischio" runat="server" CssClass="label">
            </asp:label>            
            </p>
            <p>
            <label class="labelBold" style="width:200px">Ha usato repellenti cutanei ?</label>
            <asp:label ID="Repellenti" runat="server" CssClass="label" >
            </asp:label>            
            <label class="labelBold" style="width:150px">Se usati, specificare </label>
            <asp:label ID="specificaRepellente" runat="server" CssClass="label"></asp:label>
            </p>
            <label class="sezione">Riservato Ministero e ISS</label>
            <hr />
            <p>
            <label class="labelBold" style="width:150px">Emoscopia pervenuta</label>
            <asp:label ID="Emoscopiapervenuta" runat="server" CssClass="label">   
            </asp:label>
            </p>
            <p>
            <label class="labelBold" style="width:150px">Emoscopia controllo</label>
            <asp:label ID="Emoscopiacontrollo" runat="server" CssClass="label">            
            </asp:label>
            </p>
            </div>
            </div>
</fieldset>