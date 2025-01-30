<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tos
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TextBox1 = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CheckBox1 = New CheckBox()
        Agree = New Button()
        Disagree = New Button()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Cursor = Cursors.IBeam
        TextBox1.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        TextBox1.Location = New Point(42, 196)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.ScrollBars = ScrollBars.Vertical
        TextBox1.Size = New Size(1290, 513)
        TextBox1.TabIndex = 0
        TextBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 13F)
        Label1.Location = New Point(24, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(119, 36)
        Label1.TabIndex = 1
        Label1.Text = "利用規約"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Yu Gothic UI", 9.5F)
        Label2.Location = New Point(24, 71)
        Label2.Name = "Label2"
        Label2.Size = New Size(627, 25)
        Label2.TabIndex = 2
        Label2.Text = "このソフトウェアをご利用いただく前に、利用規約に同意していただく必要があります。"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(42, 128)
        Label3.Name = "Label3"
        Label3.Size = New Size(718, 50)
        Label3.TabIndex = 3
        Label3.Text = "利用規約を読み、同意する場合は「同意する」を、同意しない場合は「同意しない」を押してください。" & vbCrLf & "なお、利用規約に同意いただけない場合、このソフトウェアをご利用いただけません。"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Cursor = Cursors.Hand
        CheckBox1.FlatStyle = FlatStyle.Flat
        CheckBox1.Location = New Point(42, 760)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(376, 29)
        CheckBox1.TabIndex = 4
        CheckBox1.Text = "利用規約を熟読し、これらの内容に同意します。"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Agree
        ' 
        Agree.Cursor = Cursors.Hand
        Agree.Enabled = False
        Agree.FlatStyle = FlatStyle.Flat
        Agree.Location = New Point(903, 748)
        Agree.Name = "Agree"
        Agree.Size = New Size(206, 52)
        Agree.TabIndex = 5
        Agree.Text = "同意する"
        Agree.UseVisualStyleBackColor = True
        ' 
        ' Disagree
        ' 
        Disagree.Cursor = Cursors.Hand
        Disagree.FlatStyle = FlatStyle.Flat
        Disagree.Location = New Point(1126, 748)
        Disagree.Name = "Disagree"
        Disagree.Size = New Size(206, 52)
        Disagree.TabIndex = 6
        Disagree.Text = "同意しない"
        Disagree.UseVisualStyleBackColor = True
        ' 
        ' tos
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1373, 838)
        Controls.Add(Disagree)
        Controls.Add(Agree)
        Controls.Add(CheckBox1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBox1)
        ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "tos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "利用規約"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Agree As Button
    Friend WithEvents Disagree As Button
End Class
