<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
 ClientIDMode="Static"
CodeFile="EditMalaria.aspx.vb" Inherits="Notifica_EditMalaria" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="Js/malaria.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Malaria Informazioni aggiuntive</b>
        </div >  
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <asp:HiddenField ID="dataWeb" runat="server" />   
        <br />
         <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
        <br />            
            <br />
            <p>
            <label class="label">Tipo Malaria</label>
            <asp:DropDownList ID="tipo" runat="server" CssClass="dropdown">
             <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
             <asp:ListItem Text="Importata" Value="Importata"></asp:ListItem>
             <asp:ListItem Text="Indotta/Post trasfusionale" Value="Indotta/Post trasfusionale"></asp:ListItem>
             <asp:ListItem Text="Autoctona" Value="Autoctona"></asp:ListItem>
             </asp:DropDownList>
            </p>
            <p>
             <label class="label">Data diagnosi clinica</label>
             <asp:TextBox ID="DataClinica" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
             <label class="label">Data Emoscopia</label>
             <asp:TextBox ID="dataEmoscopia" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
             <label class="label">Specie plasmodio</label>
             <asp:DropDownList ID="speciePlasmodio" runat="server" CssClass="dropdown">
             <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
             <asp:ListItem Text="Falciparum" Value="Falciparum"></asp:ListItem>
             <asp:ListItem Text="Vivax" Value="Vivax"></asp:ListItem>
             <asp:ListItem Text="Ovale" Value="Ovale"></asp:ListItem>
             <asp:ListItem Text="Malariae" Value="Malarie"></asp:ListItem>
             <asp:ListItem Text="Non specificabile" Value="Non specificabile"></asp:ListItem>
             <asp:ListItem Text="Forme miste" Value="Forme miste"></asp:ListItem>
             </asp:DropDownList>
             <label class="label" style="width:200px">Se Forme miste, specificare: </label>
             <asp:TextBox ID="formeMisteSpecificare" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
            <p>
               <label class="label">Terapia</label>
               <asp:DropDownList ID="terapia" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Alofantrina" Value="Alofantrina"></asp:ListItem>
                    <asp:ListItem Text="Artemeter" Value="Artemeter"></asp:ListItem>
                    <asp:ListItem Text="Artemeter + Lumefantrina" Value="Artemeter + Lumefantrina"></asp:ListItem>
                    <asp:ListItem Text="Atovaquone + Proguanile" Value="Atovaquone + Proguanile"></asp:ListItem>
                    <asp:ListItem Text="Chinino + Doxicilina" Value="Chinino + Doxicilina"></asp:ListItem>
                    <asp:ListItem Text="Clorochina" Value="Clorochina"></asp:ListItem>
                    <asp:ListItem Text="Meflochina" Value="Meflochina"></asp:ListItem>
                    <asp:ListItem Text="Sulfadossina + Pirimetamina" Value="Sulfadossina + Pirimetamina"></asp:ListItem>
                    <asp:ListItem Text="Sulfalene + Pirimetatina" Value="Sulfalene + Pirimetatina"></asp:ListItem>
                    <asp:ListItem Text="Altra" Value="Altra"></asp:ListItem>
               </asp:DropDownList>
               <label class="label" style="width:150px">Se altra, specificare</label>
               <asp:TextBox ID="altraTerapia" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
            <p>
               <label class="label">Farmaco resistenza a:</label>
               <asp:TextBox ID="faramcoResistenza" runat="server" Width="500px" Height="100px" CssClass="textBox" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
            </p>
            <p>
                <label class="label" style="width:300px">Da chi ha ricevuto informazioni sulla prevenzione della malaria ?</label>
                        <asp:DropDownList ID="prevenzioneRicevuta" runat="server" CssClass="dropdown" >
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                        <asp:ListItem Text="Nessuno" Value="Nessuno"></asp:ListItem>
                        <asp:ListItem Text="Igiene pubblica" Value="Igiene pubblica"></asp:ListItem>
                        <asp:ListItem Text="Malattie infettive" Value="Malattie infettive"></asp:ListItem>
                        <asp:ListItem Text="Medico di base" Value="Medico di base"></asp:ListItem>
                        <asp:ListItem Text="Agenzie di viaggio" Value="Agenzie di viaggio"></asp:ListItem>
                        <asp:ListItem Text="Farmacista" Value="Farmacista"></asp:ListItem>
                        <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                </asp:DropDownList>
                <label class="label" style="width:150px">se altro, specificare:</label>
                <asp:TextBox ID="AltroEnte" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
             <label class="sezione">Chemioprofilassi</label>
             <hr />
            <p>
            <label class="label"  style="width:180px">Chemioprofilassi effettuata ?</label>
            <asp:DropDownList ID="chemioprofilassi" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>                
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
            </asp:DropDownList>
            <label class="label">se si, specificare</label>
            <asp:DropDownList ID="farmaciChemioprofilassi" runat="server" CssClass="dropdown" >
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="Clorochina" Value="Clorochina"></asp:ListItem>
                <asp:ListItem Text="Clorochina + proguanile" Value="Clorochina + proguanile"></asp:ListItem>
                <asp:ListItem Text="Meflochina" Value="Meflochina"></asp:ListItem>
                <asp:ListItem Text="Doxiciclina" Value="Doxiciclina"></asp:ListItem>
                <asp:ListItem Text="Atovaquone + proguanile" Value="Atovaquone + proguanile"></asp:ListItem>
            </asp:DropDownList>            
            </p>
            <p>
            <label class="label" style="width:300px">Durante il periodo sono saltate alcune assunzioni ?</label>
            <asp:DropDownList ID="assunzioniInterrotte" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <label class="label" style="width:450px">La chemioprofilassi è stata completata per 4 settimane dopo il rientro ?</label>
            <asp:DropDownList ID="chemioProfilassiCompletata" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <label class="label" style="width:200px">Se no, specificare il motivo:</label>
                <asp:DropDownList ID="motivoInterruzione" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="Dimenticanza" Value="Dimenticanza"></asp:ListItem>
                <asp:ListItem Text="Il viaggio era finito" Value="Il viaggio era finito"></asp:ListItem>
                <asp:ListItem Text="Effetti collaterali" Value="Effetti collaterali"></asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
            <label class="label" style="width:160px">Effetto collaterale 1</label>
            <asp:DropDownList ID="Effetto1" runat="server" CssClass="dropdown" >
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>  
                <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>                              
                <asp:ListItem Text="Alopecia" Value="Alopecia"></asp:ListItem>                
                <asp:ListItem Text="Alterazione unghie" Value="Alterazione unghie"></asp:ListItem>
                <asp:ListItem Text="Alterazione dell'emocromo" Value="Alterazione dell'emocromo"></asp:ListItem>
                <asp:ListItem Text="Alterazioni dell'umore" Value="Alterazioni dell'umore"></asp:ListItem>                
                <asp:ListItem Text="Alterazione renali" Value="Alterazione renali"></asp:ListItem>
                <asp:ListItem Text="Anoressie" Value="Anoressie"></asp:ListItem>
                <asp:ListItem Text="Ansia" Value="Ansia"></asp:ListItem>
                <asp:ListItem Text="Aumento transaminasi" Value="Aumento transaminasi"></asp:ListItem>
                <asp:ListItem Text="Cefalea" Value="Cefalea"></asp:ListItem>
                <asp:ListItem Text="Convulsioni" Value="Convulsioni"></asp:ListItem>                
                <asp:ListItem Text="Candidasi vaginale" Value="Candidasi vaginale"></asp:ListItem>
                <asp:ListItem Text="Dolori addominali" Value="Dolori addominali"></asp:ListItem>
                <asp:ListItem Text="Diarrea" Value="Diarrea"></asp:ListItem>
                <asp:ListItem Text="Discrasie ematiche" Value="Discrasie ematiche"></asp:ListItem>
                <asp:ListItem Text="Disturbi gastrointestinali" Value="Disturbi gastrointestinali"></asp:ListItem>
                <asp:ListItem Text="Epatite" Value="Epatite"></asp:ListItem>
                <asp:ListItem Text="Eruzioni cutanee" Value="Eruzioni cutanee"></asp:ListItem>                
                <asp:ListItem Text="Esantema" Value="Esantema"></asp:ListItem>
                <asp:ListItem Text="Emolisi e metaemoglobinopatia" Value="Emolisi e metaemoglobinopatia"></asp:ListItem>                
                <asp:ListItem Text="Fotofobia" Value="Fotofobia"></asp:ListItem>
                <asp:ListItem Text="Fotosensibilità" Value="Fotosensibilità"></asp:ListItem>            
                <asp:ListItem Text="Incubi" Value="Incubi"></asp:ListItem>
                <asp:ListItem Text="Insonnia" Value="Insonnia"></asp:ListItem>
                <asp:ListItem Text="Irratabilità" Value="Irratabilità"></asp:ListItem>
                <asp:ListItem Text="Nausea" Value="Nausea"></asp:ListItem>
                <asp:ListItem Text="Opacità corneale reversibile" Value="Opacità corneale reversibile"></asp:ListItem>
                <asp:ListItem Text="Prurito" Value="Prurito"></asp:ListItem>
                <asp:ListItem Text="Psicosi" Value="Psicosi"></asp:ListItem>                
                <asp:ListItem Text="Retinopatia" Value="Retinopatia"></asp:ListItem>
                <asp:ListItem Text="Reazioni allergiche" Value="Reazioni allergiche"></asp:ListItem>
                <asp:ListItem Text="Ulcere del cavo orale" Value="Ulcere del cavo orale"></asp:ListItem>
                <asp:ListItem Text="Vertigini" Value="Vertigini"></asp:ListItem>
                <asp:ListItem Text="Vomito" Value="Vomito"></asp:ListItem>                
            </asp:DropDownList>
            <label class="label" style="width:150px"> Se altro, specificare</label>
            <asp:TextBox ID="altroEffetto1Specificare" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
            <p>
            <label class="label" style="width:160px">Effetto collaterale 2</label>
            <asp:DropDownList ID="Effetto2" runat="server" CssClass="dropdown" >
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>  
                <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>                              
                <asp:ListItem Text="Alopecia" Value="Alopecia"></asp:ListItem>                
                <asp:ListItem Text="Alterazione unghie" Value="Alterazione unghie"></asp:ListItem>
                <asp:ListItem Text="Alterazione dell'emocromo" Value="Alterazione dell'emocromo"></asp:ListItem>
                <asp:ListItem Text="Alterazioni dell'umore" Value="Alterazioni dell'umore"></asp:ListItem>                
                <asp:ListItem Text="Alterazione renali" Value="Alterazione renali"></asp:ListItem>
                <asp:ListItem Text="Anoressie" Value="Anoressie"></asp:ListItem>
                <asp:ListItem Text="Ansia" Value="Ansia"></asp:ListItem>
                <asp:ListItem Text="Aumento transaminasi" Value="Aumento transaminasi"></asp:ListItem>
                <asp:ListItem Text="Cefalea" Value="Cefalea"></asp:ListItem>
                <asp:ListItem Text="Convulsioni" Value="Convulsioni"></asp:ListItem>                
                <asp:ListItem Text="Candidasi vaginale" Value="Candidasi vaginale"></asp:ListItem>
                <asp:ListItem Text="Dolori addominali" Value="Dolori addominali"></asp:ListItem>
                <asp:ListItem Text="Diarrea" Value="Diarrea"></asp:ListItem>
                <asp:ListItem Text="Discrasie ematiche" Value="Discrasie ematiche"></asp:ListItem>
                <asp:ListItem Text="Disturbi gastrointestinali" Value="Disturbi gastrointestinali"></asp:ListItem>
                <asp:ListItem Text="Epatite" Value="Epatite"></asp:ListItem>
                <asp:ListItem Text="Eruzioni cutanee" Value="Eruzioni cutanee"></asp:ListItem>                
                <asp:ListItem Text="Esantema" Value="Esantema"></asp:ListItem>
                <asp:ListItem Text="Emolisi e metaemoglobinopatia" Value="Emolisi e metaemoglobinopatia"></asp:ListItem>                
                <asp:ListItem Text="Fotofobia" Value="Fotofobia"></asp:ListItem>
                <asp:ListItem Text="Fotosensibilità" Value="Fotosensibilità"></asp:ListItem>            
                <asp:ListItem Text="Incubi" Value="Incubi"></asp:ListItem>
                <asp:ListItem Text="Insonnia" Value="Insonnia"></asp:ListItem>
                <asp:ListItem Text="Irratabilità" Value="Irratabilità"></asp:ListItem>
                <asp:ListItem Text="Nausea" Value="Nausea"></asp:ListItem>
                <asp:ListItem Text="Opacità corneale reversibile" Value="Opacità corneale reversibile"></asp:ListItem>
                <asp:ListItem Text="Prurito" Value="Prurito"></asp:ListItem>
                <asp:ListItem Text="Psicosi" Value="Psicosi"></asp:ListItem>                
                <asp:ListItem Text="Retinopatia" Value="Retinopatia"></asp:ListItem>
                <asp:ListItem Text="Reazioni allergiche" Value="Reazioni allergiche"></asp:ListItem>
                <asp:ListItem Text="Ulcere del cavo orale" Value="Ulcere del cavo orale"></asp:ListItem>
                <asp:ListItem Text="Vertigini" Value="Vertigini"></asp:ListItem>
                <asp:ListItem Text="Vomito" Value="Vomito"></asp:ListItem>        
            </asp:DropDownList>
            <label class="label" style="width:150px"> Se altro, specificare</label>
            <asp:TextBox ID="altroEffetto2Specificare" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
             <label class="sezione">Misure di prevenzione</label>
             <hr />
            <p>
            <label class="label" style="width:430px">le hanno consigliato misure di protezione contro le punture di zanzare ? </label>
            <asp:DropDownList ID="protezionePunture" runat="server" CssClass="dropdown">
            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
            <asp:ListItem Text="si" Value="si"></asp:ListItem>
            <asp:ListItem Text="no" Value="no"></asp:ListItem>
            </asp:DropDownList>            
            </p>
            <p>
            <label class="label" style="width:400px">Ha dormito protetto da zanzariere nelle zone a rischio ?</label>
            <asp:DropDownList ID="zanzareZoneRischio" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="Mai" Value="Mai"></asp:ListItem>
                <asp:ListItem Text="Saltuariamente" Value="Saltuariamente"></asp:ListItem>
                <asp:ListItem Text="Sempre" Value="Sempre"></asp:ListItem>
            </asp:DropDownList>            
            </p>
            <p>
            <label class="label" style="width:200px">Ha usato repellenti cutanei ?</label>
            <asp:DropDownList ID="Repellenti" runat="server" CssClass="dropdown" >
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="Mai" Value="Mai"></asp:ListItem>
                <asp:ListItem Text="Saltuariamente" Value="Saltuariamente"></asp:ListItem>
                <asp:ListItem Text="Sempre" Value="Sempre"></asp:ListItem>
            </asp:DropDownList>            
            <label class="label" style="width:150px">Se usati, specificare </label>
            <asp:TextBox ID="specificaRepellente" runat="server" CssClass="textBox" MaxLength="200"></asp:TextBox>
            </p>
            <asp:Panel ID="pnlEmoscopia" runat="server" Enabled = "false">
            <label class="sezione">Riservato Ministero e ISS</label>
            <hr />
            <p>
            <label class="label" style="width:150px">Emoscopia pervenuta</label>
            <asp:DropDownList ID="Emoscopiapervenuta" runat="server" CssClass="textBox">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>    
            </asp:DropDownList>
            </p>
            <p>
            <label class="label" style="width:150px">Emoscopia controllo</label>
            <asp:DropDownList ID="Emoscopiacontrollo" runat="server" CssClass="textBox">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>                
            </asp:DropDownList>
            </p>
            </asp:Panel>            
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
