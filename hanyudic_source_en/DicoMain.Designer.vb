<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DicoMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DicoMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuAjoutMot = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuMiseAjour = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConversionXML = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuFermer = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuParametres = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuChoisirPolice = New System.Windows.Forms.ToolStripMenuItem
        Me.LettresAccentuéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuAfficherCaractFra = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuMasquerCaractFra = New System.Windows.Forms.ToolStripMenuItem
        Me.CaractèresSpéciauxAllemandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuAfficherCaractAllem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuMasquerCaractAllem = New System.Windows.Forms.ToolStripMenuItem
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuApropos = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuAide = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnSelectLangue = New System.Windows.Forms.Button
        Me.TxtMotRecherche = New System.Windows.Forms.TextBox
        Me.BtnRecherche = New System.Windows.Forms.Button
        Me.ListResultats = New System.Windows.Forms.RichTextBox
        Me.LblResultats = New System.Windows.Forms.Label
        Me.BtnPageSuivante = New System.Windows.Forms.Button
        Me.BtnPagePrecedente = New System.Windows.Forms.Button
        Me.LblPage = New System.Windows.Forms.Label
        Me.LblTempsExe = New System.Windows.Forms.Label
        Me.FontDialogChinois = New System.Windows.Forms.FontDialog
        Me.TabOnglets = New System.Windows.Forms.TabControl
        Me.OngletStart = New System.Windows.Forms.TabPage
        Me.BtnNewRecherche = New System.Windows.Forms.Button
        Me.ColorDialogChinois = New System.Windows.Forms.ColorDialog
        Me.ToolTipDico = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.LinkEaigu = New System.Windows.Forms.LinkLabel
        Me.LinkEgrave = New System.Windows.Forms.LinkLabel
        Me.LinkAgrave = New System.Windows.Forms.LinkLabel
        Me.LinkUgrave = New System.Windows.Forms.LinkLabel
        Me.LinkCcedille = New System.Windows.Forms.LinkLabel
        Me.LinkSset = New System.Windows.Forms.LinkLabel
        Me.ListSelectLangue = New System.Windows.Forms.ComboBox
        Me.ListSelectChinois = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LinkEtrema = New System.Windows.Forms.LinkLabel
        Me.LinkItrema = New System.Windows.Forms.LinkLabel
        Me.LinkAtrema = New System.Windows.Forms.LinkLabel
        Me.LinkUtrema = New System.Windows.Forms.LinkLabel
        Me.LinkOtrema = New System.Windows.Forms.LinkLabel
        Me.LinkAAtrema = New System.Windows.Forms.LinkLabel
        Me.LinkUUtrema = New System.Windows.Forms.LinkLabel
        Me.LinkOOtrema = New System.Windows.Forms.LinkLabel
        Me.GroupLettresFra = New System.Windows.Forms.GroupBox
        Me.GroupLettresAllem = New System.Windows.Forms.GroupBox
        Me.MenuStrip1.SuspendLayout()
        Me.TabOnglets.SuspendLayout()
        Me.OngletStart.SuspendLayout()
        Me.GroupLettresFra.SuspendLayout()
        Me.GroupLettresAllem.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(550, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAjoutMot, Me.MenuMiseAjour, Me.MenuConversionXML, Me.MenuFermer})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FichierToolStripMenuItem.Text = "File"
        '
        'MenuAjoutMot
        '
        Me.MenuAjoutMot.Name = "MenuAjoutMot"
        Me.MenuAjoutMot.Size = New System.Drawing.Size(233, 22)
        Me.MenuAjoutMot.Text = "Add entry..."
        '
        'MenuMiseAjour
        '
        Me.MenuMiseAjour.Name = "MenuMiseAjour"
        Me.MenuMiseAjour.Size = New System.Drawing.Size(233, 22)
        Me.MenuMiseAjour.Text = "Update dictionary databases..."
        '
        'MenuConversionXML
        '
        Me.MenuConversionXML.Name = "MenuConversionXML"
        Me.MenuConversionXML.Size = New System.Drawing.Size(233, 22)
        Me.MenuConversionXML.Text = "Database conversion to XML..."
        '
        'MenuFermer
        '
        Me.MenuFermer.Name = "MenuFermer"
        Me.MenuFermer.Size = New System.Drawing.Size(233, 22)
        Me.MenuFermer.Text = "Quit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuParametres, Me.MenuChoisirPolice, Me.LettresAccentuéesToolStripMenuItem, Me.CaractèresSpéciauxAllemandToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'MenuParametres
        '
        Me.MenuParametres.Name = "MenuParametres"
        Me.MenuParametres.Size = New System.Drawing.Size(221, 22)
        Me.MenuParametres.Text = "Search parameters"
        '
        'MenuChoisirPolice
        '
        Me.MenuChoisirPolice.Name = "MenuChoisirPolice"
        Me.MenuChoisirPolice.Size = New System.Drawing.Size(221, 22)
        Me.MenuChoisirPolice.Text = "Font"
        '
        'LettresAccentuéesToolStripMenuItem
        '
        Me.LettresAccentuéesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAfficherCaractFra, Me.MenuMasquerCaractFra})
        Me.LettresAccentuéesToolStripMenuItem.Name = "LettresAccentuéesToolStripMenuItem"
        Me.LettresAccentuéesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.LettresAccentuéesToolStripMenuItem.Text = "Special characters - French"
        '
        'MenuAfficherCaractFra
        '
        Me.MenuAfficherCaractFra.Name = "MenuAfficherCaractFra"
        Me.MenuAfficherCaractFra.Size = New System.Drawing.Size(152, 22)
        Me.MenuAfficherCaractFra.Text = "Show"
        '
        'MenuMasquerCaractFra
        '
        Me.MenuMasquerCaractFra.Name = "MenuMasquerCaractFra"
        Me.MenuMasquerCaractFra.Size = New System.Drawing.Size(152, 22)
        Me.MenuMasquerCaractFra.Text = "Hide"
        '
        'CaractèresSpéciauxAllemandToolStripMenuItem
        '
        Me.CaractèresSpéciauxAllemandToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuAfficherCaractAllem, Me.MenuMasquerCaractAllem})
        Me.CaractèresSpéciauxAllemandToolStripMenuItem.Name = "CaractèresSpéciauxAllemandToolStripMenuItem"
        Me.CaractèresSpéciauxAllemandToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.CaractèresSpéciauxAllemandToolStripMenuItem.Text = "Special characters - German"
        '
        'MenuAfficherCaractAllem
        '
        Me.MenuAfficherCaractAllem.Name = "MenuAfficherCaractAllem"
        Me.MenuAfficherCaractAllem.Size = New System.Drawing.Size(152, 22)
        Me.MenuAfficherCaractAllem.Text = "Show"
        '
        'MenuMasquerCaractAllem
        '
        Me.MenuMasquerCaractAllem.Name = "MenuMasquerCaractAllem"
        Me.MenuMasquerCaractAllem.Size = New System.Drawing.Size(152, 22)
        Me.MenuMasquerCaractAllem.Text = "Hide"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuApropos, Me.MenuAide})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AideToolStripMenuItem.Text = "Help"
        '
        'MenuApropos
        '
        Me.MenuApropos.Name = "MenuApropos"
        Me.MenuApropos.Size = New System.Drawing.Size(152, 22)
        Me.MenuApropos.Text = "About"
        '
        'MenuAide
        '
        Me.MenuAide.Name = "MenuAide"
        Me.MenuAide.Size = New System.Drawing.Size(152, 22)
        Me.MenuAide.Text = "Help"
        '
        'BtnSelectLangue
        '
        Me.BtnSelectLangue.Location = New System.Drawing.Point(143, 47)
        Me.BtnSelectLangue.Name = "BtnSelectLangue"
        Me.BtnSelectLangue.Size = New System.Drawing.Size(51, 25)
        Me.BtnSelectLangue.TabIndex = 5
        Me.BtnSelectLangue.Text = ">>>>"
        Me.BtnSelectLangue.UseVisualStyleBackColor = True
        '
        'TxtMotRecherche
        '
        Me.TxtMotRecherche.AllowDrop = True
        Me.TxtMotRecherche.Location = New System.Drawing.Point(36, 77)
        Me.TxtMotRecherche.Name = "TxtMotRecherche"
        Me.TxtMotRecherche.Size = New System.Drawing.Size(293, 20)
        Me.TxtMotRecherche.TabIndex = 8
        '
        'BtnRecherche
        '
        Me.BtnRecherche.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnRecherche.Location = New System.Drawing.Point(36, 103)
        Me.BtnRecherche.Name = "BtnRecherche"
        Me.BtnRecherche.Size = New System.Drawing.Size(111, 31)
        Me.BtnRecherche.TabIndex = 9
        Me.BtnRecherche.Text = "Search"
        Me.BtnRecherche.UseVisualStyleBackColor = False
        '
        'ListResultats
        '
        Me.ListResultats.BackColor = System.Drawing.SystemColors.Control
        Me.ListResultats.Location = New System.Drawing.Point(6, 6)
        Me.ListResultats.Name = "ListResultats"
        Me.ListResultats.ReadOnly = True
        Me.ListResultats.Size = New System.Drawing.Size(456, 461)
        Me.ListResultats.TabIndex = 14
        Me.ListResultats.Text = ""
        '
        'LblResultats
        '
        Me.LblResultats.AutoSize = True
        Me.LblResultats.Location = New System.Drawing.Point(33, 649)
        Me.LblResultats.Name = "LblResultats"
        Me.LblResultats.Size = New System.Drawing.Size(46, 13)
        Me.LblResultats.TabIndex = 15
        Me.LblResultats.Text = "0 results"
        '
        'BtnPageSuivante
        '
        Me.BtnPageSuivante.Location = New System.Drawing.Point(407, 645)
        Me.BtnPageSuivante.Name = "BtnPageSuivante"
        Me.BtnPageSuivante.Size = New System.Drawing.Size(105, 21)
        Me.BtnPageSuivante.TabIndex = 16
        Me.BtnPageSuivante.Text = "Next page >"
        Me.BtnPageSuivante.UseVisualStyleBackColor = True
        '
        'BtnPagePrecedente
        '
        Me.BtnPagePrecedente.Location = New System.Drawing.Point(289, 645)
        Me.BtnPagePrecedente.Name = "BtnPagePrecedente"
        Me.BtnPagePrecedente.Size = New System.Drawing.Size(112, 21)
        Me.BtnPagePrecedente.TabIndex = 17
        Me.BtnPagePrecedente.Text = "< Previous page"
        Me.BtnPagePrecedente.UseVisualStyleBackColor = True
        '
        'LblPage
        '
        Me.LblPage.AutoSize = True
        Me.LblPage.Location = New System.Drawing.Point(178, 649)
        Me.LblPage.Name = "LblPage"
        Me.LblPage.Size = New System.Drawing.Size(51, 13)
        Me.LblPage.TabIndex = 18
        Me.LblPage.Text = "page 1/1"
        '
        'LblTempsExe
        '
        Me.LblTempsExe.AutoSize = True
        Me.LblTempsExe.Location = New System.Drawing.Point(105, 649)
        Me.LblTempsExe.Name = "LblTempsExe"
        Me.LblTempsExe.Size = New System.Drawing.Size(42, 13)
        Me.LblTempsExe.TabIndex = 19
        Me.LblTempsExe.Text = "(0 sec.)"
        '
        'TabOnglets
        '
        Me.TabOnglets.Controls.Add(Me.OngletStart)
        Me.TabOnglets.Location = New System.Drawing.Point(36, 140)
        Me.TabOnglets.Name = "TabOnglets"
        Me.TabOnglets.SelectedIndex = 0
        Me.TabOnglets.Size = New System.Drawing.Size(476, 499)
        Me.TabOnglets.TabIndex = 20
        '
        'OngletStart
        '
        Me.OngletStart.BackColor = System.Drawing.Color.Transparent
        Me.OngletStart.Controls.Add(Me.ListResultats)
        Me.OngletStart.Location = New System.Drawing.Point(4, 22)
        Me.OngletStart.Name = "OngletStart"
        Me.OngletStart.Padding = New System.Windows.Forms.Padding(3)
        Me.OngletStart.Size = New System.Drawing.Size(468, 473)
        Me.OngletStart.TabIndex = 0
        Me.OngletStart.Text = "Results"
        Me.OngletStart.UseVisualStyleBackColor = True
        '
        'BtnNewRecherche
        '
        Me.BtnNewRecherche.Location = New System.Drawing.Point(153, 103)
        Me.BtnNewRecherche.Name = "BtnNewRecherche"
        Me.BtnNewRecherche.Size = New System.Drawing.Size(137, 31)
        Me.BtnNewRecherche.TabIndex = 12
        Me.BtnNewRecherche.Text = "New search"
        Me.BtnNewRecherche.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "dic_file"
        Me.OpenFileDialog.Filter = "Fichiers U8 (*.u8)|*.u8|Fichiers texte (*.txt)|*.txt"
        '
        'LinkEaigu
        '
        Me.LinkEaigu.AutoSize = True
        Me.LinkEaigu.LinkColor = System.Drawing.Color.Black
        Me.LinkEaigu.Location = New System.Drawing.Point(6, 16)
        Me.LinkEaigu.Name = "LinkEaigu"
        Me.LinkEaigu.Size = New System.Drawing.Size(19, 13)
        Me.LinkEaigu.TabIndex = 22
        Me.LinkEaigu.TabStop = True
        Me.LinkEaigu.Text = " é "
        Me.LinkEaigu.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkEgrave
        '
        Me.LinkEgrave.AutoSize = True
        Me.LinkEgrave.LinkColor = System.Drawing.Color.Black
        Me.LinkEgrave.Location = New System.Drawing.Point(6, 29)
        Me.LinkEgrave.Name = "LinkEgrave"
        Me.LinkEgrave.Size = New System.Drawing.Size(19, 13)
        Me.LinkEgrave.TabIndex = 23
        Me.LinkEgrave.TabStop = True
        Me.LinkEgrave.Text = " è "
        Me.LinkEgrave.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkAgrave
        '
        Me.LinkAgrave.AutoSize = True
        Me.LinkAgrave.LinkColor = System.Drawing.Color.Black
        Me.LinkAgrave.Location = New System.Drawing.Point(6, 42)
        Me.LinkAgrave.Name = "LinkAgrave"
        Me.LinkAgrave.Size = New System.Drawing.Size(19, 13)
        Me.LinkAgrave.TabIndex = 24
        Me.LinkAgrave.TabStop = True
        Me.LinkAgrave.Text = " à "
        Me.LinkAgrave.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkUgrave
        '
        Me.LinkUgrave.AutoSize = True
        Me.LinkUgrave.LinkColor = System.Drawing.Color.Black
        Me.LinkUgrave.Location = New System.Drawing.Point(6, 55)
        Me.LinkUgrave.Name = "LinkUgrave"
        Me.LinkUgrave.Size = New System.Drawing.Size(19, 13)
        Me.LinkUgrave.TabIndex = 25
        Me.LinkUgrave.TabStop = True
        Me.LinkUgrave.Text = " ù "
        Me.LinkUgrave.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkCcedille
        '
        Me.LinkCcedille.AutoSize = True
        Me.LinkCcedille.LinkColor = System.Drawing.Color.Black
        Me.LinkCcedille.Location = New System.Drawing.Point(22, 16)
        Me.LinkCcedille.Name = "LinkCcedille"
        Me.LinkCcedille.Size = New System.Drawing.Size(19, 13)
        Me.LinkCcedille.TabIndex = 26
        Me.LinkCcedille.TabStop = True
        Me.LinkCcedille.Text = " ç "
        Me.LinkCcedille.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkSset
        '
        Me.LinkSset.AutoSize = True
        Me.LinkSset.LinkColor = System.Drawing.Color.Black
        Me.LinkSset.Location = New System.Drawing.Point(6, 55)
        Me.LinkSset.Name = "LinkSset"
        Me.LinkSset.Size = New System.Drawing.Size(19, 13)
        Me.LinkSset.TabIndex = 27
        Me.LinkSset.TabStop = True
        Me.LinkSset.Text = " ß "
        Me.LinkSset.VisitedLinkColor = System.Drawing.Color.Black
        '
        'ListSelectLangue
        '
        Me.ListSelectLangue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListSelectLangue.FormattingEnabled = True
        Me.ListSelectLangue.Items.AddRange(New Object() {"French", "English", "German"})
        Me.ListSelectLangue.Location = New System.Drawing.Point(36, 50)
        Me.ListSelectLangue.Name = "ListSelectLangue"
        Me.ListSelectLangue.Size = New System.Drawing.Size(101, 21)
        Me.ListSelectLangue.TabIndex = 28
        '
        'ListSelectChinois
        '
        Me.ListSelectChinois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListSelectChinois.Enabled = False
        Me.ListSelectChinois.FormattingEnabled = True
        Me.ListSelectChinois.Items.AddRange(New Object() {"traditional", "simplified", "pinyin"})
        Me.ListSelectChinois.Location = New System.Drawing.Point(247, 50)
        Me.ListSelectChinois.Name = "ListSelectChinois"
        Me.ListSelectChinois.Size = New System.Drawing.Size(82, 21)
        Me.ListSelectChinois.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(200, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Chinese"
        '
        'LinkEtrema
        '
        Me.LinkEtrema.AutoSize = True
        Me.LinkEtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkEtrema.Location = New System.Drawing.Point(22, 29)
        Me.LinkEtrema.Name = "LinkEtrema"
        Me.LinkEtrema.Size = New System.Drawing.Size(19, 13)
        Me.LinkEtrema.TabIndex = 33
        Me.LinkEtrema.TabStop = True
        Me.LinkEtrema.Text = " ë "
        Me.LinkEtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkItrema
        '
        Me.LinkItrema.AutoSize = True
        Me.LinkItrema.LinkColor = System.Drawing.Color.Black
        Me.LinkItrema.Location = New System.Drawing.Point(22, 42)
        Me.LinkItrema.Name = "LinkItrema"
        Me.LinkItrema.Size = New System.Drawing.Size(17, 13)
        Me.LinkItrema.TabIndex = 34
        Me.LinkItrema.TabStop = True
        Me.LinkItrema.Text = " ï "
        Me.LinkItrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkAtrema
        '
        Me.LinkAtrema.AutoSize = True
        Me.LinkAtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkAtrema.Location = New System.Drawing.Point(6, 16)
        Me.LinkAtrema.Name = "LinkAtrema"
        Me.LinkAtrema.Size = New System.Drawing.Size(19, 13)
        Me.LinkAtrema.TabIndex = 35
        Me.LinkAtrema.TabStop = True
        Me.LinkAtrema.Text = " ä "
        Me.LinkAtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkUtrema
        '
        Me.LinkUtrema.AutoSize = True
        Me.LinkUtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkUtrema.Location = New System.Drawing.Point(6, 29)
        Me.LinkUtrema.Name = "LinkUtrema"
        Me.LinkUtrema.Size = New System.Drawing.Size(19, 13)
        Me.LinkUtrema.TabIndex = 36
        Me.LinkUtrema.TabStop = True
        Me.LinkUtrema.Text = " ü "
        Me.LinkUtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkOtrema
        '
        Me.LinkOtrema.AutoSize = True
        Me.LinkOtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkOtrema.Location = New System.Drawing.Point(6, 42)
        Me.LinkOtrema.Name = "LinkOtrema"
        Me.LinkOtrema.Size = New System.Drawing.Size(19, 13)
        Me.LinkOtrema.TabIndex = 37
        Me.LinkOtrema.TabStop = True
        Me.LinkOtrema.Text = " ö "
        Me.LinkOtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkAAtrema
        '
        Me.LinkAAtrema.AutoSize = True
        Me.LinkAAtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkAAtrema.Location = New System.Drawing.Point(22, 16)
        Me.LinkAAtrema.Name = "LinkAAtrema"
        Me.LinkAAtrema.Size = New System.Drawing.Size(20, 13)
        Me.LinkAAtrema.TabIndex = 38
        Me.LinkAAtrema.TabStop = True
        Me.LinkAAtrema.Text = " Ä "
        Me.LinkAAtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkUUtrema
        '
        Me.LinkUUtrema.AutoSize = True
        Me.LinkUUtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkUUtrema.Location = New System.Drawing.Point(22, 29)
        Me.LinkUUtrema.Name = "LinkUUtrema"
        Me.LinkUUtrema.Size = New System.Drawing.Size(21, 13)
        Me.LinkUUtrema.TabIndex = 39
        Me.LinkUUtrema.TabStop = True
        Me.LinkUUtrema.Text = " Ü "
        Me.LinkUUtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'LinkOOtrema
        '
        Me.LinkOOtrema.AutoSize = True
        Me.LinkOOtrema.LinkColor = System.Drawing.Color.Black
        Me.LinkOOtrema.Location = New System.Drawing.Point(22, 42)
        Me.LinkOOtrema.Name = "LinkOOtrema"
        Me.LinkOOtrema.Size = New System.Drawing.Size(21, 13)
        Me.LinkOOtrema.TabIndex = 40
        Me.LinkOOtrema.TabStop = True
        Me.LinkOOtrema.Text = " Ö "
        Me.LinkOOtrema.VisitedLinkColor = System.Drawing.Color.Black
        '
        'GroupLettresFra
        '
        Me.GroupLettresFra.Controls.Add(Me.LinkEaigu)
        Me.GroupLettresFra.Controls.Add(Me.LinkEgrave)
        Me.GroupLettresFra.Controls.Add(Me.LinkAgrave)
        Me.GroupLettresFra.Controls.Add(Me.LinkUgrave)
        Me.GroupLettresFra.Controls.Add(Me.LinkCcedille)
        Me.GroupLettresFra.Controls.Add(Me.LinkEtrema)
        Me.GroupLettresFra.Controls.Add(Me.LinkItrema)
        Me.GroupLettresFra.Location = New System.Drawing.Point(355, 62)
        Me.GroupLettresFra.Name = "GroupLettresFra"
        Me.GroupLettresFra.Size = New System.Drawing.Size(46, 72)
        Me.GroupLettresFra.TabIndex = 41
        Me.GroupLettresFra.TabStop = False
        Me.GroupLettresFra.Visible = False
        '
        'GroupLettresAllem
        '
        Me.GroupLettresAllem.Controls.Add(Me.LinkAtrema)
        Me.GroupLettresAllem.Controls.Add(Me.LinkSset)
        Me.GroupLettresAllem.Controls.Add(Me.LinkOOtrema)
        Me.GroupLettresAllem.Controls.Add(Me.LinkUtrema)
        Me.GroupLettresAllem.Controls.Add(Me.LinkUUtrema)
        Me.GroupLettresAllem.Controls.Add(Me.LinkOtrema)
        Me.GroupLettresAllem.Controls.Add(Me.LinkAAtrema)
        Me.GroupLettresAllem.Location = New System.Drawing.Point(407, 62)
        Me.GroupLettresAllem.Name = "GroupLettresAllem"
        Me.GroupLettresAllem.Size = New System.Drawing.Size(46, 72)
        Me.GroupLettresAllem.TabIndex = 42
        Me.GroupLettresAllem.TabStop = False
        Me.GroupLettresAllem.Visible = False
        '
        'DicoMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(550, 678)
        Me.Controls.Add(Me.GroupLettresAllem)
        Me.Controls.Add(Me.GroupLettresFra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListSelectChinois)
        Me.Controls.Add(Me.ListSelectLangue)
        Me.Controls.Add(Me.BtnRecherche)
        Me.Controls.Add(Me.TabOnglets)
        Me.Controls.Add(Me.LblTempsExe)
        Me.Controls.Add(Me.LblPage)
        Me.Controls.Add(Me.BtnPagePrecedente)
        Me.Controls.Add(Me.BtnPageSuivante)
        Me.Controls.Add(Me.LblResultats)
        Me.Controls.Add(Me.TxtMotRecherche)
        Me.Controls.Add(Me.BtnSelectLangue)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.BtnNewRecherche)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DicoMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HanYuDic"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabOnglets.ResumeLayout(False)
        Me.OngletStart.ResumeLayout(False)
        Me.GroupLettresFra.ResumeLayout(False)
        Me.GroupLettresFra.PerformLayout()
        Me.GroupLettresAllem.ResumeLayout(False)
        Me.GroupLettresAllem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuFermer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuApropos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnSelectLangue As System.Windows.Forms.Button
    Friend WithEvents TxtMotRecherche As System.Windows.Forms.TextBox
    Friend WithEvents BtnRecherche As System.Windows.Forms.Button
    Friend WithEvents ListResultats As System.Windows.Forms.RichTextBox
    Friend WithEvents MenuChoisirPolice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAjoutMot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblResultats As System.Windows.Forms.Label
    Friend WithEvents BtnPageSuivante As System.Windows.Forms.Button
    Friend WithEvents BtnPagePrecedente As System.Windows.Forms.Button
    Friend WithEvents LblPage As System.Windows.Forms.Label
    Friend WithEvents MenuParametres As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblTempsExe As System.Windows.Forms.Label
    Friend WithEvents FontDialogChinois As System.Windows.Forms.FontDialog
    Friend WithEvents TabOnglets As System.Windows.Forms.TabControl
    Friend WithEvents OngletStart As System.Windows.Forms.TabPage
    Friend WithEvents BtnNewRecherche As System.Windows.Forms.Button
    Friend WithEvents ColorDialogChinois As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolTipDico As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuConversionXML As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMiseAjour As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkEaigu As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkEgrave As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkAgrave As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkUgrave As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkCcedille As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkSset As System.Windows.Forms.LinkLabel
    Friend WithEvents ListSelectLangue As System.Windows.Forms.ComboBox
    Friend WithEvents ListSelectChinois As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkEtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkItrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkAtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkUtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkOtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkAAtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkUUtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkOOtrema As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupLettresFra As System.Windows.Forms.GroupBox
    Friend WithEvents GroupLettresAllem As System.Windows.Forms.GroupBox
    Friend WithEvents LettresAccentuéesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAfficherCaractFra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMasquerCaractFra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CaractèresSpéciauxAllemandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuAfficherCaractAllem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuMasquerCaractAllem As System.Windows.Forms.ToolStripMenuItem

End Class
