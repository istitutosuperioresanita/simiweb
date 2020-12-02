Imports System.Net.Mail
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq

Public Class BizClass
    Private _mobMessaggio As New BllMessaggio
    Public Enum MalattieLivello
        'definisce il livello di appartenenza delle malattie
        Tutte = 1
        Epatiti = 2
        Mib = 3
        Tubercolosi = 4
    End Enum
    Public Shared Function GetAge(ByVal Birthdate As System.DateTime, _
 Optional ByVal AsOf As System.DateTime = #1/1/1700#) _
 As Integer

        'Don't set second parameter if you want Age as of today

        'Demo 1: get age of person born 2/11/1954
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Debug.WriteLine(GetAge(objDate))

        'Demo 1: get same person's age 10 years from now
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Dim objdate2 As System.DateTime
        'objdate2 = Now.AddYears(10)
        'Debug.WriteLine(GetAge(objDate, objdate2))

        Dim iMonths As Integer
        Dim iYears As Integer
        Dim dYears As Decimal
        Dim lDayOfBirth As Long
        Dim lAsOf As Long
        Dim iBirthMonth As Integer
        Dim iAsOFMonth As Integer

        If AsOf = "#1/1/1700#" Then
            AsOf = DateTime.Now
        End If
        lDayOfBirth = DatePart(DateInterval.Day, Birthdate)
        lAsOf = DatePart(DateInterval.Day, AsOf)

        iBirthMonth = DatePart(DateInterval.Month, Birthdate)
        iAsOFMonth = DatePart(DateInterval.Month, AsOf)

        iMonths = DateDiff(DateInterval.Month, Birthdate, AsOf)

        dYears = iMonths / 12

        iYears = Math.Floor(dYears)

        If iBirthMonth = iAsOFMonth Then
            If lAsOf < lDayOfBirth Then
                iYears = iYears - 1
            End If
        End If

        Return iYears
    End Function
    Public Shared Function NotificaFilterQueryBuilder(Optional ByVal Criterio As String = Nothing, _
                                            Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                            Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                            Optional ByVal NotificatoDa As String = Nothing, _
                                            Optional ByVal Asl As String = Nothing, _
                                            Optional ByVal idRegione As String = Nothing, _
                                            Optional ByVal idComuneResidenza As String = Nothing, _
                                            Optional ByVal idMalattia As Nullable(Of Integer) = Nothing, _
                                            Optional ByVal stato As String = Nothing, _
                                            Optional ByVal username As String = Nothing, _
                                            Optional ByVal ruolo As String = Nothing) As String



        Dim filtri As New System.Text.StringBuilder
        Dim where As Boolean = False


        If Not username Is Nothing Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" dbo.Utenti_Gruppi_Malattie.username = '" + username + "'")
        End If



        If Not idRegione Is Nothing Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append("dbo.Notifica.idRegione = '" + idRegione + "'")
        End If



        '1- dataprimisintomi/datasegnalazione
        '2- datasegnalazione
        '3 -datasegnalazione/datanotifica
        '4 - data inizio sintomi
        '5 - data notifica

        Select Case Criterio
            Case "1"
                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" ( (")
                filtri.Append("dbo.Notifica_Clinica.DataPrimiSintomi >= '" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("dbo.Notifica_Clinica.DataPrimiSintomi <= '" + DataA + "'")
                filtri.Append(") OR (")
                filtri.Append("Notifica.DataSegnalazione >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("Notifica.DataSegnalazione <='" + DataA + "'")
                filtri.Append(" )) ")


            Case "2"


                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" Notifica.DataSegnalazione >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append(" Notifica.DataSegnalazione <='" + DataA + "'")
            Case "3"

                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" ( (")
                filtri.Append("dbo.Notifica.DataSegnalazione >= '" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("dbo.Notifica.DataSegnalazione <= '" + DataA + "'")
                filtri.Append(") OR (")
                filtri.Append("Notifica.DataNotifica >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("Notifica.DataNotifica <='" + DataA + "'")
                filtri.Append(" )) ")

            Case "4"
                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" dbo.Notifica_Clinica.DataPrimiSintomi >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append(" dbo.Notifica_Clinica.DataPrimiSintomi <='" + DataA + "'")
            Case "5"

                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" Notifica.DataNotifica >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append(" Notifica.DataNotifica <='" + DataA + "'")
        End Select

        '1- Notificati da questa asl
        '2- Residenti in questa asl ma segnalate da altre asl
        '3 -Notifcati e residenti in questa asl
        If Not IsNothing(Asl) Then


            Select Case NotificatoDa
                Case "1"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" dbo.Notifica.AslDiNotifica = '" + Asl + "'")
                Case "2"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" dbo.Notifica.AslDiResidenza = '" + Asl + "'")
                Case "3"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" ( ")
                    filtri.Append(" dbo.Notifica.AslDiNotifica = '" + Asl + "'")
                    filtri.Append(" OR ")
                    filtri.Append(" dbo.Notifica.AslDiResidenza = '" + Asl + "'")
                    filtri.Append(" ) ")
                Case Else

            End Select

        End If
        If Not IsNothing(idMalattia) Then
            Dim idmal As String = Convert.ToString(idMalattia)
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" dbo.Notifica_Clinica.idMalattia = " + idmal)
        End If

        If Not IsNothing(idComuneResidenza) Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" dbo.Notifica_Anagrafica.IdComuneResidenza = '" + idComuneResidenza + "'")
        End If

        'Nothing
        'Notifica
        'Segnalazione
        'Archiviata
        'Segnalate o Notifica

        If Not IsNothing(stato) Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If

            Select Case stato
                Case "Notifica"
                    filtri.Append(" Notifica.stato ='" + stato + "' ")
                Case "Segnalazione"
                    filtri.Append(" Notifica.stato ='" + stato + "' ")
                Case "Archiviata"
                    filtri.Append(" Notifica.stato ='" + stato + "' ")
                Case "Valide"
                    filtri.Append(" Notifica.stato <> 'Archiviata' ")
            End Select
        End If
        'If Not IsNothing(stato) Then
        '    If where = False Then
        '        filtri.Append("where ")
        '        where = True
        '    Else
        '        filtri.Append("and ")
        '    End If
        '    filtri.Append(" Notifica.stato ='" + stato + "'")
        'End If


        If ruolo = "medico" Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" Notifica.username ='" + username + "'")
        End If
        Return (filtri.ToString)

    End Function
    Public Shared Function FocolaioFilterQueryBuilder(Optional ByVal Criterio As String = Nothing, _
                                        Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                        Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                        Optional ByVal NotificatoDa As String = Nothing, _
                                        Optional ByVal Asl As String = Nothing, _
                                        Optional ByVal idRegione As String = Nothing, _
                                        Optional ByVal idComuneResidenza As String = Nothing, _
                                        Optional ByVal idMalattia As Nullable(Of Integer) = Nothing, _
                                        Optional ByVal stato As String = Nothing, _
                                        Optional ByVal All As Boolean = False) As String



        Dim filtri As New System.Text.StringBuilder
        Dim where As Boolean = False



        If All = False Then

            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If

            filtri.Append("dbo.Focolaio.idRegione = '" + idRegione + "'")
        End If




        '1- dataprimisintomi/datasegnalazione
        '2- datasegnalazione
        '3 -datasegnalazione/datanotifica


        Select Case Criterio
            Case "1"
                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" ( (")
                filtri.Append("dbo.Focolaio.DataInizio >= '" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("dbo.Focolaio.DataInizio <= '" + DataA + "'")
                filtri.Append(") OR (")
                filtri.Append("Focolaio.DataSegnalazione >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("Focolaio.DataSegnalazione <='" + DataA + "'")
                filtri.Append(" )) ")


            Case "2"


                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" Focolaio.DataSegnalazione >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append(" Focolaio.DataSegnalazione <='" + DataA + "'")
            Case "3"


                If where = False Then
                    filtri.Append("where ")
                    where = True
                Else
                    filtri.Append("and ")
                End If
                filtri.Append(" ( (")
                filtri.Append("dbo.Focolaio.DataSegnalazione >= '" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("dbo.Focolaio.DataSegnalazione <= '" + DataA + "'")
                filtri.Append(") OR (")
                filtri.Append("Focolaio.DataNotifica >='" + DataDa + "'")
                filtri.Append(" AND ")
                filtri.Append("Focolaio.DataNotifica <='" + DataA + "'")
                filtri.Append(" )) ")

            Case Else
        End Select

        '1- Notificati da questa asl
        '2- Residenti in questa asl ma segnalate da altre asl
        '3 -Notifcati e residenti in questa asl

        If Not IsNothing(Asl) Then



            Select Case NotificatoDa
                Case "1"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" dbo.Focolaio.idAslNotifica = '" + Asl + "'")
                Case "2"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" dbo.Focolaio.idAslResidenza = '" + Asl + "'")
                Case "3"

                    If where = False Then
                        filtri.Append("where ")
                        where = True
                    Else
                        filtri.Append("and ")
                    End If
                    filtri.Append(" ( ")
                    filtri.Append(" dbo.Focolaio.idAslNotifica = '" + Asl + "'")
                    filtri.Append(" OR ")
                    filtri.Append(" dbo.Focolaio.idAslResidenza = '" + Asl + "'")
                    filtri.Append(" ) ")
                Case Else

            End Select

        End If
        If Not IsNothing(idMalattia) Then
            Dim idmal As String = Convert.ToString(idMalattia)
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" dbo.Focolaio.idMalattia = " + idmal)
        End If

        If Not IsNothing(idComuneResidenza) Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" dbo.Focolaio.idComune = '" + idComuneResidenza + "'")
        End If

        If Not IsNothing(stato) Then
            If where = False Then
                filtri.Append("where ")
                where = True
            Else
                filtri.Append("and ")
            End If
            filtri.Append(" Focolaio.stato ='" + stato + "'")
        End If


        Return (filtri.ToString)

    End Function
    Public Sub InviaMail(ByVal body As String, ByVal ToReferente As Boolean, ByVal idregione As String)
        Try

            'Messaggio Username
            Dim mittente As String = "xxx@xxxxxx.it"
            Dim rsSupervisori As List(Of MailSupervisoriResult)

            Dim mm As New MailMessage(mittente, "xxx@xxxxxx.it")
            mm.Subject = "Simiweb 2.0"
            mm.SubjectEncoding = System.Text.Encoding.UTF8
            mm.IsBodyHtml = True
            mm.Body = body
            Dim smtp As New SmtpClient
            'invio username
            '   smtp.Send(mm)
            'invio avviso
            If ToReferente = True Then
                rsSupervisori = _mobMessaggio.GetMailSupervisore(idregione)
                For Each t As MailSupervisoriResult In rsSupervisori
                    mm.CC.Add(t.email)
                Next
            End If
            mm.Body = body
            '  smtp.Send(mm)
        Catch ex As Net.Mail.SmtpException
            Throw ex
        End Try
    End Sub
End Class
