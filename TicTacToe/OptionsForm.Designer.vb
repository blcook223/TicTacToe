<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PlayVsHumanRadioButton = New System.Windows.Forms.RadioButton()
        Me.PlayVsCPURadioButton = New System.Windows.Forms.RadioButton()
        Me.PlayAsPlayer1RadioButton = New System.Windows.Forms.RadioButton()
        Me.PlayAsPlayer2RadioButton = New System.Windows.Forms.RadioButton()
        Me.OpponentGroupBox = New System.Windows.Forms.GroupBox()
        Me.PlayerGroupBox = New System.Windows.Forms.GroupBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelOptionsButton = New System.Windows.Forms.Button()
        Me.OpponentGroupBox.SuspendLayout()
        Me.PlayerGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlayVsHumanRadioButton
        '
        Me.PlayVsHumanRadioButton.AutoSize = True
        Me.PlayVsHumanRadioButton.Location = New System.Drawing.Point(18, 19)
        Me.PlayVsHumanRadioButton.Name = "PlayVsHumanRadioButton"
        Me.PlayVsHumanRadioButton.Size = New System.Drawing.Size(117, 17)
        Me.PlayVsHumanRadioButton.TabIndex = 2
        Me.PlayVsHumanRadioButton.TabStop = True
        Me.PlayVsHumanRadioButton.Text = "Play against human"
        Me.PlayVsHumanRadioButton.UseVisualStyleBackColor = True
        '
        'PlayVsCPURadioButton
        '
        Me.PlayVsCPURadioButton.AutoSize = True
        Me.PlayVsCPURadioButton.Location = New System.Drawing.Point(18, 42)
        Me.PlayVsCPURadioButton.Name = "PlayVsCPURadioButton"
        Me.PlayVsCPURadioButton.Size = New System.Drawing.Size(129, 17)
        Me.PlayVsCPURadioButton.TabIndex = 3
        Me.PlayVsCPURadioButton.TabStop = True
        Me.PlayVsCPURadioButton.Text = "Play against computer"
        Me.PlayVsCPURadioButton.UseVisualStyleBackColor = True
        '
        'PlayAsPlayer1RadioButton
        '
        Me.PlayAsPlayer1RadioButton.AutoSize = True
        Me.PlayAsPlayer1RadioButton.Location = New System.Drawing.Point(18, 19)
        Me.PlayAsPlayer1RadioButton.Name = "PlayAsPlayer1RadioButton"
        Me.PlayAsPlayer1RadioButton.Size = New System.Drawing.Size(109, 17)
        Me.PlayAsPlayer1RadioButton.TabIndex = 4
        Me.PlayAsPlayer1RadioButton.TabStop = True
        Me.PlayAsPlayer1RadioButton.Text = "Play as first player"
        Me.PlayAsPlayer1RadioButton.UseVisualStyleBackColor = True
        '
        'PlayAsPlayer2RadioButton
        '
        Me.PlayAsPlayer2RadioButton.AutoSize = True
        Me.PlayAsPlayer2RadioButton.Location = New System.Drawing.Point(18, 42)
        Me.PlayAsPlayer2RadioButton.Name = "PlayAsPlayer2RadioButton"
        Me.PlayAsPlayer2RadioButton.Size = New System.Drawing.Size(128, 17)
        Me.PlayAsPlayer2RadioButton.TabIndex = 5
        Me.PlayAsPlayer2RadioButton.TabStop = True
        Me.PlayAsPlayer2RadioButton.Text = "Play as second player"
        Me.PlayAsPlayer2RadioButton.UseVisualStyleBackColor = True
        '
        'OpponentGroupBox
        '
        Me.OpponentGroupBox.Controls.Add(Me.PlayVsHumanRadioButton)
        Me.OpponentGroupBox.Controls.Add(Me.PlayVsCPURadioButton)
        Me.OpponentGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.OpponentGroupBox.Name = "OpponentGroupBox"
        Me.OpponentGroupBox.Size = New System.Drawing.Size(226, 71)
        Me.OpponentGroupBox.TabIndex = 6
        Me.OpponentGroupBox.TabStop = False
        Me.OpponentGroupBox.Text = "Opponent"
        '
        'PlayerGroupBox
        '
        Me.PlayerGroupBox.Controls.Add(Me.PlayAsPlayer1RadioButton)
        Me.PlayerGroupBox.Controls.Add(Me.PlayAsPlayer2RadioButton)
        Me.PlayerGroupBox.Location = New System.Drawing.Point(12, 91)
        Me.PlayerGroupBox.Name = "PlayerGroupBox"
        Me.PlayerGroupBox.Size = New System.Drawing.Size(226, 71)
        Me.PlayerGroupBox.TabIndex = 7
        Me.PlayerGroupBox.TabStop = False
        Me.PlayerGroupBox.Text = "Player"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(13, 169)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(107, 25)
        Me.OKButton.TabIndex = 8
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelOptionsButton
        '
        Me.CancelOptionsButton.Location = New System.Drawing.Point(126, 169)
        Me.CancelOptionsButton.Name = "CancelOptionsButton"
        Me.CancelOptionsButton.Size = New System.Drawing.Size(107, 25)
        Me.CancelOptionsButton.TabIndex = 9
        Me.CancelOptionsButton.Text = "Cancel"
        Me.CancelOptionsButton.UseVisualStyleBackColor = True
        '
        'OptionsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 206)
        Me.Controls.Add(Me.CancelOptionsButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.PlayerGroupBox)
        Me.Controls.Add(Me.OpponentGroupBox)
        Me.Name = "OptionsForm"
        Me.Text = "Tic Tac Toe Options"
        Me.OpponentGroupBox.ResumeLayout(False)
        Me.OpponentGroupBox.PerformLayout()
        Me.PlayerGroupBox.ResumeLayout(False)
        Me.PlayerGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlayVsHumanRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PlayVsCPURadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PlayAsPlayer1RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PlayAsPlayer2RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents OpponentGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents PlayerGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CancelOptionsButton As System.Windows.Forms.Button
End Class
