<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master"
 AutoEventWireup="false" 
   ClientIDMode="Static"
 CodeFile="Lista.aspx.vb" 
 Inherits="Notifica_Lista"  %>

<%--<%@ Register src="../_UserControl/Applicazione/ViewNotifica.ascx" tagname="ViewNotifica" tagprefix="uc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
    <script src="Js/Lista.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Notifiche inserite</b>
<br />
</div >  <a href =""></a>
            <p>
            <label  class="sezione">Notifiche inserite</label>
            </p>
            <hr />
            <fieldset style="margin-right:20px">
            <legend><label class="Subsezione">Criteri di ricerca</label></legend>
            <p>
                <asp:Label ID="LabelID" runat="server" AssociatedControlID="idScheda" CssClass="label" Width="150px">Codice scheda</asp:Label>
                <asp:TextBox ID="idScheda" runat="server" CssClass="textBox" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="cognome" CssClass="label" Width="150px">Cognome paziente</asp:Label>
            <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:Label ID="codiceFiscaleLabel" runat="server" AssociatedControlID="codiceFiscale" CssClass="label" Width="150px">Codice Fiscale</asp:Label>
            <asp:TextBox ID="codiceFiscale" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="dataNascitaLabel" runat="server" AssociatedControlID="dataNascita" CssClass="label" Width="150px">Data Nascita</asp:Label>
            <asp:TextBox ID="dataNascita" runat="server" CssClass="textBox"></asp:TextBox>                
            </p>
            <p>
            <asp:Label ID="malattiaLabel" runat="server" AssociatedControlID="malattia" CssClass="label" Width="150px">Malattia</asp:Label>
            <asp:DropDownList ID="malattia" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="EsitLabel" runat="server" AssociatedControlID="esito" CssClass="label" Width="150px">Esito</asp:Label>
            <span style="padding-left:50px"><asp:DropDownList ID="esito" runat="server" CssClass="dropdown" >
            <asp:ListItem Text="Tutti" Value="tutti"></asp:ListItem>
            <asp:ListItem Text="non compilato" Value=""></asp:ListItem>
            </asp:DropDownList></span>
            </p>
            <p>
<%--            <asp:Label id="ProvinciaResidenzaLabel" runat="server" CssClass="label" AssociatedControlID="ProvinciaResidenza"></asp:Label>
            <asp:DropDownList ID="ProvinciaResidenza" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
            <asp:Label ID="ComuneLabel" runat="server" AssociatedControlID="comuneResidenza" CssClass="label" Width="150px">Comune residenza</asp:Label>
            <asp:DropDownList ID="comuneResidenza" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>
            <p>
<%--            <asp:Label id="ComuneSintomiLabel" runat="server" CssClass="label" AssociatedControlID="ProvinciaSintomi"></asp:Label>
            <asp:DropDownList ID="ProvinciaSintomi" runat="server" CssClass="dropdown"></asp:DropDownList>--%>
            <asp:Label ID="comuneSintomiLabel" runat="server" AssociatedControlID="comuneSintomi" CssClass="label" Width="150px">Comune sintomi</asp:Label>
            <asp:DropDownList ID="comuneSintomi" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>
            <p>
            <asp:Label id="statolabel" runat="server" CssClass="label" AssociatedControlID="stato" Text="stato" Width="150px"></asp:Label>
            <asp:DropDownList ID="stato" runat="server" CssClass="dropdown">
            <asp:ListItem Text="Tutte" Value=""></asp:ListItem>
            <asp:ListItem Text="Segnalazione" Value="Segnalazione"></asp:ListItem>
            <asp:ListItem Text="Notifica" Value="Notifica"></asp:ListItem>
            </asp:DropDownList>      
            </p>
            <p>
            <asp:Label ID="dataNotificaDaLabel" runat="server" AssociatedControlID="dataNotificaDa" CssClass="label" Width="150px">data notifica da</asp:Label>
            <asp:TextBox ID="dataNotificaDa" runat="server" CssClass="textBox"></asp:TextBox><label class="label">(gg/mm/aaaa)</label>
            <asp:Label ID="dataNotificaALabel" runat="server" AssociatedControlID="dataNotificaALabel" CssClass="label" Width="50px">al</asp:Label>
            <asp:TextBox ID="dataNotificaA" runat="server" CssClass="textBox"></asp:TextBox><label class="label">(gg/mm/aaaa)</label>
            </p>
            <p>
            <asp:Label ID="dataSegnalazioneDaLabel" runat="server" AssociatedControlID="dataSegnalazioneDa" CssClass="label" Width="150px">data segnalazione da</asp:Label>
            <asp:TextBox ID="dataSegnalazioneDa" runat="server" CssClass="textBox"></asp:TextBox><label class="label">(gg/mm/aaaa)</label>
            <asp:Label ID="dataSegnalazioneALabel" runat="server" AssociatedControlID="dataSegnalazioneA" CssClass="label" Width="50px">al</asp:Label>
            <asp:TextBox ID="dataSegnalazioneA" runat="server" CssClass="textBox"></asp:TextBox><label class="label">(gg/mm/aaaa)</label>
            </p>
            <asp:Panel ID="pnlRegione" runat="server">
            <p>
            <asp:Label id="lblAslResidenza" runat="server" CssClass="label" AssociatedControlID="aslResidemza" Text="asl residenza" Width="150px"></asp:Label>
            <asp:DropDownList ID="aslResidemza" runat="server" CssClass="dropdown">
            </asp:DropDownList>      
            <asp:Label id="lblAslNotifica" runat="server" CssClass="label" AssociatedControlID="aslNotifica" Text="asl notifica" Width="150px"></asp:Label>
            <asp:DropDownList ID="aslNotifica" runat="server" CssClass="dropdown">
            </asp:DropDownList>      
            </p>   
            </asp:Panel>
            <p>
            <asp:Button  ID="btnPulisci" runat="server" Text="Resetta parametri" />
            <span style="padding-left:550px">
            <asp:Button  ID="btncerca" runat="server" Text="Cerca" />
            </span>
            </p>
            </fieldset>
            <hr />
            <br />  


<asp:ListView ID="LstNotifica" runat="server"  DataKeyNames="id">
    <EmptyDataTemplate>
        <table id="Table1" runat="server"  style="">
            <tr>
                <td>
                    No data was returned.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="true" />
            </td>
            <td>
                <asp:Label ID="malattiaLabel" runat="server" Text='<%# Eval("malattia") %>' />
            </td>
            <td>
                <asp:LinkButton ID="lnkCognome" runat="server" CommandName="sel" Text='<%# Eval("Cognome") + cstr("<br/>")+ Eval("Nome")%> '  ></asp:LinkButton>                
            </td>
            <td>
                <asp:Label ID="ComuneLabel" runat="server" Text='<%# Eval("comuneResidenza") %>' />
            </td>
            <td>
                <asp:Label ID="lblIdAsl" runat="server" 
                    Text='<%# Eval("AslDiNotifica") %>' Visible="false" />
                <asp:Label ID="DescrizioneLabel" runat="server" 
                    Text='<%# Eval("aslNotifica") %>' />
            </td>
            <td>                
                <asp:Label ID="DataSegnalazioneLabel" runat="server" 
                     Text='<%# DataBinder.Eval(Container.DataItem, "DataSegnalazione", "{0:dd/MM/yyyy}")%>' />
            </td>
            <td>
                <asp:Label ID="DataNotificaLabel" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "DataNotifica", "{0:dd/MM/yyyy}")%>' />
            </td>
<%--            <td>
                <asp:Label ID="DataNascitaLabel" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "DataNascita", "{0:dd/MM/yyyy}")%>' />
            </td>--%>
            <td>
                <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
            </td>
<%--            <td>
                <asp:Label ID="classificazioneLabel" runat="server" Text='<%# Eval("classificazione") %>' />
            </td>--%>
<%--            <td>
                <asp:Label ID="Label1" runat="server" 
                    Text='<%# Eval("medicoSegnalatore") %>' />
            </td>
            <td>
                <asp:Label ID="notificatoreLabel" runat="server" 
                    Text='<%# Eval("utente") %>' />
            </td>--%>
            <td>
                <asp:ImageButton ID="invalida" runat="server" CommandName="invalida" ImageUrl="~/_Styles/All/images/delete.png" AlternateText="invalida scheda" />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
           <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                        <tr id="Tr1" runat="server" style="">
                            <th runat="server">
                                ID</th>
                            <th id="Th5" runat="server">
                                malattia</th>
                            <th id="Th3" runat="server">
                                Paziente</th>
                            <th id="Th6" runat="server">
                                Comune<br />
                                residenza</th>
                            <th id="Th7" runat="server">
                                Asl <br />
                                notifica</th>
                            <th id="Th1" runat="server">
                                Data<br />
                                segnalazione</th>
                            <th id="Th2" runat="server">
                                Data<br />
                                notifica</th>
<%--                            <th id="Th4" runat="server">
                                Data<br />
                                nascita</th>--%>
                            <th id="Th8" runat="server">
                                stato</th>
<%--                            <th id="Th9" runat="server">
                                class.</th>--%>
<%--                            <th runat="server">
                                medico</th>
                            <th runat="server">
                                utente</th>--%>
                                <th runat="server"></th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
    </LayoutTemplate>
</asp:ListView>
        <p style="text-align:center">
        <asp:DataPager ID="pager" runat="server" PagedControlID="LstNotifica" PageSize="25">
            <Fields>
                <asp:NextPreviousPagerField 
                        ButtonType="image" 
                        ShowFirstPageButton="True" 
                        ShowNextPageButton="False" 
                        ShowPreviousPageButton="True" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />

                <asp:NumericPagerField />
                <asp:NextPreviousPagerField                        
                        ButtonType="image" 
                        ShowLastPageButton="True" 
                        ShowNextPageButton="True" 
                        ShowPreviousPageButton="False" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />
            </Fields>
        </asp:DataPager>
        </p>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

