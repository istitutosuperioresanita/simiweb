<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcBarra.ascx.vb" Inherits="_UserControl_Navigazione_UcBarra" %>
<div class="top_menu" >
                     <div class="top_voci" >
                     <div class="menu_top_voci" ><asp:ImageButton ID="imgHome" runat="server"  ImageUrl="~/_Styles/Veneto/images/home.png" alt="home" width="31" height="25"  BorderWidth="0" CausesValidation="false"  ValidationGroup="" /></div >
                <%--     <div class="menu_top_voci" ><asp:ImageButton ID="imgCerca" runat="server"  ImageUrl="~/_Styles/Veneto/images/cerca.png" alt="home" width="63" height="20"  BorderWidth="0" CausesValidation="false"/></div >                                                       --%>
                     <div class="menu_top_voci" ><asp:ImageButton ID="imgEmail" runat="server"  ImageUrl="~/_Styles/Veneto/images/email.png" alt="home" width="63" height="20"  BorderWidth="0" CausesValidation="false" ValidationGroup=""/></div >                      
                     <div class="menu_top_online" ><asp:Label ID="online" runat="server" CssClass="label"   Width="200px" ></asp:Label></div >
                     <div class="menu_top_voci" style="margin-left:713px"><asp:ImageButton ID="imgExit" runat="server"  ImageUrl="~/_Styles/Veneto/images/exit.png" alt="home" width="24" height="24" AlternateText="Log Out"   BorderWidth="0" /></div >
                </div >
            </div> 