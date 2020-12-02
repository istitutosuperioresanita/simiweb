Public Class JsonDto
    Private _codice As String
    Private _descrizione As String
    Public Property Codice() As String
        Get
            Return _codice
        End Get
        Set(ByVal value As String)
            _codice = value
        End Set
    End Property

    Public Property Descrizione() As String
        Get
            Return _descrizione
        End Get
        Set(ByVal value As String)
            _descrizione = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal codice As String, ByVal descrizione As String)
        _codice = codice
        _descrizione = descrizione
    End Sub
End Class
Public Class InfoNotifica
    Private _nome As String
    Private _cognome As String
    Private _malattia As String
    Private _Stato As String
    Private _qualita As Integer

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property Cognome() As String
        Get
            Return _cognome
        End Get
        Set(ByVal value As String)
            _cognome = value
        End Set
    End Property
    Public Property Malattia As String
        Get
            Return _malattia
        End Get
        Set(ByVal value As String)
            _malattia = value
        End Set
    End Property
    Public Property Stato As String
        Get
            Return _Stato
        End Get
        Set(ByVal value As String)
            _Stato = value
        End Set
    End Property
    Public Property Qualita As Integer
        Get
            Return _Stato
        End Get
        Set(ByVal value As Integer)
            _qualita = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal cognome As String, _
                   ByVal nome As String, _
                   ByVal malattia As String, _
                   ByVal qualita As Integer, _
                   ByVal stato As String)
        _cognome = cognome
        _nome = nome
        _malattia = malattia
        _qualita = qualita
        _Stato = stato
    End Sub
End Class
Public Class ReferenteMedicoDTO
    Private _id As Integer
    Private _idRegione As String
    Private _Asl As String
    Private _nome As String
    Private _cognome As String
    Private _email As String
    Private _telefono As String
    Private _valido As System.Nullable(Of Boolean)

    Public Property id() As Integer
        Get
            Return Me._id
        End Get
        Set(value As Integer)
            Me._id = value
        End Set
    End Property

    Public Property idRegione() As String
        Get
            Return Me._idRegione
        End Get
        Set(value As String)
            Me._idRegione = value
        End Set
    End Property

    Public Property Asl() As String
        Get
            Return Me._Asl
        End Get
        Set(value As String)
            Me._Asl = value
        End Set
    End Property

    Public Property nome() As String
        Get
            Return Me._nome
        End Get
        Set(value As String)
            Me._nome = value
        End Set
    End Property

    Public Property cognome() As String
        Get
            Return Me._cognome
        End Get
        Set(value As String)
            Me._cognome = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return Me._email
        End Get
        Set(value As String)
            Me._email = value
        End Set
    End Property

    Public Property telefono() As String
        Get
            Return Me._telefono
        End Get
        Set(value As String)
            Me._telefono = value
        End Set
    End Property

    Public Property valido() As System.Nullable(Of Boolean)
        Get
            Return Me._valido
        End Get
        Set(value As System.Nullable(Of Boolean))
            Me._valido = value
        End Set
    End Property


    Public Sub New(ByVal id As Integer, _
        ByVal idRegione As String, _
        ByVal Asl As String, _
        ByVal nome As String, _
        ByVal cognome As String, _
        ByVal email As String, _
        ByVal telefono As String, _
        ByVal valido As System.Nullable(Of Boolean))

        _id = id
        _idRegione = idRegione
        _Asl = Asl
        _nome = nome
        _cognome = cognome
        _email = email
        _telefono = telefono
        _valido = valido
    End Sub
End Class
