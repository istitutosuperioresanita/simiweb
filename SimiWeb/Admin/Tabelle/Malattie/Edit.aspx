<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Edit.aspx.vb" MasterPageFile="~/_MasterPage/Admin.master" Inherits="Admin_Tabelle_Malattie_Edit" 
ClientIDMode="Static"  
ValidateRequest="false"
 
%>
<%@ Register src="../../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../../_Scripts/tiny_mce/tiny_mce_gzip.js" type="text/javascript"></script>
    <script type="text/javascript" src="Js/malattie.js"></script>
    <script type="text/javascript" src="../../../_Scripts/jquery-1.4.1.min.js"></script>
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
            elements: "Epidemiologico_help,Clinico_help,Laboratorio_help,Classificazione_help",
            theme: "advanced",
            skin: "o2k7",
            plugins: "safari,style,layer,table,advhr,advimage,advlink,emotions,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,xhtmlxtras,template",
            theme_advanced_buttons1: "newdocument,|,preview,print,|,cut,copy,paste,pastetext,pasteword,|,search,replace,|,undo,redo,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,visualchars,|,fullscreen,|,template,|,code",
            theme_advanced_buttons2: "styleselect,formatselect,fontselect,fontsizeselect,|,bullist,numlist,|,outdent,indent,blockquote,|,forecolor,backcolor",
            theme_advanced_buttons3: "link,unlink,anchor,image,cleanup,|,insertdate,inserttime,|,tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,media,advhr",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            save_callback: "saveCallback",
            cleanup_callback: "loadCallback",
            language: "it",
            height: "500",
            
            // Esempio di uso di CSS 
           // content_css: "../css/stylesheet.css"
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
  <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Tabelle -> Malattie -> <b>Aggiorna malattia</b>
        </div >
        <p>
            <asp:Label ID="EsitoOperazione" runat="server" Visible="false"></asp:Label>
        </p>  
        <p>
            <label class="sezione">Malattia</label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px"><legend><label class="Subsezione">Informazioni generali</label></legend>            
            <hr />
           <p>
                    <asp:Label ID="DescrizioneBreveLabel" runat="server" AssociatedControlID="DescrizioneBreve" CssClass="label"  >Descrizione breve</asp:Label>
                    <asp:TextBox ID="DescrizioneBreve" runat="server" CssClass="textBox"></asp:TextBox>  
                     <asp:RequiredFieldValidator ID="reqDescrizioneBreve"  runat="server" InitialValue="" Text="*" ControlToValidate="DescrizioneBreve" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
          </p>
          <p>
                    <asp:Label ID="DescrizioneLabel" runat="server" AssociatedControlID="Descrizione" CssClass="label"  >Descrizione breve</asp:Label>
                    <asp:TextBox ID="Descrizione" runat="server" CssClass="textBox"></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="ReqDescrizione"  runat="server" InitialValue="" Text="*" ControlToValidate="Descrizione" SetFocusOnError="true" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                              
          </p>
          <p>
                    <asp:Label ID="icd9Label" runat="server" AssociatedControlID="icd9" CssClass="label"  >Icd9:</asp:Label>
                    <asp:TextBox ID="icd9" runat="server"  CssClass="textBox">
                    </asp:TextBox>    
                    <asp:RequiredFieldValidator ID="reqIcd9"  runat="server" InitialValue="" Text="*" ControlToValidate="icd9" CssClass="alert" SetFocusOnError="true" ValidationGroup="form"></asp:RequiredFieldValidator>                              
    
          </p>
          <p>
                    <asp:Label ID="icd10Label" runat="server" AssociatedControlID="icd10" CssClass="label"  >Icd10:</asp:Label>
                    <asp:TextBox ID="icd10" runat="server"  CssClass="textBox">
                    </asp:TextBox>    
              <%--      <asp:RequiredFieldValidator ID="reqIcd10"  runat="server" InitialValue="" Text="*" ControlToValidate="icd10" CssClass="alert" SetFocusOnError="true" ValidationGroup="form"></asp:RequiredFieldValidator>                              --%>
    
          </p>
          <p>
                    <asp:Label ID="codiceMinisteroLabel" runat="server" AssociatedControlID="CodiceMinistero" CssClass="label"  >Codice Ministero:</asp:Label>
                    <asp:TextBox ID="CodiceMinistero" runat="server"  CssClass="textBox">
                    </asp:TextBox>    
    
          </p>
          <p>
                    <asp:Label ID="AliasLabel" runat="server" AssociatedControlID="AliasDescrizione" CssClass="label" >Alias:</asp:Label>
                    <asp:textBox ID="AliasDescrizione" runat="server"  CssClass="textBox" Width="300px"  >
                    </asp:textBox>    
                    <asp:RequiredFieldValidator ID="ReqAlias"  runat="server" InitialValue="" Text="*" ControlToValidate="AliasDescrizione" CssClass="alert" SetFocusOnError="true"  ValidationGroup="form"></asp:RequiredFieldValidator>                              
    
          </p>
          <p>
                    <asp:Label ID="exClasseLabel" runat="server" AssociatedControlID="exClasse" CssClass="label"  >Ex Classe:</asp:Label>
                    <asp:DropDownList ID="exClasse" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "1" Text="1"></asp:ListItem>
                            <asp:ListItem Value = "2" Text="2"></asp:ListItem>
                            <asp:ListItem Value = "3" Text="3"></asp:ListItem>
                            <asp:ListItem Value = "5" Text="5"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="ReqExClasse"  runat="server" InitialValue="" Text="*" ControlToValidate="exClasse" CssClass="alert" SetFocusOnError="true" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
          </p>
          <p>
                    <asp:Label ID="HelpLabel" runat="server" AssociatedControlID="Help" CssClass="label"  >Help:</asp:Label>
                    <asp:textBox ID="Help" runat="server"  CssClass="textBox" Width="500px" Height="200px">
                    </asp:textBox>    
                    <asp:RequiredFieldValidator ID="ReqHelp"  runat="server" InitialValue="" Text="*" ControlToValidate="Help" CssClass="alert" SetFocusOnError="true"  ValidationGroup="form"></asp:RequiredFieldValidator>                                  
          </p>

          <p>
                    <asp:Label ID="ValidaLabel" runat="server" AssociatedControlID="PrevistoTbc" CssClass="label">Valida :</asp:Label>
                    <asp:DropDownList ID="valida" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqValida"  runat="server" InitialValue="" Text="*" ControlToValidate="valida" CssClass="alert" SetFocusOnError="true" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia è attiva può essere segnalata</label> 
          </p>
                  <br />
          <p>
                    <asp:Label ID="PrevistoFocolaioLabel" runat="server" AssociatedControlID="PrevistoFocolaio" CssClass="label" >Focolaio:</asp:Label>
                    <asp:DropDownList ID="PrevistoFocolaio" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="ReqPrevistoFocolaio"  runat="server" InitialValue="" Text="*" ControlToValidate="PrevistoFocolaio" SetFocusOnError="true" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>   
                    <br />                               
                    <br />     
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia può essere segnalata come focolaio</label>

          </p>
          <br />
          <p>
                    <asp:Label ID="PrevistoMibLabel" runat="server" AssociatedControlID="PrevistoMib" CssClass="label">Modulo Mib:</asp:Label>
                    <asp:DropDownList ID="PrevistoMib" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqMib"  runat="server" InitialValue="" Text="*" ControlToValidate="PrevistoMib" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia deve avere una sezione ulteriori di dati con i campi delle Malattie Batterico Invasive</label> 
          </p>
          <br />
          <p>
                    <asp:Label ID="PrevistoMibTipizzazioniLabel" runat="server" AssociatedControlID="PrevistoMibTipizzazioni" SetFocusOnError="true" CssClass="label">Modulo Mib Tip:</asp:Label>
                    <asp:DropDownList ID="PrevistoMibTipizzazioni" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" InitialValue="" Text="*" SetFocusOnError="true" ControlToValidate="PrevistoMibTipizzazioni" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                   <label class="label" style="width:500px;padding-left:50px">Indica se la malattia deve avere una sezione ulteriori di dati con i campi delle Malattie Batterico Invasive sezione Tipizzazione</label> 
          </p>
          <br />
                    <p>
                    <asp:Label ID="PrevistoTbcLabel" runat="server" AssociatedControlID="PrevistoTbc" CssClass="label">Modulo Tbc:</asp:Label>
                    <asp:DropDownList ID="PrevistoTbc" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="ReqTbc"  runat="server" InitialValue="" Text="*" ControlToValidate="PrevistoTbc" SetFocusOnError="true" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia deve avere una sezione ulteriori di dati con i campi delle Tubercolosi</label> 
                    </p>
            <br />
                    <p>
                    <asp:Label ID="modificabileLabel" runat="server" AssociatedControlID="PrevistoTbc" CssClass="label">Modificabile:</asp:Label>
                    <asp:DropDownList ID="modificabile" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqmodificabile"  runat="server" InitialValue="" Text="*" ControlToValidate="modificabile" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia è modificabile dopo l'inserimento, se si sarà modificabile con una malattia dello stessa categoria</label> 
                    </p>
            <br />
                    <p>
                    <asp:Label ID="visualizzabileLabel" runat="server" AssociatedControlID="PrevistoTbc" CssClass="label">Visualizzabile:</asp:Label>
                    <asp:DropDownList ID="visualizzabile" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="reqvisualizzabile"  runat="server" InitialValue="" Text="*" ControlToValidate="visualizzabile" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia compare nelle ricerche e nelle esportazioni</label> 
                    </p>
            <br />
                    <p>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="PrevistoTbc" CssClass="label">Extra obbligatori:</asp:Label>
                    <asp:DropDownList ID="obbligtori" runat="server"  CssClass="dropdown">
                            <asp:ListItem Value = "" Text="Selezionare.."></asp:ListItem>
                            <asp:ListItem Value = "si" Text="si"></asp:ListItem>
                            <asp:ListItem Value = "no" Text="no"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="ReqObbligatori"  runat="server" InitialValue="" Text="*" ControlToValidate="obbligtori" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Indica se la malattia per essere notificata necessità di campi obbligatori ulteriori</label> 
                    </p>
            <br />
            <p>
                    <asp:Label ID="gruppoLabel" runat="server" AssociatedControlID="gruppo" CssClass="label">Categoria :</asp:Label>
                    <asp:DropDownList ID="gruppo" runat="server"  CssClass="dropdown">
                            <asp:ListItem Text = "" Value="Selezionare.."></asp:ListItem>
                            <asp:ListItem Text = "Generica" Value="1"></asp:ListItem>
                            <asp:ListItem Text = "Epatiti" Value="2"></asp:ListItem>                            
                            <asp:ListItem Text = "Malattie batterico invasive" Value="3"></asp:ListItem>
                            <asp:ListItem Text= "Tubercolosi" Value="4"></asp:ListItem>
                    </asp:DropDownList>    
                    <asp:RequiredFieldValidator ID="ReqGruppo"  runat="server" InitialValue="" Text="*" ControlToValidate="visualizzabile" SetFocusOnError="true"  CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator>                                  
                    <br />
                    <br />
                    <label class="label" style="width:500px;padding-left:50px">Categoria di appartenenza della malattia utilizza in caso di cambio malattia</label> 
            </p>
            <p style="padding-left:550px">
            <asp:Button  ID="btnSalvaMalattia" runat="server" Text="Aggiorna Malattia"  ValidationGroup="form"  UseSubmitBehavior="false" />
             <asp:ValidationSummary ID="vldSummary" runat="server" ValidationGroup="form" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" ShowSummary= "false" />
            </fieldset>      
            <br />  
                <fieldset style="margin-right:20px"><legend><label class="Subsezione">Criteri clinici</label></legend>                             
            <p  style="margin-left:30px">
                <asp:CheckBox ID="epidemiologico" runat="server" CssClass="checkBox" Text="Epidemiologico" ValidationGroup="crit"></asp:CheckBox>
                <br />
                <br />
                <asp:TextBox ID="Epidemiologico_help" runat="server" Columns="50" Rows="800" CssClass="textBox" ValidationGroup="crit"></asp:TextBox>
            </p>
            <hr />
            <p style="margin-left:30px">
                <asp:CheckBox ID="clinico" runat="server" CssClass="checkBox" Text="Clinico" ValidationGroup="crit"></asp:CheckBox>
                <br />
                <br />
                <asp:TextBox ID="Clinico_help" runat="server" Columns="50" Rows="800"  CssClass="textBox" ValidationGroup="crit"></asp:TextBox>
            </p>
            <hr />
            <p style="margin-left:30px">
                <asp:CheckBox ID="laboratorio" runat="server" CssClass="checkBox" Text="laboratorio" ValidationGroup="crit"></asp:CheckBox>
                <br />            
                <br />                   
                <asp:TextBox ID="Laboratorio_help" runat="server" Columns="50" Rows="800" CssClass="textBox" ValidationGroup="crit"></asp:TextBox>
            </p>

            <p style="padding-left:550px">
                 <asp:Button  ID="btnSalvaCriteri" runat="server" Text="Aggiorna criteri"  ValidationGroup="crit"  UseSubmitBehavior="false" />
            </p>
            </fieldset>
            <br />
            <fieldset style="margin-right:20px"><legend><label class="Subsezione">Classificazione</label></legend>                 
            <p style="margin-left:30px">
                <asp:TextBox ID="Classificazione_help" runat="server" Columns="50" Rows="800" CssClass="textBox" ValidationGroup="cla"></asp:TextBox>
            </p>
            <table>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Clinico
                        </td>
                        <td>
                            Epidemiologico
                        </td>
                        <td>
                            Laboratorio
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Possibile
                            <asp:TextBox ID="idClassificazionePossibile" runat="server"  Visible="false" ValidationGroup="cla"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="PossibileClinico" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="PossibileEpidemiologico" runat="server" ValidationGroup="cla" />
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="PossibileLaboratorio" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td>
                            <asp:Button  ID="btnAggiornaPossibile" runat="server" Text="Aggiorna"  ValidationGroup="cla"  UseSubmitBehavior="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Probabile
                            <asp:TextBox ID="idClassificazioneProbabile" runat="server"  Visible="false" ValidationGroup="cla"></asp:TextBox>
                        </td>                        
                        <td align="center">
                            <asp:CheckBox ID="ProbabileClinico" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="ProbabileEpidemiologico" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="ProbabileLaboratorio" runat="server" ValidationGroup="cla"/>                            
                        </td>
                        <td>
                            <asp:Button  ID="btnAggiornaProbabile" runat="server" Text="Aggiorna"  ValidationGroup="cla"  UseSubmitBehavior="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Confermato
                        <asp:TextBox ID="idClassificazioneConfermato" runat="server"  Visible="false" ValidationGroup="cla"></asp:TextBox>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="ConfermatoClinico" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="ConfermatoEpidemiologico" runat="server" ValidationGroup="cla"/>
                        </td>
                        <td align="center">
                            <asp:CheckBox ID="ConfermatoLaboratorio" runat="server" ValidationGroup="cla"/>                            
                        </td>
                        <td>
                            <asp:Button  ID="btnAggiornaConfermato" runat="server" Text="Aggiorna"  ValidationGroup="cla"  UseSubmitBehavior="false" />
                        </td>
                    </tr>
            </table>
            </fieldset>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

