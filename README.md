# simiweb
Software gestionale notifica malattie infettive riuso pubblica amministrazione

Requisiti minini
Windows server 2012 o superiore
SQL SERVER 2021 o superiore
.NET Framework 4.0 


Installazione

Clonare il repository




Creare un database denominato simiweb_produzione
Scompattare il file db.zip
Lanciare il db.sql per creare il database e popolare i dati
create un utente per il database e la relativa password


Configurazione database e designer linq to sql

NEl web config
https://github.com/istitutosuperioresanita/simiweb/blob/master/SimiWeb/Web.config

Configurazione stringa di connessione al database sostituendo i seguenti valori
@datasource =istanza sql server
@catalog = nome del database
@user = utente del databae
@password = password dell'utente database
<connectionStrings>    
    <add name="Simiweb.DataLinq.My.MySettings.simiweb_produzioneConnectionString" connectionString="Data Source=@datasource;Initial Catalog=@catalog;User ID=@suer;Password=xxxxx" providerName="System.Data.SqlClient"/>        
  </connectionStrings>


La stessa configurazione deve essere cambiata qui per il desinger di linq to sql
https://github.com/istitutosuperioresanita/simiweb/blob/master/DataLinq/app.config

 <connectionStrings>
            <add name="Simiweb.DataLinq.My.MySettings.simiweb_produzioneConnectionString"
            connectionString="Data Source=@dataosource;Initial Catalog=@catalog;User ID=@user;Password=@password"
            providerName="System.Data.SqlClient" />
    </connectionStrings>


Parametri Posta



specifciare alla seguente impostazione il mittente delle mail nel web config
https://github.com/istitutosuperioresanita/simiweb/blob/master/SimiWeb/Web.config

<add key="mittente" value="@mailInvio"/>

in questa riga confiugrare i dati per il serve SMPT
  <system.net>
    <mailSettings>
      <smtp from="@mailInvio">
        <network host="@smtserver" port="@port" userName="@username" password="@pw" enableSsl="" />
      </smtp>
    </mailSettings>   

Modifica i seguenti file i mittenti e le relative impostazione per invio email

Mail di testing
https://github.com/istitutosuperioresanita/simiweb/blob/master/SimiWeb/Messaggi/Nuovo.aspx.vb
\SimiWeb\Messaggi\Nuovo.aspx  --> cambiare mittenti mail

https://github.com/istitutosuperioresanita/simiweb/blob/master/BusinessFacade/BizClass.vb
\businessfacade\bizcalss.vb   --> cambiare mittenti mail

https://github.com/istitutosuperioresanita/simiweb/blob/master/SimiWeb/Admin/User/Add.aspx.vb
\admin\user\add.aspx          --> cambiare messaggi benevenuto utente



Grafici  nel web.config
https://github.com/istitutosuperioresanita/simiweb/blob/master/SimiWeb/Web.config

Assicurarsi che questa directory abbia i permessi in scrittura e lettura
Questa directory deve avere i permessi in lettura e scrittura da parte dellutente applicativo
<add key="ChartImageHandler" value="Storage=memory;Timeout=180;Url=~/temp/;"/>


Una volta lanciato l'applicativo per il debug utilizzare la seguente utenza amministrativa per gestire e creare altri utenti


utente amministratore	
user:admin
pw: pass@word1





