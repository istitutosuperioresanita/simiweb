<%@ Page Title="" Language="VB" MasterPageFile="~/_MasterPage/Tubercolosi.master" AutoEventWireup="false" CodeFile="Lista.aspx.vb" Inherits="Tubercolosi_Lista" %>

<%@ Register src="_UserControl/UcLeftTubercolosi.ascx" tagname="UcLeftTubercolosi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenuto" Runat="Server">
    <div class="splitd"  >
        <div class="pag_link" ><!--a href="">
           home</a-->
           Simiweb -> Tubercolosi -> Lista
        </div >       
            <br />
                <br />
                <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="cognome" CssClass="label" Width="150px">Cognome paziente</asp:Label>
                <asp:TextBox ID="cognome" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="TipoLabel" runat="server" AssociatedControlID="tipo" CssClass="label" Width="150px">Tipo</asp:Label>
                <asp:DropDownList ID="tipo" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Tutti" Value=""></asp:ListItem>
                    <asp:ListItem Text="Tubercolosi" Value="Tubercolosi"></asp:ListItem>
                    <asp:ListItem Text="Micobatteriosi" Value="Micobatteriosi"></asp:ListItem>
                </asp:DropDownList>
                </p>
                <p>
                <asp:Label ID="SedeLabel" runat="server" CssClass="label" Width="150px">Sede</asp:Label>
                </p>
                <div style="padding-left:50px">
                <p>
                <br />
                <asp:CheckBox ID="polmonare" runat="server" Text="polmonare" CssClass="checkBox" />
                <br />
                <asp:CheckBox ID="extrapolmonare" runat="server" Text="extrapolmonare" CssClass="checkBox" />
                <br />
                <asp:CheckBox ID="miliare" runat="server" Text="miliare" CssClass="checkBox" />
               </p>
                </div>
                <p>
                <asp:Label ID="dataNotificaDaLabel" runat="server" AssociatedControlID="dataNotificaDa" CssClass="label" Width="150px">data notifica da</asp:Label>
                <asp:TextBox ID="dataNotificaDa" runat="server" CssClass="textBox"></asp:TextBox>
                <asp:Label ID="dataNotificaALabel" runat="server" AssociatedControlID="dataNotificaALabel" CssClass="label" Width="50px">al</asp:Label>
                <asp:TextBox ID="dataNotificaA" runat="server" CssClass="textBox"></asp:TextBox>
                </p>
                <p style="padding-left:450px">
                <asp:Button  ID="btnSalva" runat="server" Text="Cerca" />
                </p>
            <br />
            <label  class="sezione">Lista Notifiche Tubercolosi</label>
            <hr />
                <br />  
                <table class="yui-grid">
                        <tr>
                            <th>
                                Tipo
                            </th>
                            <th> 
                                Paziente
                            </th>
                            <th>
                                Sede
                            </th>
                            <th>
                                Segnalatore
                            </th>
                            <th>
                                Data segnalazione
                            </th>
                            <th>
                                Data notifica
                            </th>
                            <th style="width:20px">
                            </th>      
                        </tr>
                    
                    <tr>
                        <td> 
                            Tubercolosi
                        </td>
                        <td>
                            Mario Rossi
                        </td>
                        <td>
                            Polmonare     
                        </td>
                        <td>
                            Canizzo Elisabetta
                        </td>
                        <td>
                            01/03/2011     
                        </td>
                        <td>
                            01/03/2011
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton5" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/zoom.png"  />
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            Micobatteriosi
                        </td>
                        <td>
                            Paolo Bianchi
                        </td>
                        <td>
                            Extrapolmonare     
                        </td>
                        <td>
                            Canizzo Elisabetta
                        </td>
                        <td>
                            01/03/2011     
                        </td>
                        <td>
                            01/03/2011
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/zoom.png" />
                       </td>
                    </tr>
               </table>
               <p>
               <asp:Image ID="img" runat="server" ImageUrl="~/_Styles/All/images/zoom.png" /><label class="label" style="Width:150px">Visualizza dettaglio</label><br />
                </p>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenu" Runat="Server">
    <uc1:UcLeftTubercolosi ID="UcLeftTubercolosi1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Footer" Runat="Server">
    <div class="dow-center">
</div>
</asp:Content>

