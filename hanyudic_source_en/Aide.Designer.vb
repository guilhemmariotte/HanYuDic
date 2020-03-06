<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Aide
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Aide))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListTexteIntro = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'ListTexteIntro
        '
        Me.ListTexteIntro.BackColor = System.Drawing.SystemColors.Control
        Me.ListTexteIntro.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListTexteIntro.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListTexteIntro.ForeColor = System.Drawing.SystemColors.InfoText
        Me.ListTexteIntro.Location = New System.Drawing.Point(12, 12)
        Me.ListTexteIntro.Name = "ListTexteIntro"
        Me.ListTexteIntro.ReadOnly = True
        Me.ListTexteIntro.Size = New System.Drawing.Size(438, 491)
        Me.ListTexteIntro.TabIndex = 3
        Me.ListTexteIntro.Text = resources.GetString("ListTexteIntro.Text")
        '
        'Aide
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 511)
        Me.Controls.Add(Me.ListTexteIntro)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Aide"
        Me.ShowInTaskbar = False
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListTexteIntro As System.Windows.Forms.RichTextBox
End Class
