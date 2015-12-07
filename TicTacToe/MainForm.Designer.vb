<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.MainFormMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainFormPanel = New System.Windows.Forms.Panel()
        Me.MainFormMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainFormMenuStrip
        '
        Me.MainFormMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MainFormMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MainFormMenuStrip.Name = "MainFormMenuStrip"
        Me.MainFormMenuStrip.Size = New System.Drawing.Size(340, 24)
        Me.MainFormMenuStrip.TabIndex = 0
        Me.MainFormMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameMenuItem, Me.OptionsMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewGameMenuItem
        '
        Me.NewGameMenuItem.Name = "NewGameMenuItem"
        Me.NewGameMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.NewGameMenuItem.Text = "Start New Game"
        '
        'OptionsMenuItem
        '
        Me.OptionsMenuItem.Name = "OptionsMenuItem"
        Me.OptionsMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.OptionsMenuItem.Text = "Options..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutMenuItem
        '
        Me.AboutMenuItem.Name = "AboutMenuItem"
        Me.AboutMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutMenuItem.Text = "About Tic Tac Toe..."
        '
        'MainFormPanel
        '
        Me.MainFormPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MainFormPanel.Location = New System.Drawing.Point(0, 27)
        Me.MainFormPanel.Name = "MainFormPanel"
        Me.MainFormPanel.Size = New System.Drawing.Size(340, 340)
        Me.MainFormPanel.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(340, 367)
        Me.Controls.Add(Me.MainFormPanel)
        Me.Controls.Add(Me.MainFormMenuStrip)
        Me.MainMenuStrip = Me.MainFormMenuStrip
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Tic Tac Toe"
        Me.MainFormMenuStrip.ResumeLayout(False)
        Me.MainFormMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainFormMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainFormPanel As System.Windows.Forms.Panel

End Class
