Public Class Desicion

    Public SBOCompany As SAPbobsCOM.Company = Form1.SBOCompany

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim oRecSettxb As SAPbobsCOM.Recordset
        Dim stQuerytxb As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "Select ""AcctCode"",""AcctName"",""DueDate"",""Ref"",""Memo"",""DebAmount"",""CredAmnt"",""CardCode"" from ""OBNK"" where ""Ref""='DCH_SBC' and ifnull(""CardCode"",'')='' order by ""DueDate"",""Sequence"""
        oRecSettxb.DoQuery(stQuerytxb)

        Me.Hide()
        Form2.Show()

        If oRecSettxb.RecordCount > 0 Then

            MsgBox("Hasta el dia de hoy se tienen pendientes estos SALVO BUEN COBROS")
            SBC.Close()
            SBC.Show()

        Else

            SBC.Close()

        End If

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim oRecSettxb As SAPbobsCOM.Recordset
        Dim stQuerytxb As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "Select ""AcctCode"",""AcctName"",""DueDate"",""Ref"",""Memo"",""DebAmount"",""CredAmnt"",""CardCode"" from ""OBNK"" where ""Ref""='DCH_SBC' and ifnull(""CardCode"",'')='' order by ""DueDate"",""Sequence"""
        oRecSettxb.DoQuery(stQuerytxb)

        Me.Hide()
        Buscar.Show()

        If oRecSettxb.RecordCount > 0 Then

            MsgBox("Hasta el dia de hoy se tienen pendientes estos SALVO BUEN COBROS")
            SBC.Close()
            SBC.Show()

        Else

            SBC.Close()

        End If

    End Sub


    Private Sub Desicion_FormClosed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Dim SBOCompany As SAPbobsCOM.Company = Form1.SBOCompany

        SBOCompany.Disconnect()
        SBC.Close()
        Me.Hide()
        Form1.Usuario.Text = ""
        Form1.Contraseña.Text = ""
        Form1.Show()

    End Sub

    Private Sub Desicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class