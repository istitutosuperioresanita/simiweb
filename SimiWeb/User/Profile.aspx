<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="User_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Utente -> <b> miei dati</b>
        </div >
        <p>
                <label class="sezione"><b>Informazioni account</b> </label>
        </p>
        <hr />
        <br />
        <fieldset style="margin-right:20px">
        <legend><label class="Subsezione">Informazioni generali</label></legend>        
        <p>
        <asp:Label ID="ErrorMessage" runat="server" CssClass="alert"></asp:Label>
        </p>
        <p>
                <asp:Label ID="RegisteredLabel" runat="server" AssociatedControlID="Registered" CssClass="label">Registrato:</asp:Label>
                <asp:Label ID="Registered" runat="server"  CssClass="label" Width="100px"></asp:Label>       
        </p>
        <p>
                <asp:Label ID="lastLoginLabel" runat="server" AssociatedControlID="lastLogin" CssClass="label">Ultima login:</asp:Label>
                <asp:Label ID="lastLogin" runat="server"  CssClass="label" Width="100px"></asp:Label>             
        </p>
        </fieldset>
        <br />
        <fieldset style="margin-right:20px">
            <legend><label class="Subsezione">Credenziali</label></legend>
            <p>
                <asp:Label ID="usernameLabel" runat="server" AssociatedControlID="usernameVis" CssClass="label" Width="200px">Username:</asp:Label>
                <asp:Label ID="usernameVis" runat="server"  CssClass="label"></asp:Label>
           </p>
<%--            <p>
                  <asp:Label runat="server" ID="Label1" AssociatedControlID="vecchiaPassword" Text="Password auttale:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="vecchiaPassword"   CssClass="textBox" ValidationGroup="pass"/>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorvecchiaPassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="vecchiaPassword"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="La password obbligatoria"                                                                    
                                                                    ToolTip="La password obbligatoria" 
                                                                    CssClass="alert" ValidationGroup="pass"
                                                                    >*</asp:RequiredFieldValidator>
            </p>--%>
           <p>
                                       <asp:Label runat="server" ID="lblPassword" AssociatedControlID="Password" Text="Nuova password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="Password"   CssClass="textBox" ValidationGroup="pass"/>
                                        <asp:RequiredFieldValidator ID="valRequirePassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="La password obbligatoria"                                                                    
                                                                    ToolTip="La password obbligatoria" 
                                                                    CssClass="alert" ValidationGroup="pass"
                                                                    >*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="valPasswordLength" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ValidationExpression="\w{8,}" 
                                                                    ErrorMessage="La password deve essere di almeno 8 caratteri"
                                                                    ToolTip="La password deve essere di almeno 8 caratteri" 
                                                                    CssClass="alert" ValidationGroup="pass"
                                                                    >*</asp:RegularExpressionValidator>                                
           </p>
           <p>

                                        <asp:Label runat="server" ID="lblConfirmPassword" AssociatedControlID="ConfirmPassword" Text="Conferma nuova password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="ConfirmPassword"  CssClass="textBox" ValidationGroup="pass"/>
                                        <asp:RequiredFieldValidator 
                                                                    ID="valRequireConfirmPassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="ConfirmPassword"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="Confermare la  password"
                                                                    ToolTip="Confermare la  password" 
                                                                    CssClass="alert" ValidationGroup="pass"
                                                                    >*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="valComparePasswords" 
                                                                runat="server" 
                                                                ControlToCompare="Password"
                                                                SetFocusOnError="true" 
                                                                ControlToValidate="ConfirmPassword" 
                                                                Display="Dynamic" ValidationGroup="pass"
                                                                ErrorMessage="La password non coincide"
                                                                CssClass="alert" >*</asp:CompareValidator>
           </p>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"  DisplayMode="List" ShowMessageBox="true"  ShowSummary="false" ValidationGroup="pass"/>                                                                                                                                  
             <p style="padding-left:450px">
                    <asp:Button  ID="btnSalvaPassword" runat="server" Text="Salva dati autenticazione" ValidationGroup="pass" />
             </p>                    
            </fieldset>
            <br />
            <fieldset style="margin-right:20px">
            <legend><label class="Subsezione">Profilo di accesso</label></legend>              
                            <p>
                            <label for="cmbRole" class="label">Tipo utente</label>   
                                                        <asp:DropDownList ID="cmbRole" runat="server" AutoPostBack="true" CssClass="dropdown" ></asp:DropDownList>
                                                         <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" 
                                                                                    runat="server" 
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
                                <asp:TextBox ID="nome" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                            </p>
                            <p>
                                <label class="label">Cognome</label>
                                <asp:TextBox ID="Cognome" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                            </p>
                            <p>
                                <label class="label">Telefono</label>
                                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox"  ValidationGroup="prof"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValTelefono" 
                                                                    runat="server" 
                                                                    ControlToValidate="Telefono"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="Il telefono è obbligatorio"                                                                    
                                                                    ToolTip="Il telefono è obbligatorio" 
                                                                    CssClass="alert" ValidationGroup="prof"
                                                                    >*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label class="label">Mail</label>
                                <asp:TextBox ID="Mail" runat="server" CssClass="textBox"  ValidationGroup="prof"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValMail" 
                                                                    runat="server" 
                                                                    ControlToValidate="Mail"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="E-mail obbligatoria"                                                                    
                                                                    ToolTip="E-mail obbligatoria" 
                                                                    CssClass="alert" ValidationGroup="prof"
                                                                    >*</asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="valEmailPattern" 
                                                                            runat="server" 
                                                                            Display="Dynamic"
                                                                            SetFocusOnError="true" 
                                                                            ValidationGroup="prof" 
                                                                            ControlToValidate="Mail"
                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                            ErrorMessage="Formato email non corretto">*</asp:RegularExpressionValidator>
                            </p>       
                            <p>
                                <label class="label">Regione</label>
                                <asp:DropDownList ID="Regione" runat="server" CssClass="dropdown" Enabled="false"></asp:DropDownList>
                            </p>
                            <p>
                                <label class="label">Asl</label>
                                <asp:DropDownList ID="Asl" runat="server" CssClass="dropdown" Enabled="false"></asp:DropDownList>
                            </p>
                            <label class="Subsezione">Permessi</label>
                            <hr />
                            <p>
                                <asp:CheckBox ID="lettura" runat="server" Text="lettura" CssClass="checkBox"  Enabled="false"/>
                                <asp:CheckBox ID="modifica" runat="server" Text="modifica" CssClass="checkBox" Enabled="false" />
                                <asp:CheckBox ID="eliminazione" runat="server" Text="eliminazione" CssClass="checkBox" Enabled="false"/>
                            </p>
                            <br />
             <p style="padding-left:450px">
                    <asp:Button  ID="btnSalvaProfilo" runat="server" Text="Salva dati profilo" ValidationGroup="prof" />
             </p> 
            </fieldset>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server"  DisplayMode="List" ShowMessageBox="true"  ShowSummary="false" ValidationGroup="prof"/>           
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

