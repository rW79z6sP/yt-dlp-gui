Imports System.Net

Public Class tos
    Private Function CalculateHash(text As String) As String
        Dim sha256 As New System.Security.Cryptography.SHA256Managed()
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(text)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Return Convert.ToBase64String(hash)
    End Function

    Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\yt-dlp-gui")

    Private Function GetTos()
        Try
            Dim url As String = "https://raw.githubusercontent.com/rW79z6sP/yt-dlp-gui/refs/heads/master/tos.txt"
            Dim webClient As New System.Net.WebClient()
            Dim currentTermsOfService As String = webClient.DownloadString(url)
            currentTermsOfService = currentTermsOfService.Replace(vbCrLf, vbLf).Replace(vbLf, vbCrLf)


            TextBox1.Text = currentTermsOfService
        Catch ex As System.Net.WebException
            Select Case ex.Status
                Case WebExceptionStatus.NameResolutionFailure
                    Dim result As DialogResult = MessageBox.Show("ホスト名が解決できませんでした。", "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                    If result = DialogResult.Cancel Then
                        ConfirmDisagree()
                    ElseIf result = DialogResult.Retry Then
                        GetTos()
                    End If
                Case WebExceptionStatus.ConnectFailure
                    Dim result As DialogResult = MessageBox.Show("サーバーに接続できませんでした。", "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                    If result = DialogResult.Cancel Then
                        ConfirmDisagree()
                    ElseIf result = DialogResult.Retry Then
                        GetTos()
                    End If
                Case WebExceptionStatus.Timeout
                    Dim result As DialogResult = MessageBox.Show("接続がタイムアウトしました。", "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                    If result = DialogResult.Cancel Then
                        ConfirmDisagree()
                    ElseIf result = DialogResult.Retry Then
                        GetTos()
                    End If
                Case Else
                    MessageBox.Show("Webエラーが発生しました。
エラーコード: " & ex.Message, "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            End Select
        Catch ex As Exception
            MessageBox.Show("エラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function ConfirmDisagree()
        Dim result As DialogResult = MessageBox.Show("利用規約に同意いただけない場合、本ソフトウェアをご利用いただけません。
終了してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            key.SetValue("TermsOfServiceAgreed", "DisAgreed")
            base.Close()
        End If
    End Function

    Private Sub tos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTos()
    End Sub

    Private Sub tos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If DialogResult = DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
            ConfirmDisagree()
        End If
    End Sub

    Private Sub Disagree_Click(sender As Object, e As EventArgs) Handles Disagree.Click
        ConfirmDisagree()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Agree.Enabled = True
        Else
            Agree.Enabled = False
        End If
    End Sub

    Private Sub Agree_Click(sender As Object, e As EventArgs) Handles Agree.Click
        If CheckBox1.Checked Then
            Dim result As DialogResult = MessageBox.Show("続行した場合、先ほどの利用規約に同意したものとして見なされます。
同意してもよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result = DialogResult.Yes Then
                key.SetValue("TermsOfServiceAgreed", "Agreed")
                key.SetValue("TermsOfServiceHash", CalculateHash(TextBox1.Text))
                main.Show()
                Me.DialogResult = DialogResult.Yes
                Close()
            End If
        Else
            MessageBox.Show("先に利用規約をご確認ください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class