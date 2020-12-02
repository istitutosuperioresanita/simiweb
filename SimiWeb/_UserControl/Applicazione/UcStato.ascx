<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcStato.ascx.vb" Inherits="_UserControl_Applicazione_UcStato" %>
      <script type="text/javascript">
          $(document).ready(function () {


              var qualita = <%= _qualita %>;

              $("#progressbar").progressbar({ value: qualita });
              $("#progressbar").css({ 'background': 'White' });

              switch(qualita) { 
  
              case 50 : 
                //istruzioni 
                $("#progressbar > div").css({ 'background': 'Orange' });
                break; //si ferma qui                 
              case 100: 
                $("#progressbar > div").css({ 'background': 'Green' });
                //istruzioni 
               break; //si ferma qui 
                //  …
                //  
                //  case <valore n>: 
                //    //istruzioni 
                //  break; //si ferma qui 
                
                //  default: 
                //    //istruzioni 
                }


              
              $("#lblProgress").text(qualita + '%');
          });
     </script>
    <p  style="padding-left:550px">
            <asp:LinkButton ID="lnkAggiorna" runat="server" Text="Aggiorna questa sezione" CssClass="funzione"></asp:LinkButton>
    </p>
    <fieldset>
    <legend><label class="sezione">Info</label></legend>
            <hr />
<%--        <p >
            <asp:Label ID="statoSchedaLabel"  runat="server" AssociatedControlID="statoScheda"  CssClass="label">Stato</asp:Label>
            <asp:Label ID="statoScheda" runat="server" CssClass="dropdown">
            </asp:Label>
        </p>--%>
        <p>
            <label class="labelBold">data segnalazione</label>
            <asp:Label ID="datasegnalazionelabel" runat="server" CssClass="label"></asp:Label>            
        </p>
        <p>
            <label class="labelBold">data notifica</label>
            <asp:Label ID="datanotificaLabel" runat="server" CssClass="label"></asp:Label>
        </p>
        <p>
            <label class="labelBold">Asl di notifica</label>
            <asp:Label ID="aslNotificaLabel" runat="server" CssClass="label" Width="300px"></asp:Label>
        </p>
        <p>
            <label class="labelBold">Asl di residenza</label>
            <asp:Label ID="aslResidenzaLabel" runat="server" CssClass="label" Width="300px"></asp:Label>
        </p>
        <p>
            <label class="labelBold">Referente Ulss</label>
            <asp:Label ID="ReferenteUlssLabel" runat="server" CssClass="label">
            </asp:Label>
        </p>
        <p>
            <label class="labelBold">Segnalatore</label>
            <asp:Label ID="MedicoSegnalatoreLabel" runat="server" CssClass="label">
            </asp:Label>
            <label class="labelBold" style="width:150px">tipo segnalatore</label>
            <asp:Label ID="origine" runat="server" CssClass="label">
            </asp:Label>
            
        </p>
        <p>
            <label class="labelBold">inserita nel sistema da:</label>
            <asp:Label ID="inseritaDa" runat="server" CssClass="label">
            </asp:Label>
        </p>
        <br />
        <br />
        <label class="sezione">Completezza segnalazione</label>                
        <hr />
        <div id="progressbar" style="width:300px;clear:both">

        </div> 
        <label id="lblProgress" class="caption"></label>
        <br />
        <br />
        <label class="sezione">Trend Segnalazioni per questa malattia (non ancora implementato)</label>        
        <hr />
        <div>
                          <asp:Chart ID="Chart1" runat="server" Height="150px" Width="456px">
                          <Legends>
                                  <asp:Legend Name="DefaultLegend" Enabled="True" Docking="Left" />
                             </Legends>
                        <series>
                            <asp:Series ChartType="Line" Name="2009" Color="Red" >
                            </asp:Series>
                            <asp:Series ChartType="Line" Name="2010" Color="Yellow" >
                            </asp:Series>
                            <asp:Series ChartType="Line" Name="2011" Color="Blue"  >
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1">
                       
                            <AxisX Title="Mese" >
                         
                            </AxisX>
                            <AxisY Title="casi"></AxisY>
                            </asp:ChartArea>
                        </chartareas>
                        <Titles>
                            <asp:Title Name="Title1" Text="Andamento malattia">
                            </asp:Title>
                        </Titles>
                    </asp:Chart>

<%--        <br />
        <p>
        <asp:ListView ID="lst" runat="server" >
            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>
                            Nessuna operazione effettuata</td>
                    </tr>
                </table>
            </EmptyDataTemplate>  
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="tipo_operazioneLabel" runat="server" 
                            Text='<%# Eval("tipo_operazione") %>' />
                                            <asp:Label ID="idRecordLabel" runat="server" 
                            Text='<%# Eval("idRecord") %>'  Visible="false"/>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkRecord" runat="server" CommandName="sel" Text='<%# Eval("record")%>'  ></asp:LinkButton>                
                    </td>
                    <td>
                        <asp:Label ID="categoriaLabel" runat="server" Text='<%# Eval("categoria") %>' />
                    </td>
                    <td>
                        <asp:Label ID="sezioneLabel" runat="server" Text='<%# Eval("sezione") %>' />
                    </td>
                    <td>
                        <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                            <table ID="itemPlaceholderContainer" runat="server" border="0"  class="yui-grid">
                                <tr id="Tr1" runat="server" style="">
                                    <th id="Th1" runat="server">
                                        operazione</th>
                                    <th id="Th2" runat="server">
                                        Record</th>
                                    <th id="Th3" runat="server">
                                        categoria</th>
                                    <th id="Th4" runat="server">
                                        sezione</th>
                                    <th id="Th5" runat="server">
                                        data</th>
                                </tr>
                                <tr runat="server" ID="itemPlaceholder">
                                </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        </p>--%>

                </div>
    </fieldset>