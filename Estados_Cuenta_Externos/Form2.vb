Public Class Form2

    Public SBOCompany As SAPbobsCOM.Company = Nothing
    Dim Sequence As Integer
    Dim Columna, Fila, TotalLine As Integer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SBOCompany = Form1.SBOCompany
        'Actualizar.Enabled = False
        Lista1.Visible = False


        Dim oRecSettxb, oRecSettxb2 As SAPbobsCOM.Recordset
        Dim stQuerytxb, stQuerytxb2 As String
        Dim Name As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "SELECT ""Name"" FROM ""@REFBANCOS"""
        oRecSettxb.DoQuery(stQuerytxb)

        If oRecSettxb.RecordCount > 0 Then

            For cont As Integer = 0 To oRecSettxb.RecordCount - 1

                If cont = 0 Then

                    oRecSettxb.MoveFirst()
                    Name = oRecSettxb.Fields.Item("Name").Value
                    Lista1.Items.Add(Name)

                Else

                    oRecSettxb.MoveNext()
                    Name = oRecSettxb.Fields.Item("Name").Value
                    Lista1.Items.Add(Name)

                End If

            Next

        End If

        oRecSettxb2 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb2 = "Select T0.""AcctCode"" from OACT T0 where T0.""FatherNum""='110102' and T0.""AcctCode"" not in('110102002','110102005','110102008') order by T0.""AcctCode"""
        oRecSettxb2.DoQuery(stQuerytxb2)

        If oRecSettxb2.RecordCount > 0 Then

            For cont2 As Integer = 0 To oRecSettxb2.RecordCount - 1

                If cont2 = 0 Then

                    oRecSettxb2.MoveFirst()
                    Name = oRecSettxb2.Fields.Item("AcctCode").Value
                    Banco.Items.Add(Name)

                Else

                    oRecSettxb2.MoveNext()
                    Name = oRecSettxb2.Fields.Item("AcctCode").Value
                    Banco.Items.Add(Name)

                End If

            Next

        End If

    End Sub


    Private Sub Banco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Banco.SelectedIndexChanged

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx2 As SAPbobsCOM.Recordset
        Dim stQuerytx2 As String

        oRecSettx2 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx2 = "Select T0.""AcctName"" FROM OACT T0 WHERE ""AcctCode""='" & Banco.Text & "'"
        oRecSettx2.DoQuery(stQuerytx2)

        If oRecSettx2.RecordCount > 0 Then

            BancoText.Text = oRecSettx2.Fields.Item("AcctName").Value

        End If


        If Banco.Text = "110102005" Or Banco.Text = "110102002" Or Banco.Text = "110102008" Or Banco.Text = "110102001" Then

            BancoImage.Image = My.Resources.HSBC

        ElseIf Banco.text = "110102004" Then

            BancoImage.Image = My.Resources.Banorte

        ElseIf Banco.Text = "110102007" Then

            BancoImage.Image = My.Resources.Santander

        ElseIf Banco.Text = "110102010" Then

            BancoImage.Image = My.Resources.Bancomer

        ElseIf Banco.Text = "110102003" Then

            BancoImage.Image = My.Resources.Banamex

        ElseIf Banco.Text = "110102006" Then

            BancoImage.Image = My.Resources.Scotiabank

        End If

    End Sub


    Private Sub Banco_Leave(sender As Object, e As EventArgs) Handles Banco.Leave

        Dim Fecha As String
        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day

        LlenarGrid(Banco.Text, Fecha)

    End Sub


    Private Sub Calendario_ValueChanged(sender As Object, e As EventArgs) Handles Calendario.Leave

        Dim Fecha As String
        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day

        LlenarGrid(Banco.Text, Fecha)

    End Sub


    Public Sub LlenarGrid(ByVal Banco As String, ByVal Fecha As String)

        DataGridView1.Rows.Clear()
        SBOCompany = Form1.SBOCompany

        Dim oRecSettx3 As SAPbobsCOM.Recordset
        Dim stQuerytx3 As String
        Dim Ref, Memo, DebAmount, CredAmnt, DocNum, CardCode, CardName As String

        oRecSettx3 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx3 = "Select * From (Select top 5 T0.""Sequence"",T0.""Ref"",T0.""Memo"",T0.""DebAmount"",T0.""CredAmnt"",T0.""DocNum"",T0.""CardCode"",T0.""CardName"" from ""OBNK"" T0 where T0.""AcctCode""='" & Banco & "' and T0.""DueDate""='" & Fecha & "' order by T0.""Sequence"" desc) T0 order by T0.""Sequence"""
        oRecSettx3.DoQuery(stQuerytx3)

        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

        DataGridView1.Columns.Add("Referencia", "Referencia")
        DataGridView1.Columns.Add("Descripcion", "Info. detallada")
        DataGridView1.Columns.Add("Debito", "Importe débito")
        DataGridView1.Columns.Add("Credito", "Importe crédito")
        DataGridView1.Columns.Add("Documento", "N° Documento")
        DataGridView1.Columns.Add("Codigo", "Código SN")
        DataGridView1.Columns.Add("Nombre", "Nombre SN")
        DataGridView1.Columns.Add("PreCargado", "PreCargado")

        DataGridView1.Columns("Nombre").ReadOnly = True
        DataGridView1.Columns("PreCargado").ReadOnly = True
        DataGridView1.Columns("PreCargado").Visible = False

        If oRecSettx3.RecordCount > 0 Then

            TotalLine = 20 + oRecSettx3.RecordCount
            DataGridView1.Rows.Add(20 + oRecSettx3.RecordCount)

            For cont As Integer = 0 To oRecSettx3.RecordCount - 1

                If cont = 0 Then

                    oRecSettx3.MoveFirst()
                    Ref = oRecSettx3.Fields.Item("Ref").Value
                    DataGridView1.Item(0, cont).Value = Ref
                    DataGridView1.Item(0, cont).ReadOnly = True
                    Memo = oRecSettx3.Fields.Item("Memo").Value
                    DataGridView1.Item(1, cont).Value = Memo
                    DataGridView1.Item(1, cont).ReadOnly = True
                    DebAmount = oRecSettx3.Fields.Item("DebAmount").Value
                    DataGridView1.Item(2, cont).Value = DebAmount
                    DataGridView1.Item(2, cont).ReadOnly = True
                    CredAmnt = oRecSettx3.Fields.Item("CredAmnt").Value
                    DataGridView1.Item(3, cont).Value = CredAmnt
                    DataGridView1.Item(3, cont).ReadOnly = True
                    DocNum = oRecSettx3.Fields.Item("DocNum").Value
                    DataGridView1.Item(4, cont).Value = DocNum
                    DataGridView1.Item(4, cont).ReadOnly = True
                    CardCode = oRecSettx3.Fields.Item("CardCode").Value
                    DataGridView1.Item(5, cont).Value = CardCode
                    DataGridView1.Item(5, cont).ReadOnly = True
                    CardName = oRecSettx3.Fields.Item("CardName").Value
                    DataGridView1.Item(6, cont).Value = CardName
                    DataGridView1.Item(6, cont).ReadOnly = True
                    DataGridView1.Item(7, cont).Value = "Yes"

                Else

                    oRecSettx3.MoveNext()
                    Ref = oRecSettx3.Fields.Item("Ref").Value
                    DataGridView1.Item(0, cont).Value = Ref
                    DataGridView1.Item(0, cont).ReadOnly = True
                    Memo = oRecSettx3.Fields.Item("Memo").Value
                    DataGridView1.Item(1, cont).Value = Memo
                    DataGridView1.Item(1, cont).ReadOnly = True
                    DebAmount = oRecSettx3.Fields.Item("DebAmount").Value
                    DataGridView1.Item(2, cont).Value = DebAmount
                    DataGridView1.Item(2, cont).ReadOnly = True
                    CredAmnt = oRecSettx3.Fields.Item("CredAmnt").Value
                    DataGridView1.Item(3, cont).Value = CredAmnt
                    DataGridView1.Item(3, cont).ReadOnly = True
                    DocNum = oRecSettx3.Fields.Item("DocNum").Value
                    DataGridView1.Item(4, cont).Value = DocNum
                    DataGridView1.Item(4, cont).ReadOnly = True
                    CardCode = oRecSettx3.Fields.Item("CardCode").Value
                    DataGridView1.Item(5, cont).Value = CardCode
                    DataGridView1.Item(5, cont).ReadOnly = True
                    CardName = oRecSettx3.Fields.Item("CardName").Value
                    DataGridView1.Item(6, cont).Value = CardName
                    DataGridView1.Item(6, cont).ReadOnly = True
                    DataGridView1.Item(7, cont).Value = "Yes"

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
            DataGridView1.AutoResizeColumns()

        Else

            TotalLine = 20
            DataGridView1.Rows.Add(20)

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AutoResizeColumns()

        End If

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Columna = e.ColumnIndex
        Fila = e.RowIndex
        Dim Grid As DataGridView = CType(sender, DataGridView)
        Dim Rec As Rectangle

        If Columna = 0 And DataGridView1.Item(7, Fila).Value <> "Yes" Then

            DataGridView1.Enabled = False
            Banco.Enabled = False
            Calendario.Enabled = False
            Rec = Grid.GetCellDisplayRectangle(Grid.CurrentCell.ColumnIndex, Grid.CurrentCell.RowIndex, False)
            Lista1.Location = New Point(Rec.Location.X + Grid.Location.X + 80, Rec.Location.Y + Grid.Location.Y - 65)
            Lista1.Visible = True

        End If

    End Sub


    Private Sub Lista1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lista1.SelectedIndexChanged

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx As SAPbobsCOM.Recordset
        Dim stQuerytx As String

        DataGridView1.Item(Columna, Fila).Value = Lista1.SelectedItem

        oRecSettx = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx = "Select T0.""U_Descripcion"" from ""@REFBANCOS"" T0 where T0.""Name""='" & Lista1.SelectedItem & "'"
        oRecSettx.DoQuery(stQuerytx)

        If oRecSettx.RecordCount > 0 Then

            DataGridView1.Item(Columna + 1, Fila).Value = oRecSettx.Fields.Item("U_Descripcion").Value

        End If

        Lista1.Visible = False
        DataGridView1.Enabled = True
        Banco.Enabled = True
        Calendario.Enabled = True

    End Sub


    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit

        SBOCompany = Form1.SBOCompany

        Columna = e.ColumnIndex
        Fila = e.RowIndex

        Dim oRecSettx As SAPbobsCOM.Recordset
        Dim stQuerytx, CardCode As String

        If Columna = 5 And DataGridView1.Item(7, Fila).Value <> "Yes" Then

            CardCode = DataGridView1.Item(Columna, Fila).Value

            oRecSettx = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            stQuerytx = "Select T0.""CardName"" from ""OCRD"" T0 where T0.""CardCode""='" & CardCode & "'"
            oRecSettx.DoQuery(stQuerytx)

            DataGridView1.Item(Columna + 1, Fila).Value = oRecSettx.Fields.Item("CardName").Value.ToString

        End If

    End Sub


    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click

        SBOCompany = Form1.SBOCompany

        Dim oCuenta As SAPbobsCOM.BankPages
        Dim Fecha, Ref, DocNum, CardCode, Bancos As String
        Dim Deb, Cred As Double
        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day

        '------------------Agregar condicion de fecha
        If Banco.Text <> Nothing Then

            For cont As Integer = 0 To TotalLine

                If DataGridView1.Item(7, cont).Value <> "Yes" And DataGridView1.Item(0, cont).Value <> "" Then

                    If (DataGridView1.Item(5, cont).Value = "" Or DataGridView1.Item(5, cont).Value = "DEVOLUCION") Then

                        Bancos = Banco.Text
                        Ref = DataGridView1.Item(0, cont).Value

                        If (Calendario.Value.Date >= Date.Today) Then

                            If DataGridView1.Item(0, cont).Value = "TPV" Then

                                If (Banco.Text <> "110102006" Or Banco.Text <> "110102004") Then

                                    MsgBox("La referencia ""TPV"" solo se puede usar con los bancos Banorte y Scotiabank")

                                Else

                                    Deb = Val(DataGridView1.Item(2, cont).Value)
                                    Cred = Val(DataGridView1.Item(3, cont).Value)
                                    DocNum = DataGridView1.Item(4, cont).Value
                                    CardCode = DataGridView1.Item(5, cont).Value

                                    oCuenta = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBankPages)

                                    oCuenta.AccountCode = Banco.Text
                                    oCuenta.DueDate = Calendario.Value.Date.ToString
                                    oCuenta.Reference = Ref
                                    oCuenta.Memo = DataGridView1.Item(1, cont).Value
                                    oCuenta.DebitAmount = Deb
                                    oCuenta.CreditAmount = Cred
                                    oCuenta.InvoiceNumberEx = DocNum
                                    oCuenta.CardCode = CardCode
                                    oCuenta.Add()


                                    ActualizarStatus(CreatePayment(Ref, Cred, Deb, DocNum, CardCode), Deb, Cred)


                                    Ref = Nothing
                                    Deb = Nothing
                                    Cred = Nothing
                                    DocNum = Nothing
                                    CardCode = Nothing


                                End If

                            Else

                                Deb = Val(DataGridView1.Item(2, cont).Value)
                                Cred = Val(DataGridView1.Item(3, cont).Value)
                                DocNum = DataGridView1.Item(4, cont).Value
                                CardCode = DataGridView1.Item(5, cont).Value

                                oCuenta = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBankPages)

                                oCuenta.AccountCode = Banco.Text
                                oCuenta.DueDate = Calendario.Value.Date.ToString
                                oCuenta.Reference = Ref
                                oCuenta.Memo = DataGridView1.Item(1, cont).Value
                                oCuenta.DebitAmount = Deb
                                oCuenta.CreditAmount = Cred
                                oCuenta.InvoiceNumberEx = DocNum
                                oCuenta.CardCode = CardCode
                                oCuenta.Add()


                                ActualizarStatus(CreatePayment(Ref, Cred, Deb, DocNum, CardCode), Deb, Cred)


                                Ref = Nothing
                                Deb = Nothing
                                Cred = Nothing
                                DocNum = Nothing
                                CardCode = Nothing

                            End If

                        ElseIf (Calendario.Value.Date < Date.Today) Then

                            If (Ref = "DCH" Or Ref = "DCH_SBC" Or Ref = "DCH_SBC_OK") And (Bancos = "110102001" Or Bancos = "110102004" Or Bancos = "110102007" Or Bancos = "110102010") Then

                                Deb = Val(DataGridView1.Item(2, cont).Value)
                                Cred = Val(DataGridView1.Item(3, cont).Value)
                                DocNum = DataGridView1.Item(4, cont).Value
                                CardCode = DataGridView1.Item(5, cont).Value

                                oCuenta = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBankPages)

                                oCuenta.AccountCode = Banco.Text
                                oCuenta.DueDate = Calendario.Value.Date.ToString
                                oCuenta.Reference = Ref
                                oCuenta.Memo = DataGridView1.Item(1, cont).Value
                                oCuenta.DebitAmount = Deb
                                oCuenta.CreditAmount = Cred
                                oCuenta.InvoiceNumberEx = DocNum
                                oCuenta.CardCode = CardCode
                                oCuenta.Add()


                                ActualizarStatus(CreatePayment(Ref, Cred, Deb, DocNum, CardCode), Deb, Cred)


                                Ref = Nothing
                                Deb = Nothing
                                Cred = Nothing
                                DocNum = Nothing
                                CardCode = Nothing

                            Else

                                MsgBox("No se pueden agregar cuentas con fechas anteriores a la de hoy.")

                            End If

                        End If

                    Else

                        MsgBox("Solo se pueden agregar cuentas sin asignar un socio de negocios.")

                    End If

                End If

            Next

            LlenarGrid(Banco.Text, Fecha)

        Else

            MsgBox("Asigna un banco por favor.")

        End If

    End Sub


    Public Function CreatePayment(ByVal Ref As String, ByVal Cred As Double, ByVal Deb As Double, ByVal DocNum As String, ByVal CardCode As String)

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx6 As SAPbobsCOM.Recordset
        Dim stQuerytx6 As String
        Dim oPago As SAPbobsCOM.Payments
        Dim Fecha, Sequence As String

        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day

        oRecSettx6 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx6 = "SELECT ""Sequence"" FROM ""OBNK"" WHERE ""AcctCode""='" & Banco.Text & "' AND ""DueDate""='" & Fecha & "' AND ""Ref""='" & Ref & "' AND ""DebAmount""=" & Deb & " AND ""CredAmnt""=" & Cred & " AND ""DocNum""='" & DocNum & "' AND ifnull(""CardCode"",'')='" & CardCode & "'"
        oRecSettx6.DoQuery(stQuerytx6)

        Sequence = oRecSettx6.Fields.Item("Sequence").Value.ToString

        If (Cred > 0 And Deb = 0 And ExistePago(Sequence) = False) Then

            oPago = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oIncomingPayments)

            oPago.AccountPayments.AccountCode = "210201001"
            oPago.AccountPayments.ProfitCenter = "001"
            oPago.TransferAccount = Banco.Text
            oPago.TransferSum = Cred
            oPago.AccountPayments.SumPaid = Cred
            oPago.ProjectCode = "001"
            oPago.DocType = SAPbobsCOM.BoRcptTypes.rAccount
            oPago.DocDate = Fecha
            oPago.TransferReference = "ECE-" + Sequence

            oPago.Add()

        ElseIf (Cred = 0 And Deb > 0 And ExistePago(Sequence) = False) Then

            oPago = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oVendorPayments)

            If Ref = "SS" Then

                oPago.TransferAccount = "110102005"

            ElseIf Ref = "COMISIONES" Then

                oPago.TransferAccount = "611501001"

            ElseIf Ref = "IVA" Then

                oPago.TransferAccount = "111002003"

            Else

                oPago.TransferAccount = "210201001"

            End If

            oPago.AccountPayments.AccountCode = Banco.Text
            oPago.TransferSum = Deb
            oPago.AccountPayments.SumPaid = Deb
            oPago.ProjectCode = "001"
            oPago.DocType = SAPbobsCOM.BoRcptTypes.rAccount
            oPago.DocDate = Fecha
            oPago.TransferReference = "ECE-" + Sequence

            oPago.Add()

        End If

        oRecSettx6 = Nothing
        Return Sequence

    End Function


    Public Function ExistePago(ByVal Sequence As String)

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx5 As SAPbobsCOM.Recordset
        Dim stQuerytx5 As String
        Dim result As Boolean = False

        oRecSettx5 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx5 = "SELECT COUNT('A') FROM ORCT WHERE ""TrsfrAcct"" = '" + Banco.Text + "' AND ""TrsfrRef"" = 'ECE-" + Sequence.TrimEnd() + "'"
        oRecSettx5.DoQuery(stQuerytx5)

        If (oRecSettx5.RecordCount > 0) Then

            oRecSettx5.MoveFirst()

            If (Convert.ToInt32(oRecSettx5.Fields.Item(0).Value) > 0) Then
                result = True
            End If

        End If

        oRecSettx5 = Nothing
        Return result

    End Function


    Public Sub ActualizarStatus(ByVal Sequence As String, ByVal Deb As Double, ByVal Cred As Double)

        SBOCompany = Form1.SBOCompany

        Dim oCuenta As SAPbobsCOM.BankPages

        oCuenta = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBankPages)
        oCuenta.GetByKey(Banco.Text, Sequence)

        If Cred > 0 And Deb = 0 Then

            oCuenta.UserFields.Fields.Item("U_CSM_ESTATUS").Value = "R"

        ElseIf Deb > 0 And Cred = 0 Then

            oCuenta.UserFields.Fields.Item("U_CSM_ESTATUS").Value = "E"

        End If

        oCuenta.Update()

    End Sub


    Private Sub Actualizar_Click(sender As Object, e As EventArgs) Handles Actualizar.Click

        SBOCompany = Form1.SBOCompany

        Dim oCuenta As SAPbobsCOM.BankPages
        Dim Deb As Double
        Dim Cred As Double
        Dim resultado As String
        Dim Fecha, Ref, DocNum, CardCode, CardName As String
        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day


        For cont As Integer = 0 To TotalLine

            If DataGridView1.Item(7, cont).Value <> "Yes" And DataGridView1.Item(0, cont).Value <> "" Then

                If (DataGridView1.Item(5, cont).Value = "" Or DataGridView1.Item(5, cont).Value = "DEVOLUCION") Then

                    If DataGridView1.Item(0, cont).Value = "TPV" And (Banco.Text <> "110102006" Or Banco.Text <> "110102004") Then

                        MsgBox("La referencia ""TPV"" solo se puede usar con los bancos Banorte y Scotiabank")

                    Else

                        Ref = DataGridView1.Item(0, cont).Value
                        Deb = Val(DataGridView1.Item(2, cont).Value)
                        Cred = Val(DataGridView1.Item(3, cont).Value)
                        DocNum = DataGridView1.Item(4, cont).Value
                        CardCode = DataGridView1.Item(5, cont).Value
                        CardName = DataGridView1.Item(6, cont).Value

                        If Buscar(Ref, Deb, Cred, DocNum, CardCode) <> Nothing Then

                            resultado = MsgBox("¿Deseas actualizar la cuenta con los valores asignados?", vbOKCancel, "Confirmar")

                            If resultado = vbOK Then

                                oCuenta = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oBankPages)

                                oCuenta.GetByKey(Banco.Text, Sequence)
                                oCuenta.CardCode = CardCode
                                oCuenta.CardName = CardName
                                oCuenta.Update()

                                CardCode = Nothing
                                CardName = Nothing

                            End If

                        Else

                            MsgBox("No se encontro ninguna cuenta con los datos proporcionados.")

                        End If


                    End If

                Else

                    MsgBox("Solo se pueden actualizar cuentas sin asignar un socio de negocios.")

                End If

            End If

        Next

        LlenarGrid(Banco.Text, Fecha)

        Dim oRecSettxb As SAPbobsCOM.Recordset
        Dim stQuerytxb As String

        oRecSettxb = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytxb = "Select ""AcctCode"",""AcctName"",""DueDate"",""Ref"",""Memo"",""DebAmount"",""CredAmnt"",""CardCode"" from ""OBNK"" where ""Ref""='DCH_SBC' and ifnull(""CardCode"",'')='' order by ""DueDate"",""Sequence"""
        oRecSettxb.DoQuery(stQuerytxb)

        If oRecSettxb.RecordCount > 0 Then

            MsgBox("Hasta el dia de hoy se tienen pendientes estos SALVO BUEN COBROS")
            SBC.Close()
            SBC.Show()

        Else

            SBC.Close()

        End If

    End Sub


    Public Function Buscar(ByVal Ref As String, ByVal Deb As Double, ByVal Cred As Double, ByVal DocNum As String, ByVal CardCode As String)

        SBOCompany = Form1.SBOCompany

        Dim oRecSettx4 As SAPbobsCOM.Recordset
        Dim stQuerytx4 As String
        Dim result As Boolean = False
        Dim Fecha As String
        Fecha = Calendario.Value.Date.Year & "-" & Calendario.Value.Date.Month & "-" & Calendario.Value.Date.Day

        oRecSettx4 = SBOCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        stQuerytx4 = "SELECT ""Sequence"" FROM ""OBNK"" WHERE ""AcctCode""='" & Banco.Text & "' AND ""DueDate""='" & Fecha & "' AND ""Ref""='" & Ref & "' AND ""DebAmount""=" & Deb & " AND ""CredAmnt""=" & Cred & " AND ""DocNum""='" & DocNum & "'" 'AND ifnull(""CardCode"",'')='" & CardCode & "'"
        oRecSettx4.DoQuery(stQuerytx4)

        If oRecSettx4.RecordCount > 0 Then

            Sequence = oRecSettx4.Fields.Item("Sequence").Value

        End If

        oRecSettx4 = Nothing
        Return Sequence

    End Function


    Private Sub Form2_FormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed

        Me.Hide()
        Desicion.Show()

    End Sub


End Class