<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
CodeFile="Nuovo.aspx.vb"
Inherits="Messagi_Nuovo" 
 ClientIDMode="Static"
 ValidateRequest="false"
 %>

<%@ Register src="../_UserControl/Navigazione/UcLeftMessaggi.ascx" tagname="UcLeftMessaggi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Js/messaggi.js" type="text/javascript"></script>
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
            plugins: "safari,style,layer,table,advhr,advimage,advlink,emotions,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,xhtmlxtras,template",
            theme_advanced_buttons1: "newdocument,|,preview,print,|,cut,copy,paste,pastetext,pasteword,|,search,replace,|,undo,redo,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,visualchars,|,fullscreen,|,template,|,code",
            theme_advanced_buttons2: "styleselect,formatselect,fontselect,fontsizeselect,|,bullist,numlist,|,outdent,indent,blockquote,|,forecolor,backcolor",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            save_callback: "saveCallback",
            cleanup_callback: "loadCallback",
            language: "it",
            height: "500px",

            // Esempio di uso di CSS 
           // content_css: "../css/stylesheet.css"
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd">
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Messagio -> <b>Nuovo Messaggio</b>
        </div >  
        <asp:Label ID="lblErrore" runat="server"  Visible ="false" CssClass="alert"></asp:Label>
        <br />        
        <asp:Label CssClass="sezione" runat="server" ID="FunzioneLabel"  ></asp:Label>
        <hr />
        <br />        
        <fieldset style="margin-right:20px">
        <legend class="Subsezione">Messaggio</legend>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" AssociatedControlID="lista" Text="A: i seguenti utenti del sistema"  CssClass="labelBold" Width="300px"></asp:Label>
        <br />
        <br />
        <div style="width:400px; height:300px; overflow:scroll">
                <asp:CheckBoxList ID="lista" runat="server" RepeatDirection="Vertical" RepeatColumns="1" >
                            
                </asp:CheckBoxList>
            
        </div>
        <p>
        <label class="labelBold" style="width:50px">CC: </label>            
        <asp:TextBox ID="Email" runat="server" CssClass="textBox" Width="300px"></asp:TextBox>
        <label class="label" style="width:300px">(lista di email separata da ;)</label>
        </p>
        <p>
            <label class="labelBold">Soggetto:</label>     
            <asp:TextBox ID="soggetto" runat="server" CssClass="textBox" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqSoggetto" runat="server" Text="*" CssClass="alert" ValidationGroup="msg" InitialValue="" ControlToValidate="soggetto"></asp:RequiredFieldValidator>
        </p>
        <asp:Panel ID="pnlAllegato" runat="server" Visible = "false">
        <p>            
            <label class="label" style="width:250px">Invia anche la scheda notificata in allegato</label>
            <asp:CheckBox ID="allegato"  runat="server" />            
            <img src="../_Styles/All/images/attachment.png" />
        </p>
        </asp:Panel>
        <br />
        <br />
        <p style="text-align:center">
            <asp:TextBox ID="txtTesto" runat="server" Columns="50" Rows="60" CssClass="textBox"></asp:TextBox>            
        </p>
        <p  style="padding-left:500px">
            <asp:Button ID="btn" runat="server" Text="Invia" ValidationGroup="msg"/>                          
        </p>
        <asp:ValidationSummary ID="vls" runat="server" ValidationGroup="msg"  ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori"  />         
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

