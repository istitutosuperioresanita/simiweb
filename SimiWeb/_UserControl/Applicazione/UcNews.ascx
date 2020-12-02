<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcNews.ascx.vb" Inherits="_UserControl_Applicazione_UcNews" %>
<asp:ListView ID="lst" runat="server" DataKeyNames="id">
    <EmptyDataTemplate>
        <table runat="server" style="">
            <tr>
                <td>
                   Nessuna news disponibile.</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                <asp:Label ID="bodyLabel" runat="server" Text='<%# Eval("body") %>'  Width="400px"  />
            </td>
            <td>
                <asp:Label ID="dataLabel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "data", "{0:dd/MM/yyyy}")%>'/>
            </td>
            <td>
                <asp:Label ID="InviataDaLabel" runat="server" Text='<%# Eval("InviataDa") %>'  />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table ID="itemPlaceholderContainer"  runat="server" border="0" class="yui-grid">
            <tr runat="server" style="">
                <th runat="server">
                    News</th>
                <th runat="server">
                    data</th>
                <th runat="server">
                    Inviata da</th>
            </tr>
            <tr ID="itemPlaceholder" runat="server">
            </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>


