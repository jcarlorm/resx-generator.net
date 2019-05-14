Imports Localizacion
Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblSaludo.Text = Localizacion.Recursos.Saludo
    End Sub
End Class
