<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master" 
            AutoEventWireup="false" 
            CodeFile="Malattia.aspx.vb" 
            EnableViewState="false"
            ClientIDMode="Static"
            Inherits="Notifica_Malattia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../_Scripts/jquery.highlight-3.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function cerca() {

            var testo = $('#ricerca').val();
            $('i').removeHighlight();
            if (testo.length > 0) {
                $('i').highlight(testo);
            }
     


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Notifica -> <b>Nuova notifica (1 di 2)</b>
        </div >                    
        <br />
        <h3>Selezionare iniale della malattia che si vuole notificare</h3>
        <br />
        <asp:Repeater ID="rptAlphabet" runat="server" >
            <ItemTemplate>
                    <%#string.Format("<a href='#{0}'>{0}</a>",Container.DataItem)%>
            </ItemTemplate>
        </asp:Repeater>    
        <h3>oppure cerca tra gli alias malattia contenenti il testo seguente</h3>
        <br />
        <asp:TextBox ID="ricerca" runat="server" CssClass="textBox"></asp:TextBox>
        <br />
        <asp:Repeater ID="rptMalattie" runat="server">
        
                <ItemTemplate>
                        <%#AddBreak()%>
                        <img style="padding-left:50px" src="../_Styles/All/images/question.png"  alt="question"  title="<%# DataBinder.Eval(Container.DataItem,"HelpCompilazione")%>"/> 
                        <a    href="Segnalazione.aspx?idMalattia=<%# DataBinder.Eval(Container.DataItem,"id_malattia")%>&malattia=<%# DataBinder.Eval(Container.DataItem,"DescrizioneBreve")%>" >
                            <%# DataBinder.Eval(Container.DataItem, "DescrizioneBreve")%>                                                    
                        </a>  
                        <span  style="padding-left:10px"></span>  
                        <label style="width:400px"><i> <%# DataBinder.Eval(Container.DataItem, "Alias")%> </i> </label>
                        <br />
                </ItemTemplate>
        </asp:Repeater>
    </div >
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

