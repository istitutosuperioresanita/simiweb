<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="AddMalattie.aspx.vb" Inherits="Admin_Config_Malattie_AddMalattie" %>

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
        <label class="sezione">Aggiungi rimuovi malattie gruppo : Malattie Infettive</label>
        <div>
            <div style="float:left;">
                <asp:Label ID="GruppiLabel" runat="server" AssociatedControlID="Gruppi" ></asp:Label>
                <br />
                <asp:ListBox ID="Gruppi" runat="server">
                    <asp:ListItem Value="Meningite" Text="Meningite"></asp:ListItem>
                    <asp:ListItem Value="Legionella" Text="Legionella"></asp:ListItem>
                </asp:ListBox>
                <p>
                <asp:Button ID="btnCrea" runat="server"  Text="Annulla" />
                </p>
            </div>
            <div>
                <br />
                <asp:ListBox ID="Malattie" runat="server" >
                    <asp:ListItem Value="Blenoraggia" Text="Blenoraggia"></asp:ListItem>
                    <asp:ListItem Value="Epatite B" Text="Epatite B"></asp:ListItem>
                </asp:ListBox>
                <p>
                    &nbsp;</p>

            </div>
        </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
</asp:Content>

