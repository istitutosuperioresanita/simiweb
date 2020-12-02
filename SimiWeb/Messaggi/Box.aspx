<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Box.aspx.vb" Inherits="Messagi_Box" %>

<%@ Register src="../_UserControl/Navigazione/UcLeftMessaggi.ascx" tagname="UcLeftMessaggi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd">
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Messaggi -> <b>Box</b>
        </div >  
        <br />
        <asp:Label CssClass="sezione" runat="server" ID="FunzioneLabel"  ></asp:Label>
        <br />
        <br />
        <asp:Panel ID="pnlOutBox" runat="server">
        <asp:ListView ID="Outbox" runat="server"  DataKeyNames="MessageID">          
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>
                            Nessun messaggio</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">                       
                    <td>
                        <asp:Label ID="MessageIDLabel" runat="server" Text='<%# Eval("MessageID") %>'  Visible="false" />
<%--                        <asp:Label ID="SentByUserLabel" runat="server" 
                            Text='<%# Eval("SentByUser") %>' />
                    </td>
                    <td>--%>
                        <asp:Label ID="ToUserLabel" runat="server" Text='<%# Eval("ToUser") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ToMailLabel" runat="server" Text='<%# Eval("ToMail") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DataWebLabel" runat="server" Text='<%# Eval("DataWeb") %>' />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSel" runat="server" CommandName="view" ImageUrl="~/_Styles/All/images/zoom.png"/>
<%--                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />--%>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                <tr runat="server" style="">
                                    <th runat="server">
                                        A:</th>
                                    <th runat="server">
                                        Mail</th>
                                    <th runat="server">
                                        Soggetto</th>
                                    <th runat="server">
                                        Data</th>
                                    <th runat="server">
                                    </th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
            </LayoutTemplate>
        </asp:ListView>
        </asp:Panel>
        <asp:Panel ID="pnlInbox" runat="server">
         <asp:ListView ID="inbox" runat="server"  DataKeyNames="MessageID">          
            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>
                            Nessun messaggio</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <tr style="">                        
                    <td>
                        <asp:Label ID="MessageIDLabel" runat="server" Text='<%# Eval("MessageID") %>'  Visible="false" />
                        <asp:Label ID="SentByUserLabel" runat="server" 
                            Text='<%# Eval("SentByUser") %>' />
<%--                    </td>
                    <td>--%>
<%--                        <asp:Label ID="ToUserLabel" runat="server" Text='<%# Eval("ToUser") %>' />--%>
                    </td>
                    <td>
                        <asp:Label ID="ToMailLabel" runat="server" Text='<%# Eval("ToMail") %>' />
                    </td>
                    <td>
                        <asp:Label ID="SubjectLabel" runat="server" Text='<%# Eval("Subject") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DataWebLabel" runat="server" Text='<%# Eval("DataWeb") %>' />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnSel" runat="server" CommandName="view" ImageUrl="~/_Styles/All/images/zoom.png"/>
<%--                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />--%>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                            <table ID="itemPlaceholderContainer" runat="server" border="0" class="yui-grid">
                                <tr id="Tr1" runat="server" style="">
                                    <th id="Th2" runat="server">
                                        Da:</th>
                                    <th id="Th3" runat="server">
                                        Mail</th>
                                    <th id="Th4" runat="server">
                                        Soggetto</th>
                                    <th id="Th5" runat="server">
                                        Data</th>
                                    <th>
                                        </th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
            </LayoutTemplate>
        </asp:ListView>
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">

    <uc1:UcLeftMessaggi ID="UcLeftMessaggi1" runat="server" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

