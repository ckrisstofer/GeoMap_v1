Imports GeoMap.geo.model

Namespace geo.error
    Public Class GeoError

        Private _type As String
        Private _message As String
        Private _exist As Boolean
        Private _geocode As Geocode

        Sub New(ByVal geocode As Geocode)
            _geocode = geocode
            _type = ""
            _message = ""
            _exist = False
            find()
        End Sub

        Private Sub find()
            If _geocode.status = TypeError.ZERO_RESULTS Then
                _type = TypeError.ZERO_RESULTS
                _exist = True

                Exit Sub
            End If
            If _geocode.results.Count > 1 Then
                _type = TypeError.MULTIPLE_RESULTS
                _exist = True

                Exit Sub
            End If

            Dim geoResult As GeoResults = _geocode.results(0)

            If geoResult.address_components.Length < 7 Then
                _type = TypeError.OTHER
                _exist = True
            End If



        End Sub

        Public Property type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property

        Public Property message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        Public Property exist() As Boolean
            Get
                Return _exist
            End Get
            Set(ByVal value As Boolean)
                _exist = value
            End Set
        End Property
    End Class
End Namespace

