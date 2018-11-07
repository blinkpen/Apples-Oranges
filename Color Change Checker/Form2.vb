Public Class Form2
    Dim xpos As New Integer
    Dim ypos As New Integer
    Dim pos As New Point

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        xpos = Cursor.Position.X - Me.Location.X
        ypos = Cursor.Position.Y - Me.Location.Y
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            pos = MousePosition
            pos.X = pos.X - xpos
            pos.Y = pos.Y - ypos
            Me.Location = pos
        End If
    End Sub

    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Up Then
            Me.Top = Me.Top - 1
        ElseIf e.KeyCode = Keys.Down Then
            Me.Top = Me.Top + 1
        ElseIf e.KeyCode = Keys.Right Then
            Me.Left = Me.Left + 1
        ElseIf e.KeyCode = Keys.Left Then
            Me.Left = Me.Left - 1
        End If
    End Sub
End Class