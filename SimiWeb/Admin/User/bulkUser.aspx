<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="bulkUser.aspx.vb" Inherits="Admin_User_BulkUSer" %>
<%@ Register src="../_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" >
           Simiweb -> Admin -> Utenti -> <b>Lista Utenti</b>
        </div >
                <br />
                <fieldset style="margin-right:20px">
                    <legend><label class="Subsezione">Importa Utenti</label></legend>
                <p>
                    <label class="label">Regione</label>
                    <asp:DropDownList ID="regione" runat="server" CssClass="dropdown"></asp:DropDownList>
                </p>
                <p>
                    <label class="label">Ruolo</label>
                    <asp:DropDownList ID="ruolo" runat="server"  CssClass="dropdown"></asp:DropDownList>
                </p>
                <p style="padding-left:500px">
                <asp:Button ID="cerca" runat="server" Text="Cerca" />
                </p>
                </fieldset>
                <hr />
    <p>
    <label>Carica il foglio excel con i campi correttamente compilati</label>
    </p>  
    <br />
    <br />      
    <p>
    <asp:Label ID="LabelUpload" runat="server"></asp:Label>
    </p>
    <p>
        <asp:FileUpload ID="FileUploadExcel" runat="server" Width="300px"   />
            <asp:Button ID="ButtonUploadFile" runat="server"  CssClass="Button"
                Text="Importa !" />
    </p>      
    <p>       
        <asp:Label ID="lblDisplay" runat="server"></asp:Label>        
    </p>
    <p>
        <asp:GridView ID="DisplayGrid" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
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

