<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Add.aspx.vb"
 Inherits="Admin_User_Add"   ClientIDMode="Static"%>
<%@ Register src="../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
 <script src="Js/User.js" type="text/javascript"></script>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
  <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Admin -> Utenti -> <b>Nuovo Utente</b>
        </div >
            <asp:UpdatePanel ID="pnlUtente" runat="server">
            <ContentTemplate>
            <p>
                <label class="sezione"><b>Nuovo Utente</b> </label>
            </p>
            <hr />
            <br />
            <fieldset style="margin-right:20px">
                <legend><label class="Subsezione">Credenziali</label></legend>
            <p>
                                        <asp:Label runat="server" ID="lblUserName" AssociatedControlID="UserName" Text="Username:" CssClass="label"  Width="200px"/>
                                        <asp:TextBox runat="server" ID="UserName" CssClass="textBox" />
                                        <asp:RequiredFieldValidator 
                                                            ID="valRequireUserName" 
                                                            runat="server" 
                                                            ControlToValidate="UserName"
                                                            SetFocusOnError="true" 
                                                            Display="Dynamic" 
                                                            ToolTip="Username obbligatorio" 
                                                            CssClass="alert"
                                                            Text="*"
                                                            ></asp:RequiredFieldValidator>
           </p>
           <p>
                                       <asp:Label runat="server" ID="lblPassword" AssociatedControlID="Password" Text="Password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="Password"   CssClass="textBox"/>
                                        <asp:RequiredFieldValidator ID="valRequirePassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ToolTip="La password obbligatoria" 
                                                                    CssClass="alert"
                                                                     Text="*"
                                                                    ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="valPasswordLength" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ValidationExpression="\w{8,}" 
                                                                    ErrorMessage="La password deve essere di almeno 8 caratteri"
                                                                    ToolTip="La password deve essere di almeno 8 caratteri" 
                                                                    CssClass="alert"
                                                                     Text="*"
                                                                    ></asp:RegularExpressionValidator>                                
           </p>
           <p>

                                        <asp:Label runat="server" ID="lblConfirmPassword" AssociatedControlID="ConfirmPassword" Text="Confirm password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="ConfirmPassword"  CssClass="textBox" />
                                        <asp:RequiredFieldValidator 
                                                                    ID="valRequireConfirmPassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="ConfirmPassword"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ToolTip="Confermare la  password" 
                                                                    CssClass="alert" Text="*"
                                                                    ></asp:RequiredFieldValidator>                                                                    
                                        <asp:CompareValidator ID="valComparePasswords" 
                                                                runat="server" 
                                                                ControlToCompare="Password"
                                                                SetFocusOnError="true" 
                                                                ControlToValidate="ConfirmPassword" 
                                                                Display="Dynamic"
                                                                ErrorMessage="La password non coincide"
                                                                CssClass="alert" Text="*" ></asp:CompareValidator>
           </p>
           <p>

                                        <asp:Label runat="server" ID="lblEmail" AssociatedControlID="Email" Text="E-mail:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="Email" Text='<%# Email %>' CssClass="textBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valRequireEmail" runat="server" ControlToValidate="Email" CssClass="alert"
                                            SetFocusOnError="true" Display="Dynamic" ToolTip="Email obbligatoria"
                                            >*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="valEmailPattern" Display="Dynamic"
                                            SetFocusOnError="true"  ControlToValidate="Email"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Formato email non corretto">*</asp:RegularExpressionValidator>
               </p>
                <p>
                <label class="Subsezione">Profilo di accesso</label>
                </p>
                <hr />
                            <asp:Panel ID="pnlProfilo" runat="server">
                            <p>
                                        <label for="cmbRole" class="label">Tipo utente</label>   
                                        <asp:DropDownList ID="cmbRole" runat="server"  CssClass="dropdown" ></asp:DropDownList>
                                         <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" 
                                                                    runat="server" 
                                                                    ControlToValidate="cmbRole"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    InitialValue="Selezionare..."
                                                                    ToolTip="Selezionare il profilo" Text="*" CssClass="alert" ></asp:RequiredFieldValidator>                                                                 
                            </p>
                            <p>
                                <label class="label">Nome</label>
                                <asp:TextBox ID="nome" runat="server" CssClass="textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqNome" runat="server" ControlToValidate="Nome" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label class="label">Cognome</label>
                                <asp:TextBox ID="Cognome" runat="server" CssClass="textBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqCognome" runat="server" ControlToValidate="Cognome" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <label class="label">Telefono</label>
                                <asp:TextBox ID="Telefono" runat="server" CssClass="textBox"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ReqTelefono" runat="server" ControlToValidate="Telefono" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
                            </p>    
                            <p>
                                <label class="label">Regione</label>
                                <asp:DropDownList ID="Regione" runat="server"  CssClass="dropdown" AutoPostBack="true"></asp:DropDownList>
                            </p>
                            <p>
                                <label class="label">Asl</label>
                                <asp:DropDownList ID="Asl" runat="server" CssClass="dropdown"></asp:DropDownList>
                            </p>
                            <label class="Subsezione">Permessi</label>
                            <hr />
                            <p>
                               <label class="label">Gruppi malattie</label>
                               <asp:DropDownList ID="gruppiMalattie" runat="server" CssClass="dropdown"></asp:DropDownList>
                               <asp:RequiredFieldValidator ID="reqGruppi" runat="server"  ControlToValidate="gruppiMalattie" InitialValue="" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:CheckBox ID="lettura" runat="server" Text="lettura" CssClass="checkBox" />
                                <asp:CheckBox ID="modifica" runat="server" Text="modifica" CssClass="checkBox" />
                                <asp:CheckBox ID="eliminazione" runat="server" Text="eliminazione" CssClass="checkBox" />
                            </p>
                            </asp:Panel>
            </fieldset>
                         <p style="padding-left:500px">                         
                            <asp:Button ID="btnCrea" runat="server" Text="Crea Utente" CssClass="Button" />
                         </p>
                         <p>  
                            <asp:Label ID="OperazioniEffettuateLabel" runat="server" CssClass="alert"></asp:Label>           
                        <br />
                            <asp:Label ID="OperazioniEffettuate" runat="server"></asp:Label>           
                        </p>
                        <p>  
                            <%--<asp:Label ID="Errori" runat="server" CssClass="Alert" Text="Errori riscontrati"></asp:Label>    --%>
                            <asp:Label ID="ErrorMessage" runat="server" CssClass="alert"></asp:Label>           
                        </p>        
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ValidationSummary ID="vldSummary" runat="server" ShowMessageBox="true" HeaderText="I campi contrassegnati con un * rosso sono obbligatori" />
 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin2" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
   <div class="dow-center">
    </div>
</asp:Content>
