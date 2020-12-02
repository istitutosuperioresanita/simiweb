<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" AutoEventWireup="false" CodeFile="Riepilogo.aspx.vb" Inherits="Focolaio_Riepilogo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%--<%@ Register src="../_UserControl/Applicazione/ViewFocolaio.ascx" tagname="ViewFocolaio" tagprefix="uc1" %>--%>

<%@ Register src="../_UserControl/Applicazione/UcFocolaio.ascx" tagname="UcFocolaio" tagprefix="uc2" %>

<%@ Register src="../_UserControl/Applicazione/ViewCasiFocolaio.ascx" tagname="ViewCasiFocolaio" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
<asp:ScriptManager ID="mng" runat="server"></asp:ScriptManager>
<div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Focolaio -> <b>Riepilogo dati</b>            
            
        </div >
            <p style="text-align:center">  
            <label class="sezione"><b>Focolaio di: </b> </label>
            <asp:Label ID="malattiaLabel" runat="server" CssClass="alert"></asp:Label>
            </p> 
                <div>
                    <div style="float:left;width:300px">
                <p>
                <label class="sezione"  style="width:100px">Stato Notifica:</label> 
                <asp:Label ID="stato" runat="server" CssClass="alert"></asp:Label>                                                       
                </p>       
                    </div>          
                    <div style="float:left">
                          <div style="margin-left:80px;width:400px">
                                <asp:Panel ID="pnlNotifica" runat="server">
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="notifica" runat="server" ImageUrl="~/_Styles/All/images/pending.png" />
                                    <br />
                                    <label class="labelImage">Notifica</label>
                                </p>
                                </div>
                                </asp:Panel>
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="messaggio" runat="server" ImageUrl="~/_Styles/All/images/email.png" />
                                    <br />
                                    <label class="labelImage">messaggio</label>
                                </p>
                                </div>
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="stampa" runat="server" 
                                        ImageUrl="~/_Styles/All/images/printer.png" style="height: 16px" />
                                    <br />
                                    <label class="labelImage">stampa</label>
                                </p>
                                </div>
                                <asp:Panel ID="pnlInvalida" runat="server">
                                <div style="float:left">
                                <p style="text-align:center">
                                    <asp:ImageButton ID="invalida" runat="server" ImageUrl="~/_Styles/All/images/delete.png" />
                                    <br />
                                    <label class="labelImage">invalida</label>
                                </p>
                                </div>
                                </asp:Panel>
                                <div style="float:none">
                                </div>
                            </div>   
                    </div>
                    <div style="clear:both">
                       
                    </div>    
                </div>
        <asp:TabContainer ID="TabContainer1" runat="server">
            <asp:TabPanel ID="tabStato" runat="server" HeaderText="Riepilogo" TabIndex="0">
                <ContentTemplate>
                           <uc2:UcFocolaio ID="UcFocolaio1" runat="server" />
                </ContentTemplate>
                </asp:TabPanel>
        </asp:TabContainer>      
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

