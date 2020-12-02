<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/TemplateReport.master" AutoEventWireup="false" CodeFile="storico.aspx.vb" Inherits="Notifica_storico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
<div class="splitd"  >
   <div class="pag_link" >
           Simiweb -> Notifica -> <b>Storico notifica</b></div >
           <p>
            <label class="label" style="width:400px">Storico</label>
           </p>
           <p class="paragrafo">
            Di seguito sono visulizzate le modifiche della notifica nell'arco del tempo
           </p>
           <p>
            <label class="sezione">Stato</label>
            <br />
            <label class="label" style="width:200px">Non implementata</label>

            </p>
            <hr />
            <p>
            <label class="sezione">Anagrafica</label>
            <br />
            </p>
            <hr />
                <asp:ListView ID="LstAnagrafica" runat="server">
                    <EmptyDataTemplate>
                        <table id="Table1" runat="server" style="">
                            <tr>
                                <td>
                                    NEssun cambiamento</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                            </td>
                            <td>
                                <asp:Label ID="idNotificaLabel" runat="server" 
                                    Text='<%# Eval("idNotifica") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CognomeLabel" runat="server" Text='<%# Eval("Cognome") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Nazione_NascitaLabel" runat="server" 
                                    Text='<%# Eval("Nazione_Nascita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Provincia_nascitaLabel" runat="server" 
                                    Text='<%# Eval("Provincia_nascita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Comune_NascitaLabel" runat="server" 
                                    Text='<%# Eval("Comune_Nascita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataNascitaLabel" runat="server" 
                                    Text='<%# Eval("DataNascita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="EtaLabel" runat="server" Text='<%# Eval("Eta") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SessoLabel" runat="server" Text='<%# Eval("Sesso") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CodiceFiscaleNonConosciutoLabel" runat="server" 
                                    Text='<%# Eval("CodiceFiscaleNonConosciuto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CodiceFiscaleLabel" runat="server" 
                                    Text='<%# Eval("CodiceFiscale") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NumeroStpLabel" runat="server" Text='<%# Eval("NumeroStp") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StranieroNonInRegolaLabel" runat="server" 
                                    Text='<%# Eval("StranieroNonInRegola") %>' />
                            </td>
                            <td>
                                <asp:Label ID="SenzaFissaDimoraLabel" runat="server" 
                                    Text='<%# Eval("SenzaFissaDimora") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NatoEsteroLabel" runat="server" 
                                    Text='<%# Eval("NatoEstero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ProfessioneLabel" runat="server" 
                                    Text='<%# Eval("Professione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NazionalitaLabel" runat="server" 
                                    Text='<%# Eval("Nazionalita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Provincia_ResidenzaLabel" runat="server" 
                                    Text='<%# Eval("Provincia_Residenza") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Comune_ResidenzaLabel" runat="server" 
                                    Text='<%# Eval("Comune_Residenza") %>' />
                            </td>
                            <td>
                                <asp:Label ID="IndirizzoResidenzaLabel" runat="server" 
                                    Text='<%# Eval("IndirizzoResidenza") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Provincia_DomicilioLabel" runat="server" 
                                    Text='<%# Eval("Provincia_Domicilio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="Comune_domicilioLabel" runat="server" 
                                    Text='<%# Eval("Comune_domicilio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CodiceRegionaleCriptazioneLabel" runat="server" 
                                    Text='<%# Eval("CodiceRegionaleCriptazione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataWebLabel" runat="server" Text='<%# Eval("DataWeb") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataModificaLabel" runat="server" 
                                    Text='<%# Eval("DataModifica") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>
                                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                        <tr id="Tr1" runat="server" style="">
                                            <th id="Th1" runat="server">
                                                Id</th>
                                            <th id="Th2" runat="server">
                                                idNotifica</th>
                                            <th id="Th3" runat="server">
                                                Nome</th>
                                            <th id="Th4" runat="server">
                                                Cognome</th>
                                            <th id="Th5" runat="server">
                                                Nazione_Nascita</th>
                                            <th id="Th6" runat="server">
                                                Provincia_nascita</th>
                                            <th id="Th7" runat="server">
                                                Comune_Nascita</th>
                                            <th id="Th8" runat="server">
                                                DataNascita</th>
                                            <th id="Th9" runat="server">
                                                Eta</th>
                                            <th id="Th10" runat="server">
                                                Sesso</th>
                                            <th id="Th11" runat="server">
                                                CodiceFiscaleNonConosciuto</th>
                                            <th id="Th12" runat="server">
                                                CodiceFiscale</th>
                                            <th id="Th13" runat="server">
                                                NumeroStp</th>
                                            <th id="Th14" runat="server">
                                                StranieroNonInRegola</th>
                                            <th id="Th15" runat="server">
                                                SenzaFissaDimora</th>
                                            <th id="Th16" runat="server">
                                                NatoEstero</th>
                                            <th id="Th17" runat="server">
                                                Professione</th>
                                            <th id="Th18" runat="server">
                                                Nazionalita</th>
                                            <th id="Th19" runat="server">
                                                Provincia_Residenza</th>
                                            <th id="Th20" runat="server">
                                                Comune_Residenza</th>
                                            <th id="Th21" runat="server">
                                                IndirizzoResidenza</th>
                                            <th id="Th22" runat="server">
                                                Provincia_Domicilio</th>
                                            <th id="Th23" runat="server">
                                                Comune_domicilio</th>
                                            <th id="Th24" runat="server">
                                                Telefono</th>
                                            <th id="Th25" runat="server">
                                                CodiceRegionaleCriptazione</th>
                                            <th id="Th26" runat="server">
                                                DataWeb</th>
                                            <th id="Th27" runat="server">
                                                DataModifica</th>
                                        </tr>
                                        <tr ID="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                    </LayoutTemplate>
                </asp:ListView>          
            <hr />
            <label class="sezione">Clinici</label>
            <asp:Label ID="dataWeb" runat="server" Visible="false"></asp:Label>
            <hr />
            <asp:ListView id="lstClinica" runat="server">
                    <EmptyDataTemplate>
                        <table id="Table2" runat="server" style="">
                            <tr>
                                <td>
                                    Nessun cambiamento</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>                    
                    <ItemTemplate>
                        <tr style="">
                            <td>
                                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                            </td>
                            <td>
                                <asp:Label ID="IdNotificaLabel" runat="server" 
                                    Text='<%# Eval("IdNotifica") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CriterioClinicoLabel" runat="server" 
                                    Text='<%# Eval("CriterioClinico") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CriterioEpidemiologicoLabel" runat="server" 
                                    Text='<%# Eval("CriterioEpidemiologico") %>' />
                            </td>
                            <td>
                                <asp:Label ID="CriterioLaboratorioLabel" runat="server" 
                                    Text='<%# Eval("CriterioLaboratorio") %>' />
                            </td>
                            <td>
                            
                                <asp:Label ID="DataPrimiSintomiLabel" runat="server" 
                                    Text='<%# Eval("DataPrimiSintomi") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nazionePrimiSintomiLabel" runat="server" 
                                    Text='<%# Eval("nazionePrimiSintomi") %>' />
                            </td>
                            <td>
                                <asp:Label ID="provinciaSintomiLabel" runat="server" 
                                    Text='<%# Eval("provinciaSintomi") %>' />
                            </td>
                            <td>
                                <asp:Label ID="comuneSintomiLabel" runat="server" 
                                    Text='<%# Eval("comuneSintomi") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StatoVaccinaleLabel" runat="server" 
                                    Text='<%# Eval("StatoVaccinale") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataDoseUltimoVaccinoLabel" runat="server" 
                                    Text='<%# Eval("DataDoseUltimoVaccino") %>' />
                            </td>
                            <td>
                                <asp:Label ID="RicoveroOspedalieroLabel" runat="server" 
                                    Text='<%# Eval("RicoveroOspedaliero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LuogoRicoveroLabel" runat="server" 
                                    Text='<%# Eval("LuogoRicovero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="StrutturaRicoveroLabel" runat="server" 
                                    Text='<%# Eval("StrutturaRicovero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NomeStrutturaLabel" runat="server" 
                                    Text='<%# Eval("NomeStruttura") %>' />
                            </td>
                            <td>
                                <asp:Label ID="RepartoLabel" runat="server" Text='<%# Eval("Reparto") %>' />
                            </td>
                            <td>
                                <asp:Label ID="MotivoDelRicoveroLabel" runat="server" 
                                    Text='<%# Eval("MotivoDelRicovero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataRicoveroLabel" runat="server" 
                                    Text='<%# Eval("DataRicovero") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataDimissioneLabel" runat="server" 
                                    Text='<%# Eval("DataDimissione") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nazioneContagioLabel" runat="server" 
                                    Text='<%# Eval("nazioneContagio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="provinciaContagioLabel" runat="server" 
                                    Text='<%# Eval("provinciaContagio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="comuneContagioLabel" runat="server" 
                                    Text='<%# Eval("comuneContagio") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ViaggioFuoriResidenzaLabel" runat="server" 
                                    Text='<%# Eval("ViaggioFuoriResidenza") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LocalitaLabel" runat="server" Text='<%# Eval("Localita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nazione1Label" runat="server" Text='<%# Eval("nazione1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nazione2Label" runat="server" Text='<%# Eval("nazione2") %>' />
                            </td>
                            <td>
                                <asp:Label ID="nazione3Label" runat="server" Text='<%# Eval("nazione3") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ricerca1Label" runat="server" Text='<%# Eval("ricerca1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="dataesame1Label" runat="server" 
                                    Text='<%# Eval("dataesame1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="luogo1Label" runat="server" Text='<%# Eval("luogo1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="risultato1Label" runat="server" 
                                    Text='<%# Eval("risultato1") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ricerca2Label" runat="server" Text='<%# Eval("ricerca2") %>' />
                            </td>
                            <td>
                                <asp:Label ID="dataesame2Label" runat="server" 
                                    Text='<%# Eval("dataesame2") %>' />
                            </td>
                            <td>
                                <asp:Label ID="luogo2Label" runat="server" Text='<%# Eval("luogo2") %>' />
                            </td>
                            <td>
                                <asp:Label ID="risultato2Label" runat="server" 
                                    Text='<%# Eval("risultato2") %>' />
                            </td>
                            <td>
                                <asp:Label ID="ContattiStrettiLabel" runat="server" 
                                    Text='<%# Eval("ContattiStretti") %>' />
                            </td>
                            <td>
                                <asp:Label ID="comunitaLabel" runat="server" Text='<%# Eval("comunita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="AltraColletivitaLabel" runat="server" 
                                    Text='<%# Eval("AltraColletivita") %>' />
                            </td>
                            <td>
                                <asp:Label ID="NoteLabel" runat="server" Text='<%# Eval("Note") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataWebLabel" runat="server" Text='<%# Eval("DataWeb") %>' />
                            </td>
                            <td>
                                <asp:Label ID="DataModificaLabel" runat="server" 
                                    Text='<%# Eval("DataModifica") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LastUSerLabel" runat="server" Text='<%# Eval("LastUSer") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <LayoutTemplate>

                                                <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                                    <tr id="Tr2" runat="server" style="">
                                                        <th id="Th28" runat="server">
                                                            Id</th>
                                                        <th id="Th29" runat="server">
                                                            IdNotifica</th>
                                                        <th id="Th30" runat="server">
                                                            CriterioClinico</th>
                                                        <th id="Th31" runat="server">
                                                            CriterioEpidemiologico</th>
                                                        <th id="Th32" runat="server">
                                                            CriterioLaboratorio</th>
                                                        <th id="Th33" runat="server">
                                                            DataPrimiSintomi</th>
                                                        <th id="Th34" runat="server">
                                                            nazionePrimiSintomi</th>
                                                        <th id="Th35" runat="server">
                                                            provinciaSintomi</th>
                                                        <th id="Th36" runat="server">
                                                            comuneSintomi</th>
                                                        <th id="Th37" runat="server">
                                                            StatoVaccinale</th>
                                                        <th id="Th38" runat="server">
                                                            DataDoseUltimoVaccino</th>
                                                        <th id="Th39" runat="server">
                                                            RicoveroOspedaliero</th>
                                                        <th id="Th40" runat="server">
                                                            LuogoRicovero</th>
                                                        <th id="Th41" runat="server">
                                                            StrutturaRicovero</th>
                                                        <th id="Th42" runat="server">
                                                            NomeStruttura</th>
                                                        <th id="Th43" runat="server">
                                                            Reparto</th>
                                                        <th id="Th44" runat="server">
                                                            MotivoDelRicovero</th>
                                                        <th id="Th45" runat="server">
                                                            DataRicovero</th>
                                                        <th id="Th46" runat="server">
                                                            DataDimissione</th>
                                                        <th id="Th47" runat="server">
                                                            nazioneContagio</th>
                                                        <th runat="server">
                                                            provinciaContagio</th>
                                                        <th runat="server">
                                                            comuneContagio</th>
                                                        <th runat="server">
                                                            ViaggioFuoriResidenza</th>
                                                        <th runat="server">
                                                            Localita</th>
                                                        <th runat="server">
                                                            nazione1</th>
                                                        <th runat="server">
                                                            nazione2</th>
                                                        <th runat="server">
                                                            nazione3</th>
                                                        <th runat="server">
                                                            ricerca1</th>
                                                        <th runat="server">
                                                            dataesame1</th>
                                                        <th runat="server">
                                                            luogo1</th>
                                                        <th runat="server">
                                                            risultato1</th>
                                                        <th runat="server">
                                                            ricerca2</th>
                                                        <th runat="server">
                                                            dataesame2</th>
                                                        <th runat="server">
                                                            luogo2</th>
                                                        <th runat="server">
                                                            risultato2</th>
                                                        <th runat="server">
                                                            ContattiStretti</th>
                                                        <th runat="server">
                                                            comunita</th>
                                                        <th runat="server">
                                                            AltraColletivita</th>
                                                        <th runat="server">
                                                            Note</th>
                                                        <th runat="server">
                                                            DataWeb</th>
                                                        <th runat="server">
                                                            DataModifica</th>
                                                        <th runat="server">
                                                            LastUSer</th>
                                                    </tr>
                                                    <tr ID="itemPlaceholder" runat="server">
                                                    </tr>
                                                </table>
                    </LayoutTemplate>
                </asp:ListView>


   </div >   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>