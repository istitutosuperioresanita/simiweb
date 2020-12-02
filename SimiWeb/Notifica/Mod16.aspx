<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Mod16.aspx.vb" Inherits="Notifica_Mod16" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
 <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Mod. 16</b>
            
        </div > 
        <p>
            <label class="sezione">Mod. 16</label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
            <legend><label class="Subsezione">Criteri di selezione</label></legend>        
        <p>
            <label class="label">Anno</label>
            <asp:DropDownList ID="anno" runat="server" CssClass="dropdown">

            </asp:DropDownList>
         </p>
        <p>
            <label class="label">Mese</label>
            <asp:DropDownList ID="mese" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="01" Text="Gennaio"></asp:ListItem>
                    <asp:ListItem Value="02" Text="Febbraio"></asp:ListItem>
                    <asp:ListItem Value="03" Text="Marzo"></asp:ListItem>
                    <asp:ListItem Value="04" Text="Aprile"></asp:ListItem>
                    <asp:ListItem Value="05" Text="Maggio"></asp:ListItem>
                    <asp:ListItem Value="06" Text="Giugno"></asp:ListItem>
                    <asp:ListItem Value="07" Text="Luglio"></asp:ListItem>
                    <asp:ListItem Value="08" Text="Agosto"></asp:ListItem>
                    <asp:ListItem Value="09" Text="Settembre"></asp:ListItem>
                    <asp:ListItem Value="10" Text="Ottobre"></asp:ListItem>
                    <asp:ListItem Value="11" Text="Novembre"></asp:ListItem>
                    <asp:ListItem Value="12" Text="Dicembre"></asp:ListItem>
            </asp:DropDownList>
         </p>         
         <p style="padding-left:400px">
            <asp:Button ID="btnExcel" runat="server"  Text="Excel" CssClass="button" />
            <asp:Button ID="btnReport" runat="server"  Text="Pdf" CssClass="button" />
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

