Imports Newtonsoft.Json
Imports System.Net
Imports System.IO
Imports System.Text
Imports GeoMap.geo.model


Namespace geo.finder
    Public Class GeoFinder
        Private _geocode As Geocode
        Private _url


        Sub New()

        End Sub

        Public Property geocode() As Geocode
            Get
                Return _geocode
            End Get
            Set(ByVal value As Geocode)
                _geocode = value
            End Set
        End Property

        Public Property url() As String
            Get
                Return _url
            End Get
            Set(ByVal value As String)
                _url = value
            End Set
        End Property

        Public Function find(ByVal street As String, ByVal number As String, ByVal comuna As String, ByVal provincia As String, ByVal region As String)
            Dim addressSearch As String
            addressSearch = street + "," + _
                            number + _
                            "," + comuna + _
                            "," + provincia + _
                            "," + region + _
                            "&components=country:CL"
            Return findAddress(addressSearch)
        End Function

        Private Function findAddress(ByVal address As String) As Geocode
            _url = "http://maps.googleapis.com/maps/api/geocode/json?address=" & address
            Dim request As System.Net.WebRequest = WebRequest.Create(_url)
            Dim response As HttpWebResponse = request.GetResponse()

            If response.StatusCode = HttpStatusCode.OK Then
                Dim outputStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(outputStream, Encoding.ASCII)
                Dim output As String = reader.ReadToEnd()
                Dim geoCode = JsonConvert.DeserializeObject(Of Geocode)(output)
                Return geoCode
            Else
                Return Nothing
            End If
        End Function


        Public Function hasError() As Boolean
            Return False
        End Function

        Public Function getURL() As String
            Return _url
        End Function
    End Class
End Namespace
