Imports GeoMap.geo.error

Namespace geo.model
    Public Class GeoLocation
        Private _geocode As Geocode
        Private _err As GeoError

        Public Property geocode() As Geocode
            Get
                Return _geocode
            End Get
            Set(ByVal value As Geocode)
                _geocode = value

                _err = New GeoError(_geocode)
            End Set
        End Property

        Public Property err() As GeoError
            Get
                Return _err
            End Get
            Set(ByVal value As GeoError)
                _err = value
            End Set
        End Property

        Public Function getLat() As Double
            If _err.exist Then
                If _err.type = TypeError.ZERO_RESULTS Then
                    Return 0
                End If
            End If
            Return _geocode.firstResult.geometry.location.lat
        End Function

        Public Function getLng() As Double
            If _err.exist Then
                If _err.type = TypeError.ZERO_RESULTS Then
                    Return 0
                End If
            End If
            Return _geocode.firstResult.geometry.location.lng
        End Function

    End Class
End Namespace

