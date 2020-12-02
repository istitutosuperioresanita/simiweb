<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewModalitaTrasmissione.ascx.vb" Inherits="_UserControl_Applicazione_ViewModalitaTrasmissione" %>
           <label  class="sezione">Lista Veicoli Trasmissioni</label>                
            <hr />
                <br />  
                <table class="yui-grid">
                        <tr>
                            <th>
                                Modalità
                            </th>
                            <th> 
                                Veicolo
                            </th>
                            <th>
                                Identificativo
                            </th>
                        </tr>                    
                    <tr>
                        <td> 
                            Modalità 1
                        </td>
                        <td>
                            Uovo
                        </td>
                        <td>
                            Cotto     
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            Modalità 2
                        </td>
                        <td>
                            Carne
                        </td>
                        <td>
                            Cavallo     
                        </td>
                    </tr>
               </table>
            <p  style="padding-left:550px">
                <asp:LinkButton ID="linkAggiornaAnagrafica" runat="server" Text="Aggiorna trasmissione" CssClass="funzione"></asp:LinkButton>
            </p>