<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>
 Login - SIMIWEB
</title>
   <link rel="Stylesheet"  type="text/css"  href="_Styles/Iss/Template.css" />    
   <link rel="Stylesheet"  type="text/css"  href="_Styles/Field.css" /> 
</head>
<body>
    <form runat="server">
    <div class="body">
       <div class="testata"><img src="_Styles/Iss/images/simi.png" align="middle" style="height:205px;width:1024px;" alt="testata" /></div>
              
        </div >
        <div class="top-center">
        </div>
        <div class="center" >
                 
            <div class="splitd"  >
            <p>
                   <b><i>Benvenuti,</i></b>
                   <br />
                        nel sistema di sorveglianza Simiweb (v. 08/01/2020).
                </p>


        <hr />
            </div>
                <div class="split2">
      <div class="left-column_t">LOGIN</div>
      <div class="left-column" style="text-decoration:none;">
<br />
                        <label for="txtUsername" class="labelBold" >Nome utente</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqUSername" runat="server" 
                                                     ControlToValidate="txtUsername"
                                                     InitialValue=""
                                                     Display="Static" CssClass="alert"
                                                      Text="Obbligatorio" 
                                                     ></asp:RequiredFieldValidator>
<br />
                        <label for="txtPassword" class="labelBold">Password</label>
                        <asp:TextBox ID="txtPassword"   TextMode ="Password" runat="server" CssClass="textBox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqPAssword" runat="server" 
                                                     ControlToValidate="txtPassword"
                                                     InitialValue=""
                                                     Display="Static" CssClass="alert"
                                                      Text="Obbligatorio" 
                                                     ></asp:RequiredFieldValidator>
<br />
                <asp:Label ID="txtErrore" runat = "server" CssClass="alert"></asp:Label>                
                <p style="padding-left:100px">
                        <asp:Button ID="btnLogin" runat="server" CssClass="Button"  Text="Accedi"   UseSubmitBehavior="false"/>
                </p>
                <hr />
      </div >
    </div >
       </div >
        
       <div class="dow-center">
       </div>
       <div class="piede">
          
       </div>
 
    </form>
</body>
</html>
