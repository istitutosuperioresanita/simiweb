<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
AutoEventWireup="false" 
CodeFile="Lista.aspx.vb"
 EnableEventValidation= "false"
 Inherits="Focolaio_Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../_Scripts/All/ContolloData.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Focolaio -> <b>Lista focolaio</b>
</div >  
<p>
    <label class="sezione" runat="server">Lista Notifiche Focolaio</label>
</p>
<hr />
<br />
<fieldset style="margin-right:20px">
    <legend><label class="Subsezione">Criteri di ricerca</label></legend>

            <p>
            <asp:Label ID="malattiaLabel" runat="server" AssociatedControlID="malattia" CssClass="label" Width="150px">Malattia</asp:Label>
            <asp:DropDownList ID="malattia" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>
 <%--            <p>
            <asp:Label ID="agenteLabel" runat="server" AssociatedControlID="agente" CssClass="label" Width="150px">Agente</asp:Label>
            <asp:DropDownList ID="agente" runat="server" CssClass="dropdown"></asp:DropDownList> 
            </p>--%>
            <p>
            <asp:Label ID="ComuneLabel" runat="server" AssociatedControlID="comune" CssClass="label" Width="150px">Comune</asp:Label>
            <asp:DropDownList ID="comune" runat="server" CssClass="dropdown"></asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="dataNotificaDaLabel" runat="server" AssociatedControlID="dataNotificaDa" CssClass="label" Width="150px">data notifica da</asp:Label>
            <asp:TextBox ID="dataNotificaDa" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:Label ID="dataNotificaALabel" runat="server" AssociatedControlID="dataNotificaALabel" CssClass="label" Width="50px">al</asp:Label>
            <asp:TextBox ID="dataNotificaA" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="dataSegnalazioneDaLabel" runat="server" AssociatedControlID="dataSegnalazioneDa" CssClass="label" Width="150px">data segnalazione da</asp:Label>
            <asp:TextBox ID="dataSegnalazioneDa" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:Label ID="dataSegnalazioneALabel" runat="server" AssociatedControlID="dataSegnalazioneA" CssClass="label" Width="50px">al</asp:Label>
            <asp:TextBox ID="dataSegnalazioneA" runat="server" CssClass="textBox"></asp:TextBox>
            </p>
            <p style="padding-left:450px">
            <asp:Button  ID="btnCerca" runat="server" Text="Cerca"  />
            </p>
</fieldset>
<br />
<hr />
                <br /> 
       <asp:ListView ID="lstFocolaio" runat="server" DataKeyNames="id">
                <EmptyDataTemplate>
                    <table id="Table1" runat="server" style="">
                        <tr>
                            <td>
                               Nessun focolaio inserito</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>       
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                            <asp:Label ID="MalattiaLabel" runat="server" Text='<%# Eval("Malattia") %>' />
                        </td>
                        <td>                            
                            <asp:LinkButton ID="lnkComunit" runat="server" CommandName="sel" Text='<%# Eval("comunita")%> '  ></asp:LinkButton>                
                        </td>
                        <td>
                            <asp:Label ID="Comune_segnalazioneLabel" runat="server" 
                                Text='<%# Eval("Comune_segnalazione") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DataSegnalazioneLabel" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem, "DataSegnalazione", "{0:dd/MM/yyyy}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="DataNotificaLabel" runat="server" 
                                Text='<%#DataBinder.Eval(Container.DataItem, "DataNotifica", "{0:dd/MM/yyyy}")%>' />
                        </td>
                        <td>
                            <asp:Label ID="StatoLabel" runat="server" Text='<%# Eval("Stato") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                                <table ID="itemPlaceholderContainer" runat="server" border="0"  class="yui-grid" >
                                    <tr id="Tr2" runat="server" style="">
                                        <th id="Th1" runat="server">
                                            Malattia</th>
                                        <th id="Th2" runat="server">
                                            Comunita</th>
                                        <th id="Th3" runat="server">
                                            Comune segnalazione</th>
                                        <th id="Th4" runat="server">
                                            Data segnalazione</th>
                                        <th id="Th5" runat="server">
                                            Data notifica</th>
                                        <th id="Th6" runat="server">
                                            Stato</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                </LayoutTemplate>
         </asp:ListView>         
        <p style="text-align:center">
        <asp:DataPager ID="pager" runat="server" PagedControlID="lstFocolaio" PageSize="25">
            <Fields>
                <asp:NextPreviousPagerField 
                        ButtonType="image" 
                        ShowFirstPageButton="True" 
                        ShowNextPageButton="False" 
                        ShowPreviousPageButton="True" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />

                <asp:NumericPagerField />
                <asp:NextPreviousPagerField                        
                        ButtonType="image" 
                        ShowLastPageButton="True" 
                        ShowNextPageButton="True" 
                        ShowPreviousPageButton="False" 
                        FirstPageImageUrl="~/_Styles/All/images/resultset_first.png"
                        LastPageImageUrl="~/_Styles/All/images/resultset_last.png"
                        NextPageImageUrl="~/_Styles/All/images/resultset_next.png"
                        PreviousPageImageUrl="~/_Styles/All/images/resultset_previous.png" />
            </Fields>
        </asp:DataPager>
        </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>
