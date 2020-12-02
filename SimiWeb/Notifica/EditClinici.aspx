<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false"
 CodeFile="EditClinici.aspx.vb" 
 Inherits="Notifica_EditClinici" 
 ClientIDMode="Static"
 EnableEventValidation="false" 
 %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../_Scripts/jquery_plugin/fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet" type="text/css" />
    <script src="../_Scripts/jquery_plugin/fancybox/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <script src="Js/Clinici.js" type="text/javascript"></script>
    <script src="../_Scripts/All/Geografiche.js" type="text/javascript"></script>
     <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {

        $("a#inline").fancybox({
            'hideOnContentClick': true
        });

        $("a#inline2").fancybox({
            'hideOnContentClick': true
        });

        $("a#inline3").fancybox({
            'hideOnContentClick': true
        });
    });
</script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
<div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -><b>Dati Clinici</b>
            
        </div >
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <asp:HiddenField ID="DataNascita" runat="server" />
        <asp:HiddenField ID="datasegnalazione" runat="server" />
        <asp:TextBox ID="dataweb" runat="server" Visible="false"></asp:TextBox>
        <br />
         <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
        <br />

        <label class="sezione">Dati clinici</label>
        <hr />
        <label>Tipo criterio</label>
        <br />
           <label class="label"  style="width:250px">tipo criterio per la definizio di caso europea</label>
            <br />      
                <asp:CheckBox ID="Clinico" runat="server" ClientIDMode="Static" CssClass="checkBox"  Text="Clinico" Width="110px"/>                                                 
                <a id="inline" href="#divClinici"><img id="Img1" src="../_Styles/All/images/question.png" alt="visualizza criterio" style="border:0px" /> </a>
                <div style="display:none">
                        <div runat="server" id="divClinici"></div>
                </div>                            
            <br />
                <asp:CheckBox ID="Epidemiologico" runat="server" CssClass="checkBox"    Text="Epidemiologico" Width="110px"/>                
                <a id="inline2" href="#divEpidemiologico"><img id="Img2" src="../_Styles/All/images/question.png" alt="visualizza criterio" style="border:0px" /> </a>
                <div style="display:none">
                        <div runat="server" id="divEpidemiologico"></div>
                </div>       
            <br />            
                <asp:CheckBox ID="Laboratorio" runat="server" CssClass="checkBox"  Text="Laboratorio" Width="110px"/> 
                <a id="inline3" href="#divLaboratorio"><img id="Img3" src="../_Styles/All/images/question.png" alt="visualizza criterio" style="border:0px" /> </a>
                <div style="display:none">
                        <div runat="server" id="divLaboratorio"></div>
                </div> 
        <br />
        <label class="sezione">Primi sintomi</label>
        <hr />
        <div style="padding-left:50px">
        <p>
            <asp:Label ID="DataPrimiSintomiLabel" runat="server" AssociatedControlID="DataPrimiSintomi" CssClass="label" >Data primi sintomi:</asp:Label>
            <asp:TextBox ID="DataPrimiSintomi" runat="server" CssClass="textBox"></asp:TextBox>  &nbsp;*    
            <asp:RequiredFieldValidator ID="ReqDataPrimiSintomi"  runat="server" InitialValue="" Text="*" ControlToValidate="DataPrimiSintomi" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               

        </p>
        <p>
            <asp:Label ID="NazioneSintomiLabel" runat="server" AssociatedControlID="NazioneSintomi" CssClass="label" Width="150px"  >Nazione primi sintomi:</asp:Label>
            <asp:DropDownList ID="NazioneSintomi" runat="server" CssClass="dropdown">
            </asp:DropDownList>                   
            <a href="#" onclick="ImpostaItalia('NazioneSintomi','sintomi');">Clicca qui per selezionare Italia</a>
        </p>
        <p>
            <asp:Label ID="ProvinciaPrimiSintomiLabel" runat="server" AssociatedControlID="ProvinciaSintomi" CssClass="label" Width="150px">Provincia primi sintomi:</asp:Label>
            <asp:DropDownList ID="ProvinciaSintomi" runat="server" CssClass="dropdown">
            </asp:DropDownList>
        </p>
        <p>            
            <asp:Label ID="ComuneSintomiLabel" runat="server" AssociatedControlID="ComuneSintomi" CssClass="label" Width="150px" >Comune primi sintomi:</asp:Label>
            <asp:DropDownList ID="ComuneSintomi" runat="server" CssClass="dropdown">
            </asp:DropDownList>
        </p>
        </div>
        <label class="sezione">Stato vaccinale</label>
        <hr />
        <p>
            <asp:Label ID="StatoVaccinaleLabel" runat="server" AssociatedControlID="StatoVaccinale" CssClass="label" Width="150px" >Paziente vaccinato:</asp:Label>
            <asp:DropDownList ID="StatoVaccinale" runat="server" CssClass="dropdown"  style="margin-left:25px;">
                <asp:ListItem Value ="" Text="Selezionare.."></asp:ListItem>
                <asp:ListItem Text="vaccino inesistente" Value="n.a."></asp:ListItem>    
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Text="non vaccinato" Value="non vaccinato"></asp:ListItem>
                <asp:ListItem Text="vaccinato regolarmente o parzialmente" Value="vaccinato"></asp:ListItem>                
            </asp:DropDownList>
        </p>
        <div style="padding-left:50px">
        <p>
            <i>Se vaccinato, specificare</i>
        </p>
        <p>
            <asp:Label ID="DoseVaccinoLabel" runat="server" AssociatedControlID="DoseVaccino" CssClass="label" >Dose vaccino:</asp:Label>
            <asp:TextBox ID="DoseVaccino" runat="server" CssClass="textBox"></asp:TextBox>             
        </p>
        <p>
            <asp:Label ID="DataDoseVaccinoLabel" runat="server" AssociatedControlID="DataDoseVaccino" CssClass="label" >Data ultima dose (o data somministrazione):</asp:Label>
            <asp:TextBox ID="DataDoseVaccino" runat="server" CssClass="textBox"></asp:TextBox>             
        </p>
        <p>
            <asp:Label ID="NomeCommercialeVaccinoLabel" runat="server" AssociatedControlID="NomeCommercialeVaccino" CssClass="label" >Nome commerciale vaccino:</asp:Label>
            <asp:TextBox ID="NomeCommercialeVaccino" runat="server" CssClass="textBox" MaxLength="100"></asp:TextBox>             
        </p>
        <p>
            <asp:Label ID="NoteVaccinoLabel" runat="server" AssociatedControlID="NoteVaccino" CssClass="label" >Note relative alla vaccinazione:</asp:Label>
            <asp:TextBox ID="NoteVaccino" runat="server" Width="400px" CssClass="textBox" MaxLength="300"></asp:TextBox>             
        </p>
        </div>        
        <label class="sezione">Informazioni sul ricovero</label> 
        <hr />           
        <p>
            <asp:Label ID="RicoveroLabel" runat="server" AssociatedControlID="Ricovero" CssClass="label">Ricovero</asp:Label>
            <asp:DropDownList ID="Ricovero" runat="server" CssClass="dropdown">
                <asp:ListItem Value ="" Text="Selezionare.."></asp:ListItem>
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Value ="Si" Text="Si"></asp:ListItem>
                <asp:ListItem Value ="No" Text="No"></asp:ListItem>
            </asp:DropDownList>            
         </p>
         <div style="padding-left:50px">
         <p>
            <i>Se ricoverato, specificare</i>
         </p>
         <p>
            <asp:Label ID="LuogoRicoveroLabel" runat="server"  AssociatedControlID="LuogoRicovero" CssClass="label">Luogo di ricovero(provincia/comune)</asp:Label>
            <asp:TextBox ID="LuogoRicovero" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
         <p>
            <asp:Label ID="StrutturaRicoveroLabel" runat="server"  AssociatedControlID="StrutturaRicovero" CssClass="label">Struttura di ricovero</asp:Label>
            <asp:TextBox ID="StrutturaRicovero" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
         <p>
            <asp:Label ID="RepartoLabel" runat="server"  AssociatedControlID="Reparto" CssClass="label">Reparto</asp:Label>
            <asp:TextBox ID="Reparto" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
         <p>
            <asp:Label ID="MotivoRicoveroLabel" runat="server"  AssociatedControlID="MotivoRicovero" CssClass="label">Motivo ricovero</asp:Label>
            <asp:TextBox ID="MotivoRicovero" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
         <p>
            <asp:Label ID="DataRicoveroLabel" runat="server" AssociatedControlID="DataRicovero" CssClass="label">Data Ricovero</asp:Label>
            <asp:TextBox ID="DataRicovero" runat="server" CssClass="textBox"></asp:TextBox>
            <label class="label"> (gg/mm/aaaa)</label>
        </p>
        <p>
            <asp:Label ID="DataDimissioneLabel" runat="server" AssociatedControlID="DataDimissione" CssClass="label">Data Dimissione</asp:Label>
            <asp:TextBox ID="DataDimissione" runat="server" CssClass="textBox"></asp:TextBox>
            <label class="label"> (gg/mm/aaaa)</label>
        </p>
        </div>
        <label class="sezione">Ricerche diagnostiche eseguite o in corso </label>
        <hr /> 
         <div style="padding-left:50px">
        <p>
            <asp:Label ID="ricerca1label" runat="server" AssociatedControlID="ricerca1" CssClass="label">Tipo ricerca 1</asp:Label>
            <asp:TextBox ID="ricerca1" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="dataesame1label" runat="server" AssociatedControlID="dataesame1" CssClass="label">Data Esame 1</asp:Label>
            <asp:TextBox ID="dataesame1" runat="server" CssClass="textBox" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Luogo1label" runat="server" AssociatedControlID="Luogo1" CssClass="label">Luogo 1</asp:Label>
            <asp:TextBox ID="Luogo1" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="risultato1Label" runat="server" AssociatedControlID="risultato1" CssClass="label">Risultato 1 </asp:Label>
            <asp:TextBox ID="risultato1" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>

        <p>
            <asp:Label ID="ricerca2Label" runat="server" AssociatedControlID="ricerca2" CssClass="label">Tipo ricerca 2</asp:Label>
            <asp:TextBox ID="ricerca2" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="dataesame2Label" runat="server" AssociatedControlID="dataesame2" CssClass="label">Data esame 2</asp:Label>
            <asp:TextBox ID="dataesame2" runat="server" CssClass="textBox" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Luogo2Label" runat="server" AssociatedControlID="Luogo2" CssClass="label">Luogo 2</asp:Label>
            <asp:TextBox ID="Luogo2" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="risultatoLabel2" runat="server" AssociatedControlID="risultato2" CssClass="label">Risultato 2</asp:Label>
            <asp:TextBox ID="risultato2" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="agenteLabel" runat="server" AssociatedControlID="agente" CssClass="label">Agente identificato:</asp:Label>
            <asp:TextBox ID="agente" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        </p>
        </div>
        <label class="sezione">Dati esposizione</label>
        <hr /> 
        <p>
            <asp:Label ID="ViaggioLabel" AssociatedControlID="Viaggio" runat="server" CssClass="label" Width="300px">Viaggi o soggiorni al di fuori della residenza</asp:Label>
            <asp:DropDownList ID="Viaggio" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="Non noto/non inidicato" Value="ni"></asp:ListItem>
                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="MotivoViaggioLabel" AssociatedControlID="MotivoViaggio" runat="server" CssClass="label" Width="200px">Motivo del viaggio</asp:Label>
            <asp:DropDownList ID="MotivoViaggio" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Text="lavoro" Value="lavoro"></asp:ListItem>
                <asp:ListItem Text="turismo" Value="turismo"></asp:ListItem>
                <asp:ListItem Text="rientro paese d'origine" Value="rientro paese d'origine"></asp:ListItem>
                <asp:ListItem Text="immigrazione" Value="immigrazione"></asp:ListItem>
                <asp:ListItem Text="missione religiosa" Value="missione religiosa"></asp:ListItem>
                <asp:ListItem Text="missione militare" Value="missione militare"></asp:ListItem>                
                <asp:ListItem Text="altro" Value="altro"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="AltroViaggioSpecificareLabel" AssociatedControlID="AltroViaggioSpecificare" runat="server" CssClass="label" Width="150px" >Se altro specificare</asp:Label>
            <asp:TextBox ID="AltroviaggioSpecificare" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>
        </p>       
        <p>
            <i>Se permanenza , specificare permanenza a qualunque titolo in Stati esteri nei 2 mesi precedenti la comparsa dei sintomi:</i>
        </p>   
         <div style="padding-left:50px">                 
        <p>
            <asp:Label ID="Nazione1Label" runat="server" AssociatedControlID="Nazione1Label" CssClass="label">Nazione 1</asp:Label>
            <asp:DropDownList ID="Nazione1" runat="server" CssClass="dropdown" Width="150px">
            </asp:DropDownList>  
            <asp:Label ID="Nazione1Periodolabel" AssociatedControlID="Nazione1Periodo" runat="server" CssClass="label">Periodo</asp:Label>
            <asp:TextBox ID="Nazione1Periodo" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>                      
        </p>
        <p>
            <asp:Label ID="Nazione2Label" runat="server" AssociatedControlID="Nazione2Label" CssClass="label">Nazione 2</asp:Label>
            <asp:DropDownList ID="Nazione2" runat="server" CssClass="dropdown" Width="150px">
            </asp:DropDownList>                        
            <asp:Label ID="Nazione2PeriodoLabel" AssociatedControlID="Nazione2Periodo" runat="server" CssClass="label">Periodo</asp:Label>
            <asp:TextBox ID="Nazione2Periodo" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>                      
        </p>
        <p>
            <asp:Label ID="Nazione3Label" runat="server" AssociatedControlID="Nazione3Label" CssClass="label">Nazione 3</asp:Label>
            <asp:DropDownList ID="Nazione3" runat="server" CssClass="dropdown" Width="150px">
            </asp:DropDownList>                        
            <asp:Label ID="Nazione3PeriodoLabel" AssociatedControlID="Nazione3Periodo" runat="server" CssClass="label">Periodo</asp:Label>
            <asp:TextBox ID="Nazione3Periodo" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>                      
        </p>
        </div>    
        <label class="sezione">Dati presunto contagio</label>
        <hr />  
        <div>
        <p>
            <asp:Label ID="NazioneContagioLabel" runat="server" AssociatedControlID="NazioneContagio" CssClass="label" Width="150px">Nazione presunto contagio</asp:Label>
            <asp:DropDownList ID="NazioneContagio" runat="server" CssClass="dropdown">
            </asp:DropDownList>
            <a href="#imgItaliaContagio" id="imgItaliaContagio" onclick="ImpostaItalia('NazioneContagio','contagio');">Clicca qui per selezionare Italia</a>           
        </p>
        <p>
            <asp:Label ID="ProvinciaContagioLabel" runat="server" AssociatedControlID="ProvinciaContagio" CssClass="label" Width="150px"> Provincia presunto contagio</asp:Label>
            <asp:DropDownList ID="ProvinciaContagio" runat="server" CssClass="dropdown">
            </asp:DropDownList>            
        </p>
        <p>
            <asp:Label ID="ComuneContagioLabel" runat="server" AssociatedControlID="ComuneContagio" CssClass="label" Width="150px">Comune presunto contagio</asp:Label>
            <asp:DropDownList ID="ComuneContagio" runat="server" CssClass="dropdown">
            </asp:DropDownList>                        
        </p>
        <p>
            <asp:Label ID="CasiCorrelatiLable" runat="server" AssociatedControlID="CasiCorrelati" CssClass="label" Width="150px">Casi correlati</asp:Label>
            <asp:DropDownList ID="CasiCorrelati" runat="server" CssClass="dropdown">                
                <asp:ListItem Text="Non noto" Value="NN"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
            </asp:DropDownList>
        </p>             
        <p>
            <asp:Label ID="ContattiStrettiLabel" runat="server" AssociatedControlID="ContattiStretti" CssClass="label" Width="150px">Contatti stretti</asp:Label>
            <asp:DropDownList ID="ContattiStretti" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Non noto" Value="NN"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
            </asp:DropDownList>
        </p>
         <asp:Panel ID="pnlMib" runat="server">
            <label class="sezione">Contatti e focolaio epidemico</label>
            <hr />  

            <p>
            <label class="label" style="width:300px">Nei 10 giorni precedenti l'inizio dei sintomi: </label>
            </p>
            <div style="padding-left:50px">    
             <p>
                 <label class="label" style="width: 400px">il paziente è stato a contatto con un altro caso della stessa malattia ?</label>
                 <asp:DropDownList ID="contatto" runat="server" CssClass="dropdown">
                     <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                     <asp:ListItem Text="No" Value="No"></asp:ListItem>
                     <asp:ListItem Text="Si (confermato)" Value="Si (confermato)"></asp:ListItem>
                     <asp:ListItem Text="Si (sospetto)" Value="Si (sospetto)"></asp:ListItem>
                 </asp:DropDownList>
             </p> 
             <p>
            <label class="label" style="width:350px">probabile contagio fuori dall'area di domicilio abituale ?</label>
            <asp:DropDownList ID="contagio" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>                
            </asp:DropDownList>
            <label class="label" style="width:80px">Se si, dove ?</label>
            <asp:TextBox ID="contagioDove" runat="server" CssClass="textBox" Width="170px" MaxLength="50"></asp:TextBox>
            </p>
            <p>
            <label class="label" style="width:350px">il caso fa parte di un focolaio epidemico ?</label>
            <asp:DropDownList ID="focolaio" runat="server" CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                <asp:ListItem Text="Si" Value="Si"></asp:ListItem>                
            </asp:DropDownList>
             <label class="label" style="width:80px">Se si, quale ?</label>
             <asp:TextBox ID="focolaioDescrizione" runat="server" CssClass="textBox" Width="170px" MaxLength="150"></asp:TextBox>
            </p>
        </div>
         </asp:Panel>
        <p>
            <asp:Label ID="CollettivitaLabel" runat="server" AssociatedControlID="Collettivita" CssClass="label" Width="150px">Colletività</asp:Label>
            <asp:DropDownList ID="Collettivita" runat="server" CssClass="dropdown"></asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="AltreColettivitaLabel"  runat="server" AssociatedControlID="AltreColettivita"  CssClass="label">Altra collettività</asp:Label>
            <asp:TextBox ID="AltreColettivita" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        </div>
        <div>
        <label class="sezione">Esito</label>
        <hr />
        <p>
            <asp:Label ID="decedutoLbl"  runat="server" AssociatedControlID="deceduto"  CssClass="label" Width="200px" >Il paziente risulta deceduto ? :</asp:Label>
            <asp:DropDownList ID="deceduto" runat="server"  CssClass="dropdown">
            <asp:ListItem Text="Selezionare" Value=""></asp:ListItem>
            <asp:ListItem Text="Non noto" Value="NN"></asp:ListItem>
            <asp:ListItem Text="no" Value="no"></asp:ListItem>
            <asp:ListItem Text="si" Value="si"></asp:ListItem>
            </asp:DropDownList>
        </p>
        </div>
        <div>
        <label class="sezione">Note</label>
            <hr />
            <asp:Label ID="noteLabel"  runat="server" AssociatedControlID="note"  CssClass="label">Note</asp:Label>
            <asp:TextBox ID="note" runat="server" CssClass="textBox" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            <p  style="padding-left:600px">
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" CausesValidation="false"  Visible="true" UseSubmitBehavior="false"/>             
                <asp:Button ID="btn" runat="server" Text="Salva"  Visible="true" UseSubmitBehavior="false"/>                
            </p>          
        </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

