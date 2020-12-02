<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/TemplateReport.master" AutoEventWireup="false" CodeFile="AnalisiReport.aspx.vb" Inherits="Notifica_AnalisiReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
		div span input { margin-left: 10px; }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
   <div class="splitd"  >
   <div class="pag_link" >
           Simiweb -> Notifica -> <b>Analisi(2 di 2)</b></div >
<p>
    <label class="sezione">Analisi (2 di 2)</label>
</p>
<hr />
    <fieldset style="margin-right:20px">
        <legend><label class="Subsezione">Criteri selezionati</label></legend>
    <p>
        <label class="labelBold" style="width:200px">Periodo selezionato</label>
    </p>
    <div style="padding-left:50px">
    <p>
        <label class="labelBold" style="width:80px">Dalla data</label>
        <asp:Label ID="dataDa" runat="server" CssClass="alert"></asp:Label>
        <label class="labelBold" style="width:80px">alla data</label>
        <asp:Label ID="dataA" runat="server" CssClass="alert"></asp:Label>
    </p>
    <p>
    <label class="labelBold" style="width:150px">Data di riferimento</label>
    <asp:Label ID="dataRiferimento" runat="server" CssClass="alert"></asp:Label>
    </p>
    <p>
    <label class="labelBold" style="width:150px">Provenienza</label>
    <asp:Label ID="Provenienza" runat="server" CssClass="alert"></asp:Label>
    </p>
    </div>
    </fieldset>
<br />
<asp:Panel ID="pnlAnalisi" runat="server"  Visible="false">
<fieldset>
    <legend>
        <label class="Subsezione">Analisi preimpostate</label>
    </legend>
    <hr />
    <asp:RadioButtonList ID="tipoAnalisi" runat="server" CssClass="checkBox">
            <asp:ListItem Text="Conteggio malattie" Value="1" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Conteggio malattie per classi di età (0 |1-4 | 5-9 | 10-14 | 15-24 | 25-64 | >64)" Value="2"></asp:ListItem>
            <asp:ListItem Text="Conteggio malattie per classi di età (0-4 | 5-14 | >=65)" Value="3"></asp:ListItem>
            <asp:ListItem Text="Conteggio malattie per comuni" Value="4"></asp:ListItem>
            <asp:ListItem Text="Conteggio malattie per mese" Value="5"></asp:ListItem>            
            <asp:ListItem Text="Conteggio malattie per sesso" Value="6"></asp:ListItem>
    </asp:RadioButtonList>
</fieldset>
</asp:Panel>
<fieldset style="margin-right:20px">
    <legend>
        <label class="Subsezione">Esporta</label>        
    </legend>
    <br />
    <label class="label">Formato esportazione:</label>
    <asp:DropDownList ID="listExportFormat" runat="server">    
            <asp:ListItem Text="Pdf" Value="0"></asp:ListItem>
            <asp:ListItem Text="Excel" Value="1"></asp:ListItem>
            <asp:ListItem Text="Mht" Value="2"></asp:ListItem>
            <asp:ListItem Text="Rtf" Value="3"></asp:ListItem>
            <asp:ListItem Text="Text" Value="4"></asp:ListItem>
            <asp:ListItem Text="Html" Value="5"></asp:ListItem>
    </asp:DropDownList>
    <p>
    <label class="labelBold">Opzioni</label>
    </p>
    <p>
		<asp:CheckBox ID="checkPrintHeadersOnEveryPage" runat="server" Text="Stampa instestazioni in ogni pagina"  CssClass="checkBox"/>
    <br />
		<asp:CheckBox ID="checkPrintFilterHeaders" runat="server" Text="stampa campi filtro" CssClass="checkBox"
			Checked="True" />
    <br />
		<asp:CheckBox ID="checkPrintColumnHeaders" runat="server" Text="stampa intestazioni colonna" CssClass="checkBox"
			Checked="True" />
    <br />
		<asp:CheckBox ID="checkPrintRowHeaders" runat="server" Text="Stampa intestazioni colonna" Checked="True"  CssClass="checkBox"/>
    <br />
		<asp:CheckBox ID="checkPrintDataHeaders" runat="server" Text="stampa impostazioni dati" CssClass="checkBox"
			Checked="false" />        
    </p>
    <p style="padding-left:500px">
        <asp:Button ID="buttonSaveAs" runat="server" ToolTip="Esport e salva" Style="vertical-align: middle;" Text="Esporta il report visualizzato"  />
      </p>
</fieldset>
<hr />
<p >
    <asp:Button ID="reset" runat="server"  Text="Resetta parametri analisi" />
</p>
<p>
            <label class="sezione">Report</label> 
            <dx:aspxpivotgrid ID="grid" runat="server" ClientIDMode="AutoID"  
                DataSourceID="ObjAnalisiDs">                
            <Fields>
                <dx:PivotGridField Area="RowArea" AreaIndex="0" FieldName="malattia" Caption="Malattia" ID="Row_Malattia"></dx:PivotGridField>
                <dx:PivotGridField Area="DataArea" AreaIndex="0" FieldName="malattia" Caption="Malattia" ID="Area_Malattia" SummaryType="Count"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="0" FieldName="sesso" Caption="sesso" ID="Filter_Sesso"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="1" FieldName="Classificazione" Caption="Classificazione" ID="filter_classificazione"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="2" FieldName="classe" Caption="Classe eta (4 range)" ID="filter_classe"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="3" FieldName="classe2" Caption="Classe eta (6 range)" ID="filter_classe2"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="4" FieldName="comune" Caption="Comuni" ID="filter_Comuni"></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="5" FieldName="TrendSintomi" Caption="Data sintomi"  ID="filter_primiSintomi" ></dx:PivotGridField>
                <dx:PivotGridField Area="FilterArea"  AreaIndex="6" FieldName="TrendNotifica" Caption="Data Notifica"   ID="filter_dataNotifica" ></dx:PivotGridField>                              
                <dx:PivotGridField Area="FilterArea"  AreaIndex="7" FieldName="Stato" Caption="Stato"  ID="filter_stato" ></dx:PivotGridField>  
                <dx:PivotGridField Area="FilterArea"  AreaIndex="8" FieldName="aslNotifica" Caption="Asl notifica"  ID="filter_asl" Visible="False" ></dx:PivotGridField>                             
            </Fields>          
            </dx:aspxpivotgrid>

             <asp:ObjectDataSource ID="ObjAnalisiDs" runat="server" 
                SelectMethod="GetAnalisi_Notifica" 
                TypeName="Simiweb.BusinessFacade.BllAnalisi" >


             </asp:ObjectDataSource>
</p>
<p>
    <dx:ASPxPivotGridExporter ID="gridExport" runat="server"  ASPxPivotGridID="grid" >
    </dx:ASPxPivotGridExporter>
                                 
</p>




</div > 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>