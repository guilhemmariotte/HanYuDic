<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConvertFichierDico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConvertFichierDico))
        Me.TxtFichier = New System.Windows.Forms.TextBox
        Me.BtnSelectFichier = New System.Windows.Forms.Button
        Me.BtnConversion = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.LblConversion = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtFichier
        '
        Me.TxtFichier.Location = New System.Drawing.Point(12, 50)
        Me.TxtFichier.Name = "TxtFichier"
        Me.TxtFichier.Size = New System.Drawing.Size(504, 20)
        Me.TxtFichier.TabIndex = 0
        '
        'BtnSelectFichier
        '
        Me.BtnSelectFichier.Location = New System.Drawing.Point(522, 50)
        Me.BtnSelectFichier.Name = "BtnSelectFichier"
        Me.BtnSelectFichier.Size = New System.Drawing.Size(82, 20)
        Me.BtnSelectFichier.TabIndex = 1
        Me.BtnSelectFichier.Text = "Browse..."
        Me.BtnSelectFichier.UseVisualStyleBackColor = True
        '
        'BtnConversion
        '
        Me.BtnConversion.Location = New System.Drawing.Point(12, 146)
        Me.BtnConversion.Name = "BtnConversion"
        Me.BtnConversion.Size = New System.Drawing.Size(137, 32)
        Me.BtnConversion.TabIndex = 2
        Me.BtnConversion.Text = "Start conversion"
        Me.BtnConversion.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.Location = New System.Drawing.Point(155, 146)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(137, 32)
        Me.BtnAnnuler.TabIndex = 3
        Me.BtnAnnuler.Text = "Cancel"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Enter the address of the dictionary database file to convert (*.u8 or *.txt):"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 108)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(504, 23)
        Me.ProgressBar.TabIndex = 5
        Me.ProgressBar.Visible = False
        '
        'LblConversion
        '
        Me.LblConversion.AutoSize = True
        Me.LblConversion.Location = New System.Drawing.Point(12, 92)
        Me.LblConversion.Name = "LblConversion"
        Me.LblConversion.Size = New System.Drawing.Size(69, 13)
        Me.LblConversion.TabIndex = 6
        Me.LblConversion.Text = "Conversion..."
        Me.LblConversion.Visible = False
        '
        'ConvertFichierDico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 190)
        Me.Controls.Add(Me.LblConversion)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnConversion)
        Me.Controls.Add(Me.BtnSelectFichier)
        Me.Controls.Add(Me.TxtFichier)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConvertFichierDico"
        Me.ShowInTaskbar = False
        Me.Text = "Conversion of the U8 dictionary database to XML format"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtFichier As System.Windows.Forms.TextBox
    Friend WithEvents BtnSelectFichier As System.Windows.Forms.Button
    Friend WithEvents BtnConversion As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LblConversion As System.Windows.Forms.Label
End Class
