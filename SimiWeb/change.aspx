<%@ Page Title="" Language="VB"  AutoEventWireup="false" CodeFile="change.aspx.vb" Inherits="change" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
   <link rel="Stylesheet"  type="text/css"  href="_Styles/Iss/Template.css" />  
   <link rel="Stylesheet"  type="text/css"  href="_Styles/Field.css" /> 
</head>
 
<body>
<form id="form1" runat="server">
           
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>      
<div class="body">
<div class="testata">
            <img src="_Styles/Iss/images/simi.png" width="1024" height="205" align="middle" />
</div>
           <div class="top_menu" ><div class="top_voci" >
           <div class="menu_top_voci" ><a href="Default.aspx"><img src="_Styles/Iss/images/home.png" alt="home" width="31" height="25" border="0" /></a></div >

           </div >
</div> </div >

          
<div class="top-center">
</div>
 
                                
<div class="center" >
<div class="splitd"  >
   <div class="pag_link" >simiweb -> Cambio Password</div >

                <br />
                <br />
            <label  class="sezione">Cambio password</label>                
            <hr />
            <p>
            <label>E' il tuo primo accesso ti invitiamo a cambiare la password</label>
            </p>
            <p>
             <label class="labelBold" style="width:200px">Password in tuo possesso</label>
             <asp:TextBox ID="vecchiaPassword" runat="server" CssClass="textBox"></asp:TextBox> <label class="labelBold" style="width:250px">(inviata per email)</label>  
            </p>
        <p>
                                       <asp:Label runat="server" ID="lblPassword" AssociatedControlID="Password" Text="Nuova password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="Password"   CssClass="textBox" TextMode="Password"/>
                                        <asp:RequiredFieldValidator ID="valRequirePassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="Password"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="La nuova password obbligatoria"
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

                                        <asp:Label runat="server" ID="lblConfirmPassword" AssociatedControlID="ConfirmPassword" Text="Conferma la nuova password:" CssClass="label" Width="200px"/>
                                        <asp:TextBox runat="server" ID="ConfirmPassword"  CssClass="textBox"  TextMode="Password" />
                                        <asp:RequiredFieldValidator 
                                                                    ID="valRequireConfirmPassword" 
                                                                    runat="server" 
                                                                    ControlToValidate="ConfirmPassword"
                                                                    SetFocusOnError="true" 
                                                                    Display="Dynamic" 
                                                                    ErrorMessage="Confermare la nuova password"
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
           </p>
            <p>
                <asp:Button ID="salva" runat="server" Text="salva" />
            </p>
            <p>
                <asp:Label ID="lblmessaggio" runat="server" CssClass="alert"></asp:Label>
            </p>
            <p>
                <asp:HyperLink ID="lnkHome" runat="server" Visible = "false" NavigateUrl ="~/Default.aspx">fai il login</asp:HyperLink>
            </p>
            <asp:ValidationSummary ID="ValidationSummary2" runat="server"  DisplayMode="List" ShowMessageBox="true"  ShowSummary="false" />
            <ajaxToolkit:NoBot ID="NoBot1" runat="server"  />
</div >
</div >
 
 <div class="dow-center">
</div>
           <div class="piede">
         
          </div>

</form>
</body>
</html>


















