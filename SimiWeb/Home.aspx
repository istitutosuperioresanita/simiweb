<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Template.master"
 AutoEventWireup="false" 
 CodeFile="Home.aspx.vb" 
 Inherits="Home" %>

<%@ Register src="_UserControl/Applicazione/ViewProfilo.ascx" tagname="ViewProfilo" tagprefix="uc1" %>

<%@ Register src="_UserControl/Applicazione/UcUltimeOperazioni.ascx" tagname="UcUltimeOperazioni" tagprefix="uc2" %>

<%--<%@ Register src="_UserControl/Applicazione/UcNews.ascx" tagname="UcNews" tagprefix="uc3" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
         <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> <b>Home</b>
        </div >  
            <p style=" text-align:center">
                <label class="alert">SimiWeb Versione 3.0 del 17/12/2019</label>
            </p>
            <uc1:ViewProfilo ID="ViewProfilo1" runat="server" />
        
             <p style="padding-left:450px">
                <asp:HyperLink ID="lnkModificaDatiPersonali" runat="server" NavigateUrl="~/User/Profile.aspx">Modifica dati personali</asp:HyperLink>     
            </p>
            <br />
<%--            <p>
<label class='alert' >!!!! Aggiornamenti importanti cliccare </label><a href="_manuale/update.pdf">qui</a>
</p>--%>
            <br />
              
                <label  class="sezione">Ultime operazioni Effettuate</label>                
                
            <hr />
                    <uc2:UcUltimeOperazioni ID="UcUltimeOperazioni1" runat="server" />                
                <br />  
                (le righe colorate di rosso indicano che una notifica inserita è stata modificata da un altro utente)
                <br />  
                <br /> 
  <label  class="sezione">News/Avvisi</label>                
            <hr />              
                </div>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

