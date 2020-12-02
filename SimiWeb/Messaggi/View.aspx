<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="View.aspx.vb" Inherits="Messaggi_View" %>

<%@ Register src="../_UserControl/Navigazione/UcLeftMessaggi.ascx" tagname="UcLeftMessaggi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../_Scripts/tiny_mce/tiny_mce_gzip.js" type="text/javascript"></script>
    <script type="text/javascript">
        tinyMCE_GZ.init({
            plugins: "safari,style,layer,table,advhr,advimage,advlink,emotions,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,xhtmlxtras,template",
            themes: 'advanced',
            languages: 'it',
            disk_cache: true,
            debug: false
        });
    </script>

    <script type="text/javascript">
        function loadCallback(type, value) {
            if (type == "insert_to_editor") {
                value = value.replace(/&lt;/gi, "<");
                value = value.replace(/&gt;/gi, ">");
            }
            return value;
        }
        function saveCallback(element_id, html, body) {
            html = html.replace(/</gi, "&lt;");
            html = html.replace(/>/gi, "&gt;");
            return html;
        }

        tinyMCE.init({
            mode: "exact",
            elements: "<%= txtTesto.ClientID %>",
            theme: "advanced",
            skin: "o2k7",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            save_callback: "saveCallback",
            cleanup_callback: "loadCallback",
            language: "it",
            height: "500px",
            width: "500px",

            // Esempio di uso di CSS 
           // content_css: "../css/stylesheet.css"
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd">
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Messagio -> <b>Dettaglio</b>
        </div >  
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <br />    
        <label class="sezione">Dettaglio messaggio</label>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
        <legend class="Subsezione">Messaggio</legend>
                <p>
                <label class="label">Da:</label>
                <asp:Label ID="from" runat="server"></asp:Label>
                </p>
                <p style="margin-right:10px">
                <label class="label">To:</label>
                <asp:TextBox ID="toUser" runat="server" Height="200px" Width="300px"  Enabled="false"  TextMode="MultiLine"  CssClass="textBox" ></asp:TextBox>
                </p>
                <p>
                <label class="label">CC: </label>            
                <asp:Label ID="Email" runat="server" CssClass="label" Width="300px"></asp:Label>
                </p>
                <p>
                <label class="label">Data/ora: </label>            
                <asp:Label ID="data" runat="server" CssClass="label" Width="300px"></asp:Label>
                </p>
                <p>
                <label class="label">Soggetto: </label>            
                <asp:Label ID="soggetto" runat="server" CssClass="label" Width="300px"></asp:Label>
                </p>
                <p style="text-align:center">
                    <asp:TextBox ID="txtTesto" runat="server" Columns="50" Rows="60" CssClass="textBox"></asp:TextBox>            
                </p>
        </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftMessaggi ID="UcLeftMessaggi1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

