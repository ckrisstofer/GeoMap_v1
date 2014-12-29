Imports Microsoft.VisualBasic

Namespace geo.model
    Public Class GeoResults
        Public geometry As Geometry
        Public address_components() As AddressComponent
        Public formatted_address As String
    End Class
End Namespace
