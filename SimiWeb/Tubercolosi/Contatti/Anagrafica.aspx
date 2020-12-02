<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Tubercolosi.master" AutoEventWireup="false" CodeFile="Anagrafica.aspx.vb" Inherits="Tubercolosi_Contatti_Anagrafica" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Tubercolosi -> Contatto -->Anagrafica
        </div >       
            <br />
                <br />
                <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="cognome" CssClass="label" Width="150px">Cognome paziente</asp:Label>
                <asp:Label ID="cognome" runat="server" CssClass="Label"></asp:Label>
                <asp:Label ID="nomeLabel" runat="server" AssociatedControlID="nome" CssClass="label" Width="150px">Nome paziente</asp:Label>
                <asp:Label ID="nome" runat="server" CssClass="Label"></asp:Label>
                </p>
                <label class="sezione">Anagrafica contatto</label>
                <hr />
                <p>
                    <asp:Label ID="NomeContattoLabel" runat="server" AssociatedControlID="NomeContatto" CssClass="label" Width="150px">Nome</asp:Label>
                    <asp:textbox ID="NomeContatto" runat="server" CssClass="textBox"></asp:textbox>
                </p>
                <p>
                    <asp:Label ID="CongomeContattoLabel" runat="server" AssociatedControlID="CognomeContatto" CssClass="label" Width="150px">Cognome</asp:Label>
                    <asp:textbox ID="CognomeContatto" runat="server" CssClass="textBox"></asp:textbox> 
                </p>
                <p>
                    <asp:Label ID="DataNascitaLabel" runat="server" AssociatedControlID="DataNascita" CssClass="label" Width="150px">data nascita</asp:Label>
                    <asp:textbox ID="DataNascita" runat="server" CssClass="textBox"></asp:textbox> 
                </p>
                <p>
                    <asp:Label ID="ProvinciaLabel" runat="server" AssociatedControlID="Provincia" CssClass="label" Width="150px">Provincia</asp:Label>
                    <asp:DropDownList ID="Provincia" runat="server" CssClass="dropdown"></asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="ComuneLabel" runat="server" AssociatedControlID="Comune" CssClass="label" Width="150px">Comune</asp:Label>
                    <asp:DropDownList ID="Comune" runat="server" CssClass="dropdown"></asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="ViaLabel" runat="server" AssociatedControlID="Via" CssClass="label" Width="150px">Via</asp:Label>
                    <asp:textbox ID="Via" runat="server" CssClass="textBox"></asp:textbox> 
                </p>
                <p>
                    <asp:Label ID="TelefonoLabel" runat="server" AssociatedControlID="Telefono" CssClass="label" Width="150px">Telefono</asp:Label>
                    <asp:textbox ID="Telefono" runat="server" CssClass="textBox"></asp:textbox> 
                </p>
                <p>
                    <asp:Label ID="domicilioLabel" runat="server" AssociatedControlID="Domicilio" CssClass="label" Width="150px">Telefono</asp:Label>
                    <asp:textbox ID="Domicilio" runat="server" CssClass="textBox"></asp:textbox> 

                </p>
                <label class="sezione">Classsificazione</label>
                <hr />
                <p>
                    <asp:Label ID="tipoContattoLabel" runat="server" AssociatedControlID="tipo" CssClass="label">Tipo contatto</asp:Label>
                    <asp:DropDownList ID="tipo" runat="server" CssClass="dropdown">                        
                        <asp:ListItem Text="Stretto" Value="Stretto"></asp:ListItem>
                        <asp:ListItem Text="Occasionale" Value="Occasionale"></asp:ListItem>
                        <asp:ListItem Text="Regolare" Value="Regolare"></asp:ListItem>
                        <asp:ListItem Text="Non stretto" Value="Non Stretto"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="ambitoLabel" runat="server" AssociatedControlID="ambito" CssClass="label">Ambito del contatto</asp:Label>
                    <asp:DropDownList ID="ambito" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                        <asp:ListItem Text="Lavoro" Value="Lavoro"></asp:ListItem>
                        <asp:ListItem Text="Familiare" Value="Occasionale"></asp:ListItem>
                        <asp:ListItem Text="Ospedale" Value="Ospedale"></asp:ListItem>
                        <asp:ListItem Text="Scuola" Value="Scuola"></asp:ListItem>
                        <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="altroAmbitoLabel" runat="server" AssociatedControlID="altroAmbito" CssClass="label" Width="150px">se altro, specificare</asp:Label>
                    <asp:textbox ID="altroAmbito" runat="server" CssClass="textBox"></asp:textbox> 
                </p>
                <p>
                    <asp:Label ID="VaccinatoCBGLAbel" runat="server" AssociatedControlID="VaccinatoCBG" CssClass="label">Vaccinato CBG</asp:Label>
                    <asp:DropDownList ID="VaccinatoCBG" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="VaccinatoCBGDataLabel" runat="server" AssociatedControlID="VaccinatoCBGData" CssClass="label">se si, data</asp:Label>
                    <asp:TextBox ID="VaccinatoCBGData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="PrecedentiTBCLabel" runat="server" AssociatedControlID="PrecedentiTBC" CssClass="label">Prec. TBC curati</asp:Label>
                    <asp:DropDownList ID="PrecedentiTBC" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="PrecedentiTBCDataLabel" runat="server" AssociatedControlID="PrecedentiTBCData" CssClass="label">se si, data</asp:Label>
                    <asp:TextBox ID="PrecedentiTBCData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <label class="sezione">Risposta a PPD</label>
                <hr />
                <label class="label" style="width:600px;"><i>(Mantoux 5UI) rispetto alla data della denuncia del caso</i></label>
                <p>
                    <asp:Label ID="mantouxPrecLabel" runat="server" AssociatedControlID="mantouxPrec" CssClass="label">Precedente</asp:Label>
                    <asp:DropDownList ID="mantouxPrec" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                        <asp:ListItem Text="Positivo" Value="Positivo"></asp:ListItem>
                        <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="mantouxPrecMMLabel" runat="server" AssociatedControlID="mantouxPrecMM" CssClass="label">se positivo, mm</asp:Label>
                    <asp:TextBox ID="mantouxPrecMM" runat="server" CssClass="textBox" Width="20px"></asp:TextBox>
                    <asp:Label ID="mantouxPrecDataLabel" runat="server" AssociatedControlID="mantouxPrecData" CssClass="label" Width="50px">data</asp:Label>
                    <asp:TextBox ID="mantouxPrecData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="mantouxPrimoLabel" runat="server" AssociatedControlID="mantouxPrimoLabel" CssClass="label">Primo controllo</asp:Label>
                    <asp:DropDownList ID="mantouxPrimo" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="mantouxPrimoMMLabel" runat="server" AssociatedControlID="mantouxPrimoMM" CssClass="label">se positivo, mm</asp:Label>
                    <asp:TextBox ID="mantouxPrimoMM" runat="server" CssClass="textBox" Width="20px"></asp:TextBox>
                    <asp:Label ID="mantouxPrimoDataLabel" runat="server" AssociatedControlID="mantouxPrecData" CssClass="label" Width="50px">data</asp:Label>
                    <asp:TextBox ID="mantouxPrimoData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="mantouxDopoLabel" runat="server" AssociatedControlID="mantouxDopo" CssClass="label">Vaccinato BCG</asp:Label>
                    <asp:DropDownList ID="mantouxDopo" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="mantouxDopoMMLabel" runat="server" AssociatedControlID="mantouxDopoMM" CssClass="label">se positivo, mm</asp:Label>
                    <asp:TextBox ID="mantouxDopoMM" runat="server" CssClass="textBox" Width="20px"></asp:TextBox>
                    <asp:Label ID="mantouxDopoDataLabel" runat="server" AssociatedControlID="mantouxDopoData" CssClass="label" Width="50px">data</asp:Label>
                    <asp:TextBox ID="mantouxDopoData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="RXToraceLabel" runat="server" AssociatedControlID="RXTorace" CssClass="label">Rx Torace</asp:Label>
                    <asp:DropDownList ID="RXTorace" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Non effettuato" Value="Non effettuato"></asp:ListItem>                                         
                        <asp:ListItem Text="Positivo per TBC Attiva" Value="Positivo per TBC Attiva"></asp:ListItem>
                        <asp:ListItem Text="Esiti fibrotici" Value="Esiti fibrotici"></asp:ListItem>
                        <asp:ListItem Text="Negativo" Value="Negativo"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="RXToraceDataLabel" runat="server" AssociatedControlID="RXToraceData" CssClass="label">data</asp:Label>
                    <asp:TextBox ID="RXToraceData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="VistiPneumologicaLabel" runat="server" AssociatedControlID="VistiPneumologica" CssClass="label">Visita pneumologica</asp:Label>
                    <asp:DropDownList ID="VistiPneumologica" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="VistiPneumologicaDataLabel" runat="server" AssociatedControlID="VistiPneumologicaData" CssClass="label">se si, data</asp:Label>
                    <asp:TextBox ID="VistiPneumologicaData" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <label class="sezione">Condizioni contatto</label>
                <hr />
                <p>
                <label class="label" style="width:600px;"><i>Il contatto presenta condizioni in grado di aumentare la suscettibilità alla malattia o che prevedano la sorveglianza</i></label>
                </p>
                <p>
                    <asp:Label ID="CondizioniLabel" runat="server" AssociatedControlID="Condizioni" CssClass="label" Width="150px">Condizioni suscettiblità</asp:Label>
                    <asp:DropDownList ID="Condizioni" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div style="padding-left:50px">
                    <p> 
                        <label class="label" style="width:300px"><i>Se si, specificare</i></label>
                    </p>
                        <asp:Label ID="condizioniMedicheLabel" runat="server" AssociatedControlID="condizioniMediche" CssClass="label" Width="150px">Condizioni mediche</asp:Label>
                        <asp:DropDownList ID="condizioniMediche" runat="server" CssClass="dropdown">   
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                            <asp:ListItem Text="Bambini sotto i 5 anni" Value="Bambini sotto i 5 anni"></asp:ListItem>
                            <asp:ListItem Text="HIV positivi" Value="HIV positivi"></asp:ListItem>
                            <asp:ListItem Text="Condizioni patologiche" Value="Condizioni patologiche"></asp:ListItem>
                        </asp:DropDownList>
                    <p>
                        <asp:Label ID="gruppoDiAppartenenzaLabel" runat="server" AssociatedControlID="gruppoDiAppartenenza" CssClass="label" Width="150px">Gruppi di appartenenza</asp:Label>
                        <asp:DropDownList ID="gruppoDiAppartenenza" runat="server" CssClass="dropdown">   
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                            <asp:ListItem Text="Tossicodipendenti" Value="Tossicodipendenti"></asp:ListItem>
                            <asp:ListItem Text="Immigrati" Value="Immigrati"></asp:ListItem>
                            <asp:ListItem Text="Senza fissa dimora" Value="Senza fissa dimora"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </div>
                <p>
                    <asp:Label ID="ChemioprofilassiLabel" runat="server" AssociatedControlID="Chemioprofilassi" CssClass="label" Width="300px">Contatto sottoposto a chemioprofilassi</asp:Label>
                    <asp:DropDownList ID="Chemioprofilassi" runat="server" CssClass="dropdown">   
                        <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                        <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div style="padding-left:50px">
                    <p> 
                        <label class="label" style="width:300px"><i>Se si, specificare</i></label>
                    </p>
                    <p>
                        <asp:Label ID="CicloChemioLable" runat="server" AssociatedControlID="CicloChemio" CssClass="label" Width="150px">Ha completato il ciclo</asp:Label>
                        <asp:DropDownList ID="CicloChemio" runat="server" CssClass="dropdown">   
                            <asp:ListItem Text="Selezionare..." Value=""></asp:ListItem>                                         
                            <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                        <label class="label" style="width:150px"><i>Se No, specificare</i></label>
                        <asp:DropDownList ID="NoChemio" runat="server" CssClass="dropdown">   
                            <asp:ListItem Text="Non noto" Value="Non noto"></asp:ListItem>                                         
                            <asp:ListItem Text="Effetti collaterali" Value="Effetti collaterali"></asp:ListItem>
                            <asp:ListItem Text="Rifiutato" Value="Rifiutato"></asp:ListItem>
                            <asp:ListItem Text="Altro" Value="Altro"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="NoChemioDataLabel" runat="server" AssociatedControlID="NoChemioData" CssClass="label">data</asp:Label>
                        <asp:TextBox ID="NoChemioData" runat="server" CssClass="textBox"></asp:TextBox>
                    </p>
                <p  style="padding-left:600px">
                    <asp:Button ID="btn" runat="server" Text="Salva"/>                
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

