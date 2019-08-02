Imports Sap.Data.Hana
Imports SAPbobsCOM

Public Class Form1

    Public SBOCompany As SAPbobsCOM.Company

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Usuario.Text = ""
        Contraseña.Text = ""

    End Sub


    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim conectar As Boolean
        Dim User As String
        Dim Pass As String
        Dim Valido As Integer

        conectar = False

        User = Usuario.Text
        Pass = Contraseña.Text

        SBOCompany = New SAPbobsCOM.Company

        SBOCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
        SBOCompany.Server = My.Settings.Server
        SBOCompany.LicenseServer = My.Settings.LicenseServer
        SBOCompany.DbUserName = My.Settings.DbUserName
        SBOCompany.DbPassword = My.Settings.DbPassword

        SBOCompany.CompanyDB = My.Settings.CompanyDB

        SBOCompany.UserName = My.Settings.UserName
        SBOCompany.Password = My.Settings.Password

        SBOCompany.UseTrusted = False

        Valido = SBOCompany.AuthenticateUser(My.Settings.UserName, My.Settings.Password)

        If (Usuario.Text = "caja1" And Contraseña.Text = "Clara19.") Or (Usuario.Text = "caja2" And Contraseña.Text = "Ana19.*") Then

            If Valido = 0 Then

                SBOCompany.Connect()
                conectar = True
                Me.Hide()
                Desicion.Show()

            Else

                MsgBox("No se puede realizar la conexion a la base de datos por favor contacta al personal de soporte.")
                conectar = True

            End If

        Else

            MsgBox("El usuario y contraseña no coiciden o no existe ese usuario.")

        End If

    End Sub


    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed

        End

    End Sub


End Class
