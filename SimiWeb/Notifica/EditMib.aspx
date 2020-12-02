<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
 ClientIDMode="Static"
CodeFile="EditMib.aspx.vb" Inherits="Notifica_EditMib" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Js/tbc.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="Js/Mib.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Malattia Batterico invasiva informazioni aggiuntive</b>
        </div >  
         <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
        
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <br />
                     <hr />
            <label class="sezione">Quadro clinico</label>
            <asp:Label ID="dataWeb" runat="server" Visible="false"></asp:Label>
            <hr />
            <p>
              
            <asp:CheckBox ID="sepsi" runat="server" CssClass="checkBox" />
             <asp:Label ID="sepsiLabel"  runat="server" Text="sepsi" Width="150px" AssociatedControlID="sepsi"  CssClass="label" ></asp:Label>
            
            <asp:CheckBox ID="meningite" runat="server" CssClass="checkBox" />
            <asp:Label ID="meningiteLabel" runat="server" Text="meningite" Width="150px" AssociatedControlID="meningite" CssClass="label"></asp:Label>

            <asp:CheckBox ID="cellulite" runat="server" CssClass="checkBox" />
            <asp:Label ID="celluliteLabel" runat="server" Text="cellulite" Width="150px" AssociatedControlID="cellulite" CssClass="label"></asp:Label>
            </p>
            <p>

            <asp:CheckBox ID="epiglottite" runat="server" CssClass="checkBox" />
            <asp:Label ID="epiglottiteLabel" runat="server" Text="epiglottite" Width="150px" AssociatedControlID="epiglottite" CssClass="label"></asp:Label>


            <asp:CheckBox ID="peritonite" runat="server" CssClass="checkBox" />
            <asp:Label ID="peritoniteLabel" runat="server" Text="peritonite" Width="150px" AssociatedControlID="peritonite" CssClass="label"></asp:Label>

            <asp:CheckBox ID="pericardite" runat="server" CssClass="checkBox" />
            <asp:Label ID="pericarditeLabel" runat="server" Text="pericardite" Width="150px"     AssociatedControlID="pericardite" CssClass="label"></asp:Label>
            </p>
            <p>
            <asp:CheckBox ID="artrite" runat="server" CssClass="checkBox" />
            <asp:Label ID="artriteLabel" runat="server"  Text="artrite settica/osteomielite" Width="150px" AssociatedControlID="artrite" CssClass="label"></asp:Label>

            <asp:CheckBox ID="polmonite" runat="server" CssClass="checkBox" />
            <asp:Label ID="polmoniteLabel" runat="server" Text="polmonite batteriemica" Width="150px" AssociatedControlID="polmonite" CssClass="label"></asp:Label>

            <asp:CheckBox ID="altraDiagnosi" runat="server" CssClass="checkBox" />
            <asp:Label ID="altraDiagnosiLabel" runat="server" Text="Altra" Width="150px" AssociatedControlID="altraDiagnosi" CssClass="label"></asp:Label>
            </p>
            <p>
            
            <asp:Label ID="altroDiagnosiDescrLabel" runat="server" CssClass="label" Text="Se altra, " AssociatedControlID="altroDiagnosiDescr"></asp:Label>
            <asp:TextBox ID="altroDiagnosiDescr" runat="server" CssClass="textBox"></asp:TextBox>

            </p>
            <label class="sezione">Esito</label>
            <p>

                <asp:Label ID="EsitoLabel"  runat="server" AssociatedControlID="Esito"  CssClass="label" Width="300px" >Al momento della segnalazione il paziente è ? :</asp:Label>
                <asp:DropDownList ID="Esito" runat="server"  CssClass="dropdown">
                <asp:ListItem Text="Selezionare" Value=""></asp:ListItem>
                <asp:ListItem Text="Non noto" Value="NN"></asp:ListItem>
                <asp:ListItem Text="guarito" Value="guarito"></asp:ListItem>
                <asp:ListItem Text="deceduto" Value="deceduto"></asp:ListItem>
                <asp:ListItem Text="ancora in trattamento" Value="trattamento"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="Esito14GiorniLabel"  runat="server" AssociatedControlID="Esito14Giorni"  CssClass="label" Width="300px" >Esito conosciuto della malattia a 14 giorni ?</asp:Label>
                <asp:DropDownList ID="Esito14Giorni" runat="server"  CssClass="dropdown">
                <asp:ListItem Text="Selezionare" Value=""></asp:ListItem>
                <asp:ListItem Text="Non noto" Value="NN"></asp:ListItem>
                <asp:ListItem Text="guarito" Value="guarito"></asp:ListItem>
                <asp:ListItem Text="deceduto" Value="deceduto"></asp:ListItem>
                <asp:ListItem Text="ancora in trattamento" Value="trattamento"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <label class="sezione">Agente eziologico</label>
            <hr />
            <p>

                <asp:Label ID="agenteEziologicoLabel" runat="server" Text="Agente Eziologico" Width="150px" AssociatedControlID="agenteEziologico" CssClass="label"></asp:Label>                
                <asp:DropDownList id="agenteEziologico" runat="server" CssClass="dropdown">
<%--                        <asp:ListItem Value="" Text="Non identificato"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Streptococco di gruppo B"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Pneumococco"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Meningococco"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Haemophilius Influenzae"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Micobacterium tubercularis"></asp:ListItem>
                        <asp:ListItem Value="6" Text="Listeria"></asp:ListItem>
                        <asp:ListItem Value="8" Text="Altro"></asp:ListItem>--%>
                </asp:DropDownList>
            </p>
            <asp:Panel ID="pnlAltroAgente" runat="server">
                    <p>
                    <asp:Label ID="AltroAgenteLabel" runat="server" Text="Altro Agente" Width="150px" AssociatedControlID="altroAgente" CssClass="label"></asp:Label>                
                    <asp:TextBox ID="AltroAgente" runat="server" CssClass="textBox"></asp:TextBox>
                    </p>
                    <p>
                    <asp:Label ID="liquorLabel" runat="server" Text="Se agente non identificato il Liquor era:" Width="250px" AssociatedControlID="liquor" CssClass="label"></asp:Label>                           
                    <asp:DropDownList id="liquor" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="" Text="Non indicato"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Purulento"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Torbido"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Opalescente"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Limpido"></asp:ListItem>
                    </asp:DropDownList>
                    </p>
            </asp:Panel>
            <p>
                <asp:Label ID="NoteLabel" runat="server" Text="Note su diagnosi eziologica" Width="150px" AssociatedControlID="noteDiagnosi" CssClass="label" ></asp:Label>                
                <asp:TextBox ID="noteDiagnosi" runat="server" CssClass="textBox" Width="350px"></asp:TextBox>
            </p>
            <label class="sezione">Sequele a 30 gg</label>
            <hr />
        <p>
            <label class="label">Sequele</label>
            <asp:DropDownList ID="sequele" runat="server">
                <asp:ListItem Text="Selezionare" Value=""></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
            </asp:DropDownList>
        </p>
         <p>              
            <asp:CheckBox ID="SequeleUdito" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label1"  runat="server" Text="Perdita anche parziale dell'udito" Width="250px" AssociatedControlID="SequeleUdito"  CssClass="label" ></asp:Label>
            <asp:CheckBox ID="SequeleAmputazione" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label4" runat="server" Text="Amputazioni" Width="250px" AssociatedControlID="SequeleAmputazione" CssClass="label"></asp:Label>
        </p>
         <p>    
            <asp:CheckBox ID="SequelVista" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label2" runat="server" Text="Perdita anche parziale della vista" Width="250px" AssociatedControlID="SequelVista" CssClass="label"></asp:Label>
            <asp:CheckBox ID="SequeleNecrosi" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label5" runat="server" Text="Necrosi e cicatrici a livello cutaneo" Width="250px" AssociatedControlID="SequeleNecrosi" CssClass="label"></asp:Label>
        </p>
         <p>    
            <asp:CheckBox ID="SequeleNeuro" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label3" runat="server" Text="Danni neurologici compresi quelli motori" Width="250px" AssociatedControlID="SequeleNeuro" CssClass="label"></asp:Label>
            <asp:CheckBox ID="SequeleAltro" runat="server" CssClass="checkBox" />
            <asp:Label ID="Label6" runat="server" Text="Altro, specificare" Width="250px"     AssociatedControlID="SequeleAltro" CssClass="label"></asp:Label>
            <asp:TextBox ID="SequeleAltroSpecificare" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        <label class="sezione">Fattori predisponenti la malattia batterico invasiva</label>
        <hr />
        <p>
            <label class="label">Fattori</label>
            <asp:DropDownList ID="fattori" runat="server">
                <asp:ListItem Text="Selezionare" Value=""></asp:ListItem>
                <asp:ListItem Text="no" Value="no"></asp:ListItem>
                <asp:ListItem Text="si" Value="si"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <div class="header container">

            <div class="col col-1">
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="Asplenia" />Asplenia anatomica/funzionale</label><br /><br />
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="Immunodeficienza" />Immunodeficienza congenita</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server"  id="Leucemie" />Leucemie/linfomi</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server"  id="Neoplasie" />Altre neoplasie</label><br /><br />
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="TerapieImmuno" />Terapie immuno-soppressive</label><br /><br />
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="Trapianto" />Trapianto d'organo o di midollo</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Cocleare" />Impianto cocleare</label><br /><br />

        </div>
        <div class="col col-2 custom-width">

	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Fistole" />Fistole liquorali</label><br /><br />
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="Immunodeficienzaacquisita" />Immunodeficienza acquisita</label><br /><br />
	        <label style="width:250px" class="label"><asp:CheckBox  runat="server" id="Insufficenzarenale" />Insufficienza renale cronica/Dialisi</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Diabete" />Diabete mellito</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Epatopatia" />Epatopatia </label><br/><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Cardiopatie" />Cardiopatie</label><br /><br />
	        <label style="width:250px"  class="label"><asp:CheckBox  runat="server" id="Asma" />Asma/enfisema</label><br /><br />
            </div>
            <div class="col col-3">

	        <label style="width:250px"><asp:CheckBox  runat="server" id="Tossicodipendenza" />Tossicodipendenza ev</label><br /><br />
	        <label class="label" style="width:250px"><asp:CheckBox  runat="server" id="Alcolismo" />Alcolismo</label><br /><br />
	        <label class="label" style="width:250px"><asp:CheckBox  runat="server" id="Tabagismo" />Tabagismo</label><br /><br />
            <label class="label" style="width:250px"><asp:CheckBox  runat="server" id="Con_Emoglobinopatie" />Emoglobinopatie</label><br /><br />
            <label class="label" style="width:250px"><asp:CheckBox  runat="server" id="Con_Deficit" />Deficit fattori del complemento</label><br /><br />            
            <label class="label" style="width:250px"><asp:CheckBox  runat="server" id="Con_altrePolmonari" />Altre malattie polmonari croniche</label><br /><br />            
	        <label  style="width:250px" class="label"><asp:CheckBox  runat="server" id="Altrocondizione" />Altra Condizione</label><br /><br />
	        <label class="label"><asp:Textbox  runat="server" id="AltraCondizionedescrizione" CssClass="textBox" MaxLength="50"/></label>

            </div>
        </div>
        <label class="sezione">Diagnosi laboratorio periferico</label>
            <hr />                 
            <p>
                <asp:Label ID="dataPrelievoLabel" runat="server" Text="data Prelievo primo campione positivo" AssociatedControlID="dataPrelievo" CssClass="label" Width="150px"></asp:Label>
                <asp:TextBox ID="dataPrelievo" runat="server" CssClass="textBox" Width="250px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="ContattoLabLabel" runat="server" Text="Persona contatto laboratorio" AssociatedControlID="ContattoLab" CssClass="label" Width="150px"></asp:Label>
                <asp:TextBox ID="ContattoLab" runat="server" CssClass="textBox" Width="350px"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="contattoTelLabel" runat="server" Text="Telefono Laboratorio" AssociatedControlID="contattoTelefono" CssClass="label" Width="150px"></asp:Label>
                <asp:TextBox ID="contattoTelefono" runat="server" CssClass="textBox" Width="350px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="contattoOspedaleLabel" runat="server" Text="Contatto Ospedale" AssociatedControlID="contattoOspedaleLabel" CssClass="label" Width="250px" ></asp:Label>
                <asp:TextBox ID="ContattoOspedale" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Metodo1Label" runat="server" Text="Metodo diagnostico 1" AssociatedControlID="Metodo1" CssClass="label" ></asp:Label>
                <asp:DropDownList ID="Metodo1" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>
                    <asp:ListItem Value="Coltura" Text="Coltura"></asp:ListItem>
                    <asp:ListItem Value="Ricerca antigene" Text="Ricerca antigene"></asp:ListItem>
                    <asp:ListItem Value="Pcr" Text="Pcr"></asp:ListItem>
                    <asp:ListItem Value="Es. microscopico diretto" Text="Es. microscopico diretto"></asp:ListItem>                  
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqMetodo" runat="server" ControlToValidate="Metodo1" CssClass="alert" Text="*" ValidationGroup="form" ></asp:RequiredFieldValidator>

                <asp:Label ID="Materiale1Label" runat="server" Text="Materiale" AssociatedControlID="Materiale1" CssClass="label"></asp:Label>
                <asp:DropDownList ID="Materiale1" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>
                    <asp:ListItem Value="Sangue" Text="Sangue"></asp:ListItem>
                    <asp:ListItem Value="Liquor" Text="Liquor"></asp:ListItem>
                    <asp:ListItem Value="Liquido pleurico" Text="Liquido pleurico"></asp:ListItem>
                    <asp:ListItem Value="Liquido peritoneale" Text="Liquido peritoneale"></asp:ListItem>
                    <asp:ListItem Value="Liquido pericardio" Text="Liquido pericardio"></asp:ListItem>
                    <asp:ListItem Value="Liquido sinoviale" Text="Liquido sinoviale"></asp:ListItem>
                    <asp:ListItem Value="Petecchie" Text="Petecchie"></asp:ListItem>
                    <asp:ListItem Value="Placenta" Text="Placenta"></asp:ListItem>
                    <asp:ListItem Value="materiale autoptico da sito sterile" Text="materiale autoptico da sito sterile"></asp:ListItem>        
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="reqMateriale" runat="server" ControlToValidate="Materiale1" InitialValue="" CssClass="alert" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:Label ID="Metodo2Label" runat="server" Text="Metodo diagnostico 2" AssociatedControlID="Metodo2" CssClass="label"></asp:Label>
                <asp:DropDownList ID="Metodo2" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>
                    <asp:ListItem Value="Coltura" Text="Coltura"></asp:ListItem>
                    <asp:ListItem Value="Ricerca antigene" Text="Ricerca antigene"></asp:ListItem>
                    <asp:ListItem Value="Pcr" Text="Pcr"></asp:ListItem>
                    <asp:ListItem Value="Es. microscopico diretto" Text="Es. microscopico diretto"></asp:ListItem>
                                        
                </asp:DropDownList>
                <asp:Label ID="Materiale2LAbel" runat="server" Text="Materiale 2" AssociatedControlID="Materiale2" CssClass="label"></asp:Label>
                <asp:DropDownList ID="Materiale2" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>
                    <asp:ListItem Value="Sangue" Text="Sangue"></asp:ListItem>
                    <asp:ListItem Value="Liquor" Text="Liquor"></asp:ListItem>
                    <asp:ListItem Value="Liquido pleurico" Text="Liquido pleurico"></asp:ListItem>
                    <asp:ListItem Value="Liquido peritoneale" Text="Liquido peritoneale"></asp:ListItem>
                    <asp:ListItem Value="Liquido pericardio" Text="Liquido pericardio"></asp:ListItem>
                    <asp:ListItem Value="Liquido sinoviale" Text="Liquido sinoviale"></asp:ListItem>
                    <asp:ListItem Value="Petecchie" Text="Petecchie"></asp:ListItem>
                    <asp:ListItem Value="Placenta" Text="Placenta"></asp:ListItem>          
                    <asp:ListItem Value="materiale autoptico da sito sterile" Text="materiale autoptico da sito sterile"></asp:ListItem>          
                            
                </asp:DropDownList>
            </p>
            <asp:Panel ID="Pnltipizzazione" runat="server">
            <label class="sezione">Tipizzazione</label>
            <hr />
            <p>
                <asp:Label ID="tipizzazioneLabel" runat="server" Text="Tipizzazione" Width="150px" AssociatedControlID="tipizzazione" CssClass="label"></asp:Label>                                
                <asp:DropDownList ID="Tipizzazione" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                    <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="LaboratorioTipizzazioneLabel" runat="server" Width="150px" Text="Se si, Riferimenti Laboratorio"  AssociatedControlID="LabTipizzazione" CssClass="label"></asp:Label>                
                <asp:TextBox ID="LabTipizzazione" runat="server" CssClass="textBox"  Width="400px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="labbatteriolabel" runat="server" Text="specie batterio" Width="150px" AssociatedControlID="labBatterio" CssClass="label"></asp:Label>                                        
                <asp:DropDownList ID="labBatterio" runat="server" CssClass="dropdown">
<%--                <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>
                <asp:ListItem Value="1" Text="Meningococco"></asp:ListItem>
                <asp:ListItem Value="2" Text="Haemophilus influenzae"></asp:ListItem>
                <asp:ListItem Value="3" Text="Pneumococco"></asp:ListItem>
                <asp:ListItem Value="8" Text="Altro"></asp:ListItem>--%>
                </asp:DropDownList>                
            </p>
            <p>
                <asp:Label ID="altroBatterioLabel" runat="server" Text="se altro, specificare" AssociatedControlID="LabAltroBatterio" Width="150px" CssClass="label"></asp:Label>                
                <asp:TextBox ID="LabAltroBatterio" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="SierogruppoMeningoccoLabel" runat="server" Text="Sierogruppo meningocco" Width="150px" AssociatedControlID="LabSierogruppoMen" CssClass="label"></asp:Label>                
                <asp:DropDownList ID="LabSierogruppoMen" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Non indicato"></asp:ListItem>
                    <asp:ListItem Value="ND" Text="Non effettuato"></asp:ListItem>
                    <asp:ListItem Value="NG" Text="Non gruppabile"></asp:ListItem>
                    <asp:ListItem Value="NA" Text="Non agglutinabile"></asp:ListItem>
                    <asp:ListItem Value="NV" Text="Non vitale"></asp:ListItem>
                    <asp:ListItem Value="A" Text="A"></asp:ListItem>
                    <asp:ListItem Value="B" Text="B"></asp:ListItem>
                    <asp:ListItem Value="C" Text="C"></asp:ListItem>
                    <asp:ListItem Value="Y" Text="Y"></asp:ListItem>
                    <asp:ListItem Value="W" Text="W"></asp:ListItem>
                    <asp:ListItem Value="AD" Text="AD"></asp:ListItem>
                    <asp:ListItem Value="XZ" Text="XZ"></asp:ListItem>
                    <asp:ListItem Value="PO" Text="PO"></asp:ListItem>
                    <asp:ListItem Value="CW" Text="CW"></asp:ListItem>
                    <asp:ListItem Value="X" Text="X"></asp:ListItem>
                </asp:DropDownList>                
            </p>
            <p>
                <asp:Label ID="SierotipoPnuLabel" runat="server" Text="Sierotipo Pneumococco" Width="150px" AssociatedControlID="LabSierotipoPNU" CssClass="label"></asp:Label>                
                <asp:DropDownList ID="LabSierotipoPNU" runat="server"  CssClass="dropdown">
                        <asp:ListItem Value="" Text="Non indicato"></asp:ListItem>		
			            <asp:ListItem Value="NT" Text="NT"></asp:ListItem>
			            <asp:ListItem Value="NTYP" Text="NTYP"></asp:ListItem>					
			            <asp:ListItem Value="Unk" Text="Unk"></asp:ListItem>
			            <asp:ListItem Value="0" Text="O"></asp:ListItem>
			            <asp:ListItem Value="1" Text="1"></asp:ListItem>
			            <asp:ListItem Value="2" Text="2"></asp:ListItem>
			            <asp:ListItem Value="3" Text="3"></asp:ListItem>
			            <asp:ListItem Value="4" Text="4"></asp:ListItem>
			            <asp:ListItem Value="5" Text="5"></asp:ListItem>
			            <asp:ListItem Value="6" Text="6"></asp:ListItem>
			            <asp:ListItem Value="6A" Text="6A"></asp:ListItem>
			            <asp:ListItem Value="6B" Text="6B"></asp:ListItem>
			            <asp:ListItem Value="6C" Text="6C"></asp:ListItem>
			            <asp:ListItem Value="6D" Text="6D"></asp:ListItem>
			            <asp:ListItem Value="7" Text="7"></asp:ListItem>
			            <asp:ListItem Value="7A" Text="7A"></asp:ListItem>
			            <asp:ListItem Value="7B" Text="7B"></asp:ListItem>
			            <asp:ListItem Value="7C" Text="7C"></asp:ListItem>
			            <asp:ListItem Value="7F" Text="7F"></asp:ListItem>
			            <asp:ListItem Value="8" Text="8"></asp:ListItem>
			            <asp:ListItem Value="9" Text="9"></asp:ListItem>
			            <asp:ListItem Value="9A" Text="9A"></asp:ListItem>
			            <asp:ListItem Value="9L" Text="9L"></asp:ListItem>
			            <asp:ListItem Value="9N" Text="9N"></asp:ListItem>
			            <asp:ListItem Value="9V" Text="9V"></asp:ListItem>
			            <asp:ListItem Value="10" Text="10"></asp:ListItem>
			            <asp:ListItem Value="10A" Text="10A"></asp:ListItem>
			            <asp:ListItem Value="10B" Text="10B"></asp:ListItem>
			            <asp:ListItem Value="10C" Text="10C"></asp:ListItem>
			            <asp:ListItem Value="10F" Text="10F"></asp:ListItem>
			            <asp:ListItem Value="11" Text="11"></asp:ListItem>
			            <asp:ListItem Value="11A" Text="11A"></asp:ListItem>
			            <asp:ListItem Value="11B" Text="11B"></asp:ListItem>
			            <asp:ListItem Value="11C" Text="11C"></asp:ListItem>
			            <asp:ListItem Value="11D" Text="11D"></asp:ListItem>
			            <asp:ListItem Value="11F" Text="11F"></asp:ListItem>
			            <asp:ListItem Value="12" Text="12"></asp:ListItem>
			            <asp:ListItem Value="12A" Text="12A"></asp:ListItem>
			            <asp:ListItem Value="12B" Text="12B"></asp:ListItem>
			            <asp:ListItem Value="12F" Text="12F"></asp:ListItem>
			            <asp:ListItem Value="13" Text="13"></asp:ListItem>
			            <asp:ListItem Value="14" Text="14"></asp:ListItem>
			            <asp:ListItem Value="15" Text="15"></asp:ListItem>
			            <asp:ListItem Value="15A" Text="15A"></asp:ListItem>
			            <asp:ListItem Value="15B" Text="15B"></asp:ListItem>
			            <asp:ListItem Value="15C" Text="15C"></asp:ListItem>
			            <asp:ListItem Value="15B/C" Text="15B/C"></asp:ListItem>
			            <asp:ListItem Value="15F" Text="15F"></asp:ListItem>
			            <asp:ListItem Value="16" Text="16"></asp:ListItem>
			            <asp:ListItem Value="16A" Text="16A"></asp:ListItem>
			            <asp:ListItem Value="16F" Text="16F"></asp:ListItem>
			            <asp:ListItem Value="17" Text="17"></asp:ListItem>
			            <asp:ListItem Value="17A" Text="17A"></asp:ListItem>
			            <asp:ListItem Value="17F" Text="17F"></asp:ListItem>
			            <asp:ListItem Value="18" Text="18"></asp:ListItem>
			            <asp:ListItem Value="18A" Text="18A"></asp:ListItem>
			            <asp:ListItem Value="18B" Text="18B"></asp:ListItem>
			            <asp:ListItem Value="18C" Text="18C"></asp:ListItem>
			            <asp:ListItem Value="18F" Text="18F"></asp:ListItem>
			            <asp:ListItem Value="19" Text="19"></asp:ListItem>
			            <asp:ListItem Value="19A" Text="19A"></asp:ListItem>
			            <asp:ListItem Value="19B" Text="19B"></asp:ListItem>
			            <asp:ListItem Value="19C" Text="19C"></asp:ListItem>
			            <asp:ListItem Value="19F" Text="19F"></asp:ListItem>
			            <asp:ListItem Value="20" Text="20"></asp:ListItem>
			            <asp:ListItem Value="21" Text="21"></asp:ListItem>
			            <asp:ListItem Value="22" Text="22"></asp:ListItem>
			            <asp:ListItem Value="22A" Text="22A"></asp:ListItem>
			            <asp:ListItem Value="22F" Text="22F"></asp:ListItem>
			            <asp:ListItem Value="23" Text="23"></asp:ListItem>
			            <asp:ListItem Value="23A" Text="23A"></asp:ListItem>
			            <asp:ListItem Value="23B" Text="23B"></asp:ListItem>
			            <asp:ListItem Value="23F" Text="23F"></asp:ListItem>
			            <asp:ListItem Value="24" Text="24"></asp:ListItem>
			            <asp:ListItem Value="24A" Text="24A"></asp:ListItem>
			            <asp:ListItem Value="24B" Text="24B"></asp:ListItem>
			            <asp:ListItem Value="24F" Text="24F"></asp:ListItem>
			            <asp:ListItem Value="25" Text="25"></asp:ListItem>
			            <asp:ListItem Value="25A" Text="25A"></asp:ListItem>
			            <asp:ListItem Value="25F" Text="25F"></asp:ListItem>
			            <asp:ListItem Value="27" Text="27"></asp:ListItem>
			            <asp:ListItem Value="28" Text="28"></asp:ListItem>
			            <asp:ListItem Value="28A" Text="28A"></asp:ListItem>
			            <asp:ListItem Value="28F" Text="28F"></asp:ListItem>
			            <asp:ListItem Value="29" Text="29"></asp:ListItem>
			            <asp:ListItem Value="31" Text="31"></asp:ListItem>
			            <asp:ListItem Value="32" Text="32"></asp:ListItem>
			            <asp:ListItem Value="32A" Text="32A"></asp:ListItem>
			            <asp:ListItem Value="32F" Text="32F"></asp:ListItem>
			            <asp:ListItem Value="33" Text="33"></asp:ListItem>
			            <asp:ListItem Value="33A" Text="33A"></asp:ListItem>
			            <asp:ListItem Value="33B" Text="33B"></asp:ListItem>
			            <asp:ListItem Value="33C" Text="33C"></asp:ListItem>
			            <asp:ListItem Value="33D" Text="33D"></asp:ListItem>
			            <asp:ListItem Value="33F" Text="33F"></asp:ListItem>
			            <asp:ListItem Value="34" Text="34"></asp:ListItem>
			            <asp:ListItem Value="35" Text="35"></asp:ListItem>
			            <asp:ListItem Value="35A" Text="35A"></asp:ListItem>
			            <asp:ListItem Value="35B" Text="35B"></asp:ListItem>
			            <asp:ListItem Value="35C" Text="35C"></asp:ListItem>
			            <asp:ListItem Value="35F" Text="35F"></asp:ListItem>
			            <asp:ListItem Value="36" Text="36"></asp:ListItem>
			            <asp:ListItem Value="37" Text="37"></asp:ListItem>
			            <asp:ListItem Value="38" Text="38"></asp:ListItem>
			            <asp:ListItem Value="39" Text="39"></asp:ListItem>
			            <asp:ListItem Value="40" Text="40"></asp:ListItem>
			            <asp:ListItem Value="41" Text="41"></asp:ListItem>
			            <asp:ListItem Value="41A" Text="41A"></asp:ListItem>
			            <asp:ListItem Value="41F" Text="41F"></asp:ListItem>
			            <asp:ListItem Value="42" Text="42"></asp:ListItem>
			            <asp:ListItem Value="43" Text="43"></asp:ListItem>
			            <asp:ListItem Value="44" Text="44"></asp:ListItem>
			            <asp:ListItem Value="45" Text="45"></asp:ListItem>
			            <asp:ListItem Value="46" Text="46"></asp:ListItem>
			            <asp:ListItem Value="47" Text="47"></asp:ListItem>
			            <asp:ListItem Value="47A" Text="47A"></asp:ListItem>
			            <asp:ListItem Value="47F" Text="47F"></asp:ListItem>
			            <asp:ListItem Value="48" Text="48"></asp:ListItem>
                </asp:DropDownList>
                </p>
            <p>
                <asp:Label ID="SirotipoHILabel" runat="server" Text="Sierotipo Haemophilus influenzae" AssociatedControlID="LabSierotipoHI" CssClass="label"  Width= "150px"></asp:Label>
                   <asp:DropDownList ID="LabSierotipoHI" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Non indicato"></asp:ListItem>
                    <asp:ListItem Value="Unk" Text="Sconosciuto"></asp:ListItem>
                    <asp:ListItem Value="O" Text="Altro"></asp:ListItem>
                    <asp:ListItem Value="A" Text="A"></asp:ListItem>
                    <asp:ListItem Value="B" Text="B"></asp:ListItem>
                    <asp:ListItem Value="C" Text="C"></asp:ListItem>
                    <asp:ListItem Value="D" Text="D"></asp:ListItem>
                    <asp:ListItem Value="E" Text="E"></asp:ListItem>
                    <asp:ListItem Value="F" Text="F"></asp:ListItem>
                    <asp:ListItem Value="non-b" Text="NON-B"></asp:ListItem>
                    <asp:ListItem Value="non-caps" Text="NON-CAPS"></asp:ListItem>
                </asp:DropDownList>	
            </p>
            <p>
                <asp:Label ID="AltroSierotipoLabel" runat="server" Text="Altro sierotipo" AssociatedControlID="AltroSierotipo" CssClass="label"  Width="150px"></asp:Label>
                <asp:TextBox ID="AltroSierotipo" runat="server" CssClass="textBox"></asp:TextBox>             
            </p>
                <label class="sezione">Antibiogramma</label>
                <hr />
                <p>
                    <label class="label" style="width:150px">Antibiogramma</label>
                    <asp:DropDownList ID="antibioticoResistenza" runat="server" CssClass="dropdown" >                        
                        <asp:ListItem  Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem  Text="Si" Value="Si"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div id="antibioticoDIV" style="padding-left:50px">
                <p>
                    <label class="label">Penicillina</label>
                    <label class="label">Mic</label>
                    <asp:DropDownList ID="Pg_Val" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="<" Value="<"></asp:ListItem>
                    <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                    <asp:ListItem Text="=" Value="="></asp:ListItem>
                    <asp:ListItem Text=">" Value=">"></asp:ListItem>
                    <asp:ListItem Text=">=" Value=">="></asp:ListItem>                    							
                    </asp:DropDownList>
                    <asp:DropDownList ID="Pg_Mic" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
						<asp:ListItem Text="0.002" Value="0.002"></asp:ListItem>
						<asp:ListItem Text="0.003" Value="0.003"></asp:ListItem>
						<asp:ListItem Text="0.004" Value="0.004"></asp:ListItem>
						<asp:ListItem Text="0.006" Value="0.006"></asp:ListItem>
						<asp:ListItem Text="0.012" Value="0.012"></asp:ListItem>
						<asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>											
                        <asp:ListItem Text="0.023" Value="0.023"></asp:ListItem>			
						<asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>
						<asp:ListItem Text="0.047" Value="0.047"></asp:ListItem>
						<asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>
						<asp:ListItem Text="0.094" value="0.094"></asp:ListItem>
						<asp:ListItem Text="0.125" value="0.125"></asp:ListItem>						
						<asp:ListItem Text="0.19" value="0.19"></asp:ListItem>
						<asp:ListItem Text="0.25" value="0.25"></asp:ListItem>																		
   						<asp:ListItem Text="0.38" value="0.38"></asp:ListItem>																		
   						<asp:ListItem Text="0.50" value="0.50"></asp:ListItem>																		
   						<asp:ListItem Text="0.75" value="0.75"></asp:ListItem>																		
   						<asp:ListItem Text="1.0" value="1.0"></asp:ListItem>																		
   						<asp:ListItem Text="1.5" value="1.5"></asp:ListItem>																		
   						<asp:ListItem Text="2" value="2"></asp:ListItem>																		
   						<asp:ListItem Text="3" value="3"></asp:ListItem>																		
   						<asp:ListItem Text="4" value="4"></asp:ListItem>																		
   						<asp:ListItem Text="6" value="6"></asp:ListItem>																		
   						<asp:ListItem Text="8" value="8"></asp:ListItem>																		
   						<asp:ListItem Text="12" Value="12"></asp:ListItem>																		
   						<asp:ListItem Text="16" Value="16"></asp:ListItem>																		
   						<asp:ListItem Text="24" Value="24"></asp:ListItem>																		
   						<asp:ListItem Text="32" Value="32"></asp:ListItem>
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Pg_Cat" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="S" Value="S"></asp:ListItem>
                            <asp:ListItem Text="I" Value="I"></asp:ListItem>
                            <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Etest</label>
                    <asp:DropDownList ID="Pg_Val_Est" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>   
                    </asp:DropDownList>
                    <asp:DropDownList ID="Pg_Mic_Est" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>  
                            <asp:ListItem Text="0.002" Value="0.002"></asp:ListItem>
   						    <asp:ListItem Text="0.004" Value="0.004"></asp:ListItem>
   						    <asp:ListItem Text="0.008" Value="0.008"></asp:ListItem>
   						    <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>
   						    <asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>
   						    <asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>
   						    <asp:ListItem Text="0.12"  Value="0.12"></asp:ListItem>
   						    <asp:ListItem Text="0.25"  Value="0.25"></asp:ListItem>
   						    <asp:ListItem Text="0.5"   Value="0.5"></asp:ListItem>
   						    <asp:ListItem Text="1"     Value="1"></asp:ListItem>
   						    <asp:ListItem Text="2"     Value="2"></asp:ListItem>
   						    <asp:ListItem Text="4"     Value="4"></asp:ListItem>
   						    <asp:ListItem Text="8"     Value="8"></asp:ListItem>
   						    <asp:ListItem Text="16"    Value="16"></asp:ListItem>
   						    <asp:ListItem Text="32"    Value="32"></asp:ListItem>                     
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Pg_Cat_ESt" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Disco(mm)</label>
                    <asp:TextBox ID="Pg_disco" runat="server" CssClass="textBox" Width="100px"></asp:TextBox>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Pg_Disco_Cat" runat="server" CssClass="dropdown" >
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>                    
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label">Ciprofloxacina</label>
                    <label class="label">Mic</label>
                    <asp:DropDownList ID="Cip_Val" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>                                        
                    </asp:DropDownList>
                    <asp:DropDownList ID="Cip_Mic" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
						<asp:ListItem Text="0.002" Value="0.002"></asp:ListItem>
						<asp:ListItem Text="0.003" Value="0.003"></asp:ListItem>
						<asp:ListItem Text="0.004" Value="0.004"></asp:ListItem>
						<asp:ListItem Text="0.006" Value="0.006"></asp:ListItem>
						<asp:ListItem Text="0.012" Value="0.012"></asp:ListItem>
						<asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>											
                        <asp:ListItem Text="0.023" Value="0.023"></asp:ListItem>			
						<asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>
						<asp:ListItem Text="0.047" Value="0.047"></asp:ListItem>
						<asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>
						<asp:ListItem Text="0.094" value="0.094"></asp:ListItem>
						<asp:ListItem Text="0.125" value="0.125"></asp:ListItem>						
						<asp:ListItem Text="0.19" value="0.19"></asp:ListItem>
						<asp:ListItem Text="0.25" value="0.25"></asp:ListItem>																		
   						<asp:ListItem Text="0.38" value="0.38"></asp:ListItem>																		
   						<asp:ListItem Text="0.50" value="0.50"></asp:ListItem>																		
   						<asp:ListItem Text="0.75" value="0.75"></asp:ListItem>																		
   						<asp:ListItem Text="1.0" value="1.0"></asp:ListItem>																		
   						<asp:ListItem Text="1.5" value="1.5"></asp:ListItem>																		
   						<asp:ListItem Text="2" value="2"></asp:ListItem>																		
   						<asp:ListItem Text="3" value="3"></asp:ListItem>																		
   						<asp:ListItem Text="4" value="4"></asp:ListItem>																		
   						<asp:ListItem Text="6" value="6"></asp:ListItem>																		
   						<asp:ListItem Text="8" value="8"></asp:ListItem>																		
   						<asp:ListItem Text="12" Value="12"></asp:ListItem>																		
   						<asp:ListItem Text="16" Value="16"></asp:ListItem>																		
   						<asp:ListItem Text="24" Value="24"></asp:ListItem>																		
   						<asp:ListItem Text="32" Value="32"></asp:ListItem>                          
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cip_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Etest</label>
                    <asp:DropDownList ID="Cip_Val_Est" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>                     
                    </asp:DropDownList>
                    <asp:DropDownList ID="Cip_Mic_Est" runat="server" CssClass="dropdown"> 
                            <asp:ListItem Text="" Value=""></asp:ListItem>                                             
                            <asp:ListItem Text="0.002" Value="0.002"></asp:ListItem>
   						    <asp:ListItem Text="0.004" Value="0.004"></asp:ListItem>
   						    <asp:ListItem Text="0.008" Value="0.008"></asp:ListItem>
   						    <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>
   						    <asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>
   						    <asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>
   						    <asp:ListItem Text="0.12"  Value="0.12"></asp:ListItem>
   						    <asp:ListItem Text="0.25"  Value="0.25"></asp:ListItem>
   						    <asp:ListItem Text="0.5"   Value="0.5"></asp:ListItem>
   						    <asp:ListItem Text="1"     Value="1"></asp:ListItem>
   						    <asp:ListItem Text="2"     Value="2"></asp:ListItem>
   						    <asp:ListItem Text="4"     Value="4"></asp:ListItem>
   						    <asp:ListItem Text="8"     Value="8"></asp:ListItem>
   						    <asp:ListItem Text="16"    Value="16"></asp:ListItem>
   						    <asp:ListItem Text="32"    Value="32"></asp:ListItem>            
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cip_Cat_Est" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Disco(mm)</label>
                    <asp:TextBox ID="Cip_Disco" runat="server" CssClass="textBox" Width="100px"></asp:TextBox>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cip_Disco_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>                    
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label">Clindamicina</label>
                    <label class="label">Mic</label>
                    <asp:DropDownList ID="Cli_Val" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem> 
                    </asp:DropDownList>
                    <asp:DropDownList ID="Cli_Mic" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="" Value=""></asp:ListItem>  
                        <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>  
						<asp:ListItem Text="0.023" Value="0.023"></asp:ListItem>  
						<asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>  
						<asp:ListItem Text="0.047" Value="0.047"></asp:ListItem>  
						<asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>  
						<asp:ListItem Text="0.094" Value="0.094"></asp:ListItem>  						
						<asp:ListItem Text="0.125" Value="0.125"></asp:ListItem>  						
						<asp:ListItem Text="0.19" Value="0.19"></asp:ListItem>  
						<asp:ListItem Text="0.25" Value="0.25"></asp:ListItem>  
						<asp:ListItem Text="0.38" Value="0.38"></asp:ListItem>  
						<asp:ListItem Text="0.50" Value="0.50"></asp:ListItem>  
						<asp:ListItem Text="0.75" Value="0.75"></asp:ListItem>  					
						<asp:ListItem Text="1.0" Value="1.0"></asp:ListItem>  
						<asp:ListItem Text="1.5" Value="1.5"></asp:ListItem>  																	
   						<asp:ListItem Text="2" Value="2"></asp:ListItem>  																		
   						<asp:ListItem Text="3" Value="3"></asp:ListItem>  																		
   						<asp:ListItem Text="4" Value="4"></asp:ListItem>  																		
   						<asp:ListItem Text="6" Value="6"></asp:ListItem>  																		
   						<asp:ListItem Text="8" Value="8"></asp:ListItem>  																		
   						<asp:ListItem Text="12" Value="12"></asp:ListItem>  																
   						<asp:ListItem Text="16" Value="16"></asp:ListItem>  																	
   						<asp:ListItem Text="24" Value="24"></asp:ListItem>  																		
   						<asp:ListItem Text="32" Value="32"></asp:ListItem>  																		
   						<asp:ListItem Text="48" Value="48"></asp:ListItem>  															
   						<asp:ListItem Text="64" Value="64"></asp:ListItem>  															
   						<asp:ListItem Text="96" Value="96"></asp:ListItem>  															
   						<asp:ListItem Text="128" Value="128"></asp:ListItem>  																
   						<asp:ListItem Text="192" Value="192"></asp:ListItem>  																					
   						<asp:ListItem Text="256" Value="256"></asp:ListItem>  

                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cli_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>                    
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Etest</label>
                    <asp:DropDownList ID="Cli_Val_Est" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem> 
                    </asp:DropDownList>
                    <asp:DropDownList ID="Cli_Mic_Est" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="" Value=""></asp:ListItem> 
                        <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem> 
                        <asp:ListItem Text="0.032" Value="0.032"></asp:ListItem> 
                        <asp:ListItem Text="0.064" Value="0.064"></asp:ListItem> 
                        <asp:ListItem Text="0.12"  Value="0.12"></asp:ListItem> 
                        <asp:ListItem Text="0.25" Value="0.25"></asp:ListItem> 
                        <asp:ListItem Text="0.5" Value="0.5"></asp:ListItem> 
                        <asp:ListItem Text="1" Value="1"></asp:ListItem> 
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>  
                        <asp:ListItem Text="4" Value="4"></asp:ListItem> 
                        <asp:ListItem Text="8" Value="8"></asp:ListItem> 
                        <asp:ListItem Text="16" Value="16"></asp:ListItem> 
                        <asp:ListItem Text="32" Value="32"></asp:ListItem> 
                        <asp:ListItem Text="64" Value="64"></asp:ListItem> 
                        <asp:ListItem Text="128" Value="128"></asp:ListItem> 
                        <asp:ListItem Text="256" Value="256"></asp:ListItem> 
                    
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cli_Cat_Est" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Disco(mm)</label>
                    <asp:TextBox ID="Cli_Disco" runat="server" CssClass="textBox" Width="100px"></asp:TextBox>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Cli_Disco_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>                    
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label">Eritromicina</label>
                    <label class="label">Mic</label>
                    <asp:DropDownList ID="Em_val" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>                     
                    </asp:DropDownList>
                    <asp:DropDownList ID="Em_Mic" runat="server" CssClass="dropdown">
                    
                        <asp:ListItem Text="" Value=""></asp:ListItem>  
                        <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem>  
						<asp:ListItem Text="0.023" Value="0.023"></asp:ListItem>  
						<asp:ListItem Text="0.032" Value="0.032"></asp:ListItem>  
						<asp:ListItem Text="0.047" Value="0.047"></asp:ListItem>  
						<asp:ListItem Text="0.064" Value="0.064"></asp:ListItem>  
						<asp:ListItem Text="0.094" Value="0.094"></asp:ListItem>  						
						<asp:ListItem Text="0.125" Value="0.125"></asp:ListItem>  						
						<asp:ListItem Text="0.19" Value="0.19"></asp:ListItem>  
						<asp:ListItem Text="0.25" Value="0.25"></asp:ListItem>  
						<asp:ListItem Text="0.38" Value="0.38"></asp:ListItem>  
						<asp:ListItem Text="0.50" Value="0.50"></asp:ListItem>  
						<asp:ListItem Text="0.75" Value="0.75"></asp:ListItem>  					
						<asp:ListItem Text="1.0" Value="1.0"></asp:ListItem>  
						<asp:ListItem Text="1.5" Value="1.5"></asp:ListItem>  																	
   						<asp:ListItem Text="2" Value="2"></asp:ListItem>  																		
   						<asp:ListItem Text="3" Value="3"></asp:ListItem>  																		
   						<asp:ListItem Text="4" Value="4"></asp:ListItem>  																		
   						<asp:ListItem Text="6" Value="6"></asp:ListItem>  																		
   						<asp:ListItem Text="8" Value="8"></asp:ListItem>  																		
   						<asp:ListItem Text="12" Value="12"></asp:ListItem>  																
   						<asp:ListItem Text="16" Value="16"></asp:ListItem>  																	
   						<asp:ListItem Text="24" Value="24"></asp:ListItem>  																		
   						<asp:ListItem Text="32" Value="32"></asp:ListItem>  																		
   						<asp:ListItem Text="48" Value="48"></asp:ListItem>  															
   						<asp:ListItem Text="64" Value="64"></asp:ListItem>  															
   						<asp:ListItem Text="96" Value="96"></asp:ListItem>  															
   						<asp:ListItem Text="128" Value="128"></asp:ListItem>  																
   						<asp:ListItem Text="192" Value="192"></asp:ListItem>  																					
   						<asp:ListItem Text="256" Value="256"></asp:ListItem>                     
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Em_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Etest</label>
                    <asp:DropDownList ID="Em_val_est" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="<" Value="<"></asp:ListItem>
                            <asp:ListItem Text="<=" Value="<="></asp:ListItem>
                            <asp:ListItem Text="=" Value="="></asp:ListItem>
                            <asp:ListItem Text=">" Value=">"></asp:ListItem>
                            <asp:ListItem Text=">=" Value=">="></asp:ListItem>                     
                    </asp:DropDownList>
                    <asp:DropDownList ID="Em_Mic_Est" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="" Value=""></asp:ListItem> 
                        <asp:ListItem Text="0.016" Value="0.016"></asp:ListItem> 
                        <asp:ListItem Text="0.032" Value="0.032"></asp:ListItem> 
                        <asp:ListItem Text="0.064" Value="0.064"></asp:ListItem> 
                        <asp:ListItem Text="0.12"  Value="0.12"></asp:ListItem> 
                        <asp:ListItem Text="0.25" Value="0.25"></asp:ListItem> 
                        <asp:ListItem Text="0.5" Value="0.5"></asp:ListItem> 
                        <asp:ListItem Text="1" Value="1"></asp:ListItem> 
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>  
                        <asp:ListItem Text="4" Value="4"></asp:ListItem> 
                        <asp:ListItem Text="8" Value="8"></asp:ListItem> 
                        <asp:ListItem Text="16" Value="16"></asp:ListItem> 
                        <asp:ListItem Text="32" Value="32"></asp:ListItem> 
                        <asp:ListItem Text="64" Value="64"></asp:ListItem> 
                        <asp:ListItem Text="128" Value="128"></asp:ListItem> 
                        <asp:ListItem Text="256" Value="256"></asp:ListItem> 
                    
                    </asp:DropDownList>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Em_Cat_Est" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>                    
                    </asp:DropDownList>
                </p>
                <p>
                    <label class="label"></label>
                    <label class="label">Disco(mm)</label>
                    <asp:TextBox ID="Em_disco" runat="server" CssClass="textBox" Width="100px"></asp:TextBox>
                    <label class="label" style="width:35px">Cat</label>
                    <asp:DropDownList ID="Em_Disco_Cat" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="S" Value="S"></asp:ListItem>
                    <asp:ListItem Text="I" Value="I"></asp:ListItem>
                    <asp:ListItem Text="R" Value="R"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                </div>

            <p>
                <asp:Label ID="lblNote" runat="server" Text="Note" AssociatedControlID="noteTipizzazione" CssClass="label"></asp:Label>
                <asp:TextBox ID="noteTipizzazione" runat="server" CssClass="text" Width="400px" Height="100px"></asp:TextBox>
            </p>
            </asp:Panel>
            <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />
            <p  style="padding-left:600px">
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla"  Visible="true" CausesValidation="false" UseSubmitBehavior="false"/>      
                <asp:Button ID="btn" runat="server" Text="Salva"  Visible="true" UseSubmitBehavior="false"/>                
            </p>
</div>         
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>




