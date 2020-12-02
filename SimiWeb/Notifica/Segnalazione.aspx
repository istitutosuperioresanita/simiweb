<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
EnableEventValidation="false"
CodeFile="Segnalazione.aspx.vb" 
ClientIDMode="Static" EnableViewState = "true"
Inherits="Notifica_Segnalazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.8.18.min.js" type="text/javascript"></script>
    <script src="../_Scripts/jquery_plugin/fancybox/jquery.fancybox-1.3.4.pack.js" type="text/javascript"></script>
    <link href="../_Scripts/jquery_plugin/fancybox/jquery.fancybox-1.3.4.css" rel="stylesheet" />
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="Js/segnalazione.js" type="text/javascript"></script>
    <script src="Js/Notifica.js" type="text/javascript"></script>
    <script src="../_Scripts/All/Geografiche.js"  type="text/javascript"></script>
 <!--JTABLE-->
    
    <link href="../_Scripts/jquery_plugin/jtable/themes/standard/blue/jtable_blue.css"
        rel="stylesheet" type="text/css" />
    <script src="../_Scripts/modernizr-1.7.min.js" type="text/javascript"></script>
    <script src="../_Scripts/jtablesite.js" type="text/javascript"></script>
    <!-- A helper library for JSON serialization -->
    <script src="../_Scripts/jquery_plugin/jtable/external/json2.min.js" type="text/javascript"></script>
    <!-- Core jTable script file -->
    <script src="../_Scripts/jquery_plugin/jtable/jquery.jtable.min.js" type="text/javascript"></script>
    <!-- ASP.NET Web Forms extension for jTable -->
    <script src="../_Scripts/jquery_plugin/jtable/extensions/jquery.jtable.aspnetpagemethods.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#PersonTableContainer').jtable({
                title: 'Possibili doppi',
                deleteConfirmation: false,
                selecting: true,
                actions: {
                    listAction: 'Segnalazione.aspx/lista'
                },
                fields: {
                    id: {
                        key: true,
                        create: false,
                        edit: false,
                        title: 'id',
                        list: true
                    },
                    Nome: {
                        title: 'Nome',
                        width: '20%'
                    },
                    Cognome: {
                        title: 'cognome',
                        width: '30%'
                    },
                    DataNascita: {
                        title: 'data di nascita',
                        width: '25%',
                        type: 'date',
                        displayFormat: 'dd-mm-yy'
                    },
                    malattia: {
                        title: 'Malattia',
                        width: '35%'
                    },
                    TestColumn: {
                        title: '',
                        display: function (data) {
                            return '<a href="lista.aspx?id=' + data.record.id + '"><img src="../_Styles/All/images/edit.png" border="0" /></a>';
                        }
                    }
                }
            });
            $('#PersonTableContainer').hide();
        });
    </script>
<script type="text/javascript">
    $(function () {

        $(':text').bind('keydown', function (e) { //on keydown for all textboxes  

            if (e.keyCode == 13) //if this is enter key  

                e.preventDefault();

        });

    });  
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

           Simiweb -> Notifica -> <b>Nuova notifica (2 di 2)</b>
        </div >    
            <br />
            <br />
            <p style="text-align:center">
            <label class="sezione"><b>Notifica di </b> </label>
            <asp:Label ID="malattiaLabel" runat="server" CssClass="alert"></asp:Label>
            </p>
            <br />
           <label class="label"  style="width:250px">tipo criterio per la definizio di caso europea</label>
            <br />
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
            <hr />
            <p style="text-align:right; padding-right:50px">
           <b> * Campi obbligatori </b>
            </p>
            <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="Cognome" CssClass="labelObb">Cognome:</asp:Label>
                <asp:TextBox ID="Cognome" runat="server" CssClass="textBox"></asp:TextBox> &nbsp;*                
                <asp:RequiredFieldValidator ID="reqCognome"  runat="server" InitialValue="" Text="*" ControlToValidate="Cognome" CssClass="alert" ValidationGroup="form" ></asp:RequiredFieldValidator>               
            </p>
            <p>
                <asp:Label ID="nomeLabel" runat="server" AssociatedControlID="Nome" CssClass="label">Nome:</asp:Label>
                <asp:TextBox ID="Nome" runat="server" CssClass="textBox"></asp:TextBox>&nbsp;*
                <asp:RequiredFieldValidator ID="ReqNome"  runat="server" InitialValue="" Text="*" ControlToValidate="Nome" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
            </p>
            <div id="PersonTableContainer">            
            <span style="padding-left:580px">
            <label>chiudi</label>
            <img id="close" onclick="chiudi()" alt="chiudi" src="../_Styles/All/images/delete.png" />
       
            </span>
            </div>
            <p>
                <asp:Label ID="sessoLabel" runat="server" AssociatedControlID="sesso" CssClass="label">Sesso:</asp:Label>
                <asp:DropDownList ID="sesso" runat="server"  CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text="non indicato/non noto" Value="ni"></asp:ListItem>
                            <asp:ListItem Text="m" Value="m"></asp:ListItem>
                            <asp:ListItem Text="f" Value="f"></asp:ListItem>
                </asp:DropDownList>&nbsp;*
                <asp:RequiredFieldValidator ID="ReqSesso"  runat="server" InitialValue="" Text="*" ControlToValidate="sesso" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                                            
            </p>
            <p>            
                <asp:Label ID="NatoEsteroLabel" runat="server" AssociatedControlID="NatoEstero" CssClass="label" Width="200px" >E' nato all'estero ?:</asp:Label>
                    <asp:DropDownList ID="NatoEstero" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text="non indicato/non noto" Value="ni"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    </asp:DropDownList>  &nbsp;*
                <asp:RequiredFieldValidator ID="ReqNatoEstero"  runat="server" InitialValue="" Text="*" ControlToValidate="NatoEstero" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                 
            </p>
            <div style="padding-left:50px">
            <p> 
                <label class="label" style="width:300px"><i>Se si, specificare</i></label>
            </p>
            <p>            
                <asp:Label ID="NazionenascitaLabel" runat="server" AssociatedControlID="Nazionalita" CssClass="label" >Nazionalità:</asp:Label>
                <asp:DropDownList ID="NazioneNascita" runat="server"  CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                </asp:DropDownList>              &nbsp;*               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" InitialValue="" Text="*" ControlToValidate="Nazionalita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                              

            </p>     
            </div>       
            <div style="padding-left:50px">
            <p> 
                <label class="label" style="width:300px"><i>Se no, specificare</i></label>
            </p>
                <p>
                    <asp:Label  id="ProvinciaNascitaLabel" runat="server"  AssociatedControlID="ProvinciaNascita" CssClass="label"  Width="200px" >Provincia nascita</asp:Label> 
                    <asp:DropDownList ID="ProvinciaNascita" runat="server" CssClass="dropdown" >                  
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="ComuneNascitaLabel" runat="server" AssociatedControlID="ComuneNascita" CssClass="label" Width="200px" >Luogo nascita:</asp:Label>
                    <asp:DropDownList ID="ComuneNascita" runat="server"  CssClass="dropdown" Width="250px">
                    </asp:DropDownList>    
                    <img id="CopiaNascita" alt="Copia" title="Clicca Qui per copiare la provincia e il comune di nascita in quelli di domicilio e residenza"  onclick="CopiaGeografiche('ProvinciaNascita','ComuneNascita','ProvinciaResidenza','ComuneResidenza','ProvinciaDomicilio','ComuneDomicilio');" src="../_Styles/All/images/page_copy.png"  />
                    </p>

            </div>
            <div style="padding-left:50px">
            <p> 
                <label class="label" style="width:300px"><i>Se si, </i></label>
            </p>
            <p>
                <asp:Label ID="dataArrivoLabel" runat="server" Text="data arrivo in italia" CssClass="label" Width="200px" ></asp:Label>
                <asp:TextBox ID="arrivoItalia" runat="server"  CssClass="textBox" ></asp:TextBox>
            </p>
            </div>
            <p>
                <asp:Label ID="DataNascitaLabel" runat="server" AssociatedControlID="DataNascita" CssClass="label">Data di nascita:</asp:Label>
                <asp:TextBox ID="DataNascita" runat="server" CssClass="textBox"></asp:TextBox> 
                <label class="label">(gg/mm/aaaa)</label>&nbsp;*
<%--                  <asp:Label ID="EtaLabel" runat="server" AssociatedControlID="Eta" Text=" Età "></asp:Label><asp:TextBox ID="Eta" runat="server" Enabled="false" Width="50px"></asp:TextBox>--%>
                <asp:RequiredFieldValidator ID="reqDataNascita"  runat="server" InitialValue="" Text="*" ControlToValidate="DataNascita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
            </p>
            <p>            
                <asp:Label ID="NazionalitaLabel" runat="server" AssociatedControlID="Nazionalita" CssClass="label" >Nazionalità:</asp:Label>
                <asp:DropDownList ID="Nazionalita" runat="server"  CssClass="dropdown">
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                </asp:DropDownList>&nbsp;*
                <asp:RequiredFieldValidator ID="reqNazionalita"  runat="server" InitialValue="" Text="*" ControlToValidate="Nazionalita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
                <a href="javascript:void(0);" onclick="scorciatoia('Nazionalita','000');">Clicca qui per selezionare Italia</a>
                
            </p>
            <hr />
            <p>            
                <asp:Label ID="codiceFiscaleLabel" runat="server" AssociatedControlID="codiceFiscale" CssClass="label">Codice fiscale:</asp:Label>
                <asp:TextBox ID="codiceFiscale" runat="server" CssClass="textBox" MaxLength="16"></asp:TextBox>  
                <%--asp:RequiredFieldValidator ID="ReqCodiceFiscale"  runat="server" InitialValue="" Text="*" ControlToValidate="codiceFiscale" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator> --%>                                                         
            </p>
            <p>            
                <asp:Label ID="NumeroStpLabel" runat="server" AssociatedControlID="NumeroSTP" CssClass="label" >Numero STP:</asp:Label>
                <asp:TextBox ID="NumeroSTP" runat="server" CssClass="textBox"></asp:TextBox>                
                <asp:Label ID="Label1" runat="server" CssClass="label" Width="300px" >(Straniero Temporaneamente Presente)</asp:Label>
            </p>
            <p>            
                <asp:Label ID="CodiceEniLabel" runat="server" AssociatedControlID="CodiceEni" CssClass="label"  >Codice ENI:</asp:Label>
                <asp:TextBox ID="CodiceEni" runat="server" CssClass="textBox"></asp:TextBox>                
                <asp:Label ID="Label2" runat="server" CssClass="label" Width="200px" >(Europeo Non Iscritto)</asp:Label>
            </p>
            <p>            
                <asp:Label ID="StranieroNonInRegolaLabel" runat="server" AssociatedControlID="StranieroNonInRegola" CssClass="label" Width="200px" >Straniero non in regola:</asp:Label>
                 <asp:CheckBox ID="StranieroNonInRegola" runat="server" CssClass="checkBox" />               
            </p>
            <p>            
                <asp:Label ID="ProfessioneLabel" runat="server" AssociatedControlID="Professione" CssClass="label" >Professione:</asp:Label>
                <asp:DropDownList ID="Professione" runat="server"  CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                </asp:DropDownList>  &nbsp;*       
                <asp:RequiredFieldValidator ID="reqProfessione"  runat="server" InitialValue="" Text="*" ControlToValidate="Professione" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                                                       
                <a href="javascript:void(0);" onclick="scorciatoia('Professione','000026');">Clicca qui per selezionare 'non indicato'</a>
            </p>
            <p>
                <asp:Label ID="altraProfessioneLabel" runat="server" AssociatedControlID="Professione" CssClass="label" >se altra, specificare:</asp:Label>
                <asp:TextBox ID="altraProfessione" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <label class="sezione">Residenza</label>
            <hr />
            <p>            
                <asp:Label ID="SenzaFissaDimoraLabel" runat="server" AssociatedControlID="SenzaFissaDimora" CssClass="label" Width="200px" >E' Senza fissa dimora:</asp:Label>
                    <asp:DropDownList ID="SenzaFissaDimora" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    </asp:DropDownList>               
            </p>
            <div style="padding-left:50px">
            <p> 
                <label class="label" style="width:300px"><i>Se no, specificare</i></label>
            </p>
            <p>
                <asp:Label  id="ProvinciaResidenzaLabel" runat="server"  AssociatedControlID="ProvinciaResidenza" CssClass="label"  Width="200px" >Provincia residenza</asp:Label> 
                <asp:DropDownList ID="ProvinciaResidenza" runat="server" CssClass="dropdown" >               
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="ComuneResidenzaLabel" runat="server" AssociatedControlID="ComuneResidenza" CssClass="label" Width="200px" >Comune residenza:</asp:Label>
                <asp:DropDownList ID="ComuneResidenza" runat="server"  CssClass="dropdown" Width="250px">
                </asp:DropDownList>    
                <img id="CopiaResidenza" alt="Copia" title="Clicca Qui per copiare la provincia e il comune di residenza in quelli di domicilio"  onclick="CopiaGeografiche('ProvinciaResidenza','ComuneResidenza','ProvinciaDomicilio','ComuneDomicilio','','');" src="../_Styles/All/images/page_copy.png"  />
            </p>
            <p>
                <asp:Label ID="nazioneResidenzaLabel" runat="server" AssociatedControlID="NazioneResidenza" CssClass="label" Width="200px" >Nazione residenza:</asp:Label>
                <asp:DropDownList ID="NazioneResidenza" runat="server"  CssClass="dropdown">
                </asp:DropDownList>                    
                <a href="javascript:void(0);" onclick="scorciatoia('NazioneResidenza','000');">Clicca qui per selezionare Italia</a>
            </p>
            <p>  
                <asp:Label ID="IndirizzoResidenzaLabel" runat="server" AssociatedControlID="IndirizzoResidenza" CssClass="label" Width="200px" >Indirizzo residenza:</asp:Label>  
                <asp:TextBox ID="IndirizzoResidenza" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>                                                     
            </p>
<%--            <p>
                <asp:Label ID="redinteEsteroLabel" runat="server" AssociatedControlID="IndirizzoResidenza" CssClass="label" Width="200px" >Se resdidente Estero, specificare:</asp:Label>  
                <asp:TextBox ID="ResidenteEstero" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>                                                                     
            </p>--%>
            </div>
            <label class="sezione">Domicilio</label>
            <hr />
            <p> 
                <asp:Label  id="ProvinciaDomicilioLabel" runat="server"  AssociatedControlID="ProvinciaDomicilio" CssClass="label" Width="200px">Provincia Domicilio</asp:Label> 
                <asp:DropDownList ID="ProvinciaDomicilio" runat="server" CssClass="dropdown">                    
                </asp:DropDownList>
            </p>
            <p>                        
                <asp:Label ID="ComuneDomicilioLabel" runat="server" AssociatedControlID="ComuneDomicilio" CssClass="label" Width="200px" >Comune di domicilio:</asp:Label>
                <asp:DropDownList ID="ComuneDomicilio" runat="server"  CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                </asp:DropDownList>            
                <!--img id="Img4" alt="Copia" title="Clicca Qui per copiare la provincia e il comune di residenza in quelli di domicilio"  onclick="CopiaGeografiche('ProvinciaResidenza','ComuneResidenza','ProvinciaDomicilio','ComuneDomicilio','','');" src="../_Styles/All/images/page_copy.png"  /-->                                 
            </p>
            <p>  
                <asp:Label ID="indirizzoDiDomicilioLabel" runat="server" AssociatedControlID="indirizzoDiDomicilio" CssClass="label" Width="200px" >Indirizzo domicilio:</asp:Label>  
                <asp:TextBox ID="indirizzoDiDomicilio" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>                                                     
            </p>
            <p>  
                <asp:Label ID="TelefonoLabel" runat="server" AssociatedControlID="TelefonoLabel" CssClass="label" >Telefono:</asp:Label>  
                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>                                                     
            </p>
        <label class="sezione">Dati clinici</label>
        <hr />
   <p>
            <asp:Label ID="DataPrimiSintomiLabel" runat="server" AssociatedControlID="DataPrimiSintomi" CssClass="label" Width="150px" >Data primi sintomi:</asp:Label>
            <asp:TextBox ID="DataPrimiSintomi" runat="server" CssClass="textBox"></asp:TextBox> <label class="label"> (gg/mm/aaaa)</label>  &nbsp;*  
            <asp:RequiredFieldValidator ID="ReqDataPrimiSintomi"  runat="server" InitialValue="" Text="*" ControlToValidate="DataPrimiSintomi" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
        </p>          
        <p>
            <asp:Label ID="RicoveroLabel" runat="server" AssociatedControlID="Ricovero" CssClass="label" Width="150px">Ricovero</asp:Label>
            <asp:DropDownList ID="Ricovero" runat="server" CssClass="dropdown">
                <asp:ListItem Value ="" Text="Selezionare.."></asp:ListItem>
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Value ="Si" Text="Si"></asp:ListItem>
                <asp:ListItem Value ="No" Text="No"></asp:ListItem>
            </asp:DropDownList>      &nbsp;*  
            <asp:RequiredFieldValidator ID="ReqRicovero"  runat="server" InitialValue="" Text="*" ControlToValidate="Ricovero" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
         </p>
         <p>
            <asp:Label ID="LuogoRicoveroLabel" runat="server"  AssociatedControlID="LuogoRicovero" CssClass="label"  Width="150px">Luogo di ricovero(provincia/comune)</asp:Label>
            <asp:TextBox ID="LuogoRicovero" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
         <p>
            <asp:Label ID="StrutturaRicoveroLabel" runat="server"  AssociatedControlID="StrutturaRicovero" CssClass="label">Struttura di ricovero</asp:Label>
            <asp:TextBox ID="StrutturaRicovero" runat="server" CssClass="textBox"></asp:TextBox>
         </p>
        <p>
            <asp:Label ID="StatoVaccinaleLabel" runat="server" AssociatedControlID="StatoVaccinale" CssClass="label" Width="150px" >Paziente vaccinato:</asp:Label>
            <asp:DropDownList ID="StatoVaccinale" runat="server" CssClass="dropdown"  style="margin-left:25px;">
                <asp:ListItem Value ="" Text="Selezionare.."></asp:ListItem>
                <asp:ListItem Text="vaccino inesistente" Value="n.a."></asp:ListItem>    
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Text="non vaccinato" Value="non vaccinato"></asp:ListItem>
                <asp:ListItem Text="vaccinato" Value="vaccinato"></asp:ListItem>
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
            <asp:Label ID="DataDoseVaccinoLabel" runat="server" AssociatedControlID="DataDoseVaccino" CssClass="label" >Data ultima dose:</asp:Label>
            <asp:TextBox ID="DataDoseVaccino" runat="server" CssClass="textBox"></asp:TextBox>             
        </p>
        </div> 
 <%--       <p>
            <asp:Label ID="StatoVaccinaleLabel" runat="server" AssociatedControlID="StatoVaccinale" CssClass="label" Width="150px" >Paziente vaccinato:</asp:Label>
            <asp:DropDownList ID="StatoVaccinale" runat="server" CssClass="dropdown">
                <asp:ListItem Value ="" Text="Selezionare.."></asp:ListItem>       
                <asp:ListItem Text="vaccino inesistente" Value="n.a."></asp:ListItem>                         
                <asp:ListItem Text="non noto" Value="non noto"></asp:ListItem>
                <asp:ListItem Text="non vaccinato" Value="non vaccinato"></asp:ListItem>
                <asp:ListItem Text="vaccinato" Value="vaccinato"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="ReqStatoVaccinale"  runat="server" InitialValue="" Text="*" ControlToValidate="StatoVaccinale" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
        </p>    
--%>                       
         <hr />
        <p>
            <asp:Label ID="statoSchedaLabel"  runat="server" AssociatedControlID="statoScheda"  CssClass="label">Segnalazione o notifica</asp:Label>
            <asp:DropDownList ID="statoScheda" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Segnalazione" Text="Segnalazione" ></asp:ListItem>
                <asp:ListItem Value="Notifica" Text="Notifica" ></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="lbldatasegnalazione"  runat="server" AssociatedControlID="datasegnalazione"  CssClass="label" Width="150px">Data prima segnalazione</asp:Label>
            <asp:TextBox ID="datasegnalazione" runat="server" CssClass="textBox"></asp:TextBox><label class="label"> (gg/mm/aaaa)</label>
            <asp:RequiredFieldValidator ID="reqDataSegnalazione"  runat="server" InitialValue="" Text="*" ControlToValidate="datasegnalazione" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
        </p>
        <p>
            <asp:Label ID="ReferenteLabbel" runat="server" AssociatedControlID="Referente" CssClass="label" Width="150px">Referente Ulss</asp:Label>
            <asp:DropDownList ID="Referente" runat="server" CssClass="dropdown">
            </asp:DropDownList>  &nbsp;*  
            <asp:RequiredFieldValidator ID="ReqReferente"  runat="server" InitialValue="" Text="*" ControlToValidate="Referente" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
        </p>
        <p>
            <asp:Label ID="medicoSegnalatoreLbl"  runat="server" AssociatedControlID="medicoSegnalatore"  CssClass="label" Width="150px">Medico segnalatore</asp:Label>
            <asp:TextBox ID="medicoSegnalatore" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqmedicoSegnalatore"  runat="server" InitialValue="" Text="*" ControlToValidate="medicoSegnalatore" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
            <asp:Label ID="origineSegnalazioneLabel"  runat="server" AssociatedControlID="origineSegnalazione"   CssClass="label" Width="150px">tipo segnalatore</asp:Label>
            <asp:DropDownList ID="origineSegnalazione" runat="server"  CssClass="dropdown" >
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                <asp:ListItem Text="MMG" Value="MMG"></asp:ListItem>
                <asp:ListItem Text="PLS" Value="PLS"></asp:ListItem>
                <asp:ListItem Text="Medico segnalatore" Value="Medico segnalatore"></asp:ListItem>
            </asp:DropDownList>  &nbsp;*  
        </p>
        <p>
            <asp:Label ID="datanotificaLabel"  runat="server" AssociatedControlID="datanotifica"  CssClass="label" Width="150px">Data notifica</asp:Label>
            <asp:TextBox ID="datanotifica" runat="server" CssClass="textBox"></asp:TextBox><label class="label"> (gg/mm/aaaa)</label>
        </p>
        <p>
            <asp:Label ID="operatoreLabel"  runat="server" AssociatedControlID="operatore"  CssClass="label" Width="150px">Inserito nel sistema da:</asp:Label>
            <asp:Label ID="operatore" runat="server" CssClass="label"></asp:Label>
        </p>
        <asp:Panel ID="pnlRegione" runat="server" Visible="false">
        <p>
        <label class="label">Asl di notifica</label>
        <asp:DropDownList ID="aslNotifica" runat="server">

        </asp:DropDownList>
         <asp:RequiredFieldValidator ID="reqAsl" Enabled="false"  runat="server" InitialValue="" Text="*" ControlToValidate="aslNotifica" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                   
        </p>
        </asp:Panel>
            <p  style="padding-left:500px">
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla"  CausesValidation="false" UseSubmitBehavior="false"/> 
                <asp:Button ID="btn" runat="server" Text="Salva" ValidationGroup="form"  UseSubmitBehavior="false" />                
            </p>
            <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />
    </div >


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

