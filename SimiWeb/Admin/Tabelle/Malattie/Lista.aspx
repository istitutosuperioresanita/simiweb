<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Admin.master" AutoEventWireup="false" CodeFile="Lista.aspx.vb" Inherits="Admin_Tabelle_Malattie_Lista" %>
<%@ Register src="~/Admin/_UserControl/UcLeftAdmin.ascx" tagname="UcLeftAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
  <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Admin -> Tabelle -> <b>Lista Malattie</b>
        </div >
        <label class="sezione">Lista Malattie</label>
        <hr />        
        <br />
        <fieldset style="margin-right:20px">
                <legend><label class="Subsezione">Criteri di ricerca</label></legend>
        <p>
        <p>
        <asp:Label ID="malattiatestolabel" runat="server" CssClass="label" AssociatedControlID="malattiatesto" Width="180px" >Nome malattia inizia con</asp:Label>
        <asp:TextBox ID="malattiatesto" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        <p style="padding-left:500px">
             <asp:Button ID="btnCerca" runat="server" Text="Cerca" />
        </p>
        <asp:Label ID="lblErrore" runat="server" CssClass="alert"></asp:Label>
        </p>
        </fieldset>
        <br />
        <p><asp:Button ID="btnNuovo" runat="server"  Visible="false"  text="Nuovo Elemento"></asp:Button></p>
        <p>
        <hr />
         <asp:ListView ID="lstMAlattia" runat="server"  DataKeyNames="id_malattia" >
            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="id_malattiaLabel" runat="server" 
                            Text='<%# Eval("id_malattia") %>'  Visible="false" />
                        <asp:Label ID="DescrizioneBreveLabel" runat="server" 
                            Text='<%# Eval("DescrizioneBreve") %>' />
                    </td>
                    <td>
                        <asp:Label ID="icd9Label" runat="server" Text='<%# Eval("icd9") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PrevistoFocolaioLabel" runat="server" 
                            Text='<%# Eval("PrevistoFocolaio") %>' />
                    </td>
<%--                    <td>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Eval("ModuloMib") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Eval("ModuloTbc") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" 
                            Text='<%# Eval("ModuloMibTipizzazione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Eval("valida") %>' />
                    </td>

                    <td>
                        <asp:Label ID="Label5" runat="server" 
                            Text='<%# Eval("modificabile") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" 
                            Text='<%# Eval("visualizzabile") %>' />
                    </td>--%>
                    <td>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="sel" ImageUrl="~/_Styles/All/images/edit.png" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                            <table ID="itemPlaceholderContainer" runat="server" border="0" style="" class="yui-grid" >
                                <tr id="Tr2" runat="server" style="">
                                    <th id="Th2" runat="server">
                                        Descrizione Breve</th>
                                    <th id="Th4" runat="server">
                                        icd9</th>
                                        <th id="Th10" runat="server">
                                        Focolaio</th>
<%--                                        <th id="Th1" runat="server">
                                        Mib
                                        </th>
                                        <th id="Th5" runat="server">
                                        Mib Tip.
                                        </th>
                                        <th id="Th9" runat="server">
                                        Tbc
                                        </th>
                                        <th id="Th6" runat="server">
                                        Valida
                                        </th>
                                        <th id="Th7" runat="server">
                                        modificabile
                                        </th>
                                        <th id="Th3" runat="server">
                                            visualizzabile
                                        </th>--%>
                                        <th id="Th8" runat="server">
                                        </th>

                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
            </LayoutTemplate>
        </asp:ListView>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftAdmin ID="UcLeftAdmin1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
            <div class="dow-center">
</div>
</asp:Content>

