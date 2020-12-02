<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewFile.ascx.vb" Inherits="_UserControl_Applicazione_ViewFile" %>
<asp:ListView ID="lstFile" runat="server" DataKeyNames="Id">
 
    <EmptyDataTemplate>
        <table id="Table1" runat="server" style="">
            <tr>
                <td>
                    Nessun documento associato</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' Visible="false" />
                <asp:Label ID="IdSegnalazioneLabel" runat="server" 
                    Text='<%# Eval("IdSegnalazione") %>' Visible="false"/>
                <asp:Label ID="SystemNumberLabel" runat="server" 
                    Text='<%# Eval("SystemNumber") %>' Visible="false" />
                <asp:Label ID="NomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
            </td>
            <td>
                <asp:Label ID="FileTypeLabel" runat="server" Text='<%# Eval("FileType") %>' />
            </td>
            <td>
                <asp:ImageButton ID="imgUpdate" runat="server" CommandName="visualizza" ImageUrl=""  />
                <asp:ImageButton ID="imgDelete" runat="server" CommandName="elimina" ImageUrl=""   />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table id="Table2" runat="server">
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                        <tr>
                            <th id="Th1" runat="server">
                                Nome</th>
                            <th id="Th2" runat="server">
                                FileType</th>
                            <th id="Th3" runat="server">
                                </th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td2" runat="server" style="">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
 
</asp:ListView>
