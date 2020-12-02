<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Tubercolosi.master" AutoEventWireup="false" CodeFile="Controlli.aspx.vb" Inherits="Tubercolosi_Controlli" %>

<%@ Register src="_UserControl/UcLeftTubercolosi.ascx" tagname="UcLeftTubercolosi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Tubercolosi -> Controlli
        </div >                                   
                    <label class="sezione"><b>Nome: </b> </label>
                    <asp:Label ID="nome" runat="server" CssClass="alert"></asp:Label>
                    <br />
                    <label class="sezione"><b>Cognome: </b> </label>
                    <asp:Label ID="cognome" runat="server" CssClass="alert"></asp:Label>                   
                <hr />
                <p>
                <asp:Label ID="CategoriaOMSLabel" runat="server" AssociatedControlID="CategoriaOMS" CssClass="label" Width="150px">Categoria OMS/Protocollo AIPO</asp:Label>
                    <asp:DropDownList ID="CategoriaOMS" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                        <asp:ListItem Text="I" Value="I"></asp:ListItem>
                        <asp:ListItem Text="II" Value="II"></asp:ListItem>
                        <asp:ListItem Text="III" Value="III"></asp:ListItem>
                        <asp:ListItem Text="IV" Value="IV"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                <asp:Label ID="TipologiaCasoLabel" runat="server" AssociatedControlID="TipologiaCaso" CssClass="label" Width="150px">Tipologia caso</asp:Label>                
                <asp:DropDownList ID="TipologiaCaso" runat="server" CssClass="dropdown">
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                        <asp:ListItem Text="Nuovo" Value="Nuovo"></asp:ListItem>
                        <asp:ListItem Text="Recidiva" Value="Recidiva"></asp:ListItem>
                        <asp:ListItem Text="Fallimento" Value="Fallimento"></asp:ListItem>
                        <asp:ListItem Text="Cronico" Value="Cronico"></asp:ListItem>
                        <asp:ListItem Text="Trasferito IN" Value="Trasferito IN"></asp:ListItem>
                        <asp:ListItem Text="Trasferito OUT" Value="Trasferito OUT"></asp:ListItem>
                        <asp:ListItem Text="Sospetto" Value="Sospetto"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                <asp:Label ID="RegioneLabel" runat="server" AssociatedControlID="Regione" CssClass="label" Width="150px">Regione</asp:Label>
                <asp:DropDownList ID="Regione" runat="server"  CssClass="dropdown">
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                        <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                        <asp:ListItem Text="HR" Value="HR"></asp:ListItem>
                        <asp:ListItem Text="HRE" Value="HRE"></asp:ListItem>
                        <asp:ListItem Text="HRZ" Value="HRZ"></asp:ListItem>
                        <asp:ListItem Text="HRZE" Value="HRZE"></asp:ListItem>
                        <asp:ListItem Text="HRZES" Value="HRZES"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="DataProssimoControlloLabel" runat="server" CssClass="label" AssociatedControlID="DataProssimoControllo" Width="200px">Data controllo</asp:Label>
                    <asp:TextBox ID="DataProssimoControllo" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="DataEffettivaControlloLabel" runat="server" CssClass="label" AssociatedControlID="DataEffettivaControllo" Width="200px">Data effettiva controllo</asp:Label>
                    <asp:TextBox ID="DataEffettivaControllo" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="DirettaOsservazioneLAbel" runat="server" AssociatedControlID="DirettaOsservazione" CssClass="label" Width="150px">Diretta osservazione</asp:Label>
                <asp:CheckBox ID="DirettaOsservazione" runat="server" CssClass="checkBox" />
                </p>
                <p>
                <asp:Label ID="VisitaDomiciliareLabel" runat="server" AssociatedControlID="VisitaDomiciliare" CssClass="label" Width="150px">Visita domiciliare</asp:Label>
                <asp:CheckBox ID="VisitaDomiciliare" runat="server" CssClass="checkBox" />
                </p>
                <br />
                <label class="sezione">Trattamento</label>
                <hr />
                <p>
                <asp:CheckBox ID="tr_H" runat="server" CssClass="checkBox" Text="H" TextAlign="right" Width="50px" />
                    <asp:Label ID="giorniPrescrizioneHLabel" runat="server" AssociatedControlID="giorniPrescrizioneH" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizioneH" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensioneHLabel" runat="server" AssociatedControlID="giorniSospensioneH" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensioneH" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaHLabel" runat="server" AssociatedControlID="posologiaH" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaH" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                </p>
                <p>
                   <asp:CheckBox ID="tr_R" runat="server" CssClass="checkBox" Text="R" TextAlign="right" Width="50px"/>
                    <asp:Label ID="giorniPrescrizioneRLabel" runat="server" AssociatedControlID="giorniPrescrizioneR" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizioneR" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensioneRLabel" runat="server" AssociatedControlID="giorniSospensioneR" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensioneR" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaRLabel" runat="server" AssociatedControlID="posologiaR" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaR" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                 </p>
                <p>
                   <asp:CheckBox ID="tr_Z" runat="server" CssClass="checkBox" Text="Z" TextAlign="right" Width="50px"/>
                    <asp:Label ID="giorniPrescrizioneZLabel" runat="server" AssociatedControlID="giorniPrescrizioneZ" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizioneZ" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensioneZLabel" runat="server" AssociatedControlID="giorniSospensioneZ" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensioneZ" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaZLabel" runat="server" AssociatedControlID="posologiaZ" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaZ" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                 </p>
              <p>
                   <asp:CheckBox ID="tr_S" runat="server" CssClass="checkBox" Text="S" TextAlign="right" Width="50px"/>
                    <asp:Label ID="giorniPrescrizioneSLabel" runat="server" AssociatedControlID="giorniPrescrizioneS" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizioneS" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensioneSLabel" runat="server" AssociatedControlID="giorniSospensioneS" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensioneS" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaSLabel" runat="server" AssociatedControlID="posologiaS" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaS" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                 </p>
                <p>
                   <asp:CheckBox ID="tr_E" runat="server" CssClass="checkBox" Text="E" TextAlign="right" Width="50px"/>
                    <asp:Label ID="giorniPrescrizioneELabel" runat="server" AssociatedControlID="giorniPrescrizioneE" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizioneE" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensioneELabel" runat="server" AssociatedControlID="giorniSospensioneE" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensioneE" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaELabel" runat="server" AssociatedControlID="posologiaE" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaE" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                 </p>
                <p>
                   <asp:CheckBox ID="tr_altro" runat="server" CssClass="checkBox" Text="Altro" TextAlign="right" Width="50px"/>          
                    <asp:Label ID="giorniPrescrizionealtroLabel" runat="server" AssociatedControlID="giorniPrescrizionealtro" CssClass="label" Width="100px">Prescrizione gg.</asp:Label>
                    <asp:TextBox ID="giorniPrescrizionealtro" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>  
                    <asp:Label ID="giorniSospensionealtroLabel" runat="server" AssociatedControlID="giorniSospensionealtro" CssClass="label" Width="100px">Sospensione gg.</asp:Label>
                    <asp:TextBox ID="giorniSospensionealtro" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <asp:Label ID="posologiaaltroLabel" runat="server" AssociatedControlID="posologiaaltro" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="posologiaaltro" runat="server" CssClass="textBox" Width="30px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="noteLabel" runat="server" AssociatedControlID="note" CssClass="label" Width="100px">posologia</asp:Label>
                    <asp:TextBox ID="note" runat="server" CssClass="textBox" Width="500px"></asp:TextBox> 
                 </p>

                <br />
                <label class="sezione">Esami</label>
                <hr />
                <div>
                    <div  style="float:left; padding-right:50px">
                <p>
                        <asp:Label ID="EsameBkLabele" runat="server" AssociatedControlID="EsameBk" CssClass="label">Esame diretto Bk</asp:Label>
                        <asp:DropDownList ID="EsameBk" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                        </asp:DropDownList>
                </p>
                <p>

                        <asp:Label ID="EsameColturaleLabel" runat="server" AssociatedControlID="EsameColturale" CssClass="label">Esame colturale</asp:Label>
                        <asp:DropDownList ID="EsameColturale" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Positivo" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="AntibiogrammaLabel" runat="server" AssociatedControlID="Antibiogramma" CssClass="label">Antibiogramma</asp:Label>
                        <asp:DropDownList ID="Antibiogramma" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="MantouxLabel" runat="server" AssociatedControlID="Mantoux" CssClass="label">Mantoux</asp:Label>
                        <asp:DropDownList ID="Mantoux" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="EmocromoLabel" runat="server" AssociatedControlID="Emocromo" CssClass="label">Emocromo</asp:Label>
                        <asp:DropDownList ID="Emocromo" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Normale" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Alterato" Value="Negativo"></asp:ListItem>                          
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="FunzEpaticaLabel" runat="server" AssociatedControlID="FunzEpatica" CssClass="label">Funz. epatica</asp:Label>
                        <asp:DropDownList ID="FunzEpatica" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Normale" Value="Negativo"></asp:ListItem>
                            <asp:ListItem Text="Alterato" Value="Negativo"></asp:ListItem>
                        </asp:DropDownList>
                 </p>
                 <p>
                    &nbsp;
                 </p>
                    </div>
                    <div >
                 <p>
                        <asp:Label ID="RxStandardLabel" runat="server" AssociatedControlID="Emocromo" CssClass="label">Rx standard</asp:Label>
                        <asp:DropDownList ID="RxStandard" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="TacLabel" runat="server" AssociatedControlID="Tac" CssClass="label">Tac</asp:Label>                        
                        <asp:DropDownList ID="Tac" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="StratigrafiaLabel" runat="server" AssociatedControlID="Stratigrafia" CssClass="label">Rx standard</asp:Label>
                        <asp:DropDownList ID="Stratigrafia" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="AudiometriaLabel" runat="server" AssociatedControlID="Audiometria" CssClass="label">Audiometria</asp:Label>
                        <asp:DropDownList ID="Audiometria" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="CampoVisivoLabel" runat="server" AssociatedControlID="CampoVisivo" CssClass="label">Campo visivo</asp:Label>
                        <asp:DropDownList ID="CampoVisivo" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="BroncoscopiaLabel" runat="server" AssociatedControlID="Broncoscopia" CssClass="label">Broncoscopia</asp:Label>                                                                                                 
                        <asp:DropDownList ID="Broncoscopia" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="AltriEsamiLabel" runat="server" AssociatedControlID="AltriEsami" CssClass="label">Altri esami</asp:Label>    
                        <asp:DropDownList ID="AltriEsami" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Non eseguito" Value="Non eseguito"></asp:ListItem>
                            <asp:ListItem Text="Eseguito" Value="Negativo"></asp:ListItem>   
                        </asp:DropDownList>
                </p>                
                <br />                            
                    </div>
                </div>
                <label class="sezione">Note</label>
                <hr />
                <p>
                        <asp:Label ID="complianceLabel" runat="server" AssociatedControlID="compliance" CssClass="label">Compliance</asp:Label>    
                        <asp:DropDownList ID="compliance" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text=">80% dosi prescritte" Value=">80"></asp:ListItem>
                            <asp:ListItem Text="50-80% dosi prescritte" Value="50-80"></asp:ListItem>   
                            <asp:ListItem Text="<50% dosi prescritte" Value="<50"></asp:ListItem>
                        </asp:DropDownList>
                </p>
                <p>
                        <asp:Label ID="EffettiCollateraliLabel" runat="server" AssociatedControlID="EffettiCollaterali" CssClass="label">Effetti collaterali</asp:Label>    
                        <asp:DropDownList ID="EffettiCollaterali" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            <asp:ListItem Text="Si senza modifica terapia" Value="Si senza modifica terapia"></asp:ListItem>   
                            <asp:ListItem Text="Si con modifica terapia" Value="Si con modifica terapia"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="MotivoNonEffettuatoLabel" runat="server" CssClass="label" AssociatedControlID="MotivoNonEffettuato" Width="200px">Se il coontrollo non è stato effettuato specificare il motivo</asp:Label>
                        <asp:DropDownList ID="MotivoNonEffettuato" runat="server" CssClass="dropdown">
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Deceduto" Value="Deceduto"></asp:ListItem>
                            <asp:ListItem Text="Perso al follow up" Value="Perso al follow up"></asp:ListItem>   
                            <asp:ListItem Text="Trasferito" Value="Trasferito"></asp:ListItem>   
                        </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="dataMotivoLabel" runat="server" CssClass="label" AssociatedControlID="dataMotivo" Width="200px">Data decesso/perso</asp:Label>
                    <asp:TextBox ID="dataMotivo" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="trasferitoLabel" runat="server" CssClass="label" AssociatedControlID="trasferito" Width="200px">trasferito</asp:Label>
                    <asp:TextBox ID="trasferito" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p  style="padding-left:600px">
                    <asp:Button ID="btn" runat="server" Text="Salva"/>                
                </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftTubercolosi ID="UcLeftTubercolosi1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

