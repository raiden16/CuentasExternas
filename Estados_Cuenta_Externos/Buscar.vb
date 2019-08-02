Public Class Buscar

    Public SBOCompany As SAPbobsCOM.Company = Nothing

    Private Sub Buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SBOCompany = Form1.SBOCompany

        Dim oRecSettxb As SAPbobsCOM.Recordset
        Dim stQuerytxb As String
        Dim Name As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "Select T0.""AcctCode"" from OACT T0 where T0.""FatherNum""='110102' and T0.""AcctCode"" not in('110102002','110102005','110102008') order by T0.""AcctCode"""
        oRecSettxb.DoQuery(stQuerytxb)

        If oRecSettxb.RecordCount > 0 Then

            For cont As Integer = 0 To oRecSettxb.RecordCount - 1

                If cont = 0 Then

                    oRecSettxb.MoveFirst()
                    Name = oRecSettxb.Fields.Item("AcctCode").Value
                    Banco2.Items.Add(Name)

                Else

                    oRecSettxb.MoveNext()
                    Name = oRecSettxb.Fields.Item("AcctCode").Value
                    Banco2.Items.Add(Name)

                End If

            Next

        End If

    End Sub


    Private Sub Banco2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Banco2.SelectedIndexChanged

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx2 As SAPbobsCOM.Recordset
        Dim stQuerytx2 As String

        oRecSettx2 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx2 = "Select T0.""AcctName"" FROM OACT T0 WHERE ""AcctCode""='" & Banco2.Text & "'"
        oRecSettx2.DoQuery(stQuerytx2)

        If oRecSettx2.RecordCount > 0 Then

            BancoText2.Text = oRecSettx2.Fields.Item("AcctName").Value

        End If

        If Banco2.Text = "110102005" Or Banco2.Text = "110102002" Or Banco2.Text = "110102008" Or Banco2.Text = "110102001" Then

            BancoImage2.Image = My.Resources.HSBC

        ElseIf Banco2.Text = "110102004" Then

            BancoImage2.Image = My.Resources.Banorte

        ElseIf Banco2.Text = "110102007" Then

            BancoImage2.Image = My.Resources.Santander

        ElseIf Banco2.Text = "110102010" Then

            BancoImage2.Image = My.Resources.Bancomer

        ElseIf Banco2.Text = "110102003" Then

            BancoImage2.Image = My.Resources.Banamex

        ElseIf Banco2.Text = "110102006" Then

            BancoImage2.Image = My.Resources.Scotiabank

        End If

    End Sub


    Private Sub Buscar2_Click(sender As Object, e As EventArgs) Handles Buscar2.Click

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx3 As SAPbobsCOM.Recordset
        Dim stQuerytx3 As String
        Dim Fecha As Date
        Dim Ref, Memo, DebAmount, CredAmnt, DocNum, CardCode, CardName As String
        Dim LineTotal As Integer = 0

        oRecSettx3 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx3 = "Select * from (Select TO_DATE(T0.""DueDate"") as ""Fecha"",T0.""Ref"",T0.""Memo"",T0.""DebAmount"",T0.""CredAmnt"",T0.""DocNum"",T0.""CardCode"",T0.""CardName"" from ""OBNK"" T0 where ifnull(T0.""CardCode"",'') in('','DEVOLUCION') and T0.""DebAmount""=0 and T0.""AcctCode""='" & Banco2.Text & "' order by T0.""DueDate"") T0 where (T0.""Ref""not in('DCH_SBC_OK','DCH_SBC')) and (ifnull(T0.""CardCode"",'DEVOLUCION')='DEVOLUCION' or T0.""CardCode""='')"
        oRecSettx3.DoQuery(stQuerytx3)

        DataGridView1.ReadOnly = True
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

        DataGridView1.Columns.Add("#", "#")
        DataGridView1.Columns.Add("Fecha", "Fecha")
        DataGridView1.Columns.Add("Referencia", "Referencia")
        DataGridView1.Columns.Add("Descripcion", "Descripcion")
        DataGridView1.Columns.Add("Debito", "Debito")
        DataGridView1.Columns.Add("Credito", "Credito")
        DataGridView1.Columns.Add("Documento", "Documento")
        DataGridView1.Columns.Add("Codigo SN", "Codigo SN")
        DataGridView1.Columns.Add("Nombre SN", "Nombre SN")

        For cont As Integer = 0 To oRecSettx3.RecordCount - 1

            If cont = 0 Then

                oRecSettx3.MoveFirst()

                If (oRecSettx3.Fields.Item("Ref").Value <> "DCH_SBC_OK" Or oRecSettx3.Fields.Item("Ref").Value <> "DCH_SBC" Or oRecSettx3.Fields.Item("Ref").Value <> "DCH") Then

                    If oRecSettx3.Fields.Item("CardCode").Value <> "DEVOLUCION" Then

                        LineTotal = LineTotal + 1

                    End If

                End If

                Else

                    oRecSettx3.MoveNext()

                If (oRecSettx3.Fields.Item("Ref").Value = "") Then

                    LineTotal = LineTotal + 1

                End If

            End If

        Next

        DataGridView1.Rows.Add(oRecSettx3.RecordCount - 1)

        For cont As Integer = 0 To oRecSettx3.RecordCount - 1

            If cont = 0 Then

                oRecSettx3.MoveFirst()
                DataGridView1.Item(0, cont).Value = cont + 1
                Fecha = oRecSettx3.Fields.Item("Fecha").Value
                DataGridView1.Item(1, cont).Value = Fecha
                Ref = oRecSettx3.Fields.Item("Ref").Value
                DataGridView1.Item(2, cont).Value = Ref
                Memo = oRecSettx3.Fields.Item("Memo").Value
                DataGridView1.Item(3, cont).Value = Memo
                DebAmount = oRecSettx3.Fields.Item("DebAmount").Value
                DataGridView1.Item(4, cont).Value = DebAmount
                CredAmnt = oRecSettx3.Fields.Item("CredAmnt").Value
                DataGridView1.Item(5, cont).Value = CredAmnt
                DocNum = oRecSettx3.Fields.Item("DocNum").Value
                DataGridView1.Item(6, cont).Value = DocNum
                CardCode = oRecSettx3.Fields.Item("CardCode").Value
                DataGridView1.Item(7, cont).Value = CardCode
                CardName = oRecSettx3.Fields.Item("CardName").Value
                DataGridView1.Item(8, cont).Value = CardName

            Else

                oRecSettx3.MoveNext()
                DataGridView1.Item(0, cont).Value = cont + 1
                Fecha = oRecSettx3.Fields.Item("Fecha").Value
                DataGridView1.Item(1, cont).Value = Fecha
                Ref = oRecSettx3.Fields.Item("Ref").Value
                DataGridView1.Item(2, cont).Value = Ref
                Memo = oRecSettx3.Fields.Item("Memo").Value
                DataGridView1.Item(3, cont).Value = Memo
                DebAmount = oRecSettx3.Fields.Item("DebAmount").Value
                DataGridView1.Item(4, cont).Value = DebAmount
                CredAmnt = oRecSettx3.Fields.Item("CredAmnt").Value
                DataGridView1.Item(5, cont).Value = CredAmnt
                DocNum = oRecSettx3.Fields.Item("DocNum").Value
                DataGridView1.Item(6, cont).Value = DocNum
                CardCode = oRecSettx3.Fields.Item("CardCode").Value
                DataGridView1.Item(7, cont).Value = CardCode
                CardName = oRecSettx3.Fields.Item("CardName").Value
                DataGridView1.Item(8, cont).Value = CardName

            End If

            Fecha = Nothing
            Ref = Nothing
            Memo = Nothing
            DebAmount = Nothing
            CredAmnt = Nothing
            DocNum = Nothing
            CardCode = Nothing
            CardName = Nothing

        Next

        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoResizeColumns() 'bncv

    End Sub


    Private Sub Buscar_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

        Me.Hide()
        Desicion.Show()

    End Sub


End Class