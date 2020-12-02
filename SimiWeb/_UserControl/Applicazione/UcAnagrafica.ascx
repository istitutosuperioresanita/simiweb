<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcAnagrafica.ascx.vb" Inherits="_UserControl_Applicazione_UcAnagrafica" %>
            <p  style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
            </p>
<fieldset style="padding-right:30px">
             <legend><label class="sezione">Dati anagrafici</label></legend>
            <hr />
            <div style="padding-left:50px">
            <p>             
                <asp:Label ID="nomeLabel" runat="server"  CssClass="labelBold"   Width="200px">Nome:</asp:Label>
                <asp:Label ID="Nome" runat="server" CssClass="label"></asp:Label> 
            <br />
                <asp:Label ID="cognomeLabel" runat="server" CssClass="labelBold"   Width="200px">Cognome:</asp:Label>
                <asp:Label ID="Cognome" runat="server" CssClass="label"></asp:Label>                
            <br />
                <asp:Label ID="sessoLabel" runat="server"  CssClass="labelBold"   Width="200px">Sesso:</asp:Label>
                <asp:Label ID="sesso" runat="server" CssClass="label"></asp:Label>
            <br />
                <asp:Label ID="NatoEsteroLabel" runat="server"  CssClass="labelBold" Width="200px" >E' nato all'estero:</asp:Label>
                <asp:Label ID="NatoEstero" runat="server" CssClass="label" Width="300px"></asp:Label>
            <br />                
                <asp:Label ID="arrivoItaliaLAbel" runat="server"  CssClass="labelBold" Width="200px" >Anno arrivo in Italia:</asp:Label>
                <asp:Label ID="arrivoItalia" runat="server"  CssClass="label"></asp:Label>
            <br />
                <asp:Label  id="ProvinciaNascitaLabel" runat="server"   CssClass="labelBold"  Width="200px" >Provincia nascita</asp:Label> 
                <asp:Label ID="ProvinciaNascita" runat="server" CssClass="label" Width="200px" ></asp:Label>
            <br />
                <asp:Label ID="ComuneNascitaLabel" runat="server"  CssClass="labelBold" Width="200px" >Luogo nascita:</asp:Label>
                <asp:Label ID="ComuneNascita" runat="server" CssClass="label" Width="200px" ></asp:Label>
            <br />
                <asp:Label ID="DataNascitaLabel" runat="server"  CssClass="labelBold"  Width="200px">Data di nascita:</asp:Label>
                <asp:Label ID="DataNascita" runat="server" CssClass="label"></asp:Label> 
            <br />
                <asp:Label ID="NazionalitaLabel" runat="server"  CssClass="labelBold"  Width="200px">Nazionalità:</asp:Label>
                 <asp:Label ID="Nazionalita" runat="server" CssClass="label"></asp:Label>                            
            <br />
                <asp:Label ID="codiceFiscaleLabel" runat="server"  CssClass="labelBold"  Width="200px">Codice fiscale:</asp:Label>
                <asp:Label ID="codiceFiscale" runat="server" CssClass="label"></asp:Label>  
            <br />         
                <asp:Label ID="NumeroStpLabel" runat="server"  CssClass="labelBold" Width="200px">Numero STP:</asp:Label>
                <asp:Label ID="NumeroSTP" runat="server" CssClass="label"></asp:Label>                
            <br />           
                <asp:Label ID="CodiceEniLabel" runat="server"  CssClass="labelBold" Width="200px">Codice ENI:</asp:Label>
                <asp:Label ID="CodiceEni" runat="server" CssClass="label"></asp:Label>                
            <br />                      
                <asp:Label ID="StranieroNonInRegolaLabel" runat="server"  CssClass="labelBold" Width="200px" >Straniero non in regola:</asp:Label>
                <asp:Label ID="StranieroNonInRegola" runat="server" CssClass="label">sss</asp:Label>               
            <br />          
                <asp:Label ID="ProfessioneLabel" runat="server"  CssClass="labelBold"   Width="200px">Professione:</asp:Label>
                <asp:Label ID="Professione" runat="server" CssClass="label">sss</asp:Label>     
            </p>     
            </div>                
            <label class="sezione">Residenza</label>
            <hr />
            <div style="padding-left:50px">
            <p>            
                <asp:Label ID="SenzaFissaDimoraLabel" runat="server"  CssClass="labelBold" Width="200px" >E' Senza fissa dimora:</asp:Label>
                <asp:Label ID="SenzaFissaDimora" runat="server" CssClass="label"></asp:Label>
            <br />
            <br />
                <asp:Label ID="NazioneResidenzaLabel" runat="server" AssociatedControlID="NazioneResidenza" CssClass="labelBold" Width="200px" >Nazione residenza:</asp:Label>  
                <asp:Label ID="NazioneResidenza" runat="server" CssClass="label" Width="400px"></asp:Label>
            <br />
                <asp:Label  id="ProvinciaResidenzaLabel" runat="server"   CssClass="labelBold"  Width="200px" >Provincia residenza</asp:Label> 
                <asp:Label ID="ProvinciaResidenza" runat="server" CssClass="label" Width="200px" ></asp:Label>
            <br />
                <asp:Label ID="ComuneResidenzaLabel" runat="server" CssClass="labelBold" Width="200px" >Comune residenza:</asp:Label>
                <asp:Label ID="ComuneResidenza" runat="server" CssClass="label" Width="300px"></asp:Label>
            <br />
                <asp:Label ID="IndirizzoResidenzaLabel" runat="server"  CssClass="labelBold" Width="200px" >Indirizzo residenza:</asp:Label>  
                <asp:Label ID="IndirizzoResidenza" runat="server" CssClass="label" Width="200px"></asp:Label>                                                     
                                                            
            </p>
            </div>
            <label class="sezione">Domicilio</label>
            <hr />
            <div style="padding-left:50px">
            <p> 
                <asp:Label  id="ProvinciaDomicilioLabel" runat="server"   CssClass="labelBold" Width="200px">Provincia Domicilio</asp:Label> 
                <asp:Label ID="ProvinciaDomicilio" runat="server" CssClass="label" Width="200px"></asp:Label> 
            <br />                     
                <asp:Label ID="ComuneDomicilioLabel" runat="server" CssClass="labelBold" Width="200px" >Comune di domicilio:</asp:Label>
                <asp:Label ID="ComuneDomicilio" runat="server" CssClass="label" Width="200px">ssss</asp:Label>                                           
            <br />
                <asp:Label ID="indirizzoDiDomicilioLabel" runat="server" AssociatedControlID="indirizzoDiDomicilio" CssClass="labelBold" Width="200px" >Indirizzo domicilio:</asp:Label>  
                <asp:Label ID="indirizzoDiDomicilio" runat="server" CssClass="label" Width="200px"></asp:Label>                                                     
            <br /> 
                <asp:Label ID="TelefonoLabel" runat="server"  CssClass="labelBold" Width="200px">Telefono:</asp:Label>  
                <asp:Label ID="Telefono" runat="server" CssClass="label" Width="200px">aaa</asp:Label>                                                     
            </p>
            <asp:Panel ID="pnlCentroPermanenza" runat="server">
                <p>
                        <asp:Label ID="lblcentroPermanenza" runat="server" AssociatedControlID="centroPermanenza" CssClass="labelBold" Width="200px">C.I.E.:</asp:Label>  
                        <asp:Label ID="centroPermanenza" runat="server" CssClass="label" ></asp:Label>                     
                        <asp:Label ID="lblNomeCentroPermanenza" runat="server" AssociatedControlID="centroPermanenza" CssClass="labelBold" >Nome struttura:</asp:Label>  
                        <asp:Label ID="NomeCentroPermanenza" runat="server" CssClass="label"  ></asp:Label>                        
                </p>
            </asp:Panel>
            </div>
</fieldset>