<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcTubercolosiFattori.ascx.vb" Inherits="_UserControl_Applicazione_UcTubercolosiFattori" %>
            <p  style="padding-left:550px">
                <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
            </p>
<fieldset style="padding-right:30px">
    <legend><label class="sezione">Tubercolosi Informazioni aggiuntive</label></legend>
            <hr />

            <div style="width:100%">
               <div style="float:left">
               <p>
            <asp:Label ID="esitiradiograficiLabel"  runat="server" Text="esiti radiografici di tbc" Width="150px" AssociatedControlID="esitiradiografici"  CssClass="labelBold"></asp:Label>
            <asp:Label ID="esitiradiografici" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="graveimmudeficenzaLabel" runat="server" Text="grave immunodeficienza acquisita" Width="150px" AssociatedControlID="graveimmudeficenza" CssClass="labelBold"></asp:Label>
            <asp:Label ID="graveimmudeficenza" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="terapiaImmunosoppresivaLabel" runat="server" Text="terapia immunosopressiva" Width="150px" AssociatedControlID="terapiaImmunosoppresiva" CssClass="labelBold"></asp:Label>
            <asp:Label ID="terapiaImmunosoppresiva" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="deperimentoOrganicoLabel" runat="server" Text="deperimento organico grave" Width="150px" AssociatedControlID="deperimentoOrganico" CssClass="labelBold"></asp:Label>
            <asp:Label ID="deperimentoOrganico" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="recenteViaggioTbcLabel" runat="server" Text="recente viraggio tubercolinico" Width="150px" AssociatedControlID="recenteViaggioTbc" CssClass="labelBold"></asp:Label>
            <asp:Label ID="recenteViaggioTbc" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="diabeteScarsamenteControllatoLabel" runat="server" Text="diabete scarsamente controllato" Width="150px"     AssociatedControlID="diabeteScarsamenteControllato" CssClass="labelBold"></asp:Label>
            <asp:Label ID="diabeteScarsamenteControllato" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="silicosiLabel" runat="server"  Text="silicosi" Width="150px" AssociatedControlID="silicosi" CssClass="labelBold"></asp:Label>
            <asp:Label ID="silicosi" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="insufficenzaRenaleLabel" runat="server" Text="insufficienza renale cronica" Width="150px" AssociatedControlID="insufficenzaRenale" CssClass="labelBold"></asp:Label>
            <asp:Label ID="insufficenzaRenale" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="gastrectomiaLabel" runat="server" Text="gastrectomia" Width="150px"  AssociatedControlID="gastrectomia" CssClass="labelBold"></asp:Label>
            <asp:Label ID="gastrectomia" runat="server" CssClass="label" />
            </p>
            </div>
               <div style="float:left;margin-left:50px">               
            <p>
            <asp:Label ID="ContattoMalatoLabel" runat="server" Text="contatto con malato" Width="150px" AssociatedControlID="ContattoMalato" CssClass="labelBold"></asp:Label>
            <asp:Label ID="ContattoMalato" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="tossicodipendenzaLabel" runat="server"  Text="tossicodipendenza" Width="150px" AssociatedControlID="tossicodipendenza" CssClass="labelBold"></asp:Label>
            <asp:Label ID="tossicodipendenza" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="ImmigrazioneLabel" runat="server"  Text="immigrazione" Width="150px" AssociatedControlID="Immigrazione" CssClass="labelBold"></asp:Label>
            <asp:Label ID="Immigrazione" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="carcereLabel" runat="server"  Text="carcere" Width="150px" AssociatedControlID="carcere" CssClass="labelBold"></asp:Label>
            <asp:Label ID="carcere" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="alcolismoLabel" runat="server" Text="alcolismo" Width="150px" AssociatedControlID="alcolismo" CssClass="labelBold"></asp:Label>
            <asp:Label ID="alcolismo" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="senzaFissaDimoraLabel" runat="server" Text="senzaFissaDimora" Width="150px" AssociatedControlID="senzaFissaDimora" CssClass="labelBold"></asp:Label>
            <asp:Label ID="senzaFissaDimora" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="personaleSanitarioLabel" runat="server" Text="personaleSanitario" Width="150px" AssociatedControlID="personaleSanitario" CssClass="labelBold"></asp:Label>
            <asp:Label ID="personaleSanitario" runat="server" CssClass="label" />
            </p>
            <p>
            <asp:Label ID="AltroLabel" runat="server" Text="altro" Width="150px"  AssociatedControlID="altro" CssClass="labelBold"></asp:Label>
            <asp:Label ID="altro" runat="server" CssClass="label" />
            </p>
            </div>
            </div>
</fieldset>