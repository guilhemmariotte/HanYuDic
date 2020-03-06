<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjoutMot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjoutMot))
        Me.TxtMotTradi = New System.Windows.Forms.TextBox
        Me.TxtMotSimpli = New System.Windows.Forms.TextBox
        Me.TxtMotPinyin = New System.Windows.Forms.TextBox
        Me.TxtMotsTraduc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnOK = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.LblIntro = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtMotTradi
        '
        Me.TxtMotTradi.AllowDrop = True
        Me.TxtMotTradi.Location = New System.Drawing.Point(12, 89)
        Me.TxtMotTradi.Name = "TxtMotTradi"
        Me.TxtMotTradi.Size = New System.Drawing.Size(515, 20)
        Me.TxtMotTradi.TabIndex = 0
        '
        'TxtMotSimpli
        '
        Me.TxtMotSimpli.AllowDrop = True
        Me.TxtMotSimpli.Location = New System.Drawing.Point(12, 136)
        Me.TxtMotSimpli.Name = "TxtMotSimpli"
        Me.TxtMotSimpli.Size = New System.Drawing.Size(515, 20)
        Me.TxtMotSimpli.TabIndex = 1
        '
        'TxtMotPinyin
        '
        Me.TxtMotPinyin.AllowDrop = True
        Me.TxtMotPinyin.Location = New System.Drawing.Point(12, 189)
        Me.TxtMotPinyin.Name = "TxtMotPinyin"
        Me.TxtMotPinyin.Size = New System.Drawing.Size(515, 20)
        Me.TxtMotPinyin.TabIndex = 2
        '
        'TxtMotsTraduc
        '
        Me.TxtMotsTraduc.AllowDrop = True
        Me.TxtMotsTraduc.Location = New System.Drawing.Point(12, 239)
        Me.TxtMotsTraduc.Name = "TxtMotsTraduc"
        Me.TxtMotsTraduc.Size = New System.Drawing.Size(515, 20)
        Me.TxtMotsTraduc.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Enter traditional characters (example : 綠色的):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Enter simplified characters (example : 绿色的) :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Enter pinyin transcription (example : lu:4se4de) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(385, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Enter all translations separated by a semicolon (example : green;green color; ..." & _
            ") :"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(12, 270)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(105, 26)
        Me.BtnOK.TabIndex = 8
        Me.BtnOK.Text = "Add"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.Location = New System.Drawing.Point(123, 270)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnAnnuler.Size = New System.Drawing.Size(105, 26)
        Me.BtnAnnuler.TabIndex = 9
        Me.BtnAnnuler.Text = "Cancel"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'LblIntro
        '
        Me.LblIntro.AutoSize = True
        Me.LblIntro.ForeColor = System.Drawing.SystemColors.InfoText
        Me.LblIntro.Location = New System.Drawing.Point(9, 9)
        Me.LblIntro.Name = "LblIntro"
        Me.LblIntro.Size = New System.Drawing.Size(332, 13)
        Me.LblIntro.TabIndex = 10
        Me.LblIntro.Text = "The new entry will be added to the extension of the current dictionary"
        '
        'AjoutMot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 308)
        Me.Controls.Add(Me.LblIntro)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtMotsTraduc)
        Me.Controls.Add(Me.TxtMotPinyin)
        Me.Controls.Add(Me.TxtMotSimpli)
        Me.Controls.Add(Me.TxtMotTradi)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AjoutMot"
        Me.ShowInTaskbar = False
        Me.Text = "Add a new entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMotTradi As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotSimpli As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotPinyin As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotsTraduc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents LblIntro As System.Windows.Forms.Label
End Class
