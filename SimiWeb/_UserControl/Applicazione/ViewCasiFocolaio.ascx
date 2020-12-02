<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewCasiFocolaio.ascx.vb" Inherits="_UserControl_ViewCasiFocolaio" %>
            <label  class="sezione">Lista segnalazione/notifiche associate a questo focolaio</label>
            <hr />
                <br />  

<asp:ListView ID="LstNotifica" runat="server"  DataKeyNames="id">
    <EmptyDataTemplate>
        <table runat="server"  style="">
            <tr>
                <td>
                   Nessuna segnalazione/notifiche a questo focolaio</td>
            </tr>
        </table>
    </EmptyDataTemplate>
    <ItemTemplate>
        <tr style="">
            <td>
                <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                <asp:Label ID="DataSegnalazioneLabel" runat="server" 
                     Text='<%# DataBinder.Eval(Container.DataItem, "DataSegnalazione", "{0:dd/MM/yyyy}")%>' />
            </td>
            <td>
                <asp:Label ID="DataNotificaLabel" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "DataNotifica", "{0:dd/MM/yyyy}")%>' />
            </td>
            <td>
                <asp:LinkButton ID="lnkCognome" runat="server" CommandName="sel" Text='<%# Eval("Cognome") + cstr("<br/>")+ Eval("Nome")%> '  ></asp:LinkButton>                
            </td>
            <td>
                <asp:Label ID="DataNascitaLabel" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "DataNascita", "{0:dd/MM/yyyy}")%>' />
            </td>
            <td>
                <asp:Label ID="malattiaLabel" runat="server" Text='<%# Eval("malattia") %>' />
            </td>
            <td>
                <asp:Label ID="ComuneLabel" runat="server" Text='<%# Eval("Comune") %>' />
            </td>
            <td>
                <asp:Label ID="DescrizioneLabel" runat="server" 
                    Text='<%# Eval("Descrizione") %>' />
            </td>
            <td>
                <asp:Label ID="statoLabel" runat="server" Text='<%# Eval("stato") %>' />
            </td>
            <td>
                <asp:Label ID="notificatoreLabel" runat="server" 
                    Text='<%# Eval("notificatore") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
           <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                        <tr runat="server" style="">
                            <th runat="server">
                                Data<br />
                                segnalazione</th>
                            <th runat="server">
                                Data<br />
                                notifica</th>
                            <th runat="server">
                                Paziente</th>
                            <th runat="server">
                                Data<br />
                                nascita</th>
                            <th runat="server">
                                malattia</th>
                            <th runat="server">
                                Comune</th>
                            <th runat="server">
                                Asl <br />
                                notifica</th>
                            <th runat="server">
                                stato</th>
                            <th runat="server">
                                notificatore</th>
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
    </LayoutTemplate>
</asp:ListView>
  


