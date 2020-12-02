<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcTubercolosi.ascx.vb" Inherits="_UserControl_Applicazione_UcTubercolosi" %>
<p  style="padding-left:550px">
    <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
</p>
<fieldset style="padding-right:30px">
             <legend><label class="sezione">Specifiche</label></legend>
            <hr />
            <label class="sezione">Tubercolosi</label>
            <div style="padding-left:50px">
            <p>         
                <asp:Label ID="TipoLabel" runat="server"  CssClass="labelBold" AssociatedControlID="Tipo" Width="50px">Tipo:</asp:Label>
                <asp:Label ID="Tipo" runat="server"  CssClass="label" ></asp:Label>
            </p>
            <p>
                <asp:Label ID="DataInizioTerapiaTubercolareLabel" runat="server" AssociatedControlID="DataInizioTerapiaTubercolare" 
                                        CssClass="labelBold" 
                                        Width="250px">DataInizio Terapia Tubercolare:</asp:Label>
                <asp:Label ID="DataInizioTerapiaTubercolare" runat="server"  CssClass="label" ></asp:Label>     
            </p>
            <p>
                <asp:Label ID="LivelloDiAccertamentoLabel" runat="server"  CssClass="labelBold" AssociatedControlID="LivelloDiAccertamento" Width="200px">Livello di accertamento:</asp:Label>
                <asp:Label ID="LivelloDiAccertamento" runat="server"  CssClass="label" ></asp:Label> 
            </p>
            <p>
                <asp:Label ID="DiagnosiTubercolosiPassatoLabel" runat="server"  CssClass="labelBold" 
                            AssociatedControlID="DiagnosiTubercolosiPassato"  Width="200px">Diagnosi tubercolosi passata:</asp:Label>
                <asp:Label ID="DiagnosiTubercolosiPassato" runat="server"  CssClass="label" ></asp:Label> 
            </p>
            <div style="padding-left:50px;">
                <label class="label" style="width:300px"><i>Se si, specificare</i></label>
            <br />
            <p>
                <br />
                <asp:Label ID="annoLabel" runat="server" AssociatedControlID="anno" CssClass="labelBold" Width="50px">Anno:</asp:Label>
                <asp:Label ID="anno" runat="server"  CssClass="label" ></asp:Label>    
                <asp:Label ID="meseLabel" runat="server" AssociatedControlID="mese" CssClass="labelBold" Width="50px">Mese:</asp:Label>
                <asp:Label ID="mese" runat="server"  CssClass="label" ></asp:Label>                            
            </p>
            </div>
            <p>
                <asp:Label ID="TipoClassificazioneLabel" runat="server"  CssClass="labelBold" 
                            AssociatedControlID="TipoClassificazione"  Width="100px">Classificazione:</asp:Label>
                <asp:Label ID="TipoClassificazione" runat="server"  CssClass="label" ></asp:Label>       
            </p>
            <p>
                <asp:Label ID="AgenteLabel" runat="server"  CssClass="labelBold" AssociatedControlID="Agente"  Width="150px">Agente Eziologico</asp:Label>
                <asp:Label ID="Agente" runat="server"  CssClass="label" ></asp:Label>        
            </p>
            <p>
                <asp:Label ID="AltroAgenteLabel" runat="server" AssociatedControlID="AltroAgente" CssClass="labelBold"  Width="100px">Altro:</asp:Label>
                <asp:Label ID="AltroAgente" runat="server"  CssClass="label" ></asp:Label>     
            </p>
            <p>
                <asp:Label ID="AntibiogrammaLabel" runat="server" AssociatedControlID="Antibiogramma" CssClass="labelBold"  Width="100px">Antibiogramma:</asp:Label>
                <asp:Label ID="Antibiogramma" runat="server"  CssClass="label" ></asp:Label>     
            </p>
            <p style="padding-left:50px">
               <asp:Label ID="STRELabel" runat="server" CssClass="labelBold">STRE :</asp:Label>
               <asp:Label ID="STRE" runat="server" CssClass="label">
               </asp:Label>
               <br />
               <br />
               <asp:Label ID="INHLabel" runat="server" CssClass="labelBold" >INH :</asp:Label> 	
               <asp:Label ID="INH" runat="server" CssClass="label">         
               </asp:Label>
               <br />
               <br />
               <asp:Label ID="RMPLabel" runat="server" CssClass="labelBold">RMP :</asp:Label> 	
               <asp:Label ID="RMP" runat="server" CssClass="label">           
               </asp:Label>
               <br />
               <br />
               <asp:Label ID="EMBLabel" runat="server"  CssClass="labelBold">EMB :</asp:Label> 	
               <asp:Label ID="EMB" runat="server" CssClass="label">           
               </asp:Label>
               <br />
               <br />
               <asp:Label ID="PZALabel" runat="server" CssClass="labelBold">PZA :</asp:Label> 	
               <asp:Label ID="PZA" runat="server" CssClass="label">            
               </asp:Label>

            </p>
            </div>
      <label class="sezione">Esami</label>
                  <div style="padding-left:50px">
                  
                    <hr />
                    <p>
                            <asp:Label ID="EsameColturaleEscreatoLabel" runat="server" AssociatedControlID="EsameColturaleEscreato" CssClass="labelBold" Width="200px">Esame colturale escreato</asp:Label>
                            <asp:Label ID="EsameColturaleEscreato" runat="server" CssClass="label">
                            </asp:Label>
                    </p>
                    <p>

                            <asp:Label ID="EsameColturaleAltroMaterialeLabel" runat="server" AssociatedControlID="EsameColturaleAltroMateriale" CssClass="labelBold" Width="200px">Esame colturale altro materiale</asp:Label>
                            <asp:Label ID="EsameColturaleAltroMateriale" runat="server" CssClass="label"> 
                            </asp:Label>
                            <asp:Label ID="EsameColturaleDescLabel" runat="server" AssociatedControlID="EsameColturaleDesc" CssClass="labelBold" Width="150px" style="padding-left:20px;">se altro, materiale:</asp:Label>
                            <asp:Label ID="EsameColturaleDesc" runat="server" CssClass="label"></asp:Label>
                    </p>
                    <p>
                            <asp:Label ID="EsameDirettoEscreatoLabel" runat="server" AssociatedControlID="EsameDirettoEscreato" CssClass="labelBold" Width="200px">Esame Diretto escreato</asp:Label>
                            <asp:Label ID="EsameDirettoEscreato" runat="server" CssClass="label">
                            </asp:Label>
                    </p>
                    <p>
                            <asp:Label ID="EsamedirettoaltromaterialeLabel" runat="server" AssociatedControlID="Esamedirettoaltromateriale" CssClass="labelBold" Width="200px">Esame diretto altro materiale</asp:Label>
                            <asp:Label ID="Esamedirettoaltromateriale" runat="server" CssClass="label"> 
                            </asp:Label>
                            <asp:Label ID="EsamedirettoaltromaterialeDescLabel" runat="server" AssociatedControlID="EsamedirettoaltromaterialeDesc" CssClass="labelBold" Width="150px" style="padding-left:20px;">se altro, materiale:</asp:Label>
                            <asp:Label ID="EsamedirettoaltromaterialeDesc" runat="server" CssClass="label"></asp:Label>

                    </p>
                    <p>
                            <asp:Label ID="ClinicaLabel" runat="server" AssociatedControlID="Clinica" CssClass="labelBold" Width="200px">Clinica</asp:Label>
                            <asp:Label ID="Clinica" runat="server" CssClass="label">                           
                            </asp:Label>
                    </p>
                <p>
                        <asp:Label ID="MantouxLabel" runat="server" AssociatedControlID="Mantoux" CssClass="labelBold" Width="200px">Mantoux</asp:Label>
                        <asp:Label ID="Mantoux" runat="server" CssClass="label">   
                        </asp:Label>
                    </p>
                 <p>
                        <asp:Label ID="RxStandardLabel" runat="server" AssociatedControlID="RxStandard" CssClass="labelBold" Width="200px">Rx torace/Esami strumentali</asp:Label>
                        <asp:Label ID="RxStandard" runat="server" CssClass="label">
                        </asp:Label>
                </p>
                <p>
                        <asp:Label ID="RispostaTerapiaLabel" runat="server" AssociatedControlID="RispostaTerapia" CssClass="labelBold" Width="200px">Risposta alla terapia antitubercolare</asp:Label>
                        <asp:Label ID="RispostaTerapia" runat="server" CssClass="label">
                        </asp:Label>
                </p>
                <p>
                        <asp:Label ID="RiscontroAutopicoLabel" runat="server" AssociatedControlID="RiscontroAutopico" CssClass="labelBold" Width="200px">Riscontro autoptico di TB attiva</asp:Label>
                        <asp:Label ID="RiscontroAutopico" runat="server" CssClass="label">
                        </asp:Label>
                </p>
                <p>
                        <asp:Label ID="QuantiferonLabel" runat="server" AssociatedControlID="Quantiferon" CssClass="labelBold" Width="200px">Quantiferon</asp:Label>
                        <asp:Label ID="Quantiferon" runat="server" CssClass="label">
                        </asp:Label>
                </p>
            </div>
            <label class="sezione">Sede anatomica</label>
            <div style="padding-left:50px">
            <br />
            <hr />
            <p>
                <asp:Label ID="SedePolmonareLabel" runat="server" AssociatedControlID="SedePolmonare" CssClass="labelBold"  Width="300px" >Polmonare/tracheale/bronchiale:</asp:Label>
                <asp:Label ID="SedePolmonare" runat="server"  CssClass="label" ></asp:Label>    
            </p>
            <p>
                <asp:Label ID="SedeExtraPolmonareLabel" runat="server" AssociatedControlID="SedeExtraPolmonare" CssClass="labelBold" Width="150px" >Extrapolmonare:</asp:Label>
                <asp:Label ID="SedeExtraPolmonare" runat="server"  CssClass="label" ></asp:Label>    
            </p>
            <div style="padding-left:150px;">
                <asp:Label ID="Localizzazione1Label" runat="server"  CssClass="labelBold" AssociatedControlID="Localizzazione1" Width="150px" >Localizzazione 1:</asp:Label>
                <asp:Label ID="Localizzazione1" runat="server"  CssClass="label" ></asp:Label>     
                <p>
                <asp:Label ID="Localizzazione2Label" runat="server"  CssClass="labelBold" AssociatedControlID="Localizzazione2" Width="150px">Localizzazione 2:</asp:Label>
                <asp:Label ID="Localizzazione2" runat="server"  CssClass="label" ></asp:Label>             
                </p>
                </div>
                <p>
                <asp:Label ID="MiliareLabel" runat="server" AssociatedControlID="Miliare" CssClass="labelBold" Width="150px" >Miliare:</asp:Label>
                <asp:Label ID="Miliare" runat="server"  CssClass="label" ></asp:Label> 
                </p>
                <p>
                <asp:Label ID="DisseminataLabel" runat="server"  CssClass="labelBold" AssociatedControlID="Disseminata" Width="100px">Disseminata:</asp:Label>
                <asp:Label ID="Disseminata" runat="server"  CssClass="label" ></asp:Label>               
                </p>
                </div>
                <label class="sezione">Sorveglianza dell'esito</label>
                <hr />
                <div style="padding-left:50px">
                <p>                
                <asp:Label ID="DataInizioTerapiaCentroLabel" runat="server" CssClass="labelBold" Text="Data Inizio terapia presso il centro" Width="300px"></asp:Label>
                <asp:Label ID="DataInizioTerapiaCentro" runat="server" CssClass="label"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="lblTipo" runat="server" Text="" CssClass="label"></asp:Label>
                    <asp:Label ID="lblTerapia" runat="server" Text="Effettuata" CssClass="labelBold"></asp:Label>
                    <asp:Label ID="faseIniziale"  runat="server"   Text="Fase iniziale N° Mesi"   CssClass="labelBold"></asp:Label>
                    <asp:Label ID="Continuazione" runat="server"   Text="Continuazione N° Mesi"   CssClass="labelBold"></asp:Label>                               
                </p>
                <p>
                    <asp:Label ID="IsoniazideLabel" runat="server" Text="Isoniazide" CssClass="labelBold">Isoniazide</asp:Label>
                    <asp:Label ID="Isoniazide" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="IsoniazideInizio" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="IsoniazideFine" runat="server" CssClass="label" ></asp:Label>                               
                </p>
                <p>
                    <asp:Label ID="RifampicinaLabel" runat="server" CssClass="labelBold">Rifampicina</asp:Label>
                    <asp:Label ID="Rifampicina" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="RifampicinaInizio" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="RifampicinaFine" runat="server" CssClass="label" ></asp:Label>                               
                </p>
                <p>
                    <asp:Label ID="PirazinamideLabel" runat="server" CssClass="labelBold">Pirazinamide</asp:Label>
                    <asp:Label ID="Pirazinamide" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="PirazinamideInizio" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="PirazinamideFine" runat="server" CssClass="label"></asp:Label>                               
                </p>
                <p>
                    <asp:Label ID="EtambutoloLabel" runat="server" CssClass="labelBold">Etambutolo</asp:Label>
                    <asp:Label ID="Etambutolo" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="EtambutoloInizio" runat="server" CssClass="label"></asp:Label>
                    <asp:Label ID="EtambutoloFIne" runat="server" CssClass="label" ></asp:Label>                               
                </p>
                <p>
                    <label class="label" style="width:300px"><b>Altri farmaci non compresi nei precedenti</b></label>
                </p>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Farmaco" CssClass="labelBold"  Font-Bold="true" Width="100px" ></asp:Label>
                    <span style="padding-left:40px">
                    <asp:Label ID="Label2"  runat="server"   Text="Fase iniziale N° Mesi"   Font-Bold="true" CssClass="labelBold" Width="150px"  ></asp:Label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:Label ID="Label3" runat="server"   Text="Continuazione N° Mesi"   Font-Bold="true" CssClass="labelBold" Width="150px" ></asp:Label>                               
                    </span>
                </p>
                <p>
                    <asp:label ID="altro1" runat="server"   CssClass="label"></asp:label>
                    <span style="padding-left:10px">
                    <asp:label ID="altro1Inizio" runat="server" CssClass="label"></asp:label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:label ID="altro1Fine" runat="server" CssClass="label" ></asp:label>                               
                    </span>
                </p>
                <p>
                    <asp:label ID="altro2" runat="server"   CssClass="label"></asp:label>
                    <span style="padding-left:10px">
                    <asp:label ID="altro2Inizio" runat="server" CssClass="label"></asp:label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:label ID="altro2Fine" runat="server" CssClass="label" ></asp:label>                               
                    </span>
                </p>
                <p>
                    <asp:label ID="altro3" runat="server"   CssClass="label"></asp:label>
                    <span style="padding-left:10px">
                    <asp:label ID="altro3Inizio" runat="server" CssClass="label"></asp:label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:label ID="altro3Fine" runat="server" CssClass="label" ></asp:label>                               
                    </span>
                </p>
                <p>
                    <asp:label ID="altro4" runat="server"   CssClass="label"></asp:label>
                    <span style="padding-left:10px">
                    <asp:label ID="altro4Inizio" runat="server" CssClass="label"></asp:label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:label ID="altro4Fine" runat="server" CssClass="label" ></asp:label>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="TerapiaModificataLabel" runat="server" AssociatedControlID="TerapiaModificata" CssClass="labelBold">Terapia modificata</asp:Label>
                    <asp:Label ID="TerapiaModificata" runat="server" CssClass="label">                  
                    </asp:Label>
                    
                </p>
                <p>
                    <asp:Label ID="EsitoLabel" runat="server" Text="Esito del trattamento" AssociatedControlID="Esito" CssClass="labelBold"></asp:Label>
                    <asp:Label ID="Esito" runat="server" CssClass="label">                                      
                    </asp:Label>
                </p>
                <p>
                    <asp:Label ID="trasferitoLabel" runat="server" CssClass="labelBold">se trasferito: </asp:Label>
                    <asp:Label ID="trasferito" runat="server"  CssClass="Label"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="trattamentoLabel" runat="server"  CssClass="labelBold">se trattamento interrotto:</asp:Label>
                    <asp:Label ID="trattamentoInterotto" runat="server" CssClass="Label">
                    </asp:Label>

                </p>
                <p>
                    <asp:Label ID="DataChiusuraLabel" runat="server" CssClass="labelBold" Text="Data chiusura" >Data chiusura</asp:Label>
                    <asp:Label ID="DataChiusura" runat="server" CssClass="label"></asp:Label>
                </p>
                <p>
                <asp:Label ID="NoteLabel" runat="server" AssociatedControlID="Note" CssClass="labelBold" Width="100px">Note:</asp:Label>
                <asp:Label ID="Note" runat="server" CssClass="Label" Width="400px" ></asp:Label>     
                </p>
                </div>
</fieldset>