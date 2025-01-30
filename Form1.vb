Imports System.Net

Public Class base
    Private Function CalculateHash(text As String) As String
        Dim sha256 As New System.Security.Cryptography.SHA256Managed()
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return Convert.ToBase64String(hash)
    End Function

    Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\yt-dlp-gui")

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H80
            Return cp
        End Get
    End Property

    Private Function CheckTOSState()
        Try
            Dim url As String = "https://raw.githubusercontent.com/rW79z6sP/yt-dlp-gui/refs/heads/master/tos.txt"
            Dim webClient As New System.Net.WebClient()
            Dim currentTermsOfService As String = webClient.DownloadString(url)
            currentTermsOfService = currentTermsOfService.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)
            Dim currentHash As String = CalculateHash(currentTermsOfService)
            Dim storedHash As String = key.GetValue("TermsOfServiceHash")
            If currentHash <> storedHash Then
                Dim result As DialogResult = MessageBox.Show("利用規約が更新されました。
新しい利用規約を確認しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    DialogResult = DialogResult.Yes
                    tos.ShowDialog()
                Else
                    DialogResult = DialogResult.No
                    Close()
                End If
            Else
                DialogResult = DialogResult.Yes
            End If
        Catch ex As System.Net.WebException
            Dim result As DialogResult = MessageBox.Show("ネットワークエラーが発生しました。
もう一度試しますか？", "yt-dlp-gui", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            If result = DialogResult.Cancel Then
                Close()
            ElseIf result = DialogResult.Retry Then
                CheckTOSState()
            End If
        Catch ex As Exception
            Dim result As DialogResult = MessageBox.Show("エラーが発生しました。
" & ex.Message & "
再試行しますか？", "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            If result = DialogResult.Cancel Then
                Close()
            ElseIf result = DialogResult.Retry Then
                CheckTOSState()
            End If
        End Try
    End Function

    Private Sub base_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If key.GetValue("TermsOfServiceAgreed") = "Agreed" Then
            CheckTOSState()
            If DialogResult = DialogResult.Yes Then
                main.Show()
            End If
        Else
            key.SetValue("TermsOfServiceAgreed", "NotAgreed")
            tos.ShowDialog()
        End If
    End Sub

End Class
