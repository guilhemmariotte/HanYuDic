<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Parametres
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Parametres))
        Me.ChoixNbResPage = New System.Windows.Forms.NumericUpDown
        Me.ChoixDiffMaxChinois = New System.Windows.Forms.NumericUpDown
        Me.ChoixDiffMaxPinyin = New System.Windows.Forms.NumericUpDown
        Me.ChoixDiffMaxFrancais = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnOK = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        CType(Me.ChoixNbResPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChoixDiffMaxChinois, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChoixDiffMaxPinyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChoixDiffMaxFrancais, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChoixNbResPage
        '
        Me.ChoixNbResPage.Location = New System.Drawing.Point(323, 27)
        Me.ChoixNbResPage.Name = "ChoixNbResPage"
        Me.ChoixNbResPage.Size = New System.Drawing.Size(40, 20)
        Me.ChoixNbResPage.TabIndex = 0
        '
        'ChoixDiffMaxChinois
        '
        Me.ChoixDiffMaxChinois.Location = New System.Drawing.Point(323, 115)
        Me.ChoixDiffMaxChinois.Name = "ChoixDiffMaxChinois"
        Me.ChoixDiffMaxChinois.Size = New System.Drawing.Size(40, 20)
        Me.ChoixDiffMaxChinois.TabIndex = 1
        '
        'ChoixDiffMaxPinyin
        '
        Me.ChoixDiffMaxPinyin.Location = New System.Drawing.Point(323, 141)
        Me.ChoixDiffMaxPinyin.Name = "ChoixDiffMaxPinyin"
        Me.ChoixDiffMaxPinyin.Size = New System.Drawing.Size(40, 20)
        Me.ChoixDiffMaxPinyin.TabIndex = 2
        '
        'ChoixDiffMaxFrancais
        '
        Me.ChoixDiffMaxFrancais.Location = New System.Drawing.Point(323, 167)
        Me.ChoixDiffMaxFrancais.Name = "ChoixDiffMaxFrancais"
        Me.ChoixDiffMaxFrancais.Size = New System.Drawing.Size(40, 20)
        Me.ChoixDiffMaxFrancais.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Number of results per page:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 26)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Max. number of different characters between" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the word which is searched and the o" & _
            "ne which is found:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "- in French/English/German:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(137, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "- in Chinese:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(137, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "- in pinyin:"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(24, 213)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(100, 31)
        Me.BtnOK.TabIndex = 9
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.Location = New System.Drawing.Point(140, 213)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(100, 31)
        Me.BtnAnnuler.TabIndex = 10
        Me.BtnAnnuler.Text = "Cancel"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'Parametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 253)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ChoixDiffMaxFrancais)
        Me.Controls.Add(Me.ChoixDiffMaxPinyin)
        Me.Controls.Add(Me.ChoixDiffMaxChinois)
        Me.Controls.Add(Me.ChoixNbResPage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Parametres"
        Me.ShowInTaskbar = False
        Me.Text = "Parameters"
        CType(Me.ChoixNbResPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChoixDiffMaxChinois, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChoixDiffMaxPinyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChoixDiffMaxFrancais, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChoixNbResPage As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChoixDiffMaxChinois As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChoixDiffMaxPinyin As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChoixDiffMaxFrancais As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
End Class
