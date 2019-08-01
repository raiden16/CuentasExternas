Public Class SBC

    Public SBOCompany As SAPbobsCOM.Company = Form1.SBOCompany

    Private Sub SBC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.Rows.Clear()

        Dim oRecSettxb As SAPbobsCOM.Recordset
        Dim stQuerytxb As String
        Dim Code, Name, Fecha, Ref, Memo, Deb, Cred, DocNum, CardCode As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "Select ""AcctCode"",""AcctName"",""DueDate"",""Ref"",""Memo"",""DebAmount"",""CredAmnt"",""DocNum"",""CardCode"" from ""OBNK"" where ""Ref""='DCH_SBC' and ifnull(""CardCode"",'')='' order by ""DueDate"",""Sequence"""
        oRecSettxb.DoQuery(stQuerytxb)

        If oRecSettxb.RecordCount > 0 Then

            DataGridView1.Columns.Add("Codigo", "Codigo")
            DataGridView1.Columns.Add("Nombre", "Nombre")
            DataGridView1.Columns.Add("Fecha", "Fecha")
            DataGridView1.Columns.Add("Referencia", "Ref")
            DataGridView1.Columns.Add("Descripcion", "Info. detallada")
            DataGridView1.Columns.Add("Debito", "Importe Debito")
            DataGridView1.Columns.Add("Credito", "Importe Credito")
            DataGridView1.Columns.Add("Documento", "Documento")
            DataGridView1.Columns.Add("Codigo", "Codigo SN")

            DataGridView1.Rows.Add(oRecSettxb.RecordCount)

            For cont As Integer = 0 To oRecSettxb.RecordCount - 1

                If cont = 0 Then

                    oRecSettxb.MoveFirst()
                    Code = oRecSettxb.Fields.Item("AcctCode").Value
                    DataGridView1.Item(0, cont).Value = Code
                    DataGridView1.Item(0, cont).ReadOnly = True
                    Name = oRecSettxb.Fields.Item("AcctName").Value
                    DataGridView1.Item(1, cont).Value = Name
                    DataGridView1.Item(1, cont).ReadOnly = True
                    Fecha = oRecSettxb.Fields.Item("DueDate").Value
                    DataGridView1.Item(2, cont).Value = Fecha
                    DataGridView1.Item(2, cont).ReadOnly = True
                    Ref = oRecSettxb.Fields.Item("Ref").Value
                    DataGridView1.Item(3, cont).Value = Ref
                    DataGridView1.Item(3, cont).ReadOnly = True
                    Memo = oRecSettxb.Fields.Item("Memo").Value
                    DataGridView1.Item(4, cont).Value = Memo
                    DataGridView1.Item(4, cont).ReadOnly = True
                    Deb = oRecSettxb.Fields.Item("DebAmount").Value
                    DataGridView1.Item(5, cont).Value = Deb
                    DataGridView1.Item(5, cont).ReadOnly = True
                    Cred = oRecSettxb.Fields.Item("CredAmnt").Value
                    DataGridView1.Item(6, cont).Value = Cred
                    DataGridView1.Item(6, cont).ReadOnly = True
                    DocNum = oRecSettxb.Fields.Item("DocNum").Value
                    DataGridView1.Item(7, cont).Value = DocNum
                    DataGridView1.Item(7, cont).ReadOnly = True
                    CardCode = oRecSettxb.Fields.Item("CardCode").Value
                    DataGridView1.Item(8, cont).Value = CardCode
                    DataGridView1.Item(8, cont).ReadOnly = True

                Else

                    oRecSettxb.MoveNext()
                    Code = oRecSettxb.Fields.Item("AcctCode").Value
                    DataGridView1.Item(0, cont).Value = Code
                    DataGridView1.Item(0, cont).ReadOnly = True
                    Name = oRecSettxb.Fields.Item("AcctName").Value
                    DataGridView1.Item(1, cont).Value = Name
                    DataGridView1.Item(1, cont).ReadOnly = True
                    Fecha = oRecSettxb.Fields.Item("DueDate").Value
                    DataGridView1.Item(2, cont).Value = Fecha
                    DataGridView1.Item(2, cont).ReadOnly = True
                    Ref = oRecSettxb.Fields.Item("Ref").Value
                    DataGridView1.Item(3, cont).Value = Ref
                    DataGridView1.Item(3, cont).ReadOnly = True
                    Memo = oRecSettxb.Fields.Item("Memo").Value
                    DataGridView1.Item(4, cont).Value = Memo
                    DataGridView1.Item(4, cont).ReadOnly = True
                    Deb = oRecSettxb.Fields.Item("DebAmount").Value
                    DataGridView1.Item(5, cont).Value = Deb
                    DataGridView1.Item(5, cont).ReadOnly = True
                    Cred = oRecSettxb.Fields.Item("CredAmnt").Value
                    DataGridView1.Item(6, cont).Value = Cred
                    DataGridView1.Item(6, cont).ReadOnly = True
                    DocNum = oRecSettxb.Fields.Item("DocNum").Value
                    DataGridView1.Item(7, cont).Value = DocNum
                    DataGridView1.Item(7, cont).ReadOnly = True
                    CardCode = oRecSettxb.Fields.Item("CardCode").Value
                    DataGridView1.Item(8, cont).Value = CardCode
                    DataGridView1.Item(8, cont).ReadOnly = True

                End If

                Code = Nothing
                Name = Nothing
                Fecha = Nothing
                Ref = Nothing
                Memo = Nothing
                Deb = Nothing
                Cred = Nothing
                DocNum = Nothing
                CardCode = Nothing

            Next

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AutoResizeColumns()

        End If

    End Sub


End Class