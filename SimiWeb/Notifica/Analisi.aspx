<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Analisi.aspx.vb"  
EnableEventValidation="false"
Inherits="Notifica_Analisi"  UICulture="it" Culture="it-IT"
ClientIDMode="Static" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style type="text/css">
		div span input { margin-left: 10px; }
	</style>
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
   <div class="pag_link" >
           Simiweb -> Notifica -> <b>Analisi (1 di 2)</b></div >

<p>
    <label class="sezione">Analisi (1 di 2)</label>
</p>
<hr />
<br />
<fieldset style="margin-right:20px">
    <legend><label class="Subsezione">Criteri di selezione</label></legend>
<p>
  <label class="label" style="width:300px">Selezionare il periodo di riferimento</label>  
</p>
<p>
    <label class="labelBold" style="width:100px">Dalla data</label>
    <asp:TextBox ID="dataDa" runat="server" CssClass="textBox"></asp:TextBox>
    <label class="label">(gg/mm/aaaa)</label>
    <label class="labelBold" style="width:100px">alla data</label>
    <asp:TextBox ID="dataA" runat="server" CssClass="textBox"></asp:TextBox>
    <label class="label">(gg/mm/aaaa)</label>
</p>
<p>
    <label class="labelBold" style="width:230px">Selezionare la data di riferimento</label>
    <asp:RequiredFieldValidator ID="reqTipoRiferimento" 
                                runat="server" Text="*" 
                                ErrorMessage="obbligatorio"
                                 InitialValue=""
                                ControlToValidate="TipodataRiferimento"
                                 CssClass="alert"></asp:RequiredFieldValidator>
</p>
<p>
    <asp:RadioButtonList ID="TipodataRiferimento" runat="server"  CssClass="checkBox">        

                <asp:ListItem Text="data inizio sintomi/data segnalazione" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="data notifica/data segnalazione" Value="3"></asp:ListItem>
                <asp:ListItem Text="data segnalazione" Value="2"></asp:ListItem>
                <asp:ListItem Text="data inizio sintomi" Value="4"></asp:ListItem>
                <asp:ListItem Text="data notifica" Value="5"></asp:ListItem>

    </asp:RadioButtonList>

</p>
    <asp:Panel ID="pnlAsl" runat="server"  Visible="false">
    <p>
        <label class="labelBold" style="width:230px">Seleziona i dati :</label>
        <asp:RadioButtonList ID="provenienza" runat="server"  CssClass="checkBox">            
                        <asp:ListItem Text="Notificati da questa asl" Value="1"  Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Tutti i residenti di questa Asl" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Notificati e residenti in questa asl" Value="3"></asp:ListItem>
        </asp:RadioButtonList>
    </p>
    </asp:Panel> 
         <br />
         <br />

<p style="padding-left:600px">
    <asp:Button ID="avanti" runat="server" Text="avanti" CssClass="button" />
</p>
</fieldset>
</div > 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
   <div class="dow-center"></div>
</asp:Content>

