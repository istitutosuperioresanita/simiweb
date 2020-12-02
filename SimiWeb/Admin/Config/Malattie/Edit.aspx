<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Edit.aspx.vb" Inherits="Admin_Config_Malattie_Edit" %>

<%@ Register src="../../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
  <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Configura -> Gruppi malattie
        </div >
        <p>
        <br />
          <label class="label" style="width:400px"><i>I gruppi permettono di associare solo alcune malattie a determinati utenti</i></label>  
        </p> 
        <hr />
        <label class="sezione">Gruppi Malattie</label>
        <div>
            <p>
                <asp:Label ID="nomeGruppoLabel" runat="server" AssociatedControlID="nomeGruppo">Nome Gruppo:</asp:Label>
                <asp:TextBox ID="nomeGruppo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqNomeGruppo" 
                                            runat="server" Text="*" 
                                            ErrorMessage="*" ControlToValidate="nomeGruppo"></asp:RequiredFieldValidator>
                
            </p>
            <p>
                <asp:Label ID="gruppoDescrizioneLabel" runat="server" AssociatedControlID="gruppoDescrizione">Descrizione:</asp:Label>
                <asp:TextBox ID="gruppoDescrizione" runat="server" Height="200px" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                            runat="server" Text="*" 
                                            ErrorMessage="*"
                                             ControlToValidate="gruppoDescrizione"></asp:RequiredFieldValidator>
                
            </p>
            <p style="padding-left:450px">
            <asp:Button  ID="btnSalva" runat="server" Text="Salva" />
            </p>
        </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>

