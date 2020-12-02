<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="EsportaTabelle.aspx.vb" Inherits="Utility_EsportaTabelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
 <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Utility -> <b>Esporta tabelle</b>
        </div >  
        <p>
        <asp:Label ID="errore" runat="server" CssClass="alert"  Visible="false"></asp:Label>
        <label class="sezione">Esporta tabelle</label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
           <legend><label class="Subsezione">Notifiche</label></legend>         
        <p class="paragrafo">
            La procedura di esportazione delle notifche permette di esportare tutti i dati presenti nelle tabelle del sistema in formato excel di propria competenza.
            Si può ricostruire l'intero tracciato record mettendo in relazione il campo "idNotifica" presente nei singoli fogli.            
            Verrà esportato un file excel con in seguenti fogli:
        </p>
        <br />
            <ul>
                <li class="paragrafo">Notifica</li>
                <li class="paragrafo">Anagrafica</li>
                <li class="paragrafo">Clinica</li>
                <li class="paragrafo">Tbc</li>
                <li class="paragrafo">Mib</li>
                <li class="paragrafo">Malaria</li>
            </ul>
        <p>
            <label class="Subsezione">Criteri di selezione</label>
        </p>
        <hr />
        <p>
            <label class="label" style="width:300px">Regione di notifica</label>
            <asp:DropDownList ID="regione" runat="server"></asp:DropDownList>
        </p>
        <p>
            <label class="label" style="width:300px">Asl di notifica</label>
            <asp:DropDownList ID="asl" runat="server"></asp:DropDownList>
        </p>
        <p>
            <label class="label" style="width:300px">anno (data inserimento nel sistema)</label>
            <asp:DropDownList ID="anno" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            <label class="label" style="width:300px">Oscura nominativi</label>
            <asp:CheckBox ID="privacy" runat="server" />
        </p>
        <p style="padding-left:500px">
            <asp:Button ID="notifica" runat="server"  Text="Esporta notifiche"/>
        </p>
        </fieldset>
        <br />
        <br />
        <fieldset style="margin-right:20px">
            <legend><label class="Subsezione">Focolaio</label></legend>
        <p class="paragrafo">
            La procedura di esportazione delle notifiche di focolaio permette di esportare le tabelle presenti nel sistema relative alle notifiche dei focolai di propria competenza, in formato excel.            
            Verrà esportato un file excel con in seguenti fogli:
        </p>
        <br />
        <ul>
                <li class="paragrafo">Focolaio</li>
        </ul>
        <p>
            <label class="Subsezione">Criteri di selezione</label>
        </p>
        <hr />
        <p>
            <label class="label" style="width:300px">Regione di notifica</label>
            <asp:DropDownList ID="regionefocolaio" runat="server"></asp:DropDownList>
        </p>
        <p>
            <label class="label" style="width:300px">Asl di notifica</label>
            <asp:DropDownList ID="aslFocolaio" runat="server"></asp:DropDownList>
        </p>
        <p>
            <label class="label" style="width:300px">anno (data inserimento nel sistema)</label>
            <asp:DropDownList ID="annofocolaio" runat="server">
            </asp:DropDownList>
        </p>
        <p style="padding-left:500px">
            <asp:Button ID="focolaio" runat="server"  Text="Esporta focolaio"/>
        </p>
        </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

