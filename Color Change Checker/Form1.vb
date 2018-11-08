

Imports System.Text

Public Class Form1
    Dim pixelIndex As Integer = -1
    Dim pixelIndex2 As Integer = -1
    Dim LoopString1 As String
    Dim LoopString2 As String
    Dim COMPARE As Boolean
    Dim bmpNew As Bitmap = Nothing


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
        'Dim painting As New Bitmap(20, 20)
        'Dim painting2 As New Bitmap(20, 20)

        For x = 1 To Panel1.Width
            For y = 1 To Panel1.Height
                Dim curPixColor As Color = image1.GetPixel(x - 1, y - 1)
                Dim pixel1A As String = curPixColor.ToArgb
                Dim pixel1B As String = pixel1A.Replace("-", "")
                Dim pixel1C As Integer = pixel1B
                ListBox1.Items.Add(pixel1C)

                'Dim curPixColor3 As Color = image1.GetPixel(x - 1, y - 1)

                'painting.SetPixel(x - 1, y - 1, curPixColor3)
                'PictureBox3.BackgroundImage = painting

            Next
        Next

        For x = 1 To Panel2.Width
            For y = 1 To Panel2.Height
                Dim curPixColor2 As Color = image2.GetPixel(x - 1, y - 1)
                Dim pixel2A As String = curPixColor2.ToArgb
                Dim pixel2B As String = pixel2A.Replace("-", "")
                Dim pixel2C As Integer = pixel2B
                ListBox2.Items.Add(pixel2C)

                'Dim curPixColor4 As Color = image2.GetPixel(x - 1, y - 1)

                'painting2.SetPixel(x - 1, y - 1, curPixColor4)
                'PictureBox4.BackgroundImage = painting2
            Next
        Next

        Label5.Text = ListBox1.Items.Count & " pixels generated"
        Label6.Text = ListBox2.Items.Count & " pixels generated"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetScreen1()
        GetScreen2()
        'PictureBox3.BackgroundImage = Panel1.BackgroundImage
        'PictureBox4.BackgroundImage = Panel2.BackgroundImage


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GenPixels()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        PictureBox1.BackColor = Color.FromArgb(ListBox1.SelectedItem.ToString)
        TextBox3.Text = PictureBox1.BackColor.ToString
        Label7.Text = "Selected Index: " & ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        PictureBox2.BackColor = Color.FromArgb(ListBox2.SelectedItem.ToString)
        TextBox4.Text = PictureBox2.BackColor.ToString
        Label8.Text = "Selected Index: " & ListBox2.SelectedIndex
    End Sub
#Region "Dead Loops"
    Private Function Loop1()
        For i = 0 To ListBox1.Items.Count - 1
            pixelIndex = i
            MsgBox("1: " & pixelIndex)
            Loop2()
        Next

        'For Each item In ListBox1.Items
        '    'If COMPARE = False Then Exit For
        '    pixelIndex = ListBox1.Items.IndexOf(item)

        '    MsgBox("1: " & pixelIndex)

        '    LoopString1 = item
        '    Loop2()

        'Next
    End Function

    Private Function Loop2()
        For i = 0 To ListBox2.Items.Count - 1
            pixelIndex2 = i
            MsgBox("2: " & pixelIndex2)
            CompareLoops()
        Next

        'For Each item In ListBox2.Items
        '    'If COMPARE = False Then Exit For
        '    pixelIndex2 = ListBox2.Items.IndexOf(item)


        '    MsgBox("2: " & pixelIndex2)

        '    LoopString2 = item
        '    CompareLoops()

        'Next
    End Function


    Private Function CompareLoops()
        If pixelIndex = pixelIndex2 Then

            If LoopString1 = LoopString2 Then
                COMPARE = True
                Label9.Text = "Identical"
                Label9.ForeColor = Color.Green
                LinkLabel1.Visible = False
            Else
                COMPARE = False
                Label9.Text = "Different"
                Label9.ForeColor = Color.Red
                LinkLabel1.Visible = True
                'MsgBox(pixelIndex & vbNewLine & pixelIndex2)
            End If
        Else

            'ListBox3.Items.Add(COMPARE & vbNewLine & pixelIndex & " " & LoopString1 & vbNewLine & pixelIndex2 & " " & LoopString2)
        End If


        'MsgBox(COMPARE & vbNewLine & LoopString1 & vbNewLine & LoopString2)
    End Function
#End Region

    Private Function Loopy()

        For i = 0 To Math.Min(ListBox1.Items.Count, ListBox2.Items.Count) - 1
            'MsgBox(ListBox1.Items(i) & vbNewLine & ListBox2.Items(i))

            If ListBox1.Items(i) = ListBox2.Items(i) Then
                COMPARE = True
                Label9.Text = "Identical"
                Label9.ForeColor = Color.Green
                LinkLabel1.Visible = False
            Else
                COMPARE = False
                Label9.Text = "Different"
                Label9.ForeColor = Color.Red
                LinkLabel1.Visible = True
                pixelIndex = ListBox1.Items.IndexOf(ListBox1.Items(i))
                pixelIndex2 = ListBox2.Items.IndexOf(ListBox2.Items(i))
                Exit For
            End If
        Next


        'Dim s As String
        'Dim builder As New StringBuilder
        'For Each item In ListBox1.Items

        '    builder.Append(item)
        '    s = builder.ToString
        'Next


        'Dim s2 As String
        'Dim builder2 As New StringBuilder
        'For Each item2 In ListBox2.Items

        '    builder2.Append(item2)
        '    s2 = builder2.ToString
        'Next

        'If s = s2 Then
        '    COMPARE = True
        '    Label9.Text = "Identical"
        '    Label9.ForeColor = Color.Green
        '    LinkLabel1.Visible = False
        'Else
        '    COMPARE = False
        '    Label9.Text = "Different"
        '    Label9.ForeColor = Color.Red
        '    LinkLabel1.Visible = True
        'End If
    End Function



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If COMPARE = False Then
        '    COMPARE = True

        'End If

        Loopy()



        'For Each item1 In ListBox1.Items
        '    For Each item2 In ListBox2.Items
        '        'ListBox3.Items.Add(item1 & " = " & item2)
        '        'Me.Text = ListBox3.Items.Count
        '        If item1 = item2 Then
        '                COMPARE = True
        '                pixelIndex = -1
        '                pixelIndex2 = -1
        '                Label9.Text = "Identical"
        '                Label9.ForeColor = Color.Green
        '                LinkLabel1.Visible = False
        '            Else
        '                pixelIndex = ListBox1.Items.IndexOf(item1)
        '                pixelIndex2 = ListBox2.Items.IndexOf(item2)
        '                COMPARE = False
        '                Label9.Text = "Different"
        '                Label9.ForeColor = Color.Red
        '                LinkLabel1.Visible = True
        '                Exit For

        '            End If


        '    Next

        'Next
        'MsgBox(COMPARE & " Index1: " & pixelIndex & " Index2: " & pixelIndex2)
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

        If COMPARE = False Then
            COMPARE = True

        End If


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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'PictureBox4.BackgroundImage = Panel1.BackgroundImage
        'Using bmp As New Bitmap(PictureBox3.Width, PictureBox3.Height)

        '    Using g As Graphics = Graphics.FromImage(bmp)

        '        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        '        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
        '        g.DrawImage(bmp, New Rectangle(0, 0, PictureBox3.Width, PictureBox3.Height))
        '        PictureBox3.BackgroundImage = bmp
        '    End Using
        'End Using


        Using pic As New Bitmap(Panel1.Width, Panel1.Height)
            'Dim pixeled As New Bitmap(pic, New Size(512, 512))
            bmpNew = New Bitmap(pic, PictureBox3.Width, PictureBox3.Height)



            Using g As Graphics = Graphics.FromImage(bmpNew)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half
                g.DrawImage(pic, 0, 0, PictureBox3.Width, PictureBox3.Height)
                PictureBox3.BackgroundImage = bmpNew
            End Using
        End Using

    End Sub
End Class
