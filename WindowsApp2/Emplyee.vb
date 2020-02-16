
Public Class Emplyee
    Dim reference As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Dim FillBy As String = emptxt.Text
        Try
            Me.EmployeeTableAdapter.FillBy(Me.CCEMPLOYEEDataSet.Employee, FillBy)
        Catch a As InvalidCastException
            MessageBox.Show("Enter an employee ID!!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            emptxt.Text = "Employee ID#"
            TextBox2.Text = "Last Name"
            TextBox3.Text = "First Name"
            TextBox4.Text = "M.I."
        End Try
        If TextBox2.Text = "" Then
            MessageBox.Show("Employee ID not found!!", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            emptxt.Text = "Employee ID#"
            TextBox2.Text = "Last Name"
            TextBox3.Text = "First Name"
            TextBox4.Text = "M.I."
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        btn3.Enabled = True
        reference = emptxt.Text
line1:

        reference = Convert.ToInt32(reference)
        reference = reference + 1
        If reference > 90000 Then
            MessageBox.Show("Last employee ID reached. " + Environment.NewLine + "No next Employee. ", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn4.Enabled = False
            reference = 90000
        End If
        reference = Convert.ToString(reference)
        Me.EmployeeTableAdapter.FillBy(Me.CCEMPLOYEEDataSet.Employee, reference)
        If TextBox2.Text = "" Then
            GoTo line1
        End If
        BindingNavigatorMoveNextItem.PerformClick()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        btn4.Enabled = True
        reference = emptxt.Text
line2:

        reference = Convert.ToInt32(reference)
        reference = reference - 1
        If reference < 3 Then
            MessageBox.Show("First employee ID reached. " + Environment.NewLine + "No previous Employee. ", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btn3.Enabled = False
            reference = 3
        End If
        reference = Convert.ToString(reference)
        Me.EmployeeTableAdapter.FillBy(Me.CCEMPLOYEEDataSet.Employee, reference)
        If TextBox2.Text = "" Then
            GoTo line2
        End If
        BindingNavigatorMoveNextItem.PerformClick()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class
