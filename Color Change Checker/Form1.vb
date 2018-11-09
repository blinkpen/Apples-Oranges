

Imports System.Text

Public Class Form1
    Dim pixelIndex As Integer = -1
    Dim pixelIndex2 As Integer = -1
    Dim COMPARE As Boolean
    Dim T3 As Integer = 0
    Dim screengit As Integer = 12
    Dim IM1MOVE As Integer = 1
    Dim IM2MOVE As Integer = 1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Left = PictureBox2.Left
        Form2.Top = Panel1.Top
        Form2.Show()
        Form3.Show()
        Form2.Panel1.Width = TextBox1.Text
        Form2.Panel1.Height = TextBox2.Text
        Form3.Panel1.Width = TextBox1.Text
        Form3.Panel1.Height = TextBox2.Text
        AdjustWindows()
        Form2.BringToFront()
        Form3.BringToFront()
        PictureBox3.Left = Panel1.Left
        PictureBox4.Left = Panel2.Left

    End Sub

    Private Sub AdjustWindows()
        Form2.Width = Form2.Panel1.Width + 24
        Form2.Height = Form2.Panel1.Height + 24
        Form3.Width = Form3.Panel1.Width + 24
        Form3.Height = Form3.Panel1.Height + 24
        Panel1.Width = TextBox1.Text
        Panel1.Height = TextBox2.Text
        Panel2.Width = TextBox1.Text
        Panel2.Height = TextBox2.Text
        Panel2.Left = Panel1.Left + Panel1.Width + 7
        PictureBox3.Width = Panel1.Width
        PictureBox4.Width = Panel2.Width
        If Panel2.Width <= 20 Then
            Panel2.Left = 184
            PictureBox4.Left = Panel2.Left
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Panel1.Width = TextBox1.Text
        Form2.Panel1.Height = TextBox2.Text
        Form3.Panel1.Width = TextBox1.Text
        Form3.Panel1.Height = TextBox2.Text
        AdjustWindows()
        Form2.BringToFront()
        Form3.BringToFront()
        PictureBox3.Left = Panel1.Left
        PictureBox4.Left = Panel2.Left

        screengit = TextBox5.Text
        Form2.Panel1.Left = TextBox5.Text
        Form2.Panel1.Top = TextBox5.Text
        Form2.Width = screengit * 2 + Form2.Panel1.Width
        Form2.Height = screengit * 2 + Form2.Panel1.Height

        Form3.Panel1.Left = TextBox5.Text
        Form3.Panel1.Top = TextBox5.Text
        Form3.Width = screengit * 2 + Form3.Panel1.Width
        Form3.Height = screengit * 2 + Form3.Panel1.Height
    End Sub

    Private Sub GetScreen1()
        Dim pic As Bitmap = New Bitmap(Form2.Panel1.Width, Form2.Panel1.Height)
        Dim gfx As Graphics = Graphics.FromImage(pic)
        gfx.CopyFromScreen(New Point(Form2.Location.X + screengit, Form2.Location.Y + screengit), New Point(0, 0), pic.Size)
        Panel1.BackgroundImage = pic
        gfx.Dispose()
    End Sub

    Private Sub GetScreen2()
        Dim pic As Bitmap = New Bitmap(Form3.Panel1.Width, Form3.Panel1.Height)
        Dim gfx As Graphics = Graphics.FromImage(pic)
        gfx.CopyFromScreen(New Point(Form3.Location.X + screengit, Form3.Location.Y + screengit), New Point(0, 0), pic.Size)
        Panel2.BackgroundImage = pic
        gfx.Dispose()
    End Sub

    Private Sub GenPixels()
        Dim image1 As New Bitmap(Panel1.BackgroundImage)
        Dim image2 As New Bitmap(Panel2.BackgroundImage)
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()


        'For i = 1 To Math.Min(Panel1.Width, Panel1.Height)
        '    Dim curPixColor As Color = image1.GetPixel(i - 1, i - 1)
        '    ListBox1.Items.Add(curPixColor.ToArgb)
        'Next

        'For i = 1 To Math.Min(Panel2.Width, Panel2.Height)
        '    Dim curPixColor2 As Color = image2.GetPixel(i - 1, i - 1)
        '    ListBox2.Items.Add(curPixColor2.ToArgb)
        'Next


        'For i = 1 To image1.Width * image1.Height
        '    Dim x = i / image1.Width
        '    Dim y = i / image1.Width
        '    'ListBox1.Items.Add(x)
        '    Dim curPixColor As Color = image1.GetPixel(x, y)
        '    ListBox1.Items.Add(curPixColor.ToArgb)
        'Next

        'For i = 1 To (image1.Width * image1.Height)
        '    Dim x As Integer = i Mod image1.Width
        '    Dim y As Integer = i
        '    'ListBox1.Items.Add(x & ", " & y)
        '    'TextBox6.Text = TextBox6.Text & x & ", " & y & vbNewLine

        '    Dim curPixColor As Color = image1.GetPixel(x, y)
        '    ListBox1.Items.Add(curPixColor.ToArgb)
        'Next

        For x = 1 To Panel1.Width
            For y = 1 To Panel1.Height
                Dim curPixColor As Color = image1.GetPixel(x - 1, y - 1)
                ListBox1.Items.Add(curPixColor.ToArgb)
            Next
        Next

        For x = 1 To Panel2.Width
            For y = 1 To Panel2.Height
                Dim curPixColor2 As Color = image2.GetPixel(x - 1, y - 1)
                ListBox2.Items.Add(curPixColor2.ToArgb)
            Next
        Next



        Label5.Text = ListBox1.Items.Count & " pixels generated"
        Label6.Text = ListBox2.Items.Count & " pixels generated"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetScreen1()
        GetScreen2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenPixels()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then
        Else
            PictureBox1.BackColor = Color.FromArgb(ListBox1.SelectedItem.ToString)
            TextBox3.Text = PictureBox1.BackColor.ToString
            Label7.Text = "Selected Index: " & ListBox1.SelectedIndex
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex = -1 Then
        Else
            PictureBox2.BackColor = Color.FromArgb(ListBox2.SelectedItem.ToString)
            TextBox4.Text = PictureBox2.BackColor.ToString
            Label8.Text = "Selected Index: " & ListBox2.SelectedIndex
        End If
    End Sub

    Private Function Loopy()
        timer3.start
        Label9.Text = "Identical"
        Label9.ForeColor = Color.Green
        LinkLabel1.Visible = False
        Dim COMPARE = True
        pixelIndex = -1
        pixelIndex2 = -1
        For i = 0 To Math.Min(ListBox1.Items.Count, ListBox2.Items.Count) - 1
            If Not ListBox1.Items(i) = ListBox2.Items(i) Then
                COMPARE = False
                Label9.Text = "Different"
                Label9.ForeColor = Color.Red
                LinkLabel1.Visible = True
                pixelIndex = ListBox1.Items.IndexOf(ListBox1.Items(i))
                pixelIndex2 = ListBox2.Items.IndexOf(ListBox2.Items(i))
                Exit For
            End If
        Next
        Return 0
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Loopy()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ListBox1.SelectedIndex = -1
        ListBox2.SelectedIndex = -1
        Dim winningPixelIndex As Integer
        If pixelIndex > pixelIndex2 Then
            winningPixelIndex = pixelIndex
        Else
            winningPixelIndex = pixelIndex2
        End If
        ListBox1.SelectedIndex = winningPixelIndex
        ListBox2.SelectedIndex = winningPixelIndex
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Timer2.Start()
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox5.Enabled = False
            Button1.Enabled = False
        Else
            Timer2.Stop()
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox5.Enabled = True
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        GenPixels()
        Loopy()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Form2.Hide()
            Form3.Hide()
        Else
            Form2.Show()
            Form3.Show()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Timer2.Enabled = True Then
        Else
            T3 = T3 + 1
            Label9.Visible = False
            If T3 = 5 Then
                Label9.Visible = True
                Timer3.Stop()
                T3 = 0
            End If
        End If

    End Sub


    Private Sub CheckBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckBox1.MouseClick
        If CheckBox1.Checked = False Then
        Else
            If Panel1.Width > 50 Or Panel1.Height > 50 Then
                CheckBox1.Checked = False
                Dim result As Integer = MessageBox.Show("It is not recommended to run this for images exceeding widths and/or heights of 50 pixels. Do you wish to run this operation anyway?", "Warning", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then

                ElseIf result = DialogResult.Yes Then
                    CheckBox1.Checked = True
                End If
                'MsgBox("It is not recommended to run this for images exceeding widths and/or heights of 50 pixels." & vbNewLine & "This process has been aborted.")
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Top = Form2.Top - IM1MOVE
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Top = Form2.Top + IM1MOVE
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form2.Left = Form2.Left - IM1MOVE
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form2.Left = Form2.Left + IM1MOVE
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form3.Top = Form3.Top - IM2MOVE
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form3.Top = Form3.Top + IM2MOVE
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form3.Left = Form3.Left - IM2MOVE
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form3.Left = Form3.Left + IM2MOVE
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        IM1MOVE = NumericUpDown1.Value
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        IM2MOVE = NumericUpDown2.Value
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
End Class
