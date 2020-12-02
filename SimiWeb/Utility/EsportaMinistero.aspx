<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/TemplateReport.master" AutoEventWireup="false" CodeFile="EsportaMinistero.aspx.vb" 
Inherits="Utility_EsportaMinistero" EnableViewState = "true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
<div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Utility -> <b>Esporta per Ministero</b>
        </div >  
        <p>
        <asp:Label ID="errore" runat="server" CssClass="alert"  Visible="false"></asp:Label>
        <label class="sezione">Esporta dati per Ministero</label>
        </p>
        <hr />
        <br />
        <asp:Panel ID="pnlOld" runat="server" Visible="false">
        <fieldset style="margin-right:20px">
           <legend><label class="Subsezione">Notifiche (NUOVA VERSIONE)</label></legend>         
        <p class="paragrafo">
            La procedura di esportazione delle notifiche per il ministero permette di esportare i dati presenti nelle tabelle del sistema in formato csv di propria competenza.
                        
        </p>
        <br />
        <p>
            <label class="Subsezione">Criteri di selezione</label>
        </p>
        <hr />
        <label class="label">Data notifica da:</label>
        <asp:TextBox ID="dataNotificaDa" runat="server"></asp:TextBox>
        <label class="label">Data notifica a:</label>
        <asp:TextBox ID="DataNotificaA" runat="server"></asp:TextBox>
        <p>
           <asp:Button ID="btnEsporta" runat="server" Text="Esporta" ValidationGroup="form" />
        </p>
        </fieldset>
        </asp:Panel>
        <br />
        <br />
        <p>
                <label class="sezione">Esporta dati per Ministero (Retrocompatibilità)</label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
           <legend><label class="Subsezione">Notifiche (VECCHIA VERSIONE)</label></legend>         
        <p class="paragrafo">
            La procedura di esportazione delle notifiche per il ministero permette di esportare i dati presenti nelle tabelle del sistema in formato csv di propria competenza.
            Questa procedura è per l'invio dei dati nel vecchio formato.
            E' ancora prevista la suddivisione per classi
                        
        </p>
        <br />
        <p>
            <label class="Subsezione">Criteri di selezione</label>
        </p>
        <hr />
        <label class="label">Classe:</label>
        <asp:DropDownList ID="classe" runat="server" >
       <%-- <asp:ListItem Text="1" Value="1"></asp:ListItem>--%>
        <asp:ListItem Text="2" Value="2"></asp:ListItem>
        <asp:ListItem Text="3" Value="3"></asp:ListItem>
        <asp:ListItem Text="4" Value="4"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <label class="label">Data notifica da:</label>
        <asp:TextBox ID="DataNotificaDaEx" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqDataDa" runat="server" ControlToValidate="DataNotificaDaEx"  CssClass="alert" ErrorMessage="*" Text="data da" ValidationGroup="form"></asp:RequiredFieldValidator>
        <label class="label">Data notifica a:</label>
        <asp:TextBox ID="DataNotificaAEx" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqDataA" runat="server" ControlToValidate="DataNotificaAEx"  CssClass="alert" ErrorMessage="*"   Text="data da"  ValidationGroup="form"  ></asp:RequiredFieldValidator>
        <p>
           <asp:Button ID="btnEsportaEx" runat="server" Text="Esporta"  ValidationGroup="form" />
        </p>
  <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true"  HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />
        </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center"></div>
</asp:Content>

