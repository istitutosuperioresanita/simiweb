<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
ClientIDMode="Static"
CodeFile="EditTubercolosi.aspx.vb" 
Inherits="Notifica_EditTubercolosi" %>

<%@ Register src="../_UserControl/Applicazione/UcStatoSegnalazione.ascx" tagname="UcStatoSegnalazione" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Js/tbc.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Tubercolosi Informazioni aggiuntive</b>
        </div >  
         <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
                     <asp:HiddenField ID="dataWeb" runat="server" />   
        <br />
         <uc1:UcStatoSegnalazione ID="UcStatoSegnalazione1" runat="server" />
        <br />
            <hr />
<%--            <p>
                <asp:Label ID="Label1" runat="server"  CssClass="label" AssociatedControlID="Tipo">Tipo:</asp:Label>
                <asp:DropDownList ID="Tipo" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Tubercolosi" Value="Tubercolosi"></asp:ListItem>
                    <asp:ListItem Text="Micobatteriosi" Value="Micobatteriosi"></asp:ListItem>
                </asp:DropDownList>
            </p>--%>
            <p>
                <asp:Label ID="DataInizioTerapiaTubercolareLabel" runat="server" AssociatedControlID="DataInizioTerapiaTubercolare" 
                                        CssClass="label" 
                                        Width="250px">DataInizio Terapia Tubercolare:</asp:Label>
                <asp:TextBox ID="DataInizioTerapiaTubercolare" runat="server" CssClass="textBox"></asp:TextBox> 
                <label class="label" style="width:250px">(se diagnosi post-mortem indicare la data di decesso)</label>      
            </p>
            <p>
                <asp:Label ID="LivelloDiAccertamentoLabel" runat="server"  CssClass="label" AssociatedControlID="LivelloDiAccertamento" Width="250px">Livello di accertamento:</asp:Label>
                <asp:DropDownList ID="LivelloDiAccertamento" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Accertato" Value="Accertato"></asp:ListItem>
                    <asp:ListItem Text="Sospetto" Value="Sospetto"></asp:ListItem>
                    <asp:ListItem Text="Non confermato" Value="Non confermato"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Label ID="DiagnosiTubercolosiPassatoLabel" runat="server"  CssClass="label" 
                            AssociatedControlID="DiagnosiTubercolosiPassato"  Width="250px">Diagnosi tubercolosi passata:</asp:Label>
                <asp:DropDownList ID="DiagnosiTubercolosiPassato" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>                    
                </asp:DropDownList>
            </p>
            <div style="padding-left:50px;">
                <label class="label" style="width:300px"><i>Se si, specificare</i></label>
            <br />
            <p>
                <br />
                <asp:Label ID="annoLabel" runat="server" AssociatedControlID="anno" CssClass="label" Width="50px">Anno:</asp:Label>
                <asp:TextBox ID="anno" runat="server" CssClass="textBox" Width="50px" MaxLength="4"></asp:TextBox>
                <label class="label">(aaaa)</label>
                <asp:Label ID="meseLabel" runat="server" AssociatedControlID="mese" CssClass="label" Width="50px">Mese:</asp:Label>
                <asp:TextBox ID="mese" runat="server" CssClass="textBox" Width="50px" MaxLength="2"></asp:TextBox>         
                <label class="label">(mm)</label>                    
            </p>
            </div>
            <p>
                <asp:Label ID="TipoClassificazioneLabel" runat="server"  CssClass="label" 
                            AssociatedControlID="TipoClassificazione"  Width="300px">Classificazione in relazione a precedenti trattamenti:</asp:Label>
                <asp:DropDownList ID="TipoClassificazione" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                    <asp:ListItem Text="Nuovo caso" Value="Nuovo caso"></asp:ListItem>
                    <asp:ListItem Text="Recidiva" Value="Recidiva"></asp:ListItem>                 
                </asp:DropDownList>      
            </p>
            <p>
                <asp:Label ID="AgenteLabel" runat="server"  CssClass="label" AssociatedControlID="Agente"  Width="300px">Agente Eziologico</asp:Label>
                <asp:DropDownList ID="Agente" runat="server" CssClass="dropdown">
                </asp:DropDownList>      
            </p>
            <p>
                <asp:Label ID="AltroAgenteLabel" runat="server" AssociatedControlID="AltroAgente" CssClass="label" >Altro:</asp:Label>
                <asp:TextBox ID="AltroAgente" runat="server" CssClass="textBox"></asp:TextBox>     
            </p>
            <p>
                <asp:Label ID="antibiogrammaLabel" runat="server" AssociatedControlID="Antibiogramma" CssClass="label">Antibiogramma:</asp:Label>
                <asp:DropDownList ID="Antibiogramma" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="Selezionare..."></asp:ListItem>                    
                    <asp:ListItem Value="No" Text="No"></asp:ListItem>
                    <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                </asp:DropDownList>
            </p>
            <p style="padding-left:50px">
               <asp:Label ID="STRELabel" runat="server" CssClass="label">STRE</asp:Label>
               <asp:DropDownList ID="STRE" runat="server" CssClass="dropdown" >
                    <asp:ListItem Value="" Text="non indicato" ></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="R" Text="R"></asp:ListItem>
               </asp:DropDownList>
               <br />
               <br />
               <asp:Label ID="INHLabel" runat="server" CssClass="label" >INH</asp:Label> 	
               <asp:DropDownList ID="INH" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="non indicato"></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="R" Text="R"></asp:ListItem>               
               </asp:DropDownList>
               <br />
               <br />
               <asp:Label ID="RMPLabel" runat="server" CssClass="label">RMP</asp:Label> 	
               <asp:DropDownList ID="RMP" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="non indicato"></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="R" Text="R"></asp:ListItem>               
               </asp:DropDownList>
               <br />
               <br />
               <asp:Label ID="EMBLabel" runat="server"  CssClass="label">EMB</asp:Label> 	
               <asp:DropDownList ID="EMB" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="non indicato"></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="R" Text="R"></asp:ListItem>               
               </asp:DropDownList>
               <br />
               <br />
               <asp:Label ID="PZALabel" runat="server" CssClass="label">PZA</asp:Label> 	
               <asp:DropDownList ID="PZA" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="" Text="non indicato"></asp:ListItem>
                    <asp:ListItem Value="S" Text="S"></asp:ListItem>
                    <asp:ListItem Value="R" Text="R"></asp:ListItem>               
               </asp:DropDownList>

            </p>
         <label class="sezione">Esami</label>
                    <hr />
                    <p>
                            <asp:Label ID="EsameColturaleEscreatoLabel" runat="server" AssociatedControlID="EsameColturaleEscreato" CssClass="label" Width="200px">Esame colturale escreato</asp:Label>
                            <asp:DropDownList ID="EsameColturaleEscreato" runat="server" CssClass="dropdown">
                                <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                                <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                                <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                            </asp:DropDownList>
                    </p>
                    <p>

                            <asp:Label ID="EsameColturaleAltroMaterialeLabel" runat="server" AssociatedControlID="EsameColturaleAltroMateriale" CssClass="label" Width="200px">Esame colturale altro materiale</asp:Label>
                            <asp:DropDownList ID="EsameColturaleAltroMateriale" runat="server" CssClass="dropdown">
                                <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                                <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                                <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                            </asp:DropDownList>
                            <asp:Label ID="EsameColturaleDescLabel" runat="server" AssociatedControlID="EsameColturaleDesc" CssClass="label" Width="150px" style="padding-left:20px;">se altro, materiale:</asp:Label>
                            <asp:TextBox ID="EsameColturaleDesc" runat="server" CssClass="textBox"></asp:TextBox>
                    </p>
                    <p>
                            <asp:Label ID="EsameDirettoEscreatoLabel" runat="server" AssociatedControlID="EsameDirettoEscreato" CssClass="label" Width="200px">Esame Diretto escreato</asp:Label>
                            <asp:DropDownList ID="EsameDirettoEscreato" runat="server" CssClass="dropdown">
                                <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                                <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                                <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                            </asp:DropDownList>
                    </p>
                    <p>
                            <asp:Label ID="EsamedirettoaltromaterialeLabel" runat="server" AssociatedControlID="Esamedirettoaltromateriale" CssClass="label" Width="200px">Esame diretto altro materiale</asp:Label>
                            <asp:DropDownList ID="Esamedirettoaltromateriale" runat="server" CssClass="dropdown">
                                <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                                <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                                <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                            </asp:DropDownList>
                            <asp:Label ID="EsamedirettoaltromaterialeDescLabel" runat="server" AssociatedControlID="EsamedirettoaltromaterialeDesc" CssClass="label" Width="150px" style="padding-left:20px;">se altro, materiale:</asp:Label>
                            <asp:TextBox ID="EsamedirettoaltromaterialeDesc" runat="server" CssClass="textBox"></asp:TextBox>

                    </p>
                    <p>
                            <asp:Label ID="ClinicaLabel" runat="server" AssociatedControlID="Clinica" CssClass="label" Width="200px">Clinica</asp:Label>
                            <asp:DropDownList ID="Clinica" runat="server" CssClass="dropdown">
                                <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                                <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                                <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                                <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                           
                            </asp:DropDownList>
                    </p>
                <p>
                        <asp:Label ID="MantouxLabel" runat="server" AssociatedControlID="Mantoux" CssClass="label" Width="200px">Mantoux</asp:Label>
                        <asp:DropDownList ID="Mantoux" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                        </asp:DropDownList>
                 </p>
                 <p>
                        <asp:Label ID="RxStandardLabel" runat="server" AssociatedControlID="RxStandard" CssClass="label" Width="200px">Rx torace/Esami strumentali</asp:Label>
                        <asp:DropDownList ID="RxStandard" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="RispostaTerapiaLabel" runat="server" AssociatedControlID="RispostaTerapia" CssClass="label" Width="200px">Risposta alla terapia antitubercolare</asp:Label>
                        <asp:DropDownList ID="RispostaTerapia" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>    
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="RiscontroAutopicoLabel" runat="server" AssociatedControlID="RiscontroAutopico" CssClass="label" Width="200px">Riscontro autoptico di TB attiva</asp:Label>
                        <asp:DropDownList ID="RiscontroAutopico" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                        </asp:DropDownList>
                </p>       
                <p>

                        <asp:Label ID="QuantiferonLabel" runat="server" AssociatedControlID="Quantiferon" CssClass="label" Width="200px">Quantiferon</asp:Label>
                        <asp:DropDownList ID="Quantiferon" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>   
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>   
                        </asp:DropDownList>      
                </p>      

            <label class="sezione">Sede anatomica</label>
            <br />
            <label class="label" style="width:600px">(la localizzazione polmonare deve essere barrata sempre anche se secondaria o disseminata)</label>
            <hr />
            <p>
                <asp:Label ID="SedePolmonareLabel" runat="server" AssociatedControlID="SedePolmonare" CssClass="label" Width="200px" >Polmonare/tracheale/bronchiale:</asp:Label>
                <asp:CheckBox ID="SedePolmonare" runat="server" CssClass="checkBox"></asp:CheckBox>     
            </p>
            <p>
                <asp:Label ID="SedeExtraPolmonareLabel" runat="server" AssociatedControlID="SedeExtraPolmonare" CssClass="label" Width="200px" >Extrapolmonare:</asp:Label>
                <asp:CheckBox ID="SedeExtraPolmonare" runat="server" CssClass="checkBox"></asp:CheckBox>     
            </p>
            <div style="padding-left:250px;">
                <asp:Label ID="Localizzazione1Label" runat="server"  CssClass="label" AssociatedControlID="Localizzazione1" Width="100px" >Localizzazione 1:</asp:Label>
                <asp:DropDownList ID="Localizzazione1" runat="server" CssClass="dropdown">           
                </asp:DropDownList>   
                <p>
                <asp:Label ID="Localizzazione2Label" runat="server"  CssClass="label" AssociatedControlID="Localizzazione2" >Localizzazione 2:</asp:Label>
                <asp:DropDownList ID="Localizzazione2" runat="server" CssClass="dropdown">            
                </asp:DropDownList>                  
                </p>
                </div>
                <p>
                <asp:Label ID="MiliareLabel" runat="server" AssociatedControlID="Miliare" CssClass="label" Width="200px" >Miliare:</asp:Label>
                <asp:CheckBox ID="Miliare" runat="server" CssClass="checkBox"></asp:CheckBox>     
                </p>
                <p>
                <asp:Label ID="DisseminataLabel" runat="server"  CssClass="label" AssociatedControlID="Disseminata" >Disseminata:</asp:Label>
                <asp:DropDownList ID="Disseminata" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>   
                    <asp:ListItem Text="Miliare" Value="miliare"></asp:ListItem>   
                    <asp:ListItem Text="Da più localizzazioni" Value="localizzazioni"></asp:ListItem>     
                    <asp:ListItem Text="Da sangue" Value="sangue"></asp:ListItem>                                
                </asp:DropDownList>                  
                </p>
                <label class="sezione">Sorveglianza dell'esito</label>
                <hr />
                <p>
                <asp:Label ID="DataInizioTerapiaCentroLabel" runat="server" CssClass="label" Text="Data Inizio terapia presso il centro" Width="300px"></asp:Label>
                <asp:TextBox ID="DataInizioTerapiaCentro" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lblTipo" runat="server" Text="" CssClass="label"><b>Farmaco</b></asp:Label>
                    <span style="padding-left:45px">
                    <asp:Label ID="faseIniziale"  runat="server"   Text="Fase iniziale N° Mesi"   Font-Bold="true" CssClass="label" Width="150px"></asp:Label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:Label ID="Continuazione" runat="server"   Text="Continuazione N° Mesi"   Font-Bold="true" CssClass="label" Width="150px" ></asp:Label>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="IsoniazideLAbel" runat="server" Text="Isoniazide" CssClass="label">Isoniazide</asp:Label>
                    <asp:DropDownList ID="Isoniazide" runat="server" CssClass="dropdown">                        
                        <asp:ListItem Text="no" Value="no"></asp:ListItem>
                        <asp:ListItem Text="si" Value="si"></asp:ListItem>
                    </asp:DropDownList>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="IsoniazideInizio" runat="server" CssClass="textBox" MaxLength="3"></asp:TextBox>
                    </span>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="IsoniazideFine" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="RifampicinaLabel" runat="server" CssClass="label">Rifampicina</asp:Label>
                    <asp:DropDownList ID="Rifampicina" runat="server" CssClass="dropdown">                        
                        <asp:ListItem Text="no" Value="no"></asp:ListItem>
                        <asp:ListItem Text="si" Value="si"></asp:ListItem>
                    </asp:DropDownList>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="RifampicinaInizio" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>
                    </span>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="RifampicinaFine" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="PirazinamideLabel" runat="server" CssClass="label">Pirazinamide</asp:Label>
                    <asp:DropDownList ID="Pirazinamide" runat="server" CssClass="dropdown">                        
                        <asp:ListItem Text="no" Value="no"></asp:ListItem>
                        <asp:ListItem Text="si" Value="si"></asp:ListItem>
                    </asp:DropDownList>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="PirazinamideInizio" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>
                    </span>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="PirazinamideFine" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="EtambutoloLabel" runat="server" CssClass="label">Etambutolo</asp:Label>
                    <asp:DropDownList ID="Etambutolo" runat="server" CssClass="dropdown">                        
                        <asp:ListItem Text="no" Value="no"></asp:ListItem>
                        <asp:ListItem Text="si" Value="si"></asp:ListItem>
                    </asp:DropDownList>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="EtambutoloInizio" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>
                    </span>
                         <span style="padding-left:10px">
                    <asp:TextBox ID="EtambutoloFIne" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <label class="label" style="width:300px"><b>Altri farmaci non compresi nei precedenti</b></label>
                </p>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Farmaco" CssClass="label"  Font-Bold="true" Width="100px" ></asp:Label>
                    <span style="padding-left:40px">
                    <asp:Label ID="Label2"  runat="server"   Text="Fase iniziale N° Mesi"   Font-Bold="true" CssClass="label" Width="150px" ></asp:Label>
                    </span>
                    <span style="padding-left:10px">
                    <asp:Label ID="Label3" runat="server"   Text="Continuazione N° Mesi"   Font-Bold="true" CssClass="label" Width="150px" ></asp:Label>                               
                    </span>
                </p>
                <p>
                    <asp:TextBox ID="altro1" runat="server"   CssClass="textBox"></asp:TextBox>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro1Inizio" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>
                    </span>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro1Fine" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:TextBox ID="altro2" runat="server"   CssClass="textBox"></asp:TextBox>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro2Inizio" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>
                    </span>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro2Fine" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:TextBox ID="altro3" runat="server"   CssClass="textBox"></asp:TextBox>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro3Inizio" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>
                    </span>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro3Fine" runat="server" CssClass="textBox" MaxLength="3" ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:TextBox ID="altro4" runat="server"   CssClass="textBox"></asp:TextBox>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro4Inizio" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>
                    </span>
                    <span style="padding-left:10px">
                    <asp:TextBox ID="altro4Fine" runat="server" CssClass="textBox" MaxLength="3"  ></asp:TextBox>                               
                    </span>
                </p>
                <p>
                    <asp:Label ID="TerapiaModificataLabel" runat="server" AssociatedControlID="TerapiaModificata" CssClass="label">Terapia modificata</asp:Label>
                    <asp:DropDownList ID="TerapiaModificata" runat="server" CssClass="dropdown">
                            <asp:ListItem Value="" Text="Non indicato"></asp:ListItem>
                            <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                            <asp:ListItem Value="No" Text="No"></asp:ListItem>                    
                    </asp:DropDownList>
                    
                </p>
                <p>
                    <asp:Label ID="EsitoLabel" runat="server" Text="Esito del trattamento" AssociatedControlID="Esito" CssClass="label"></asp:Label>
                    <asp:DropDownList ID="Esito" runat="server" CssClass="dropdown"> 
                            <asp:ListItem Value="Non disponibile" Text=""></asp:ListItem>
                            <asp:ListItem Value="guarito" Text="guarito"></asp:ListItem>
                            <asp:ListItem Value="trattamento completato" Text="trattamento completato"></asp:ListItem>
                            <asp:ListItem Value="deceduto" Text="deceduto"></asp:ListItem>      
                            <asp:ListItem Value="fallimento terapeutico" Text="fallimento terapeutico"></asp:ListItem>
                            <asp:ListItem Value="trasferito" Text="trasferito"></asp:ListItem>
                            <asp:ListItem Value="interotto" Text="interotto"></asp:ListItem>                            
                            <asp:ListItem Value="No" Text="No"></asp:ListItem>                                              
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="trasferitoLabel" runat="server" CssClass="label">se trasferito</asp:Label>
                    <asp:TextBox ID="trasferito" runat="server"  CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="trattamentoLabel" runat="server"  CssClass="label">se trattamento interrotto</asp:Label>
                    <asp:DropDownList ID="trattamentoInterotto" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="" Text="non indicato"></asp:ListItem>
                        <asp:ListItem Value="comparsa effetti collaterali" Text="comparsa effetti collaterali"></asp:ListItem>
                        <asp:ListItem Value="paziente non collaborante" Text="paziente non collaborante"></asp:ListItem>
                        <asp:ListItem Value="perso al follow up" Text="perso al follow up"></asp:ListItem>
                    </asp:DropDownList>

                </p>
                <p>
                    <asp:Label ID="DataChiusuraLabel" runat="server" CssClass="label" Text="Data chiusura" >Data chiusura</asp:Label>
                    <asp:TextBox ID="DataChiusura" runat="server" CssClass="textBox"></asp:TextBox> (gg/mm/aaaa)
                </p>
                <p>
                    <asp:Label ID="NoteLabel" runat="server" AssociatedControlID="Note" CssClass="label" >Note:</asp:Label>
                    <asp:TextBox ID="Note" runat="server" CssClass="textBox" Width="400px" Height="200px"></asp:TextBox>     
                </p>
            <p  style="padding-left:600px">
                <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" CausesValidation="false"  Visible="true" UseSubmitBehavior="false"/>    
                <asp:Button ID="btn" runat="server" Text="Salva"  Visible="true" UseSubmitBehavior="false"/>                
            </p>

</div>         
    </label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

