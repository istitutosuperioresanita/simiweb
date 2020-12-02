<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcMib.ascx.vb" Inherits="_UserControl_Applicazione_UcMib" %>
<p  style="padding-left:550px">
    <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>

</p>
<fieldset style="padding-right:30px">
    <legend><label class="sezione">Mib Informazioni aggiuntive</label></legend>
            <hr />

            <div style="width:100%">
               <div style="float:left">
               <p>
             <asp:Label ID="sepsiLabel"  runat="server" Text="sespsi" Width="120px" AssociatedControlID="sepsi"  CssClass="labelBold" ></asp:Label>
            <asp:Label ID="sepsi" runat="server" CssClass="label" />


            <asp:Label ID="meningiteLabel" runat="server" Text="meningite" Width="120px" AssociatedControlID="meningite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="meningite" runat="server" CssClass="label" />


            <asp:Label ID="celluliteLabel" runat="server" Text="cellulite" Width="120px" AssociatedControlID="cellulite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="cellulite" runat="server" CssClass="label" />
            </p>
            <p>


            <asp:Label ID="epiglottiteLabel" runat="server" Text="epiglottite" Width="120px" AssociatedControlID="epiglottite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="epiglottite" runat="server" CssClass="label" />


            <asp:Label ID="peritoniteLabel" runat="server" Text="peritonite" Width="120px" AssociatedControlID="peritonite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="peritonite" runat="server" CssClass="label" />


            <asp:Label ID="pericarditeLabel" runat="server" Text="pericardite" Width="120px"     AssociatedControlID="pericardite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="pericardite" runat="server" CssClass="label" />
            </p>
            <p>

            <asp:Label ID="artriteLabel" runat="server"  Text="artrite settica/osteomielite" Width="120px" AssociatedControlID="artrite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="artrite" runat="server" CssClass="label" />

            <asp:Label ID="PolmoniteLabel" runat="server" Text="Polmonite" Width="120px" AssociatedControlID="polmonite" CssClass="labelBold"></asp:Label>
            <asp:Label ID="polmonite" runat="server" CssClass="label" />

            <asp:Label ID="altraDiagnosiLabel" runat="server" Text="Altra" Width="120px" AssociatedControlID="altraDiagnosi" CssClass="labelBold"></asp:Label>
            <asp:Label ID="altraDiagnosi" runat="server" CssClass="label" />
            </p>
            <p>
            
            <asp:Label ID="altroDiagnosiDescrLabel" runat="server" CssClass="labelBold" Text="Se altra, " AssociatedControlID="altroDiagnosiDescr"></asp:Label>
            <asp:Label ID="altroDiagnosiDescr" runat="server" CssClass="label"></asp:Label>
            </p>
            <label class="sezione">Esito</label>
            <hr />
            <p>
            <asp:Label ID="EsitoLabel"  runat="server" AssociatedControlID="Esito"  CssClass="labelBold" Width="300px" >Al momento della segnalazione il paziente è ? :</asp:Label>
            <asp:Label ID="Esito" runat="server"  CssClass="label">
            </asp:Label>
            </p>
            <p>
            <asp:Label ID="Esito14GiorniLabel"  runat="server" AssociatedControlID="Esito14Giorni"  CssClass="labelBold" Width="300px" >Esito conosciuto della malattia a 14 giorni ?</asp:Label>
            <asp:Label ID="Esito14Giorni" runat="server"  CssClass="label">
            </asp:Label>
            </p>
            <label class="sezione">Sequele a 30 gg</label>
            <hr />
        <p>
            <label class="labelBold">Sequele</label>
            <asp:Label ID="sequele" runat="server">
            </asp:Label>
        </p>
         <p>              

            <asp:Label ID="Label1"  runat="server" Text="Perdita anche parziale dell'udito" Width="250px" AssociatedControlID="SequeleUdito"  CssClass="labelBold" ></asp:Label>
            <asp:Label ID="SequeleUdito" runat="server" CssClass="label" />            
            <asp:Label ID="Label4" runat="server" Text="Amputazioni" Width="250px" AssociatedControlID="SequeleAmputazione" CssClass="labelBold"></asp:Label>
            <asp:label ID="SequeleAmputazione" runat="server" CssClass="label" />
        </p>
         <p>    
            
            <asp:Label ID="Label2" runat="server" Text="Perdita anche parziale della vista" Width="250px" AssociatedControlID="SequelVista" CssClass="labelBold"></asp:Label>
            <asp:Label ID="SequelVista" runat="server" CssClass="label" />
            <asp:Label ID="Label5" runat="server" Text="Necrosi e cicatrici a livello cutaneo" Width="250px" AssociatedControlID="SequeleNecrosi" CssClass="labelBold"></asp:Label>
            <asp:Label ID="SequeleNecrosi" runat="server" CssClass="label" />
        </p>
         <p>    
            
            <asp:Label ID="Label3" runat="server" Text="Danni neurologici compresi quelli motori" Width="250px" AssociatedControlID="SequeleNeuro" CssClass="labelBold"></asp:Label>
            <asp:Label ID="SequeleNeuro" runat="server" CssClass="label" />
            <asp:Label ID="Label6" runat="server" Text="Altro, specificare" Width="250px"     AssociatedControlID="SequeleAltro" CssClass="labelBold"></asp:Label>
            <asp:Label ID="SequeleAltro" runat="server" CssClass="label" />
            <asp:Label ID="SequeleAltroSpecificare" runat="server" CssClass="label"></asp:Label>
        </p>
        <label class="sezione">Fattori predisponenti la malattia batterico invasiva</label>
        <hr />
        <p>
            <label class="labelBold">Fattori</label>
            <asp:Label ID="fattori" runat="server">
            </asp:Label>
        </p>
        <div class="header container">

            <div class="col col-1">
	        <label style="width:250px"  class="labelBold">Asplenia anatomica/funzionale</label><asp:Label  runat="server" id="Asplenia" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Immunodeficienza congenita</label><asp:Label  runat="server" id="Immunodeficienza" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Leucemie/linfomi</label><asp:Label  runat="server"  id="Leucemie" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Altre neoplasie</label><asp:Label  runat="server"  id="Neoplasie" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Terapie immuno-soppressive</label><asp:Label  runat="server" id="TerapieImmuno" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Trapianto d'organo o di midollo</label><asp:Label  runat="server" id="Trapianto" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Impianto cocleare</label><asp:Label  runat="server" id="Cocleare" CssClass="label" /><br /><br />

        </div>
        <div class="col col-2">

	        <label style="width:250px"  class="labelBold">Fistole liquorali</label><asp:Label  runat="server" id="Fistole" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Immunodeficienza acquisita</label><asp:Label  runat="server" id="Immunodeficienzaacquisita" CssClass="label"  /><br /><br />
	        <label style="width:250px"  class="labelBold">Insufficienza renale cronica/Dialisi</label><asp:Label  runat="server" id="Insufficenzarenale" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Diabete mellito</label><asp:Label  runat="server" id="Diabete" CssClass="label"  /><br /><br />
	        <label style="width:250px"  class="labelBold">Epatopatia </label><asp:Label  runat="server" id="Epatopatia" CssClass="label" /><br/><br />
	        <label style="width:250px"  class="labelBold">Cardiopatie</label><asp:Label  runat="server" id="Cardiopatie" CssClass="label" /><br /><br />
	        <label style="width:250px"  class="labelBold">Asma/enfisema</label><asp:Label  runat="server" id="Asma" CssClass="label" /><br /><br />
            </div>
            <div class="col col-3">

	        <label style="width:250px"   class="labelBold">Tossicodipendenza ev</label><asp:Label  runat="server" id="Tossicodipendenza" CssClass="label" /><br /><br />
	        <label style="width:250px"   class="labelBold">Alcolismo</label><asp:Label  runat="server" id="Alcolismo" CssClass="label" /><br /><br />
	        <label style="width:250px"   class="labelBold">Tabagismo</label><asp:Label  runat="server" id="Tabagismo" CssClass="label" /><br /><br />
            <label style="width:250px"   class="labelBold">Emoglobinopatie</label><asp:Label  runat="server" id="Con_Emoglobinopatie" /><br /><br />            
            <label style="width:250px"   class="labelBold">Deficit fattori del complemento</label><asp:Label  runat="server" id="Con_Deficit" /><br /><br />            
            <label style="width:250px"   class="labelBold">Altre malattie polmonari croniche</label><asp:Label  runat="server" id="Con_altrePolmonari" /><br /><br />            
	        <label style="width:250px"   class="labelBold">Altra Condizione</label><asp:Label  runat="server" id="Altrocondizione" CssClass="label"  /><br /><br />
	        <label style="width:250px"   class="labelBold"><asp:Label  runat="server" id="AltraCondizionedescrizione" CssClass="label" MaxLength="50"/></label>

            </div>
        </div>        
            <label class="sezione">Agente eziologico</label>
            <hr />
            <p>
                <asp:Label ID="agenteEziologicoLabel" runat="server" Text="Agente Eziologico" Width="150px" AssociatedControlID="agenteEziologico" CssClass="labelBold"></asp:Label>                
                <asp:Label id="agenteEziologico" runat="server" CssClass="label">

                </asp:Label>
            </p>
            <p>
            <asp:Label ID="AltroAgenteLabel" runat="server" Text="Altro Agente" Width="150px" AssociatedControlID="altroAgente" CssClass="labelBold"></asp:Label>                
            <asp:Label ID="AltroAgente" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
            <asp:Label ID="liquorLabel" runat="server" Text="Se agente non identificato il Liquor era:" Width="250px" AssociatedControlID="liquor" CssClass="labelBold"></asp:Label>                           
            <asp:Label id="liquor" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="NoteLabel" runat="server" Text="Note su diagnosi eziologica" Width="150px" AssociatedControlID="noteDiagnosi" CssClass="labelBold"></asp:Label>                
                <asp:Label ID="noteDiagnosi" runat="server"  CssClass="label" Width="400px" Height="100px"></asp:Label>
            </p>
            <label class="sezione">Diagnosi laboratorio periferico</label>
            <hr />                 
            <p>
                <asp:Label ID="dataPrelievoLabel" runat="server" Text="data Prelievo primo campione positivo" Width="200px" AssociatedControlID="dataPrelievo" CssClass="labelBold"></asp:Label>
                <asp:Label ID="dataPrelievo" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="ContattoLabLabel" runat="server" Text="Persona contatto laboratorio" Width="200px" AssociatedControlID="ContattoLab" CssClass="labelBold"></asp:Label>
                <asp:Label ID="ContattoLab" runat="server" CssClass="label"></asp:Label>
            </p>

            <p>
                <asp:Label ID="contattoTelLabel" runat="server" Text="Telefono Laboratorio" AssociatedControlID="contattoTelefono" CssClass="labelBold"></asp:Label>
                <asp:Label ID="contattoTelefono" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="contattoOspedaleLabel" runat="server" Text="Telefono Laboratorio" AssociatedControlID="contattoOspedaleLabel" CssClass="labelBold"></asp:Label>
                <asp:Label ID="ContattoOspedale" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Metodo1Label" runat="server" Text="Metodo diagnostico 1" AssociatedControlID="Metodo1" CssClass="labelBold"></asp:Label>
                <asp:Label ID="Metodo1" runat="server" CssClass="label"></asp:Label>

                <asp:Label ID="Materiale1Label" runat="server" Text="Materiale 1" AssociatedControlID="Materiale1" CssClass="labelBold"></asp:Label>
                <asp:Label ID="Materiale1" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Metodo2Label" runat="server" Text="Metodo diagnostico 2" AssociatedControlID="Metodo2" CssClass="labelBold"></asp:Label>
                <asp:Label ID="Metodo2" runat="server" CssClass="label"></asp:Label>
                <asp:Label ID="Materiale2LAbel" runat="server" Text="Materiale 2" AssociatedControlID="Materiale2" CssClass="labelBold"></asp:Label>
                <asp:Label ID="Materiale2" runat="server" CssClass="label"></asp:Label>
            </p>

            <label class="sezione">Tipizzazione</label>
            <hr />
            <p>
                <asp:Label ID="tipizzazioneLabel" runat="server" Text="Tipizzazione" Width="150px" AssociatedControlID="tipizzazione" CssClass="labelBold"></asp:Label>                                
                <asp:Label ID="Tipizzazione" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="LaboratorioTipizzazioneLabel" runat="server" Width="400px" Text="Se si, Riferimenti Laboratorio"  AssociatedControlID="LabTipizzazione" CssClass="labelBold"></asp:Label>                
                <asp:Label ID="LabTipizzazione" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="labbatteriolabel" runat="server" Text="specie batterio" Width="150px" AssociatedControlID="labBatterio" CssClass="labelBold"></asp:Label>                                        
                <asp:Label ID="labBatterio" runat="server" CssClass="label"></asp:Label>                
            </p>
            <p>
                <asp:Label ID="altroBatterioLabel" runat="server" Text="se altro, specificare" AssociatedControlID="LabAltroBatterio" CssClass="labelBold"></asp:Label>                
                <asp:Label ID="LabAltroBatterio" runat="server" CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="SierogruppoMeningoccoLabel" runat="server" Text="Sierogruppo Meningocco" Width="150px" AssociatedControlID="LabSierogruppoMen" CssClass="labelBold"></asp:Label>                
                <asp:Label ID="LabSierogruppoMen" runat="server" CssClass="label"></asp:Label>                
            </p>
            <p>
                <asp:Label ID="SierotipoPnuLabel" runat="server" Text="Sierotipo Pneumococco" Width="150px" AssociatedControlID="LabSierotipoPNU" CssClass="labelBold"></asp:Label>                
                <asp:Label ID="LabSierotipoPNU" runat="server"  CssClass="label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="SirotipoHILabel" runat="server" Text="Sierotipo Haemophilus influenzae"  Width="200px" AssociatedControlID="LabSierotipoHI" CssClass="labelBold"></asp:Label>
                <asp:Label ID="LabSierotipoHI" runat="server" CssClass="label"></asp:Label>	
            </p>
            <p>
                <asp:Label ID="AltroSierotipoLabel" runat="server" Text="Altro sierotipo" AssociatedControlID="AltroSierotipo" CssClass="labelBold"></asp:Label>
                <asp:Label ID="AltroSierotipo" runat="server" CssClass="label"></asp:Label>             
            </p>
            <label class="sezione">Antibiogramma</label>
            <hr />
            <p>
                <asp:Label ID="AntibiogrammaLabel" runat="server" Text="Antibiogramma" AssociatedControlID="Antibiogramma" CssClass="labelBold"></asp:Label>
                <asp:Label ID="Antibiogramma" runat="server" CssClass="label"></asp:Label>             
            </p>
    <div id="antibioticoDIV" style="padding-left:50px">
    
                <p>
                    <label class="labelBold">Penicillina</label>
                    <label class="labelBold">Mic</label>
                    <asp:Label ID="Pg_Val" runat="server" CssClass="label" Width="10px"></asp:Label>
                    <asp:Label ID="Pg_Mic" runat="server" CssClass="label"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Pg_Cat" runat="server" CssClass="label">

                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Etest</label>
                    <asp:Label ID="Pg_Val_Est" runat="server" CssClass="label" Width="10px"></asp:Label>
                    <asp:Label ID="Pg_Mic_Est" runat="server" CssClass="label"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Pg_Cat_ESt" runat="server" CssClass="label">

                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Disco(mm)</label>
                    <asp:Label ID="Pg_disco" runat="server" CssClass="label" Width="120px"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Pg_Disco_Cat" runat="server" CssClass="label" >
                   
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold">Ciprofloxacina</label>
                    <label class="labelBold">Mic</label>
                    <asp:Label ID="Cip_Val" runat="server" CssClass="label" Width="10px">
                                   
                    </asp:Label>
                    <asp:Label ID="Cip_Mic" runat="server" CssClass="label">
                      
                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cip_Cat" runat="server" CssClass="label">

                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Etest</label>
                    <asp:Label ID="Cip_Val_Est" runat="server" CssClass="label" Width="10px">
                  
                    </asp:Label>
                    <asp:Label ID="Cip_Mic_Est" runat="server" CssClass="label"> 
           
                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cip_Cat_Est" runat="server" CssClass="label">

                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Disco(mm)</label>
                    <asp:Label ID="Cip_Disco" runat="server" CssClass="label" Width="120px"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cip_Disco_Cat" runat="server" CssClass="label">
                   
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold">Clindamicina</label>
                    <label class="labelBold">Mic</label>
                    <asp:Label ID="Cli_Val" runat="server" CssClass="label" Width="10px">

                    </asp:Label>
                    <asp:Label ID="Cli_Mic" runat="server" CssClass="label">

                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cli_Cat" runat="server" CssClass="label">
            
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Etest</label>
                    <asp:Label ID="Cli_Val_Est" runat="server" CssClass="label" Width="10px">

                    </asp:Label>
                    <asp:Label ID="Cli_Mic_Est" runat="server" CssClass="label">

                    
                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cli_Cat_Est" runat="server" CssClass="label">

                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Disco(mm)</label>
                    <asp:Label ID="Cli_Disco" runat="server" CssClass="label" Width="120px"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Cli_Disco_Cat" runat="server" CssClass="label">
                 
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold">Eritromicina</label>
                    <label class="labelBold">Mic</label>
                    <asp:Label ID="Em_val" runat="server" CssClass="label" Width="10px">
         
                    </asp:Label>
                    <asp:Label ID="Em_Mic" runat="server" CssClass="label">
       
                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Em_Cat" runat="server" CssClass="label">
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Etest</label>
                    <asp:Label ID="Em_val_est" runat="server" CssClass="label" Width="10px">               
                    </asp:Label>
                    <asp:Label ID="Em_Mic_Est" runat="server" CssClass="label">                   
                    </asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Em_Cat_Est" runat="server" CssClass="label">                
                    </asp:Label>
                </p>
                <p>
                    <label class="labelBold"></label>
                    <label class="labelBold">Disco(mm)</label>
                    <asp:Label ID="Em_disco" runat="server" CssClass="label" Width="120px"></asp:Label>
                    <label class="labelBold" style="width:35px">Cat</label>
                    <asp:Label ID="Em_Disco_Cat" runat="server" CssClass="label">
                    </asp:Label>
                </p>
                </div>
            <p>
                <asp:Label ID="lblNote" runat="server" Text="Note" AssociatedControlID="noteTipizzazione" CssClass="labelBold"></asp:Label>
                <asp:Label ID="noteTipizzazione" runat="server" CssClass="text" Width="400px" Height="100px"></asp:Label>
            </p>
            </div>
            </div>
</fieldset>  