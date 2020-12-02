<%@ Control Language="VB" AutoEventWireup="false" 
CodeFile="UcUltimeOperazioni.ascx.vb" 
Inherits="_UserControl_Applicazione_UcUltimeOperazioni" %>
<asp:ListView ID="lst" runat="server" 
    DataKeyNames="id,idRecord,sezione,categoria">
    <EmptyDataTemplate>
        <table runat="server" style="">
            <tr>
                <td>
                    Nessuna operazione effettuata</td>
            </tr>
        </table>
    </EmptyDataTemplate>  
    <ItemTemplate>
        <tr style="" id="riga" runat="server">
            <td>
                <asp:Label ID="tipo_operazioneLabel" runat="server" 
                    Text='<%# Eval("tipo_operazione") %>' />
                                    <asp:Label ID="idRecordLabel" runat="server" 
                    Text='<%# Eval("idRecord") %>'  Visible="false"/>
            </td>
            <td>
                <asp:LinkButton ID="lnkRecord" runat="server" CommandName="sel" Text='<%# Eval("record")%>'  ></asp:LinkButton>                
            </td>
            <td>
                <asp:Label ID="categoriaLabel" runat="server" Text='<%# Eval("categoria") %>' />
            </td>
            <td>
                <asp:Label ID="sezioneLabel" runat="server" Text='<%# Eval("sezione") %>' />
            </td>
            <td>
                <asp:Label ID="effettuataLabel" runat="server" Text='<%# Eval("cognome") %>'/>
            </td>
            <td>
                <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
                    <table ID="itemPlaceholderContainer" runat="server" border="0"  class="yui-grid">
                        <tr runat="server" style="" >
                            <th runat="server">
                                operazione</th>
                            <th runat="server">
                                Record</th>
                            <th runat="server">
                                categoria</th>
                            <th runat="server">
                                sezione</th>
                            <th runat="server">
                                effettuato da</th>
                            <th runat="server">
                                data</th>
                        </tr>
                        <tr runat="server" ID="itemPlaceholder">
                        </tr>
        </table>
    </LayoutTemplate>
</asp:ListView>



