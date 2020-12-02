<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewEsami.ascx.vb" Inherits="_UserControl_Applicazione_ViewEsami" %>


<asp:ListView ID="lstEsami" runat="server"  DataKeyNames="id">
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="">
            <tr>
                <td>
                    Nessun esame inserito</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                <asp:Label ID="MetodoLabel" runat="server" Text='<%# Eval("Metodo") %>' />
            </td>
            <td>
                <asp:Label ID="MaterialeLabel" runat="server" Text='<%# Eval("Materiale") %>' />
            </td>
            <td>
                <asp:Label ID="DataLabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Data", "{0:dd/MM/yyyy}")%>'/>
            </td>
            <td>
                <asp:Label ID="LuogoLabel" runat="server" Text='<%# Eval("Luogo") %>' />
            </td>
            <td>
                <asp:Label ID="RisultatoLabel" runat="server" Text='<%# Eval("Risultato") %>' />
            </td>
            <td>
                <asp:Label ID="EffettuatoDaLabel" runat="server" 
                    Text='<%# Eval("EffettuatoDa") %>' />
            </td>
            <td>
                <asp:Label ID="NoteLabel" runat="server" Text='<%# Eval("Note") %>' />
            </td>
            <td>
                <asp:ImageButton ID="imgUpdate" runat="server" CommandName="aggiorna" CausesValidation="false" ImageUrl="~/_Styles/All/images/edit.png"   />
                <asp:ImageButton ID="imgDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png"   />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                        <tr id="Tr2" runat="server" style="">
                            <th id="Th1" runat="server">
                                Metodo</th>
                            <th id="Th2" runat="server">
                                Materiale</th>
                            <th id="Th3" runat="server">
                                Data</th>
                            <th id="Th4" runat="server">
                                Luogo</th>
                            <th id="Th5" runat="server">
                                Risultato</th>
                            <th id="Th6" runat="server">
                                EffettuatoDa</th>
                            <th id="Th7" runat="server">
                                Note</th>
                            <th id="th8" runat="server"> 
                                </th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
    </LayoutTemplate>  
</asp:ListView>
