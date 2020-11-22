Public Class Form1

  
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ListBox1.Visible = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        ListBox1.Visible = False
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Try
            Dim test As Boolean = False
            If ListBox1.Items.Count = 0 Then
                test = True
            End If
            OpenFileDialog1 = New OpenFileDialog()
            OpenFileDialog1.Multiselect = True

            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim i As Integer = OpenFileDialog1.SafeFileNames.Count
                For cp As Integer = 0 To i - 1
                    ListBox1.Items.Add(OpenFileDialog1.FileNames(cp))
                Next
                If test = True Then
                    AxWindowsMediaPlayer1.URL = ListBox1.Items(0)
                    ListBox1.SelectedIndex = 0
                    AxWindowsMediaPlayer1.Ctlcontrols.play()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Try
            Dim x As Integer = ListBox1.SelectedIndex
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            AxWindowsMediaPlayer1.URL = ListBox1.Items(x)
            ListBox1.SelectedIndex = x
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        MsgBox(Title:="X_Player", Prompt:="X_Player Created By Mohamed Tarek Guez Guez")
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Try
            If Panel6.Visible = False Then
                Panel6.Visible = True
            Else
                Panel6.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        Try
            AxWindowsMediaPlayer1.URL = ListBox1.Items(ListBox1.SelectedIndex + 1)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            ListBox1.SelectedItem = ListBox1.Items(ListBox1.SelectedIndex + 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        Try
            AxWindowsMediaPlayer1.URL = ListBox1.Items(ListBox1.SelectedIndex - 1)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            ListBox1.SelectedItem = ListBox1.Items(ListBox1.SelectedIndex - 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuSlider1_ValueChanged(sender As Object, e As EventArgs) Handles BunifuSlider1.ValueChanged
        Try
            AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = BunifuSlider1.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuSlider2_ValueChanged(sender As Object, e As EventArgs) Handles BunifuSlider2.ValueChanged
        Try
            AxWindowsMediaPlayer1.settings.volume = BunifuSlider2.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            AxWindowsMediaPlayer1.URL = ListBox1.SelectedItem
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Label8.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
            Label9.Text = AxWindowsMediaPlayer1.currentMedia.durationString
            BunifuSlider1.MaximumValue = AxWindowsMediaPlayer1.currentMedia.duration
            BunifuSlider1.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
            BunifuSlider2.Value = AxWindowsMediaPlayer1.settings.volume
            Label10.Text = AxWindowsMediaPlayer1.settings.volume.ToString
            Label7.Text = AxWindowsMediaPlayer1.currentMedia.name
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            Dim max As Integer = BunifuSlider1.MaximumValue
            If BunifuSlider1.Value = max - 1 Then
                Dim x As Integer = ListBox1.SelectedIndex
                x = x + 1
                ListBox1.SelectedIndex = x
                AxWindowsMediaPlayer1.Ctlcontrols.play()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AxWindowsMediaPlayer1_MouseMoveEvent(sender As Object, e As AxWMPLib._WMPOCXEvents_MouseMoveEvent) Handles AxWindowsMediaPlayer1.MouseMoveEvent
        Panel6.Visible = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.settings.volume = 100
    End Sub

End Class
