<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin_User_Edit"  ClientIDMode="Static"%>

<%@ Register src="../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="Js/User.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Admin -> Utenti -> <b>Aggiorna Utente</b>
        </div >
        <p>
                <label class="sezione"><b>Aggiorna utente</b> </label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
        <legend><label class="Subsezione">Informazioni generali</label>            </legend>                                  

        <p>
                <asp:Label ID="usernameLabel" runat="server" AssociatedControlID="usernameVis" CssClass="label">Username:</asp:Label>
                <asp:Label ID="usernameVis" runat="server"  CssClass="label"></asp:Label>
        </p>
<%--        <p>
                <asp:Label ID="emailLabel" runat="server" AssociatedControlID="username"  CssClass="label">Email:</asp:Label>
                <asp:HyperLink ID="lnkEmail" runat="server" CssClass="funzione" >[lnkEmail]</asp:HyperLink>            
        </p>--%>
        <p>
                <asp:Label ID="RegisteredLabel" runat="server" AssociatedControlID="Registered" CssClass="label">Registrato:</asp:Label>
                <asp:Label ID="Registered" runat="server"  CssClass="label" Width="300px"></asp:Label>       
        </p>
        <p>
                <asp:Label ID="lastLoginLabel" runat="server" AssociatedControlID="lastLogin" CssClass="label">Ultima login:</asp:Label>
                <asp:Label ID="lastLogin" runat="server"  CssClass="label" Width="300px"></asp:Label>             
        </p>
        <p>    
                <asp:Label ID="chkOnlineNowLabel" runat="server" AssociatedControlID="chkOnlineNow" CssClass="label">On line ora:</asp:Label>
                <asp:CheckBox ID="chkOnlineNow" runat="server" Enabled="False"  CssClass="checkBox" />                        
        </p>   
        <p>
                <asp:Label ID="chkApprovedLabel" runat="server" AssociatedControlID="chkApproved" CssClass="label">Autorizzato</asp:Label>
                <asp:CheckBox ID="chkApproved" runat="server" Enabled="False"  CssClass="checkBox"  AutoPostBack="True"  /><i>Utente autorizzato all'accesso</i>    
         </p>
        <p>  
                <asp:Label ID="chkLockedOutLabel" runat="server" AssociatedControlID="chkApproved" CssClass="label">Bloccato</asp:Label>
                <asp:CheckBox ID="chkLockedOut" runat="server" Enabled="False"  CssClass="checkBox"  AutoPostBack="True"  /><i>Utente attualmente bloccato per ragioni sicurezza</i>         
         </p>
         </fieldset>
         <br />
        <fieldset style="margin-right:20px">
        <legend><label class="Subsezione">Credenziali</label>            </legend>                                  
        <p>
                                        <asp:Label runat="server" ID="lblUserName" AssociatedControlID="UserName" Text="Username:" CssClass="label"  Width="200px"/>
                                        <asp:TextBox runat="server" ID="UserName" CssClass="textBox" />
                                        <asp:RequiredFieldValidator 
                                                            ID="valRequireUserName" 
                                                            runat="server" 
                                                            ControlToValidate="UserName"
                                                            SetFocusOnError="true" 
                                                            Display="Dynamic" 
                                                            ValidationGroup = "valProfilo"
                                                            ErrorMessage="Inserire username"
                                                            ToolTip="Username obbligatorio" 
                                                            CssClass="alert"
                                                            >*</asp:RequiredFieldValidator>
           </p>
           <p>
                <asp:Label runat="server" ID="lblPassword" AssociatedControlID="passwordGenerata" Text="Password generata:" CssClass="label" Width="200px"/>                
                <asp:Label ID="passwordGenerata" runat="server" CssClass="label"></asp:Label>
           </p>
<%--        <p>
                                       <asp:Label runat="server" ID="lblPassword" AssociatedControlID="Password" Text="Password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="Password"   CssClass="textBox" TextMode="Password"/>
                                        <asp:RequiredFieldValidator ID="valRequirePassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="La password obbligatoria"
                                                                    ToolTip="La password obbligatoria" 
                                                                    CssClass="alert"
                                                                    >*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="valPasswordLength" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ValidationExpression="\w{8,}" 
                                                                    ErrorMessage="La password deve essere di almeno 8 caratteri"
                                                                    ToolTip="La password deve essere di almeno 8 caratteri" 
                                                                    CssClass="alert"
                                                                    >*</asp:RegularExpressionValidator>                                
           </p>
        <p>

                                        <asp:Label runat="server" ID="lblConfirmPassword" AssociatedControlID="ConfirmPassword" Text="Confirm password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="ConfirmPassword"  CssClass="textBox" TextMode="Password"  />
                                        <asp:RequiredFieldValidator 
                                                                    ID="valRequireConfirmPassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="ConfirmPassword"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="Confermare la  password"
                                                                    ToolTip="Confermare la  password" 
                                                                    CssClass="alert"
                                                                    >*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="valComparePasswords" 
                                                                runat="server" 
                                                                ControlToCompare="Password"
                                                                SetFocusOnError="true" 
                                                                ControlToValidate="ConfirmPassword" 
                                                                Display="Dynamic"
                                                                ErrorMessage="La password non coincide"
                                                                CssClass="alert" >*</asp:CompareValidator>
           </p>--%>
<%--            <asp:UpdatePanel ID="pnlUtente" runat="server">
            <ContentTemplate>--%>
                                                         
                   
             <p style="padding-left:450px">
                    <asp:Button  ID="btnSalvaAccount" runat="server" Text="Salva Informazioni account" Visible="false" />
                    <asp:Button  ID="btnResettaPassword" runat="server" Text="Resetta password" Visible="true" />
                    <br />
                    <asp:Label ID="accountLabel"  runat="server"  CssClass="alert"></asp:Label>
             </p> 
             </fieldset>
             <br />
             <fieldset style="margin-right:20px">
                <legend><label class="Subsezione">Profilo di accesso</label>            </legend>                                  
                <p>
                                        <label for="cmbRole" class="label">Tipo utente</label>   
                                        <asp:DropDownList ID="cmbRole" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                         <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" 
                                                                    runat="server" 
                                                                    ValidationGroup = "valProfilo"
                                                                    ControlToValidate="cmbRole"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    CssClass="Alert"
                                                                    InitialValue="Selezionare..."
                                                                    ErrorMessage="Selezionare il profilo"
                                                                    ToolTip="Selezionare il profilo" >*</asp:RequiredFieldValidator>        
                            </p>
                            <p>
                                <label class="label">Nome</label>
                                <asp:TextBox ID="nome" runat="server" CssClass="textBox"></asp:TextBox>
                            </p>
                            <p>
                                <label class="label">Cognome</label>
                                <asp:TextBox ID="Cognome" runat="server" CssClass="textBox"></asp:TextBox>
                            </p>
                            <p>
                                <label class="label">Telefono</label>
                                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox"></asp:TextBox>
                            </p>
                            <p>
                                <label class="label">Mail</label>
                                <asp:TextBox ID="Mail" runat="server" CssClass="textBox"></asp:TextBox>
                            </p>       
                            <p>
                                <label class="label">Regione</label>
                                <asp:DropDownList ID="Regione" runat="server" AutoPostBack="true" CssClass="dropdown"></asp:DropDownList>
                            </p>
                            <p>
                                <label class="label">Asl</label>
                                <asp:DropDownList ID="Asl" runat="server" CssClass="dropdown"></asp:DropDownList>
                            </p>
                            <p style="padding-left:450px">
                                <asp:Button  ID="btnSalvaProfilo" runat="server" Text="Salva Informazioni profilo" ValidationGroup = "valProfilo" />
                            <br />
                            <asp:Label ID="profilolabel"  runat="server"  CssClass="alert"></asp:Label>
                            </p>

                    </fieldset>
                    <fieldset style="margin-right:20px">
                        <legend><label class="Subsezione">Permessi</label></legend>                                  
                            <p>
                               <label class="label">Gruppi malattie</label>
                               <asp:DropDownList ID="gruppiMalattie" runat="server" CssClass="dropdown"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="reqGruppi" runat="server" 
                                            ValidationGroup = "valPermessi"  
                                            ControlToValidate="gruppiMalattie" 
                                            InitialValue="" 
                                            Text="*" 
                                            CssClass="alert"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:CheckBox ID="lettura" runat="server" Text="lettura" CssClass="checkBox" />
                                <asp:CheckBox ID="modifica" runat="server" Text="modifica" CssClass="checkBox" />
                                <asp:CheckBox ID="eliminazione" runat="server" Text="eliminazione" CssClass="checkBox" />
                            </p>                  
                            <p style="padding-left:450px">
                                <asp:Button  ID="btnPermessi" runat="server" Text="Salva permessi" ValidationGroup = "valPermessi" />
                            <br />
                            <asp:Label ID="permessiLabel"  runat="server"  CssClass="alert"></asp:Label>
             </p> 
            </fieldset>
<%--            </ContentTemplate>
            </asp:UpdatePanel>--%>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"  DisplayMode="List" ShowMessageBox="true"  ShowSummary="false" HeaderText="Controllare i campi obbligatori della sezione permessi" ValidationGroup = "valPermessi" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server"  DisplayMode="List" ShowMessageBox="true"  ShowSummary="false" HeaderText="Controllare i campi obbligatori della sezione profili" ValidationGroup = "valProfilo" />
            <p>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="Alert"></asp:Label>
            </p>
            
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

