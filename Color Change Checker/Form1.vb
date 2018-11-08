

Imports System.Text

Public Class Form1
    Dim pixelIndex As Integer = -1
    Dim pixelIndex2 As Integer = -1
    Dim COMPARE As Boolean
    Dim T3 As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Left = Panel1.Left
        Form2.Top = Panel1.Top
        Form2.Show()
        Form3.Show()
        Form2.Panel1.Width = TextBox1.Text
        Form2.Panel1.Height = TextBox2.Text
        Form3.Panel1.Width = TextBox1.Text
        Form3.Panel1.Height = TextBox2.Text
        AdjustWindows()
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Panel1.Width = TextBox1.Text
        Form2.Panel1.Height = TextBox2.Text
        Form3.Panel1.Width = TextBox1.Text
        Form3.Panel1.Height = TextBox2.Text
        AdjustWindows()
        Form2.BringToFront()
        Form3.BringToFront()
    End Sub

    Private Sub GetScreen1()
        Dim pic As Bitmap = New Bitmap(Form2.Panel1.Width, Form2.Panel1.Height)
        Dim gfx As Graphics = Graphics.FromImage(pic)
        gfx.CopyFromScreen(New Point(Form2.Location.X + 12, Form2.Location.Y + 12), New Point(0, 0), pic.Size)
        Panel1.BackgroundImage = pic
    End Sub

    Private Sub GetScreen2()
        Dim pic As Bitmap = New Bitmap(Form3.Panel1.Width, Form3.Panel1.Height)
        Dim gfx As Graphics = Graphics.FromImage(pic)
        gfx.CopyFromScreen(New Point(Form3.Location.X + 12, Form3.Location.Y + 12), New Point(0, 0), pic.Size)
        Panel2.BackgroundImage = pic
    End Sub

    Private Sub GenPixels()
        Dim image1 As New Bitmap(Panel1.BackgroundImage)
        Dim image2 As New Bitmap(Panel2.BackgroundImage)
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        For x = 1 To Panel1.Width
            For y = 1 To Panel1.Height
                Dim curPixColor As Color = image1.GetPixel(x - 1, y - 1)
                'Dim pixel1A As String = curPixColor.ToArgb
                'Dim pixel1B As String = pixel1A.Replace("-", "")
                'Dim pixel1C As Integer = pixel1B
                ListBox1.Items.Add(curPixColor.ToArgb)
            Next
        Next

        For x = 1 To Panel2.Width
            For y = 1 To Panel2.Height
                Dim curPixColor2 As Color = image2.GetPixel(x - 1, y - 1)
                'Dim pixel2A As String = curPixColor2.ToArgb
                'Dim pixel2B As String = pixel2A.Replace("-", "")
                'Dim pixel2C As Integer = pixel2B
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
        Else
            Timer2.Stop()
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
End Class
