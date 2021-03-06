﻿<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Elenchi.aspx.vb" Inherits="Focolaio_Elenchi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Focolaio -><b>Elenchi</b>
            
        </div >
         <p>
               <label class="sezione">Elenchi</label>
         </p>       
        <hr />
         <fieldset style="margin-right:20px">
            <legend>
            <label class="Subsezione">Criteri di selezione</label>
            </legend>         
         <hr />
    <p>
      <label class="labelBold" style="width:300px">Selezionare il periodo di riferimento</label>  
    </p>
    <p>
        <label class="label" style="width:100px">Dalla data</label>
        <asp:TextBox ID="dataDa" runat="server" CssClass="textBox"></asp:TextBox>
        <label class="label">(gg/mm/aaaa)</label>
        <label class="label" style="width:100px">alla data</label>
        <asp:TextBox ID="dataA" runat="server" CssClass="textBox"></asp:TextBox>
        <label class="label">(gg/mm/aaaa)</label>
    </p>
    <p>
        <label class="labelBold" style="width:230px">Selezionare la data di riferimento</label>
    </p>
    <p>
        <asp:RadioButtonList ID="criterio" runat="server"  CssClass="checkBox">        
                    <asp:ListItem Text="data inizio sintomi/data segnalazione" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="data segnalazione" Value="2"></asp:ListItem>
                    <asp:ListItem Text="data notifica/data segnalazione" Value="3"></asp:ListItem>
        </asp:RadioButtonList>

    </p>
<%--    <p>
        <label class="labelBold" style="width:230px">Seleziona i dati :</label>
        <asp:RadioButtonList ID="provenienza" runat="server"  CssClass="checkBox">            
                        <asp:ListItem Text="Notificati da questa asl" Value="1"  Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Residenti in questa asl ma segnalate da altre asl" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Notificati e residenti in questa asl" Value="3"></asp:ListItem>
        </asp:RadioButtonList>
    </p>--%>
         <p>
            <label class="labelBold">Stato</label>
         </p>
                <p>
                <asp:RadioButtonList ID="stato" runat="server" CssClass="checkBox">
                    <asp:ListItem Value="" Text="Tutte" ></asp:ListItem>
                    <asp:ListItem Value="Notifica" Text="Notificate"></asp:ListItem>
                    <asp:ListItem Value="Segnalazione" Text="Segnalate"></asp:ListItem>
                    <asp:ListItem Value="Archiviata" Text="Annullate"></asp:ListItem>
                </asp:RadioButtonList>
                </p>
         <p>
            <label class="labelBold">Malattie</label>
            <asp:DropDownList ID="Malattie" runat="server" CssClass="dropdown">
            </asp:DropDownList>
         </p>
         <p>
            <label class="labelBold" style="width:200px">Comune residenza:</label>
            <asp:DropDownList ID="comune" runat="server" CssClass="dropdown">
            </asp:DropDownList>            
         </p>   
         <p style="padding-left:450px">
            <asp:Button ID="btnExcel" runat="server"  Text="Excel" CssClass="button" />
            <asp:Button ID="btnReport" runat="server"  Text="Report" CssClass="button" />
            <asp:Button ID="btnCsv" runat="server"  Text="Csv" CssClass="button" />
         </p>
         </fieldset>
    </div>
         
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center"></div>
</asp:Content>

