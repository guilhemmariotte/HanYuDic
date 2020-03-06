<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiseAjour
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiseAjour))
        Me.LinkCfdictU8 = New System.Windows.Forms.LinkLabel
        Me.ListTexteIntro = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LinkSiteCfdict = New System.Windows.Forms.LinkLabel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LinkSiteCedict = New System.Windows.Forms.LinkLabel
        Me.LinkCedictU8 = New System.Windows.Forms.LinkLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LinkSiteHandedict = New System.Windows.Forms.LinkLabel
        Me.LinkHandedictU8 = New System.Windows.Forms.LinkLabel
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkCfdictU8
        '
        Me.LinkCfdictU8.AutoSize = True
        Me.LinkCfdictU8.Enabled = False
        Me.LinkCfdictU8.Location = New System.Drawing.Point(6, 16)
        Me.LinkCfdictU8.Name = "LinkCfdictU8"
        Me.LinkCfdictU8.Size = New System.Drawing.Size(48, 13)
        Me.LinkCfdictU8.TabIndex = 0
        Me.LinkCfdictU8.TabStop = True
        Me.LinkCfdictU8.Text = "cfdict.u8"
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
        Me.ListTexteIntro.Size = New System.Drawing.Size(429, 195)
        Me.ListTexteIntro.TabIndex = 2
        Me.ListTexteIntro.Text = resources.GetString("ListTexteIntro.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkSiteCfdict)
        Me.GroupBox1.Controls.Add(Me.LinkCfdictU8)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(450, 43)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CFDict - Chinese/French"
        '
        'LinkSiteCfdict
        '
        Me.LinkSiteCfdict.AutoSize = True
        Me.LinkSiteCfdict.Location = New System.Drawing.Point(368, 16)
        Me.LinkSiteCfdict.Name = "LinkSiteCfdict"
        Me.LinkSiteCfdict.Size = New System.Drawing.Size(70, 13)
        Me.LinkSiteCfdict.TabIndex = 6
        Me.LinkSiteCfdict.TabStop = True
        Me.LinkSiteCfdict.Text = "go to website"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkSiteCedict)
        Me.GroupBox2.Controls.Add(Me.LinkCedictU8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 262)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(450, 40)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CC-CEDict - Chinese/English"
        '
        'LinkSiteCedict
        '
        Me.LinkSiteCedict.AutoSize = True
        Me.LinkSiteCedict.Location = New System.Drawing.Point(368, 16)
        Me.LinkSiteCedict.Name = "LinkSiteCedict"
        Me.LinkSiteCedict.Size = New System.Drawing.Size(70, 13)
        Me.LinkSiteCedict.TabIndex = 6
        Me.LinkSiteCedict.TabStop = True
        Me.LinkSiteCedict.Text = "go to website"
        '
        'LinkCedictU8
        '
        Me.LinkCedictU8.AutoSize = True
        Me.LinkCedictU8.Location = New System.Drawing.Point(6, 16)
        Me.LinkCedictU8.Name = "LinkCedictU8"
        Me.LinkCedictU8.Size = New System.Drawing.Size(65, 13)
        Me.LinkCedictU8.TabIndex = 0
        Me.LinkCedictU8.TabStop = True
        Me.LinkCedictU8.Text = "cedict_ts.u8"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LinkSiteHandedict)
        Me.GroupBox3.Controls.Add(Me.LinkHandedictU8)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 308)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(450, 40)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "HanDeDict - Chinese/German"
        '
        'LinkSiteHandedict
        '
        Me.LinkSiteHandedict.AutoSize = True
        Me.LinkSiteHandedict.Enabled = False
        Me.LinkSiteHandedict.Location = New System.Drawing.Point(368, 16)
        Me.LinkSiteHandedict.Name = "LinkSiteHandedict"
        Me.LinkSiteHandedict.Size = New System.Drawing.Size(70, 13)
        Me.LinkSiteHandedict.TabIndex = 6
        Me.LinkSiteHandedict.TabStop = True
        Me.LinkSiteHandedict.Text = "go to website"
        '
        'LinkHandedictU8
        '
        Me.LinkHandedictU8.AutoSize = True
        Me.LinkHandedictU8.Location = New System.Drawing.Point(6, 16)
        Me.LinkHandedictU8.Name = "LinkHandedictU8"
        Me.LinkHandedictU8.Size = New System.Drawing.Size(69, 13)
        Me.LinkHandedictU8.TabIndex = 0
        Me.LinkHandedictU8.TabStop = True
        Me.LinkHandedictU8.Text = "handedict.u8"
        '
        'MiseAjour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 360)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListTexteIntro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MiseAjour"
        Me.ShowInTaskbar = False
        Me.Text = "Dictionary database update"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LinkCfdictU8 As System.Windows.Forms.LinkLabel
    Friend WithEvents ListTexteIntro As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkSiteCfdict As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkSiteCedict As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkCedictU8 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkSiteHandedict As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkHandedictU8 As System.Windows.Forms.LinkLabel
End Class
