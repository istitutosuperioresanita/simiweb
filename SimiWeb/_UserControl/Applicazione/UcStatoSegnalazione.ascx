<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcStatoSegnalazione.ascx.vb" Inherits="_UserControl_Applicazione_UcStatoSegnalazione" %>
                <div>
                    <p>                    
                    <asp:ImageButton ID="lnkRitorna" runat="server" ImageUrl="~/_Styles/All/images/arrow_left.png"  CausesValidation="false"></asp:ImageButton><label style="vertical-align:bottom" ><i><b>Riepilogo dati</b></i></label>
                    </p>
                    <p style="text-align:center">
                         
                    <label class="sezione"><b>Notifica di: </b> </label>
                    <asp:Label ID="malattialbl" runat="server" CssClass="alert"></asp:Label>               
                    </p>
                    <p>                    
                    <label class="sezione"><b>Nome: </b> </label>
                    <asp:Label ID="nomelbl" runat="server" CssClass="alert"></asp:Label>
                    <br />
                    <label class="sezione"><b>Cognome: </b> </label>
                    <asp:Label ID="cognomelbl" runat="server" CssClass="alert"></asp:Label>
                    </p>
                </div>
                