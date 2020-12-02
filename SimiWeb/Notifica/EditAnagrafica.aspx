<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="EditAnagrafica.aspx.vb"  
EnableEventValidation="false"
Inherits="Notifica_EditAnagrafica"
ClientIDMode="Static" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>    
    <script src="Js/Notifica.js" type="text/javascript"></script>
    <script src="../_Scripts/All/Geografiche.js"  type="text/javascript"></script>
        <script src="Js/anagrafica.js"  type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Dati anagrafici</b>
        </div >    
            <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
            <br />
            <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
            <asp:HiddenField ID="DataPrimiSintomi" runat="server" />   
            <asp:HiddenField ID="dataWeb" runat="server" />   
            <br />
            <br />
            <label class="sezione">Anagrafica</label>
            <hr />
            <p style="text-align:right; padding-right:50px">
            <b> * Campi obbligatori </b>
            </p>
            <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="Cognome" CssClass="label">Cognome:</asp:Label>
                <asp:TextBox ID="Cognome" runat="server" CssClass="textBox"></asp:TextBox> &nbsp;*                    
                <asp:RequiredFieldValidator ID="reqCognome"  runat="server" InitialValue="" Text="*" ControlToValidate="Cognome" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
            </p>
            <p>
                <asp:Label ID="nomeLabel" runat="server" AssociatedControlID="Nome" CssClass="label">Nome:</asp:Label>
                <asp:TextBox ID="Nome" runat="server" CssClass="textBox"></asp:TextBox> &nbsp;*     
                <asp:RequiredFieldValidator ID="ReqNome"  runat="server" InitialValue="" Text="*" ControlToValidate="Nome" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>               
            </p>
            <p>
                <asp:Label ID="sessoLabel" runat="server" AssociatedControlID="sesso" CssClass="label">Sesso:</asp:Label>
                <asp:DropDownList ID="sesso" runat="server"  CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text="non indicato/non noto" Value="ni"></asp:ListItem>
                            <asp:ListItem Text="m" Value="m"></asp:ListItem>
                            <asp:ListItem Text="f" Value="f"></asp:ListItem>
                </asp:DropDownList> &nbsp;*    
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
                <label class="label"> (gg/mm/aaaa)</label> &nbsp;*    
<%--                  <asp:Label ID="EtaLabel" runat="server" AssociatedControlID="Eta" Text=" Età "></asp:Label><asp:TextBox ID="Eta" runat="server" Enabled="false" Width="50px"></asp:TextBox>--%>
                <asp:RequiredFieldValidator ID="reqDataNascita"  runat="server" InitialValue="" Text="*" ControlToValidate="DataNascita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
            </p>
            <p>            
                <asp:Label ID="NazionalitaLabel" runat="server" AssociatedControlID="Nazionalita" CssClass="label" >Nazionalità:</asp:Label>
                <asp:DropDownList ID="Nazionalita" runat="server"  CssClass="dropdown">   
                <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                         
                </asp:DropDownList>        &nbsp;*    
                <asp:RequiredFieldValidator ID="reqNazionalita"  runat="server" InitialValue="" Text="*" ControlToValidate="Nazionalita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                                                    
                <a href="#" onclick="scorciatoia('Nazionalita','000');">Clicca qui per selezionare Italia</a>
            </p>
            <hr />
            <p>            
                <asp:Label ID="codiceFiscaleLabel" runat="server" AssociatedControlID="codiceFiscale" CssClass="label">Codice fiscale:</asp:Label>
                <asp:TextBox ID="codiceFiscale" runat="server" CssClass="textBox"></asp:TextBox>  
            <%--    <asp:RequiredFieldValidator ID="ReqCodiceFiscale"  runat="server" InitialValue="" Text="*" ControlToValidate="codiceFiscale" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                                            --%>
            </p>
            <p>            
                <asp:Label ID="NumeroStpLabel" runat="server" AssociatedControlID="NumeroSTP" CssClass="label">Numero STP:</asp:Label>
                <asp:TextBox ID="NumeroSTP" runat="server" CssClass="textBox"></asp:TextBox>                
            </p>
            <p>            
                <asp:Label ID="CodiceEniLabel" runat="server" AssociatedControlID="CodiceEni" CssClass="label" >Codice ENI:</asp:Label>
                <asp:TextBox ID="CodiceEni" runat="server" CssClass="textBox"></asp:TextBox>                
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
                <asp:RequiredFieldValidator ID="reqProfessione"  runat="server" InitialValue="" Text="*" ControlToValidate="DataNascita" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                                                                                                   
                <a href="#" onclick="scorciatoia('Professione','000026');">Clicca qui per selezionare 'non indicato'</a>
            </p>
            <p>
                <asp:Label ID="altraProfessioneLabel" runat="server" AssociatedControlID="Professione" CssClass="label" >se altra, specificare:</asp:Label>
                <asp:TextBox ID="altraProfessione" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <label class="sezione">Residenza</label>
            <hr />
            <p>            
                <asp:Label ID="SenzaFissaDimoraLabel" runat="server" AssociatedControlID="SenzaFissaDimora" CssClass="label" Width="200px" >E' Senza fissa dimora:</asp:Label>
                    <asp:DropDownList ID="SenzaFissaDimora" runat="server" CssClass="dropdown" Width="250px">
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    </asp:DropDownList>               
            </p>
            <div style="padding-left:50px">
            <p> 
                <label class="label" style="width:300px"><i>Se no, specificare</i></label>
            </p>
            <p>
                <asp:Label ID="nazioneResidenzaLabel" runat="server" AssociatedControlID="NazioneResidenza" CssClass="label" Width="200px" >Nazione residenza:</asp:Label>
                <asp:DropDownList ID="NazioneResidenza" runat="server"  CssClass="dropdown">
                </asp:DropDownList>                    
                <a href="#" onclick="scorciatoia('NazioneResidenza','000');">Clicca qui per selezionare Italia</a>
            </p>
            <p>
                <asp:Label  id="ProvinciaResidenzaLabel" runat="server"  AssociatedControlID="ProvinciaResidenza" CssClass="label"  Width="200px" >Provincia residenza</asp:Label> 
                <asp:DropDownList ID="ProvinciaResidenza" runat="server" CssClass="dropdown" >                 
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="ComuneResidenzaLabel" runat="server" AssociatedControlID="ComuneResidenza" CssClass="label" Width="200px" >Comune residenza:</asp:Label>
                <asp:DropDownList ID="ComuneResidenza" runat="server"  CssClass="dropdown">
                </asp:DropDownList>    
                <img id="CopiaResidenza" alt="Copia" title="Clicca Qui per copiare la provincia e il comune di residenza in quelli di domicilio"  onclick="CopiaGeografiche('ProvinciaResidenza','ComuneResidenza','ProvinciaDomicilio','ComuneDomicilio','','');" src="../_Styles/All/images/page_copy.png"  />
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
            </p>
            <p>  
                <asp:Label ID="indirizzoDiDomicilioLabel" runat="server" AssociatedControlID="indirizzoDiDomicilio" CssClass="label" Width="200px" >Indirizzo domicilio:</asp:Label>  
                <asp:TextBox ID="indirizzoDiDomicilio" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>                                                     
            </p>
            <p>  
                <asp:Label ID="TelefonoLabel" runat="server" AssociatedControlID="TelefonoLabel" CssClass="label" >Telefono:</asp:Label>  
                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox" Width="200px"></asp:TextBox>                                                     
            </p>
        <asp:Panel ID="pnlCentroPermanenza" runat="server">
            <p>
                    <asp:Label ID="lblcentroPermanenza" runat="server" AssociatedControlID="centroPermanenza" CssClass="label" >C.I.E.:</asp:Label>  
                    <asp:DropDownList ID="centroPermanenza" runat="server" CssClass="dropdown" Width="250px">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    </asp:DropDownList>                     
                    <asp:Label ID="lblNomeCentroPermanenza" runat="server" AssociatedControlID="centroPermanenza" CssClass="label" >Nome struttura:</asp:Label>  
                    <asp:TextBox ID="NomeCentroPermanenza" runat="server" CssClass="textBox" Width="200px" MaxLength="150"></asp:TextBox>                        
            </p>
        </asp:Panel>
               <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />


            <p  style="padding-left:600px">
                            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" ValidationGroup="form" UseSubmitBehavior="false" /> 
                <asp:Button ID="btnSalva" runat="server" Text="Salva" ValidationGroup="form" UseSubmitBehavior="false" />                      
            </p>
    </div >


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>

</asp:Content>


