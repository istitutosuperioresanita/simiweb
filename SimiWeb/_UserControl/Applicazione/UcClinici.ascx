<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcClinici.ascx.vb" Inherits="_UserControl_Applicazione_UcClinici" %>

        <p  style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
        </p>
<fieldset style="padding-right:30px">
    <legend><label class="sezione">Dati Clinici</label></legend>
        <hr />
        <label class="sezione">Criterio</label>
        <hr />
        <div style="padding-left:50px"> 
        <p>
            <label class="labelBold">Clinico</label>
            <asp:label ID="Clinico" runat="server"  CssClass="label"  Text="Clinico" Width="110px"/>
            <br />
            <label class="labelBold">Epidemiologico</label>
            <asp:label ID="Epidemiologico" runat="server" CssClass="label" Text="Epidemiologico" Width="110px"/>
            <br />            
            <label class="labelBold">Laboratorio</label>
            <asp:label ID="Laboratorio" runat="server" CssClass="label"  Text="Laboratorio" Width="110px"/>            
        </p>
        </div>
        <label class="sezione">Informazioni primi sintomi</label>
        <hr />
        <div style="padding-left:50px"> 
        <p>
            <asp:Label ID="DataPrimiSintomiLabel" runat="server"  CssClass="labelBold" >Data:</asp:Label>
            <asp:Label ID="DataPrimiSintomi" runat="server" CssClass="label"></asp:Label> 
        <br />
            <asp:Label ID="NazioneSintomiLabel" runat="server"  CssClass="labelBold" Width="60px">Nazione:</asp:Label>
            <asp:Label ID="NazioneSintomi" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="ProvinciaPrimiSintomiLabel" runat="server" CssClass="labelBold" Width="60px">Provincia:</asp:Label>
            <asp:Label ID="ProvinciaPrimiSintomi" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="ComuneSintomiLabel" runat="server" CssClass="labelBold" Width="60px">Comune:</asp:Label>
            <asp:Label ID="ComuneSintomi" runat="server" CssClass="labelView"></asp:Label>
        </p>
        </div>
        <label class="sezione">Informazioni stato vaccinale</label>
        <hr />   
        <p>
            <asp:Label ID="StatoVaccinaleLabel" runat="server"  CssClass="labelBold"  Width="100px" >Vaccinato:</asp:Label>
            <asp:Label ID="StatoVaccinale" runat="server" CssClass="labelView" Width="200px"></asp:Label>
        </p>
        <div style="padding-left:50px">
        <p>
            <asp:Label ID="DoseVaccinoLabel" runat="server" CssClass="labelBold" Width="200px" >Dose vaccino:</asp:Label>
            <asp:Label ID="DoseVaccino" runat="server" CssClass="labelView"></asp:Label>             
        </p>
        <p>
            <asp:Label ID="DataDoseVaccinoLabel" runat="server"  CssClass="labelBold" Width="200px" >Data ultima dose (o data somministrazione)::</asp:Label>
            <asp:Label ID="DataDoseVaccino" runat="server" CssClass="labelView"></asp:Label>             
        </p>
        <p>
            <asp:Label ID="NomeCommercialeLAbel" runat="server" AssociatedControlID="nomecommerciale" CssClass="labelBold" Width="200px" >Nome commerciale vaccino:</asp:Label>
            <asp:Label ID="NomeCommerciale" runat="server" CssClass="labelView" MaxLength="100"></asp:Label>             
        </p>
        <p>
            <asp:Label ID="NoteVaccinoLabel" runat="server" AssociatedControlID="NoteVaccino" CssClass="labelBold" Width="200px" >Note relative alla vaccinazione:</asp:Label>
            <asp:Label ID="NoteVaccino" runat="server" Width="400px" CssClass="labelView" MaxLength="300"></asp:Label>             
        </p>               
        </div>
        <label class="sezione">Informazioni sul ricovero</label> 
        <hr />           
        <p>
            <asp:Label ID="RicoveroLuogoDicuraLabel" runat="server"  CssClass="labelBold">Ricovero:</asp:Label>
            <asp:Label ID="RicoveroLuogoDicura" runat="server" CssClass="labelView"></asp:Label>            
         </p>
         <div style="padding-left:50px">
        <p>
            <asp:Label ID="LuogoRicoveroLabel" runat="server" CssClass="labelBold" Width="150px" >Luogo di ricovero:</asp:Label>
            <asp:Label ID="LuogoRicovero" runat="server" CssClass="labelView" ></asp:Label>
        <br />
            <asp:Label ID="StrutturaRicoveroLabel" runat="server" CssClass="labelBold" Width="150px" >Struttura di ricovero:</asp:Label>
            <asp:Label ID="StrutturaRicovero" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="RepartoLabel" runat="server"   CssClass="labelBold" Width="150px" >Reparto:</asp:Label>
            <asp:Label ID="Reparto" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="MotivoRicoveroLabel" runat="server"   CssClass="labelBold" Width="150px" >Motivo:</asp:Label>
            <asp:Label ID="MotivoRicovero" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="DataRicoveroLabel" runat="server"  CssClass="labelBold" Width="150px" >Data Ricovero:</asp:Label>
            <asp:Label ID="DataRicovero" runat="server" CssClass="labelView"></asp:Label>
        <br />
            <asp:Label ID="DataDimissioneLabel" runat="server"  CssClass="labelBold" Width="150px" >Data Dimissione:</asp:Label>
            <asp:Label ID="DataDimissione" runat="server" CssClass="labelView"></asp:Label>
        </p>
        </div>
        <label class="sezione">Ricerche diagnostiche eseguite o in corso </label>
        <hr /> 
        <div>
        <p>
            <asp:Label ID="ricerca1label" runat="server" AssociatedControlID="ricerca1" CssClass="labelBold">Tipo ricerca 1</asp:Label>
            <asp:Label ID="ricerca1" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="dataesame1label" runat="server" AssociatedControlID="dataesame1" CssClass="labelBold">Data Esame 2</asp:Label>
            <asp:Label ID="dataesame1" runat="server" CssClass="labelView"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Luogo1label" runat="server" AssociatedControlID="Luogo1" CssClass="labelBold">Luogo 1</asp:Label>
            <asp:Label ID="Luogo1" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="risultato1Label" runat="server" AssociatedControlID="risultato1" CssClass="labelBold">Risultato 1 </asp:Label>
            <asp:Label ID="risultato1" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>

        <p>
            <asp:Label ID="ricerca2Label" runat="server" AssociatedControlID="ricerca2" CssClass="labelBold">Tipo ricerca 2</asp:Label>
            <asp:Label ID="ricerca2" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="dataesame2Label" runat="server" AssociatedControlID="dataesame2" CssClass="labelBold">Data esame 2</asp:Label>
            <asp:Label ID="dataesame2" runat="server" CssClass="labelView"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Luogo2Label" runat="server" AssociatedControlID="Luogo2" CssClass="labelBold">Luogo 2</asp:Label>
            <asp:Label ID="Luogo2" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="risultatoLabel2" runat="server" AssociatedControlID="risultato2" CssClass="labelBold">Risultato 2</asp:Label>
            <asp:Label ID="risultato2" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        <p>
            <asp:Label ID="agenteLabel" runat="server" AssociatedControlID="agente" CssClass="labelBold">Agente identificato:</asp:Label>
            <asp:Label ID="agente" runat="server" CssClass="labelView" Width="300px"></asp:Label>
        </p>
        </div>
        <label class="sezione">Dati esposizione</label>
        <hr /> 
        <p>
            <asp:Label ID="ViaggioLabel" AssociatedControlID="Viaggio" runat="server" CssClass="labelBold" Width="300px">Viaggi o soggiorni al di fuori della residenza</asp:Label>
            <asp:Label ID="Viaggio" runat="server" CssClass="label" Width="200px"></asp:Label>
        </p>
        <div style="padding-left:50px">        
        <p>
            <asp:Label ID="Nazione1Label" runat="server"  CssClass="labelBold" Width="70px">Nazione 1:</asp:Label>
            <asp:Label ID="Nazione1" runat="server" CssClass="labelView" Width="150px" ></asp:Label>  
            <asp:Label ID="Nazione1Periodolabel" AssociatedControlID="Nazione1Periodo" runat="server" CssClass="labelBold" Width="50px">Periodo</asp:Label>
            <asp:Label ID="Nazione1Periodo" runat="server" CssClass="labelView" Width="200px"></asp:Label>                                         
        <br />
            <asp:Label ID="Nazione2Label" runat="server"  CssClass="labelBold" Width="70px">Nazione 2:</asp:Label>
            <asp:Label ID="Nazione2" runat="server" CssClass="labelView" Width="150px" ></asp:Label>                    
            <asp:Label ID="Nazione2PeriodoLabel" AssociatedControlID="Nazione2Periodo" runat="server" CssClass="labelBold" Width="50px">Periodo</asp:Label>
            <asp:Label ID="Nazione2Periodo" runat="server" CssClass="labelView" Width="200px"></asp:Label>                   
        <br />
            <asp:Label ID="Nazione3Label" runat="server"  CssClass="labelBold" Width="70px">Nazione 3:</asp:Label>
            <asp:Label ID="Nazione3" runat="server" CssClass="labelView" Width="150px" ></asp:Label>                           
            <asp:Label ID="Nazione3PeriodoLabel" AssociatedControlID="Nazione3Periodo" runat="server" CssClass="labelBold" Width="50px">Periodo</asp:Label>
            <asp:Label ID="Nazione3Periodo" runat="server" CssClass="labelView" Width="200px"></asp:Label>                   
        </p>
        </div>
        <label class="sezione">Dati presunto contagio</label>
        <hr />  
        <div style="padding-left:50px">
        <p>
            <asp:Label ID="NazioneContagioLabel" runat="server" CssClass="labelBold">Nazione:</asp:Label>
            <asp:Label ID="NazioneContagi" runat="server" CssClass="labelView"></asp:Label>  
        <br />
            <asp:Label ID="ProvinciaContagioLabel" runat="server"  CssClass="labelBold">Provincia:</asp:Label>
            <asp:Label ID="ProvinciaContagio" runat="server" CssClass="labelView"></asp:Label>       
        <br />
            <asp:Label ID="ComuneContagioLabel" runat="server"  CssClass="labelBold">Comune:</asp:Label>
            <asp:Label ID="ComuneContagio" runat="server" CssClass="labelView"></asp:Label>    
        <br />
            <asp:Label ID="CasiCorrelatiLabel" runat="server"  CssClass="labelBold">Casi correlati:</asp:Label>
            <asp:Label ID="CasiCorrelati" runat="server" CssClass="labelView"></asp:Label>                                 
        <br />
            <asp:Label ID="ContattiStrettiLabel" runat="server"  CssClass="labelBold">Contatti stretti:</asp:Label>
            <asp:Label ID="ContattiStretti" runat="server" CssClass="labelView"></asp:Label>   
        <br />
         <asp:Panel ID="pnlMib" runat="server">
            <label class="labelBold" style="width:300px">Nei 10 giorni precedenti l'inizio dei sintomi: </label>
         <br />
         <br />
            <label class="labelBold" style="width:430px">il paziente è stato a contatto con un altro caso della stessa malattia ?</label>
            <asp:Label ID="contatto" runat="server" CssClass="labelView">
            </asp:Label>
            
         <br />
         <br />
            <label class="labelBold" style="width:350px">probabile contagio fuori dall'area di domicilio abituale ?</label>
            <asp:Label ID="contagio" runat="server" CssClass="labelView">             
            </asp:Label>
            <label class="labelBold" style="width:100px">Se si, dove ?</label>
            <asp:Label ID="contagioDove" runat="server" CssClass="labelView"></asp:Label>
        <br />
        <br />
            <label class="labelBold"  style="width:350px">il caso fa parte di un focolaio epidemico ?</label>
            <asp:Label ID="focolaio" runat="server" CssClass="labelView">              
            </asp:Label>
        <br />
        <br />
             <label class="labelBold" style="width:100px">Se si, quale ?</label>
             <asp:Label ID="focolaioDescrizione" runat="server" CssClass="labelView"></asp:Label>
         </asp:Panel>
        <br />
        <br />
            <asp:Label ID="CollettivitaLabel" runat="server"  CssClass="labelBold">Collettività:</asp:Label>
            <asp:Label ID="Collettivita" runat="server" CssClass="labelView"></asp:Label> 
        <br />
            <asp:Label ID="AltreColettivitaLabel"  runat="server"   CssClass="labelBold">Altra collettività:</asp:Label>
            <asp:Label ID="AltreColettivita" runat="server" CssClass="labelView"></asp:Label> 
        </p>
        </div>
        <div>
        <label class="sezione">Esito</label>
        <hr />
        <p>
            <asp:Label ID="decedutoLbl"  runat="server" AssociatedControlID="deceduto"  CssClass="labelBold" Width="200px">Il paziente risulta deceduto ? :</asp:Label>
            <asp:Label ID="deceduto" runat="server" CssClass="labelView"></asp:Label>
        </p>
        </div>
        <div>
        <label class="sezione">Note</label>
        <hr />
            <asp:Label ID="noteLabel"  runat="server"   CssClass="labelBold">note:</asp:Label>
            <asp:Label ID="note" runat="server" CssClass="labelView"></asp:Label> 
        </div>
</fieldset>