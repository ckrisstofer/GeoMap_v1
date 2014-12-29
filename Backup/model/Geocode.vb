Imports Microsoft.VisualBasic
Namespace geo.model
    Public Class Geocode
        Public _status As String
        Public _results As List(Of GeoResults)

        Public Property status() As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
            End Set
        End Property

        Public Property results() As List(Of GeoResults)
            Get
                Return _results
            End Get
            Set(ByVal value As List(Of GeoResults))
                _results = value
            End Set
        End Property

        Public Function firstResult() As GeoResults
            Return _results(0)
        End Function
    End Class
End Namespace

