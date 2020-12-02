<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcSegnalazione.ascx.vb" Inherits="_UserControl_Applicazione_UcSegnalazione" %>
 <fieldset style="padding-right:30px">
 <legend><label class="sezione">Riepilogo</label></legend>
            <hr />
            <p style="text-align:center">
            </p>
            <br />
           <label class="labelBold" style="width:300px">Tipo criterio per la definizio di caso europea</label>
            <br />
             <p>              
                <asp:Label ID="clinicoLabel" runat="server" AssociatedControlID="Nome" CssClass="labelBold">Clinico:</asp:Label>
                <asp:Label ID="clinico" runat="server" CssClass="label"></asp:Label> 
                <br />
                <asp:Label ID="epidemiologicoLabel" runat="server" AssociatedControlID="Nome" CssClass="labelBold">Epidemiologico:</asp:Label>
                <asp:Label ID="epidemiologico" runat="server" CssClass="label"></asp:Label> 
                <br />         
                <asp:Label ID="laboratorioLabel" runat="server" AssociatedControlID="Nome" CssClass="labelBold">Laboratorio:</asp:Label>   
                <asp:Label ID="laboratorio" runat="server" CssClass="label"></asp:Label>            

            </p>
            <hr />
            <p>
                <asp:Label ID="nomeLabel" runat="server" AssociatedControlID="Nome" CssClass="labelBold">Nome:</asp:Label>
                <asp:Label ID="Nome" runat="server" CssClass="textBox"></asp:Label> 
            </p>
            <p>
                <asp:Label ID="cognomeLabel" runat="server" AssociatedControlID="Cognome" CssClass="labelBold">Cognome:</asp:Label>              
                <asp:Label ID="Cognome" runat="server" CssClass="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="sessoLabel" runat="server" AssociatedControlID="sesso" CssClass="labelBold">Sesso:</asp:Label>
                <asp:Label ID="sesso" runat="server" CssClass="Label"></asp:Label>
             </p>
            <%--p>            
                <asp:Label ID="NatoEsteroLabel" runat="server" AssociatedControlID="NatoEstero" CssClass="label" Width="200px" >E' nato all'estero ?:</asp:Label>
                <asp:Label ID="NatoEstero" runat="server" CssClass="label"></asp:Label>
             </p>  --%>
            <div style="padding-left:50px">
            <p> 
                <label class="labelBold" style="width:300px"><i>Se no, specificare</i></label>
            </p>
                <p>
                <asp:Label  id="ProvinciaNascitaLabel" runat="server"  AssociatedControlID="ProvinciaNascita" CssClass="labelBold"  Width="200px" >Provincia nascita</asp:Label> 
                <asp:Label ID="ProvinciaNascita" runat="server" CssClass="label"></asp:Label>
                </p>
                <p>
                <asp:Label ID="ComuneNascitaLabel" runat="server" AssociatedControlID="ComuneNascita" CssClass="labelBold" Width="200px" >Luogo nascita:</asp:Label>
                 <asp:Label ID="ComuneNascita" runat="server" CssClass="label"></asp:Label> 
                 </p>
            </div>
            <p>
                <asp:Label ID="DataNascitaLabel" runat="server" AssociatedControlID="DataNascita" CssClass="labelBold">Data di nascita:</asp:Label>
                <asp:Label ID="DataNascita" runat="server" CssClass="label"></asp:Label> 
            </p>
            <p>            
                <asp:Label ID="NazionalitaLabel" runat="server" AssociatedControlID="Nazionalita" CssClass="labelBold" >Nazionalità:</asp:Label>
                <asp:Label ID="Nazionalita" runat="server" CssClass="label" ></asp:Label>                             
            </p>
            <hr />
            <p>          
                <asp:Label ID="codiceFiscaleNonconosciutoLabel" runat="server" CssClass="labelBold">Codice fiscale non conosciuto</asp:Label>                   
                <asp:Label ID="codiceFiscaleNonconosciuto" runat="server" CssClass="label" ></asp:Label>  
            </p>
            <p>            
                <asp:Label ID="codiceFiscaleLabel" runat="server" AssociatedControlID="codiceFiscale" CssClass="labelBold">Codice fiscale:</asp:Label>
                <asp:Label ID="codiceFiscale" runat="server" CssClass="label" ></asp:Label>  
                <%--asp:RequiredFieldValidator ID="ReqCodiceFiscale"  runat="server" InitialValue="" Text="*" ControlToValidate="codiceFiscale" CssClass="alert" ValidationGroup="form"></asp:RequiredFieldValidator> --%>                                                         
            </p>
            <p>            
                <asp:Label ID="NumeroStpLabel" runat="server" AssociatedControlID="NumeroSTP" CssClass="labelBold" MaxLength="20">Numero STP:</asp:Label>
                <asp:Label ID="NumeroSTP" runat="server" CssClass="label"></asp:Label>                
            </p>
            <p>            
             <asp:Label ID="StranieroNonInRegolaLabel" runat="server" AssociatedControlID="StranieroNonInRegola" CssClass="labelBold" Width="200px" >Straniero non in regola:</asp:Label>
             <asp:Label ID="StranieroNonInRegola" runat="server" CssClass="label"></asp:Label>             
            </p>
            <p>            
             <asp:Label ID="ProfessioneLabel" runat="server" AssociatedControlID="Professione" CssClass="labelBold" >Professione:</asp:Label>                
             <asp:Label ID="Professione" runat="server" CssClass="label"></asp:Label>
            </p>
            <hr />
        <p>
            <asp:Label ID="DataPrimiSintomiLabel" runat="server" AssociatedControlID="DataPrimiSintomi" CssClass="labelBold" Width="150px" >Data primi sintomi:</asp:Label>
            <asp:Label ID="DataPrimiSintomi" runat="server" CssClass="label"></asp:Label> 
        </p>
        <p>
            <asp:Label ID="StatoVaccinaleLabel" runat="server" AssociatedControlID="StatoVaccinale" CssClass="labelBold" Width="150px" >Paziente vaccinato:</asp:Label>
            <asp:Label ID="StatoVaccinale" runat="server" CssClass="label"></asp:Label>          
        </p>                 
        <p>
            <asp:Label ID="RicoveroLuogoDicuraLabel" runat="server" AssociatedControlID="RicoveroLuogoDicura" CssClass="labelBold" Width="150px">Ricovero in luogo di cura</asp:Label>
            <asp:Label ID="RicoveroLuogoDicura" runat="server" CssClass="label"></asp:Label>          
         </p>
         <hr />
        <p>
            <asp:Label ID="ReferenteLabel" runat="server" AssociatedControlID="ReferenteUlss" CssClass="labelBold" Width="150px">Referente Ulss</asp:Label>
            <asp:Label ID="ReferenteUlss" runat="server" CssClass="label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="dataSegnalazioneLabel"  runat="server" AssociatedControlID="dataSegnalazione"  CssClass="labelBold" Width="150px">Data segnalazione</asp:Label>
            <asp:Label ID="dataSegnalazione" runat="server" CssClass="label"></asp:Label>            
        </p>
</fieldset>