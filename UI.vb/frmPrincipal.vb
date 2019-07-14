Imports Localizacion
Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Recursos.Culture = New Globalization.CultureInfo("en-US")

        lblSaludo.Text = Localizacion.Recursos.Mensaje

    End Sub
End Class
