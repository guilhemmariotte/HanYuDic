<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChoisirPolice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChoisirPolice))
        Me.BtnOK = New System.Windows.Forms.Button
        Me.BtnAnnuler = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListFontTailleSimpli = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnPoliceChinoisSimpli = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnColorSimpli = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ListFontStyleSimpli = New System.Windows.Forms.ComboBox
        Me.ListFontSimpli = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BtnColorTradi = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.ListFontStyleTradi = New System.Windows.Forms.ComboBox
        Me.ListFontTradi = New System.Windows.Forms.ComboBox
        Me.BtnPoliceChinoisTradi = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ListFontTailleTradi = New System.Windows.Forms.ComboBox
        Me.LblSetFontDefaut = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(12, 279)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(111, 31)
        Me.BtnOK.TabIndex = 1
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'BtnAnnuler
        '
        Me.BtnAnnuler.Location = New System.Drawing.Point(129, 279)
        Me.BtnAnnuler.Name = "BtnAnnuler"
        Me.BtnAnnuler.Size = New System.Drawing.Size(111, 31)
        Me.BtnAnnuler.TabIndex = 2
        Me.BtnAnnuler.Text = "Cancel"
        Me.BtnAnnuler.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Latest fonts used:"
        '
        'ListFontTailleSimpli
        '
        Me.ListFontTailleSimpli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontTailleSimpli.FormattingEnabled = True
        Me.ListFontTailleSimpli.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"})
        Me.ListFontTailleSimpli.Location = New System.Drawing.Point(259, 69)
        Me.ListFontTailleSimpli.Name = "ListFontTailleSimpli"
        Me.ListFontTailleSimpli.Size = New System.Drawing.Size(47, 21)
        Me.ListFontTailleSimpli.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Size:"
        '
        'BtnPoliceChinoisSimpli
        '
        Me.BtnPoliceChinoisSimpli.Location = New System.Drawing.Point(6, 19)
        Me.BtnPoliceChinoisSimpli.Name = "BtnPoliceChinoisSimpli"
        Me.BtnPoliceChinoisSimpli.Size = New System.Drawing.Size(123, 21)
        Me.BtnPoliceChinoisSimpli.TabIndex = 6
        Me.BtnPoliceChinoisSimpli.Text = "Browse fonts..."
        Me.BtnPoliceChinoisSimpli.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.BtnColorSimpli)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ListFontStyleSimpli)
        Me.GroupBox1.Controls.Add(Me.ListFontSimpli)
        Me.GroupBox1.Controls.Add(Me.BtnPoliceChinoisSimpli)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ListFontTailleSimpli)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 100)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Font for simplified Chinese"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(311, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Color:"
        '
        'BtnColorSimpli
        '
        Me.BtnColorSimpli.BackColor = System.Drawing.Color.Black
        Me.BtnColorSimpli.Location = New System.Drawing.Point(312, 68)
        Me.BtnColorSimpli.Name = "BtnColorSimpli"
        Me.BtnColorSimpli.Size = New System.Drawing.Size(48, 21)
        Me.BtnColorSimpli.TabIndex = 10
        Me.BtnColorSimpli.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Style:"
        '
        'ListFontStyleSimpli
        '
        Me.ListFontStyleSimpli.BackColor = System.Drawing.SystemColors.Window
        Me.ListFontStyleSimpli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontStyleSimpli.FormattingEnabled = True
        Me.ListFontStyleSimpli.Items.AddRange(New Object() {"Standard", "Bold", "Italic", "Underline", "Strike"})
        Me.ListFontStyleSimpli.Location = New System.Drawing.Point(159, 69)
        Me.ListFontStyleSimpli.Name = "ListFontStyleSimpli"
        Me.ListFontStyleSimpli.Size = New System.Drawing.Size(94, 21)
        Me.ListFontStyleSimpli.TabIndex = 8
        '
        'ListFontSimpli
        '
        Me.ListFontSimpli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontSimpli.FormattingEnabled = True
        Me.ListFontSimpli.Location = New System.Drawing.Point(6, 69)
        Me.ListFontSimpli.Name = "ListFontSimpli"
        Me.ListFontSimpli.Size = New System.Drawing.Size(147, 21)
        Me.ListFontSimpli.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.BtnColorTradi)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ListFontStyleTradi)
        Me.GroupBox2.Controls.Add(Me.ListFontTradi)
        Me.GroupBox2.Controls.Add(Me.BtnPoliceChinoisTradi)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ListFontTailleTradi)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 100)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Font for traditional Chinese"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(309, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Color:"
        '
        'BtnColorTradi
        '
        Me.BtnColorTradi.BackColor = System.Drawing.Color.DarkGray
        Me.BtnColorTradi.Location = New System.Drawing.Point(312, 69)
        Me.BtnColorTradi.Name = "BtnColorTradi"
        Me.BtnColorTradi.Size = New System.Drawing.Size(48, 21)
        Me.BtnColorTradi.TabIndex = 11
        Me.BtnColorTradi.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Style:"
        '
        'ListFontStyleTradi
        '
        Me.ListFontStyleTradi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontStyleTradi.FormattingEnabled = True
        Me.ListFontStyleTradi.Items.AddRange(New Object() {"Standard", "Bold", "Italic", "Underline", "Strike"})
        Me.ListFontStyleTradi.Location = New System.Drawing.Point(159, 69)
        Me.ListFontStyleTradi.Name = "ListFontStyleTradi"
        Me.ListFontStyleTradi.Size = New System.Drawing.Size(94, 21)
        Me.ListFontStyleTradi.TabIndex = 8
        '
        'ListFontTradi
        '
        Me.ListFontTradi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontTradi.FormattingEnabled = True
        Me.ListFontTradi.Location = New System.Drawing.Point(6, 69)
        Me.ListFontTradi.Name = "ListFontTradi"
        Me.ListFontTradi.Size = New System.Drawing.Size(147, 21)
        Me.ListFontTradi.TabIndex = 7
        '
        'BtnPoliceChinoisTradi
        '
        Me.BtnPoliceChinoisTradi.Location = New System.Drawing.Point(6, 19)
        Me.BtnPoliceChinoisTradi.Name = "BtnPoliceChinoisTradi"
        Me.BtnPoliceChinoisTradi.Size = New System.Drawing.Size(123, 21)
        Me.BtnPoliceChinoisTradi.TabIndex = 6
        Me.BtnPoliceChinoisTradi.Text = "Browse fonts..."
        Me.BtnPoliceChinoisTradi.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Latest fonts used:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(256, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Size:"
        '
        'ListFontTailleTradi
        '
        Me.ListFontTailleTradi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListFontTailleTradi.FormattingEnabled = True
        Me.ListFontTailleTradi.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72"})
        Me.ListFontTailleTradi.Location = New System.Drawing.Point(259, 69)
        Me.ListFontTailleTradi.Name = "ListFontTailleTradi"
        Me.ListFontTailleTradi.Size = New System.Drawing.Size(47, 21)
        Me.ListFontTailleTradi.TabIndex = 4
        '
        'LblSetFontDefaut
        '
        Me.LblSetFontDefaut.AutoSize = True
        Me.LblSetFontDefaut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblSetFontDefaut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSetFontDefaut.Location = New System.Drawing.Point(289, 252)
        Me.LblSetFontDefaut.Name = "LblSetFontDefaut"
        Me.LblSetFontDefaut.Size = New System.Drawing.Size(67, 13)
        Me.LblSetFontDefaut.TabIndex = 10
        Me.LblSetFontDefaut.Text = "Default fonts"
        '
        'ChoisirPolice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 322)
        Me.Controls.Add(Me.LblSetFontDefaut)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnAnnuler)
        Me.Controls.Add(Me.BtnOK)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChoisirPolice"
        Me.ShowInTaskbar = False
        Me.Text = "Font"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnAnnuler As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListFontTailleSimpli As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnPoliceChinoisSimpli As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListFontSimpli As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ListFontStyleSimpli As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListFontStyleTradi As System.Windows.Forms.ComboBox
    Friend WithEvents ListFontTradi As System.Windows.Forms.ComboBox
    Friend WithEvents BtnPoliceChinoisTradi As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListFontTailleTradi As System.Windows.Forms.ComboBox
    Friend WithEvents LblSetFontDefaut As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnColorSimpli As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnColorTradi As System.Windows.Forms.Button
End Class
