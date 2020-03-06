Imports System.Xml
Imports System.IO
Imports System.Text

Public Class DicoMain
    'Adresse du fichier dictionnaire au format xml
    Public FichierDico As String = "data\cfdict.xml"
    'Langue dans laquelle s'effectue la recherche
    Public LangueStart As String = "Francais"
    'Mode dans lequel la recherche en chinois s'effectue
    Private ModeChinois As String = "Simpli"
    'Sens de traduction
    Private VersChinois As Boolean = True

    'Numero de l'onglet courant (a partir de 0)
    Private OngletCourant As Integer = 0
    'Indique la creation d'un nouvel onglet (pour ne pas declencher ChgtOnglet)
    Private CreationNouvelOnglet As Boolean = False
    'Nombre de resultats, nombre de pages, numero de la page en cours
    Private NbRes(0) As Integer
    Private NbPages(0) As Integer
    Private PageCourante(0) As Integer
    'Tableau de tableaux a 2 dimensions pour classer les resultats par page
    Private TabResOrg(0)(,) As Word
    'Tableau de RichTextBox pour l'affichage des resultats
    Private ListRes(0) As RichTextBox

    'Mesure du temps d'execution en secondes
    Private TimeStart, TimeEnd As Integer
    Private TimeRes(0) As Integer

    'Parametres - Nombre de resultats par page
    Public NbResPage As Integer = 10
    'Difference de caracteres max autorisee pour la recherche
    Public DiffMaxPinyin As Integer = 10
    Public DiffMaxChinois As Integer = 5
    Public DiffMaxFrancais As Integer = 20

    'Police - affichage des caracteres chinois simplifies et traditionnels
    Public TabFontSimpli() As System.Drawing.Font
    Public FontColorSimpli As System.Drawing.Color = Color.Black
    Public TabFontTradi() As System.Drawing.Font
    Public FontColorTradi As System.Drawing.Color = Color.DarkGray

    'Fonction deleguee qui permet d'instancier des fonctions : Word -> Integer
    Delegate Function WordToInteger(ByVal w As Word) As Integer



    'Lancement et menus
    Private Sub DicoMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        'Centrage de la fenêtre
        Me.StartPosition = FormStartPosition.CenterScreen

        'Initialisation de la premiere liste d'affichage (qui est celle creee en mode [Design])
        AddHandler ListResultats.MouseDown, AddressOf List_MouseDown
        AddHandler ListResultats.MouseMove, AddressOf List_MouseMove
        ListRes(0) = ListResultats

        'Initialise les tooltip
        ToolTipDico.SetToolTip(TxtMotRecherche, "Enter one or several words")
        ToolTipDico.SetToolTip(BtnRecherche, "Search in the current tab")
        ToolTipDico.SetToolTip(BtnNewRecherche, "Search in a new tab")
        ToolTipDico.SetToolTip(TabOnglets, "Double-click to close the tab")
        ToolTipDico.SetToolTip(ChoisirPolice.LblSetFontDefaut, _
                               "Click here to reset to default fonts")
        ToolTipDico.SetToolTip(GroupLettresFra, _
                               "Click on a letter to print in the search bar")
        ToolTipDico.SetToolTip(GroupLettresAllem, _
                               "Click on a letter to print in the search bar")

        'Chargement des fichiers config
        Try
            Dim ResLecture1() As Object = LecturePolices("config\config_police.txt")
            TabFontSimpli = ResLecture1(0)
            FontColorSimpli = ResLecture1(1)
            TabFontTradi = ResLecture1(2)
            FontColorTradi = ResLecture1(3)

            Dim ResLecture2() As Integer = LectureParametres("config\config_parametres.txt")
            NbResPage = ResLecture2(0)
            DiffMaxPinyin = ResLecture2(1)
            DiffMaxChinois = ResLecture2(2)
            DiffMaxFrancais = ResLecture2(3)

            Dim ResLecture3() As Object = LectureLangue("config\config_langue.txt")
            LangueStart = ResLecture3(0)
            ModeChinois = ResLecture3(1)
            VersChinois = ResLecture3(2)

        Catch ex As Exception

            ReDim TabFontSimpli(0)
            TabFontSimpli(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Bold)
            ReDim TabFontTradi(0)
            TabFontTradi(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Regular)

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading parameters - Error !")
        End Try

        'Langues choisies
        Try
            If LangueStart = "Francais" Then
                ListSelectLangue.SelectedIndex = 0
            ElseIf LangueStart = "Anglais" Then
                ListSelectLangue.SelectedIndex = 1
            ElseIf LangueStart = "Allemand" Then
                ListSelectLangue.SelectedIndex = 2
            End If
            If ModeChinois = "Tradi" Then
                ListSelectChinois.SelectedIndex = 0
            ElseIf ModeChinois = "Simpli" Then
                ListSelectChinois.SelectedIndex = 1
            ElseIf ModeChinois = "Pinyin" Then
                ListSelectChinois.SelectedIndex = 2
            End If
            If VersChinois Then
                BtnSelectLangue.Text = ">>>>"
                ListSelectChinois.Enabled = False
            Else
                BtnSelectLangue.Text = "<<<<"
                ListSelectChinois.Enabled = True
            End If

        Catch ex As Exception
            LangueStart = "Francais"
            ListSelectLangue.SelectedIndex = 0
            ModeChinois = "Simpli"
            ListSelectChinois.SelectedIndex = 1
            VersChinois = True
            BtnSelectLangue.Text = ">>>>"
            ListSelectChinois.Enabled = False

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading parameters - Error !")
        End Try
        
    End Sub

    Private Sub DicoMain_FormClosing(ByVal sender As Object, _
                                  ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                                  Handles MyBase.FormClosing
        Try
            'Enregistrement de la configuration en cours
            SauvegardeLangue("config\config_langue.txt", LangueStart, ModeChinois, VersChinois)
            SauvegardePolices("config\config_police.txt", TabFontSimpli, FontColorSimpli, _
                              TabFontTradi, FontColorTradi)
            SauvegardeParametres("config\config_parametres.txt", NbResPage, DiffMaxChinois, _
                                 DiffMaxPinyin, DiffMaxFrancais)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Saving parameters - Error!")
        End Try

    End Sub

    Private Sub MenuAjoutMot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuAjoutMot.Click
        AjoutMot.Show()
    End Sub

    Private Sub MenuMiseAjour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuMiseAjour.Click
        MiseAjour.Show()
    End Sub

    Private Sub MenuConversionXML_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConversionXML.Click
        ConvertFichierDico.Show()
    End Sub

    Private Sub MenuFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuFermer.Click
        Me.Close()
    End Sub

    Private Sub MenuChoisirPolice_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuChoisirPolice.Click
        ChoisirPolice.ShowDialog()
    End Sub

    Private Sub MenuParametres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuParametres.Click
        Parametres.ShowDialog()
    End Sub

    Private Sub MenuApropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuApropos.Click
        Apropos.Show()
    End Sub

    Private Sub MenuAide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MenuAide.Click
        Aide.Show()
    End Sub


    'Selection des langues
    Private Sub BtnSelectLangue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnSelectLangue.Click
        If VersChinois Then
            BtnSelectLangue.Text = "<<<<"
            VersChinois = False
            ListSelectChinois.Enabled = True
        Else
            BtnSelectLangue.Text = ">>>>"
            VersChinois = True
            ListSelectChinois.Enabled = False
        End If
    End Sub

    Private Sub ListSelectLangue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSelectLangue.SelectedIndexChanged
        If ListSelectLangue.SelectedIndex = 0 Then
            LangueStart = "Francais"
            FichierDico = "data\cfdict.xml"
        ElseIf ListSelectLangue.SelectedIndex = 1 Then
            LangueStart = "Anglais"
            FichierDico = "data\cedict_ts.xml"
        ElseIf ListSelectLangue.SelectedIndex = 2 Then
            LangueStart = "Allemand"
            FichierDico = "data\handedict.xml"
        End If
    End Sub

    Private Sub ListSelectChinois_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSelectChinois.SelectedIndexChanged
        If ListSelectChinois.SelectedIndex = 0 Then
            ModeChinois = "Tradi"
        ElseIf ListSelectChinois.SelectedIndex = 1 Then
            ModeChinois = "Simpli"
        ElseIf ListSelectChinois.SelectedIndex = 2 Then
            ModeChinois = "Pinyin"
        End If
    End Sub


    'Boutons de recherche
    Private Sub BtnRecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnRecherche.Click
        Dim sMotRecherche As String

        Try
            'Mesure du temps actuel
            TimeStart = TimeOfDay.Second

            'Reinitialisation des resultats pour l'onglet courant
            ReDim TabResOrg(OngletCourant)(NbResPage - 1, 0)
            ListRes(OngletCourant).Clear()
            NbRes(OngletCourant) = 0
            NbPages(OngletCourant) = 1
            PageCourante(OngletCourant) = 1
            TimeRes(OngletCourant) = 0

            LblResultats.Text = NbRes(OngletCourant) & " results"
            LblPage.Text = "page " & PageCourante(OngletCourant) & "/" & NbPages(OngletCourant)
            LblTempsExe.Text = "(" & TimeRes(OngletCourant) & " sec.)"

            'mot saisi dans la barre de recherche
            sMotRecherche = TxtMotRecherche.Text

            If sMotRecherche <> "" Then

                TabOnglets.TabPages(OngletCourant).Text = sMotRecherche
                'Lancement de la recherche
                If VersChinois Then
                    AnalyseResultatsTraduc(sMotRecherche)
                Else
                    If ModeChinois = "Tradi" Then
                        AnalyseResultatsTradi(sMotRecherche)
                    ElseIf ModeChinois = "Simpli" Then
                        AnalyseResultatsSimpli(sMotRecherche)
                    ElseIf ModeChinois = "Pinyin" Then
                        AnalyseResultatsPinyin(sMotRecherche)
                    End If
                End If
                'On selectionne le texte dans la barre de recherche
                Me.SelectNextControl(BtnSelectLangue, True, True, True, True)
                TxtMotRecherche.SelectAll()

            Else
                TabOnglets.TabPages(OngletCourant).Text = "Results"

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Starting search - Error !")
        End Try

    End Sub

    Private Sub BtnNewRecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnNewRecherche.Click
        Dim sMotRecherche As String
        Dim newOnglet As TabPage
        Dim newListResultats As RichTextBox

        Try
            'mot saisi dans la barre de recherche
            sMotRecherche = TxtMotRecherche.Text

            If sMotRecherche <> "" Then
                'Mesure du temps actuel
                TimeStart = TimeOfDay.Second

                'Creation d'une RichTextBox pour l'affichage, X=6 Y=6 Width=456 Height=461
                newListResultats = New RichTextBox()
                newListResultats.SetBounds(6, 6, 456, 461)
                newListResultats.BackColor() = Color.FromName("Control")
                newListResultats.ReadOnly() = True
                newListResultats.AllowDrop = True
                AddHandler newListResultats.MouseDown, AddressOf List_MouseDown
                AddHandler newListResultats.MouseMove, AddressOf List_MouseMove

                'Creation d'un nouvel onglet auquel on ajoute newListResultats
                CreationNouvelOnglet = True 'pour eviter de lancer ChgtOnglets
                newOnglet = New TabPage()
                newOnglet.Text = sMotRecherche
                newOnglet.Controls.Add(newListResultats)
                TabOnglets.TabPages.Add(newOnglet)
                'Reperage de l'onglet courant = c'est celui qu'on vient de creer
                OngletCourant = TabOnglets.TabCount - 1
                TabOnglets.SelectTab(OngletCourant)
                CreationNouvelOnglet = False 'creation terminee

                'On selectionne le texte dans la barre de recherche
                Me.SelectNextControl(BtnSelectLangue, True, True, True, True)
                TxtMotRecherche.SelectAll()

                'Initialisation des resultats pour le nouvel onglet
                ReDim Preserve TabResOrg(OngletCourant)
                ReDim TabResOrg(OngletCourant)(NbResPage - 1, 0)
                ReDim Preserve ListRes(OngletCourant)
                ListRes(OngletCourant) = newListResultats
                ReDim Preserve NbRes(OngletCourant)
                NbRes(OngletCourant) = 0
                ReDim Preserve NbPages(OngletCourant)
                NbPages(OngletCourant) = 1
                ReDim Preserve PageCourante(OngletCourant)
                PageCourante(OngletCourant) = 1
                ReDim Preserve TimeRes(OngletCourant)
                TimeRes(OngletCourant) = 0

                LblResultats.Text = NbRes(OngletCourant) & " results"
                LblPage.Text = "page " & PageCourante(OngletCourant) & "/" & NbPages(OngletCourant)
                LblTempsExe.Text = "(" & TimeRes(OngletCourant) & " sec.)"

                'Lancement de la recherche
                If VersChinois Then
                    AnalyseResultatsTraduc(sMotRecherche)
                Else
                    If ModeChinois = "Tradi" Then
                        AnalyseResultatsTradi(sMotRecherche)
                    ElseIf ModeChinois = "Simpli" Then
                        AnalyseResultatsSimpli(sMotRecherche)
                    ElseIf ModeChinois = "Pinyin" Then
                        AnalyseResultatsPinyin(sMotRecherche)
                    End If
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Starting new search - Error !")
        End Try

    End Sub

    Private Sub BtnPageSuivante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnPageSuivante.Click
        Try
            If PageCourante(OngletCourant) < NbPages(OngletCourant) Then
                AffichageResultats(PageCourante(OngletCourant))
                PageCourante(OngletCourant) = PageCourante(OngletCourant) + 1

                LblPage.Text = "page " & PageCourante(OngletCourant) & _
                "/" & NbPages(OngletCourant)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Next page - Error !")
        End Try
    End Sub

    Private Sub BtnPagePrecedente_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPagePrecedente.Click
        Try
            If PageCourante(OngletCourant) > 1 Then
                AffichageResultats(PageCourante(OngletCourant) - 2)
                PageCourante(OngletCourant) = PageCourante(OngletCourant) - 1

                LblPage.Text = "page " & PageCourante(OngletCourant) & _
                "/" & NbPages(OngletCourant)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Previous page - Error !")
        End Try
    End Sub

    Private Sub ChgtOnglet_SelectedIndexChanged _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TabOnglets.SelectedIndexChanged

        'test pour eviter les interferences avec BtnNewRecherche
        If Not CreationNouvelOnglet Then
            'Reperage de l'onglet courant
            OngletCourant = TabOnglets.SelectedIndex()

            LblTempsExe.Text = "(" & TimeRes(OngletCourant) & " sec.)"
            LblResultats.Text = NbRes(OngletCourant) & " results"
            LblPage.Text = "page " & PageCourante(OngletCourant) & "/" & NbPages(OngletCourant)
        End If

    End Sub

    Private Sub FermerOnglet_DoubleClick _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabOnglets.DoubleClick
        Dim iNbOnglets As Integer
        Dim i As Integer
        Dim oOnglet As TabPage

        'Reperage de l'onglet courant et du nombre actuel d'onglets
        OngletCourant = TabOnglets.SelectedIndex()
        iNbOnglets = TabOnglets.TabCount()

        'On ne fait rien s'il ne reste qu'un seul onglet
        If iNbOnglets > 1 Then

            For i = 0 To iNbOnglets - 2
                'Apres avoir passe l'indice de l'onglet courant
                If i >= OngletCourant Then
                    'on decale les elements du tableau vers la gauche
                    'l'element n°OngletCourant est alors efface, et le dernier n'est pas touche
                    TabResOrg(i) = TabResOrg(i + 1)
                    ListRes(i) = ListRes(i + 1)
                    NbRes(i) = NbRes(i + 1)
                    NbPages(i) = NbPages(i + 1)
                    PageCourante(i) = PageCourante(i + 1)
                    TimeRes(i) = TimeRes(i + 1)
                End If
            Next i
            's'il ne s'est rien passe, c'est que l'onglet courant est le dernier
            'dans tous les cas on supprime le dernier element du tableau
            ReDim Preserve TabResOrg(iNbOnglets - 2)
            ReDim Preserve ListRes(iNbOnglets - 2)
            ReDim Preserve NbRes(iNbOnglets - 2)
            ReDim Preserve NbPages(iNbOnglets - 2)
            ReDim Preserve PageCourante(iNbOnglets - 2)
            ReDim Preserve TimeRes(iNbOnglets - 2)

            'on supprime aussi l'onglet courant
            oOnglet = New TabPage()
            oOnglet = TabOnglets.TabPages(OngletCourant)
            TabOnglets.TabPages.Remove(oOnglet)

        End If

    End Sub


    'Procedures de recherche
    Private Sub AnalyseResultatsTradi(ByVal sMotRecherche As String)
        Dim tTabRes(0) As Word
        Dim sFichierXml As String
        Dim iNbRes As Integer
        Dim fTradiLength As New WordToInteger(AddressOf TradiLength)

        Try
            sFichierXml = FichierDico
            tTabRes = RechercheMotTradi(sMotRecherche, sFichierXml)
            iNbRes = tTabRes.Length

            If iNbRes = 1 Then
                'Aucun resultat trouve dans ce dico, on essaye dans son extension
                'MsgBox("Aucun résultat trouvé dans le dictionnaire de base", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).Clear()
                ListRes(OngletCourant).AppendText("No results found in the original dictionary" & vbNewLine)
                sFichierXml = Replace(FichierDico, ".xml", "_ext.xml")
                tTabRes = RechercheMotTradi(sMotRecherche, sFichierXml)
            End If

            iNbRes = tTabRes.Length
            If iNbRes = 1 Then
                'Le seul element de tTabRes est en fait un mot vide
                'MsgBox("Aucun résultat trouvé", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).AppendText("No results found")
                Beep()
            Else
                'On enleve le dernier element qui est en fait un mot vide
                ReDim Preserve tTabRes(iNbRes - 2)
                'On trie le tableau par ordre croissant du nombre de caracteres du mot chinois simplifie
                TriRapide(tTabRes, fTradiLength, 0, iNbRes - 2)

                'On lance la procedure d'affichage des resultats, a partir de TabRes
                OrganisationResultats(tTabRes)
            End If

        Catch ex As Exception
            DiffMaxChinois = 5

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Search Chinese - Error !")
        End Try
    End Sub

    Private Sub AnalyseResultatsSimpli(ByVal sMotRecherche As String)
        Dim tTabRes(0) As Word
        Dim sFichierXml As String
        Dim iNbRes As Integer
        Dim fSimpliLength As New WordToInteger(AddressOf SimpliLength)

        Try
            sFichierXml = FichierDico
            tTabRes = RechercheMotSimpli(sMotRecherche, sFichierXml)
            iNbRes = tTabRes.Length

            If iNbRes = 1 Then
                'Aucun resultat trouve dans ce dico, on essaye dans son extension
                'MsgBox("Aucun résultat trouvé dans le dictionnaire de base", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).Clear()
                ListRes(OngletCourant).AppendText("No results found in the original dictionary" & vbNewLine)
                sFichierXml = Replace(FichierDico, ".xml", "_ext.xml")
                tTabRes = RechercheMotSimpli(sMotRecherche, sFichierXml)
            End If

            iNbRes = tTabRes.Length
            If iNbRes = 1 Then
                'Le seul element de tTabRes est en fait un mot vide
                'MsgBox("Aucun résultat trouvé", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).AppendText("No results found")
                Beep()
            Else
                'On enleve le dernier element qui est en fait un mot vide
                ReDim Preserve tTabRes(iNbRes - 2)
                'On trie le tableau par ordre croissant du nombre de caracteres du mot chinois simplifie
                TriRapide(tTabRes, fSimpliLength, 0, iNbRes - 2)

                'On lance la procedure d'affichage des resultats, a partir de TabRes
                OrganisationResultats(tTabRes)
            End If

        Catch ex As Exception
            DiffMaxChinois = 5

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Search Chinese - Error !")
        End Try
    End Sub

    Private Sub AnalyseResultatsPinyin(ByVal sMotRecherche As String)
        Dim tTabRes() As Word
        Dim sFichierXml As String
        Dim iNbRes As Integer
        Dim fPinyinLength As New WordToInteger(AddressOf PinyinLength)

        Try
            sFichierXml = FichierDico
            tTabRes = RechercheMotPinyin(sMotRecherche, sFichierXml)
            iNbRes = tTabRes.Length

            If iNbRes = 1 Then
                'Aucun resultat trouve dans ce dico, on essaye dans son extension
                'MsgBox("Aucun résultat trouvé dans le dictionnaire de base", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).Clear()
                ListRes(OngletCourant).AppendText("No results found in the original dictionary" & vbNewLine)
                sFichierXml = Replace(FichierDico, ".xml", "_ext.xml")
                tTabRes = RechercheMotPinyin(sMotRecherche, sFichierXml)
            End If

            iNbRes = tTabRes.Length
            If iNbRes = 1 Then
                'Le seul element de tTabRes est en fait un mot vide
                'MsgBox("Aucun résultat trouvé", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).AppendText("No results found")
                Beep()
            Else
                'On enleve le dernier element qui est en fait un mot vide
                ReDim Preserve tTabRes(iNbRes - 2)
                'On trie le tableau par ordre croissant du nombre de caracteres du pinyin
                TriRapide(tTabRes, fPinyinLength, 0, iNbRes - 2)
                'On lance la procedure d'affichage des resultats, a partir de tTabRes
                OrganisationResultats(tTabRes)
            End If

        Catch ex As Exception
            DiffMaxPinyin = 10

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Search pinyin - Error !")
        End Try
    End Sub

    Private Sub AnalyseResultatsTraduc(ByVal sMotRecherche As String)
        Dim tTabRes(0) As Word
        Dim sFichierXml As String
        Dim iNbRes As Integer
        Dim fFirstTraducLength As New WordToInteger(AddressOf FirstTraducLength)

        Try
            sFichierXml = FichierDico
            tTabRes = RechercheMotTraduc(sMotRecherche, sFichierXml)
            iNbRes = tTabRes.Length

            If iNbRes = 1 Then
                'Aucun resultat trouve dans ce dico, on essaye dans son extension
                'MsgBox("Aucun résultat trouvé dans le dictionnaire de base", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).Clear()
                ListRes(OngletCourant).AppendText("No results found in the original dictionary" & vbNewLine)
                sFichierXml = Replace(FichierDico, ".xml", "_ext.xml")
                tTabRes = RechercheMotTraduc(sMotRecherche, sFichierXml)
            End If

            iNbRes = tTabRes.Length
            If iNbRes = 1 Then
                'Le seul element de tTabRes est en fait un mot vide
                'MsgBox("Aucun résultat trouvé", MsgBoxStyle.Information, "Recherche")
                ListRes(OngletCourant).AppendText("No results found")
                Beep()
            Else
                'On enleve le dernier element qui est en fait un mot vide
                ReDim Preserve tTabRes(iNbRes - 2)
                'On trie le tableau de resultats obtenu
                'par ordre croissant du nombre de caracteres de la premiere traduction
                TriRapide(tTabRes, fFirstTraducLength, 0, iNbRes - 2)

                'On lance la procedure d'affichage des resultats, a partir de TabRes
                OrganisationResultats(tTabRes)
            End If

        Catch ex As Exception
            DiffMaxFrancais = 20

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Search - Error !")
        End Try
    End Sub

    Private Function RechercheMotTradi(ByVal sMotRecherche As String, _
                                        ByVal sFichierXml As String) As Word()
        Dim xReader, xTraducReader As XmlReader
        Dim sTradi, sSimpli, sPinyin, sTraduc As String
        Dim wMotTrouve As Word
        Dim tTabRes(0) As Word
        Dim iNbRes As Integer

        'Lecteur du document .xml :
        xReader = New XmlTextReader(sFichierXml)

        'On parcourt le document xml avec le lecteur
        While xReader.Read()

            xReader.ReadToFollowing("traditional")
            sTradi = xReader.ReadString()

            'Si le caractère chinois lu correspond à notre recherche :
            If CBool(InStr(sTradi, sMotRecherche)) _
            And sTradi.Length - sMotRecherche.Length <= DiffMaxChinois Then
                'On stocke les resultats dans un objet "Word"
                wMotTrouve = New Word
                wMotTrouve.setTradi(sTradi)

                xReader.ReadToFollowing("simplified")
                sSimpli = xReader.ReadString()
                wMotTrouve.setSimpli(sSimpli)
                xReader.ReadToFollowing("pinyin")
                sPinyin = xReader.ReadString()
                wMotTrouve.setPinyin(sPinyin)

                xReader.ReadToFollowing("translations")
                'Nouveau lecteur pour le noeud des traductions
                xTraducReader = xReader.ReadSubtree
                While xTraducReader.Read()
                    xTraducReader.ReadToFollowing("translation")
                    sTraduc = xTraducReader.ReadString()
                    If sTraduc <> "" Then
                        wMotTrouve.setTraduc(sTraduc)
                    End If
                End While

                'l'objet Word est ajouté au tableau des résultats
                iNbRes = tTabRes.Length
                tTabRes(iNbRes - 1) = wMotTrouve
                ReDim Preserve tTabRes(iNbRes)
            End If

        End While

        Return tTabRes

    End Function

    Private Function RechercheMotSimpli(ByVal sMotRecherche As String, _
                                        ByVal sFichierXml As String) As Word()
        Dim xReader, xTraducReader As XmlReader
        Dim sTradi, sSimpli, sPinyin, sTraduc As String
        Dim wMotTrouve As Word
        Dim tTabRes(0) As Word
        Dim iNbRes As Integer

        'Lecteur du document .xml :
        xReader = New XmlTextReader(sFichierXml)

        'On parcourt le document xml avec le lecteur
        While xReader.Read()

            xReader.ReadToFollowing("traditional")
            sTradi = xReader.ReadString()
            xReader.ReadToFollowing("simplified")
            sSimpli = xReader.ReadString()

            'Si le caractère chinois lu correspond à notre recherche :
            If CBool(InStr(sSimpli, sMotRecherche)) _
            And sSimpli.Length - sMotRecherche.Length <= DiffMaxChinois Then
                'On stocke les resultats dans un objet "Word"
                wMotTrouve = New Word
                wMotTrouve.setSimpli(sSimpli)
                wMotTrouve.setTradi(sTradi)

                xReader.ReadToFollowing("pinyin")
                sPinyin = xReader.ReadString()
                wMotTrouve.setPinyin(sPinyin)

                xReader.ReadToFollowing("translations")
                'Nouveau lecteur pour le noeud des traductions
                xTraducReader = xReader.ReadSubtree
                While xTraducReader.Read()
                    xTraducReader.ReadToFollowing("translation")
                    sTraduc = xTraducReader.ReadString()
                    If sTraduc <> "" Then
                        wMotTrouve.setTraduc(sTraduc)
                    End If
                End While

                'l'objet Word est ajouté au tableau des résultats
                iNbRes = tTabRes.Length
                tTabRes(iNbRes - 1) = wMotTrouve
                ReDim Preserve tTabRes(iNbRes)
            End If

        End While

        Return tTabRes

    End Function

    Private Function RechercheMotPinyin(ByVal sMotRecherche As String, _
                                        ByVal sFichierXml As String) As Word()
        Dim xReader, xTraducReader As XmlReader
        Dim sTradi, sSimpli, sPinyin, sTraduc As String
        Dim wMotTrouve As Word
        Dim tTabRes(0) As Word
        Dim iNbRes As Integer

        'Lecteur du document .xml :
        xReader = New XmlTextReader(sFichierXml)

        'On parcourt le document xml avec le lecteur
        While xReader.Read()

            xReader.ReadToFollowing("traditional")
            sTradi = xReader.ReadString()
            xReader.ReadToFollowing("simplified")
            sSimpli = xReader.ReadString()
            xReader.ReadToFollowing("pinyin")
            sPinyin = xReader.ReadString()

            'Si le pinyin lu correspond à notre recherche :
            If ComparePinyin(sMotRecherche, sPinyin) _
            And sPinyin.Length - sMotRecherche.Length <= DiffMaxPinyin Then
                'On stocke les resultats dans un objet "Word"
                wMotTrouve = New Word
                wMotTrouve.setSimpli(sSimpli)
                wMotTrouve.setTradi(sTradi)
                wMotTrouve.setPinyin(sPinyin)

                xReader.ReadToFollowing("translations")
                'Nouveau lecteur pour le noeud des traductions
                xTraducReader = xReader.ReadSubtree
                While xTraducReader.Read()
                    xTraducReader.ReadToFollowing("translation")
                    sTraduc = xTraducReader.ReadString()
                    If sTraduc <> "" Then
                        wMotTrouve.setTraduc(sTraduc)
                    End If
                End While

                'l'objet Word est ajouté au tableau des résultats
                iNbRes = tTabRes.Length
                tTabRes(iNbRes - 1) = wMotTrouve
                ReDim Preserve tTabRes(iNbRes)
            End If

        End While

        Return tTabRes

    End Function

    Private Function RechercheMotTraduc(ByVal sMotRecherche As String, _
                                        ByVal sFichierXml As String) As Word()
        Dim xReader, xTraducReader As XmlReader
        Dim sTradi, sSimpli, sPinyin, sTraduc As String
        Dim wMotTrouve As Word
        Dim tTabRes(0) As Word
        Dim iNbRes As Integer

        'Lecteur du document .xml :
        xReader = New XmlTextReader(sFichierXml)

        'On parcourt le document xml avec le lecteur
        While xReader.Read()

            xReader.ReadToFollowing("traditional")
            sTradi = xReader.ReadString()

            'Si on n'a pas atteint la fin du dictionnaire
            If sTradi <> "" Then

                xReader.ReadToFollowing("simplified")
                sSimpli = xReader.ReadString()
                xReader.ReadToFollowing("pinyin")
                sPinyin = xReader.ReadString()

                xReader.ReadToFollowing("translations")
                'Nouveau lecteur pour le noeud des traductions
                xTraducReader = xReader.ReadSubtree
                While xTraducReader.Read()
                    xTraducReader.ReadToFollowing("translation")
                    sTraduc = xTraducReader.ReadString()

                    'Si la traduction lue correspond à notre recherche :
                    If CompareTraduc(sMotRecherche, sTraduc) _
                    And sTraduc.Length - sMotRecherche.Length <= DiffMaxFrancais Then
                        'On stocke les resultats dans un objet "Word"
                        wMotTrouve = New Word
                        wMotTrouve.setSimpli(sSimpli)
                        wMotTrouve.setTradi(sTradi)
                        wMotTrouve.setPinyin(sPinyin)
                        wMotTrouve.setTraduc(sTraduc)
                        'On ajoute aussi les traductions suivantes du mot trouvé
                        While xTraducReader.Read()
                            xTraducReader.ReadToFollowing("translation")
                            sTraduc = xTraducReader.ReadString()
                            If sTraduc <> "" Then
                                wMotTrouve.setTraduc(sTraduc)
                            End If
                        End While

                        'l'objet Word est ajouté au tableau des résultats
                        iNbRes = tTabRes.Length
                        tTabRes(iNbRes - 1) = wMotTrouve
                        ReDim Preserve tTabRes(iNbRes)
                    End If
                End While

            End If

        End While

        Return tTabRes

    End Function

    Private Function ComparePinyin(ByVal sPinyin As String, ByVal sPinyinSource As String) As Boolean
        'sPinyin est de la forme : pin yin
        'sPinyinSource est de la forme : pin1yin1
        Dim Resultat As Boolean
        Dim tPinyin() As String
        Dim i As Integer

        'Si le pinyin recherche n'est fait que d'une syllabe
        If Not CBool(InStr(sPinyin, " ")) Then
            Resultat = CBool(InStr(sPinyinSource, sPinyin))

            'Sinon le pinyin recherche est fait de plusieurs syllabes separees par des espaces
        Else
            tPinyin = sPinyin.Split(" ")
            'Si la taille du pinyin recherche sans les espaces depasse celle de sPinyinSource
            If sPinyinSource.Length < sPinyin.Length - tPinyin.Length + 1 Then
                Resultat = False
            Else
                'Sinon le resultat est vrai a condition que toutes les syllabes du pinyin
                'soient presentes dans sPinyinSource
                Resultat = True
                For i = 0 To tPinyin.Length - 1
                    If Not CBool(InStr(sPinyinSource, tPinyin(i))) Then
                        Resultat = False
                    End If
                Next i
            End If
        End If

        Return Resultat
    End Function

    Private Function CompareTraduc(ByVal sTraduc As String, ByVal sTraducSource As String) As Boolean
        Dim Resultat As Boolean = False
        Dim tTraduc As String()
        Dim i As Integer

        'Si la taille de l'expression recherchee depasse celle de sTraducSource
        If sTraducSource.Length < sTraduc.Length Then
            Resultat = False

        Else
            'Si l'expression recherchee n'est faite que d'un seul mot
            If Not CBool(InStr(sTraduc, " ")) Then
                'Si ce mot apparait delimite par 1 ou 2 espaces
                If sTraduc = sTraducSource _
                Or CBool(InStr(sTraducSource, " " & sTraduc)) _
                Or CBool(InStr(sTraducSource, sTraduc & " ")) _
                Or CBool(InStr(sTraducSource, " " & sTraduc & " ")) Then
                    Resultat = True
                Else
                    Resultat = False
                End If

                'Sinon l'expression recherchee est faite de plusieurs mots
                'separes par des espaces
            Else
                tTraduc = sTraduc.Split(" ")
                'Le resultat est vrai a condition que tous les mots de l'expression recherchee
                'soient presents dans sTraducSource, delimites par 1 ou 2 espaces
                Resultat = True
                For i = 0 To tTraduc.Length - 1
                    If Not (CBool(InStr(sTraducSource, " " & tTraduc(i))) _
                    Or CBool(InStr(sTraducSource, tTraduc(i) & " ")) _
                    Or CBool(InStr(sTraducSource, " " & tTraduc(i) & " "))) Then
                        Resultat = False
                    End If
                Next i
            End If

        End If

        Return Resultat
    End Function


    'Fonctions utiles aux procedures de recherche
    Public Sub TriRapide(ByVal tTab() As Word, ByVal fInt As WordToInteger, _
                         ByVal iStart As Integer, ByVal iEnd As Integer)
        'Algorithme de tri "QuickSort" tire de Wikipedia
        'Il tri un tableau de Word selon les valeurs que donne la fonction fInt(Word)
        Dim iPivot As Integer
        Dim NewiPivot As Integer
        If iStart < iEnd Then
            iPivot = CInt(Rnd() * (iEnd - iStart) + iStart)
            NewiPivot = PartitionTab(tTab, fInt, iStart, iEnd, iPivot)
            TriRapide(tTab, fInt, iStart, NewiPivot - 1)
            TriRapide(tTab, fInt, NewiPivot + 1, iEnd)
        End If
    End Sub

    Public Function PartitionTab(ByVal tTab() As Word, ByVal fInt As WordToInteger, _
                                 ByVal iStart As Integer, ByVal iEnd As Integer, _
                                 ByVal iPivot As Integer) As Integer
        Dim iVal As Word
        Dim i, j As Integer
        iVal = tTab(iPivot)
        tTab(iPivot) = tTab(iEnd)
        tTab(iEnd) = iVal
        j = iStart
        For i = iStart To iEnd - 1
            If fInt(tTab(i)) <= fInt(tTab(iEnd)) Then
                iVal = tTab(i)
                tTab(i) = tTab(j)
                tTab(j) = iVal
                j = j + 1
            End If
        Next i
        iVal = tTab(j)
        tTab(j) = tTab(iEnd)
        tTab(iEnd) = iVal
        Return j
    End Function

    Private Function TradiLength(ByVal wMot As Word) As Integer
        'Retourne le nombre de caracteres composant le mot chinois d'un element word du dico
        Return wMot.Tradi.Length
    End Function

    Private Function SimpliLength(ByVal wMot As Word) As Integer
        'Retourne le nombre de caracteres composant le mot chinois d'un element word du dico
        Return wMot.Simpli.Length
    End Function

    Private Function PinyinLength(ByVal wMot As Word) As Integer
        'Retourne la longueur du pinyin d'un element word du dico
        Return wMot.Pinyin.Length
    End Function

    Private Function FirstTraducLength(ByVal wMot As Word) As Integer
        'Retourne la longueur de la premiere traduction d'un element word du dico
        Return wMot.Traduc(0).Length
    End Function


    'Procedures d'organisation et d'affichage des resultats
    Private Sub OrganisationResultats(ByVal tTabRes() As Word)
        Dim i, j, k As Integer
        'Nombre de resultats par page = NbResPage

        Try
            'Nombre total de resultats :
            NbRes(OngletCourant) = tTabRes.Length()
            i = 0
            j = 0
            'Remplissage de TabResOrg : en colonne les resultats par page, en ligne les pages
            While i + j * NbResPage < NbRes(OngletCourant)
                'On initialise d'abord la page pour ne pas avoir de probleme de definition
                'des elements du tableau si la page n'est pas complete ensuite
                For k = 0 To NbResPage - 1
                    TabResOrg(OngletCourant)(k, j) = New Word
                Next k
                'On remplit ensuite la page
                While i + j * NbResPage < NbRes(OngletCourant) And i < NbResPage
                    TabResOrg(OngletCourant)(i, j) = tTabRes(i + j * NbResPage)
                    i = i + 1
                End While
                j = j + 1
                'On ajoute une ligne a TabResOrg = on ajoute une page de resultats
                ReDim Preserve TabResOrg(OngletCourant)(NbResPage - 1, j)
                i = 0
            End While
            'Le nombre de pages est :
            NbPages(OngletCourant) = j
            'La page courante est :
            PageCourante(OngletCourant) = 1

            LblResultats.Text = NbRes(OngletCourant) & " results"
            LblPage.Text = "page " & PageCourante(OngletCourant) & "/" & NbPages(OngletCourant)
            TimeEnd = TimeOfDay.Second
            TimeRes(OngletCourant) = TimeEnd - TimeStart
            If TimeRes(OngletCourant) < 0 Then
                TimeRes(OngletCourant) = TimeRes(OngletCourant) + 60
            End If
            LblTempsExe.Text = "(" & TimeRes(OngletCourant) & " sec.)"

            AffichageResultats(PageCourante(OngletCourant) - 1)

        Catch ex As Exception
            'En cas de probleme, reinitialisation des parametres
            NbResPage = 10

            ReDim TabFontSimpli(0)
            TabFontSimpli(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Bold)
            FontColorSimpli = Color.Black
            ReDim TabFontTradi(0)
            TabFontTradi(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Regular)
            FontColorTradi = Color.DarkGray

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Show results - Error !")
        End Try

    End Sub

    Public Sub AffichageResultats(ByVal iPage As Integer)
        Dim i, j As Integer
        Dim sTradi, sSimpli, sPinyin, sNewPinyin, sTraduc As String

        ListRes(OngletCourant).Clear()

        For i = 0 To NbResPage - 1
            If Not TabResOrg(OngletCourant)(i, iPage).isWordNothing Then

                sSimpli = TabResOrg(OngletCourant)(i, iPage).Simpli
                ListRes(OngletCourant).SelectionFont = TabFontSimpli(0)
                ListRes(OngletCourant).SelectionColor = FontColorSimpli
                ListRes(OngletCourant).SelectionAlignment = HorizontalAlignment.Left
                ListRes(OngletCourant).AppendText(sSimpli & "   ")
                ListRes(OngletCourant).SelectionStart = ListRes(OngletCourant).TextLength()
                ListRes(OngletCourant).SelectionLength = sSimpli.Length + 3

                sTradi = TabResOrg(OngletCourant)(i, iPage).Tradi
                ListRes(OngletCourant).SelectionFont = TabFontTradi(0)
                ListRes(OngletCourant).SelectionColor = FontColorTradi
                ListRes(OngletCourant).AppendText(sTradi & vbNewLine)
                ListRes(OngletCourant).SelectionStart = ListRes(OngletCourant).TextLength()
                ListRes(OngletCourant).SelectionLength = sTradi.Length

                sPinyin = TabResOrg(OngletCourant)(i, iPage).Pinyin
                ListRes(OngletCourant).SelectionFont = New System.Drawing.Font("Arial", 12)
                ListRes(OngletCourant).SelectionAlignment = HorizontalAlignment.Left
                sNewPinyin = EditeurPinyin(Replace(sPinyin, """", ""))
                ListRes(OngletCourant).AppendText(sNewPinyin & vbNewLine)
                ListRes(OngletCourant).SelectionStart = ListRes(OngletCourant).TextLength
                ListRes(OngletCourant).SelectionLength = sPinyin.Length - 2

                ListRes(OngletCourant).SelectionAlignment = HorizontalAlignment.Left
                For j = 0 To TabResOrg(OngletCourant)(i, iPage).Traduc.Length - 2
                    sTraduc = TabResOrg(OngletCourant)(i, iPage).Traduc(j)
                    ListRes(OngletCourant).SelectionFont = _
                    New System.Drawing.Font("Times New Roman", 14, FontStyle.Italic)
                    ListRes(OngletCourant).SelectionColor = Color.DarkViolet
                    ListRes(OngletCourant).AppendText(" - " & sTraduc & vbNewLine)
                    ListRes(OngletCourant).SelectionStart = ListRes(OngletCourant).TextLength
                    ListRes(OngletCourant).SelectionLength = sTraduc.Length + 3
                Next j

                ListRes(OngletCourant).AppendText(vbNewLine & vbNewLine)
            End If
        Next i

        ListRes(OngletCourant).SelectionStart = 0

    End Sub


    'Fonctions utiles a l'affichage des resultats
    Public Function AccentLettre(ByVal cLettre As Char, ByVal cAccent As Char) As String
        Dim sLettreAccentue As String = ""

        'Renvoie le caractere Unicode accentue sous forme d'un string
        'pour une voyelle cLettre suivie de son numero de ton/accent cAccent
        'cAccent = "5" signifie "pas de ton" // cLettre = ":" signifie "u" avec trema
        If cLettre = "a" Then
            If cAccent = "1" Then
                sLettreAccentue = "ā"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "á"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ǎ"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "à"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "a"
            End If
        ElseIf cLettre = "e" Then
            If cAccent = "1" Then
                sLettreAccentue = "ē"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "é"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ě"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "è"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "e"
            End If
        ElseIf cLettre = "i" Then
            If cAccent = "1" Then
                sLettreAccentue = "ī"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "í"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ǐ"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "ì"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "i"
            End If
        ElseIf cLettre = "o" Then
            If cAccent = "1" Then
                sLettreAccentue = "ō"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "ó"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ǒ"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "ò"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "o"
            End If
        ElseIf cLettre = "u" Then
            If cAccent = "1" Then
                sLettreAccentue = "ū"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "ú"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ǔ"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "ù"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "u"
            End If
        ElseIf cLettre = ":" Then
            If cAccent = "1" Then
                sLettreAccentue = "ǖ"
            ElseIf cAccent = "2" Then
                sLettreAccentue = "ǘ"
            ElseIf cAccent = "3" Then
                sLettreAccentue = "ǚ"
            ElseIf cAccent = "4" Then
                sLettreAccentue = "ǜ"
            ElseIf cAccent = "5" Then
                sLettreAccentue = "ü"
            End If
        End If

        Return sLettreAccentue
    End Function

    Public Function EditeurPinyin(ByVal sPinyin As String) As String
        'sPinyin est de la forme : xiao3lu:3cha1 ou xiao3lü3cha1
        Dim sMot, sResultat, sMotCut() As String
        Dim iCharPosition, j As Integer
        Dim cNumTon As Char
        Dim MotFinish As Boolean

        sResultat = ""
        iCharPosition = 0
        'Tant que notre marqueur iCharPosition pointe toujours dans sPinyin
        While iCharPosition < sPinyin.Length

            sMot = ""
            MotFinish = False
            While Not MotFinish And iCharPosition < sPinyin.Length
                'Si le marqueur pointe sur un chiffre, la boucle s'arrete
                If IsNumeric(sPinyin.Chars(iCharPosition)) Then
                    MotFinish = True
                Else 'Sinon on remplit sMot et on avance
                    sMot = sMot & sPinyin.Chars(iCharPosition)
                    iCharPosition = iCharPosition + 1
                End If
            End While

            'Si on n'a pas rencontre de chiffre, on a alors avance jusqu'a la fin du mot sPinyin
            'Le resultat est trivial : sMot ne change pas
            If iCharPosition = sPinyin.Length Then
                sResultat = sResultat & sMot

                'Sinon la boucle s'est arrete car le marqueur pointe sur un chiffre
                'Il reste donc des caracteres (au moins 1 = le chiffre)
            ElseIf iCharPosition < sPinyin.Length Then
                'Ce chiffre nous donne le ton de la voyelle 
                cNumTon = sPinyin.Chars(iCharPosition)

                'Pour la suite on recupere sMot qui represente la syllable pinyin en cours
                'Reste a determiner la voyelle sur laquelle le ton va s'appliquer
                j = 0
                MotFinish = False
                'Tant qu'on boucle dans sMot
                While Not MotFinish And j < sMot.Length
                    'Une premiere apparition de "a" "e" "o" ou "ü" termine la boucle
                    'C'est sur cette lettre que sera le ton
                    If sMot.Chars(j) = "a" Then
                        sMotCut = sMot.Split("a")
                        sMot = sMotCut(0) & AccentLettre("a", cNumTon) & sMotCut(1)
                        sResultat = sResultat & sMot & " "
                        MotFinish = True
                    ElseIf sMot.Chars(j) = "e" Then
                        sMotCut = sMot.Split("e")
                        sMot = sMotCut(0) & AccentLettre("e", cNumTon) & sMotCut(1)
                        sResultat = sResultat & sMot & " "
                        MotFinish = True
                    ElseIf sMot.Chars(j) = "o" Then
                        sMotCut = sMot.Split("o")
                        sMot = sMotCut(0) & AccentLettre("o", cNumTon) & sMotCut(1)
                        sResultat = sResultat & sMot & " "
                        MotFinish = True
                    ElseIf sMot.Chars(j) = "ü" Then
                        sMotCut = sMot.Split("ü")
                        sMot = sMotCut(0) & AccentLettre(":", cNumTon) & sMotCut(1)
                        sResultat = sResultat & sMot & " "
                        MotFinish = True
                        'Le ton est sur "i" ou "u" s'il s'agit de la derniere lettre de sMot
                        'ou s'il n'y a pas d'autres voyelles derriere
                    ElseIf sMot.Chars(j) = "i" Then
                        'Si j pointe sur le dernier caractere de sMot
                        If j = sMot.Length - 1 Then
                            sMotCut = sMot.Split("i")
                            sMot = sMotCut(0) & AccentLettre("i", cNumTon) & sMotCut(1)
                            sResultat = sResultat & sMot & " "
                            MotFinish = True
                        ElseIf j < sMot.Length - 1 Then
                            'Sinon si la prochaine lettre n'est pas une voyelle
                            If sMot.Chars(j + 1) <> "a" And sMot.Chars(j + 1) <> "e" _
                            And sMot.Chars(j + 1) <> "o" And sMot.Chars(j + 1) <> "u" Then
                                sMotCut = sMot.Split("i")
                                sMot = sMotCut(0) & AccentLettre("i", cNumTon) & sMotCut(1)
                                sResultat = sResultat & sMot & " "
                                MotFinish = True
                            End If
                        End If
                    ElseIf sMot.Chars(j) = "u" Then
                        'Si j pointe sur le dernier caractere de sMot
                        If j = sMot.Length - 1 Then
                            sMotCut = sMot.Split("u")
                            sMot = sMotCut(0) & AccentLettre("u", cNumTon) & sMotCut(1)
                            sResultat = sResultat & sMot & " "
                            MotFinish = True
                        ElseIf j < sMot.Length - 1 Then
                            'Sinon si la prochaine lettre n'est pas une voyelle ou ":"
                            If sMot.Chars(j + 1) <> "a" And sMot.Chars(j + 1) <> "e" _
                            And sMot.Chars(j + 1) <> "o" And sMot.Chars(j + 1) <> "i" _
                            And sMot.Chars(j + 1) <> ":" Then
                                sMotCut = sMot.Split("u")
                                sMot = sMotCut(0) & AccentLettre("u", cNumTon) & sMotCut(1)
                                sResultat = sResultat & sMot & " "
                                MotFinish = True
                                'Cas special pour "u" les ":" indique un trema sur le "u"
                                'Si le prochain caractere est ":"
                            ElseIf sMot.Chars(j + 1) = ":" Then
                                sMotCut = sMot.Split("u")
                                sMot = sMotCut(0) & AccentLettre(":", cNumTon) & sMotCut(1)
                                sMot = Replace(sMot, ":", "")
                                sResultat = sResultat & sMot & " "
                                MotFinish = True
                            End If
                        End If
                    End If

                    j = j + 1
                End While
            End If

            'Une fois le travail termine sur sMot,
            'sResultat a ete complete et on avance dans la lecture de sPinyin
            iCharPosition = iCharPosition + 1
        End While

        Return sResultat
    End Function


    'Fonctions de lecture et sauvegarde des fichiers config
    Public Function LecturePolices(ByVal sFichierConfigPolice As String) As Object()
        Dim readerPolice As StreamReader
        Dim sLine As String, iIndex As Integer
        Dim tFontSimpli(), tFontTradi() As System.Drawing.Font
        Dim sName As String, fStyle As System.Drawing.FontStyle, iTaille As Integer
        Dim cColorSimpli, cColorTradi As System.Drawing.Color

        'le fichier config_police.txt contient les polices dernierement utilisees
        readerPolice = New StreamReader(sFichierConfigPolice)
        sLine = readerPolice.ReadLine() 'sLine : "---FontSimpli"
        sLine = readerPolice.ReadLine() 'sLine : nom de la 1° police simpli
        iIndex = 0
        ReDim tFontSimpli(iIndex)
        While Not readerPolice.EndOfStream And sLine <> "---FontColorSimpli"
            sName = sLine 'sLine : nom de police
            sLine = readerPolice.ReadLine() 'sLine : style de police
            If sLine = "Regular" Then
                fStyle = FontStyle.Regular
            ElseIf sLine = "Bold" Then
                fStyle = FontStyle.Bold
            ElseIf sLine = "Italic" Then
                fStyle = FontStyle.Italic
            ElseIf sLine = "Underline" Then
                fStyle = FontStyle.Underline
            ElseIf sLine = "Strikeout" Then
                fStyle = FontStyle.Strikeout
            End If
            sLine = readerPolice.ReadLine() 'sLine : taille de police
            iTaille = CInt(sLine)
            ReDim Preserve tFontSimpli(iIndex)
            tFontSimpli(iIndex) = New System.Drawing.Font(sName, iTaille, fStyle)

            iIndex = iIndex + 1
            sLine = readerPolice.ReadLine()
        End While
        sLine = readerPolice.ReadLine() 'sLine : integer argb de la couleur
        cColorSimpli = Color.FromArgb(CInt(sLine))

        sLine = readerPolice.ReadLine() 'sLine : "---FontTradi"
        sLine = readerPolice.ReadLine() 'sLine : nom de la 1° police tradi
        iIndex = 0
        ReDim tFontTradi(iIndex)
        While Not readerPolice.EndOfStream And sLine <> "---FontColorTradi"
            sName = sLine 'nom de police
            sLine = readerPolice.ReadLine() 'style de police
            If sLine = "Regular" Then
                fStyle = FontStyle.Regular
            ElseIf sLine = "Bold" Then
                fStyle = FontStyle.Bold
            ElseIf sLine = "Italic" Then
                fStyle = FontStyle.Italic
            ElseIf sLine = "Underline" Then
                fStyle = FontStyle.Underline
            ElseIf sLine = "Strikeout" Then
                fStyle = FontStyle.Strikeout
            End If
            sLine = readerPolice.ReadLine() 'taille de police
            iTaille = CInt(sLine)
            ReDim Preserve tFontTradi(iIndex)
            tFontTradi(iIndex) = New System.Drawing.Font(sName, iTaille, fStyle)

            iIndex = iIndex + 1
            sLine = readerPolice.ReadLine()
        End While
        sLine = readerPolice.ReadLine() 'sLine : integer argb de la couleur
        cColorTradi = Color.FromArgb(CInt(sLine))

        readerPolice.Close()

        Dim ResLecture() As Object = {tFontSimpli, cColorSimpli, tFontTradi, cColorTradi}
        Return ResLecture

    End Function

    Public Function LectureParametres(ByVal sFichierConfigParametres As String) As Integer()
        Dim readerParametres As StreamReader
        Dim sLine As String
        Dim iResPage, iDiffPinyin, iDiffChinois, iDiffFrancais As Integer

        'le fichier config_parametres.txt contient les parametres dernierement utilises
        readerParametres = New StreamReader(sFichierConfigParametres)
        sLine = readerParametres.ReadLine() 'sLine : "---NbResPage"
        sLine = readerParametres.ReadLine()
        iResPage = CInt(sLine)
        sLine = readerParametres.ReadLine() 'sLine : "---DiffMaxPinyin"
        sLine = readerParametres.ReadLine()
        iDiffPinyin = CInt(sLine)
        sLine = readerParametres.ReadLine() 'sLine : "---DiffMaxChinois"
        sLine = readerParametres.ReadLine()
        iDiffChinois = CInt(sLine)
        sLine = readerParametres.ReadLine() 'sLine : "---DiffMaxFrancais"
        sLine = readerParametres.ReadLine()
        iDiffFrancais = CInt(sLine)

        readerParametres.Close()

        Dim ResLecture As Integer() = {iResPage, iDiffPinyin, iDiffChinois, iDiffFrancais}
        Return ResLecture

    End Function

    Public Function LectureLangue(ByVal sFichierConfigLangue As String) As Object()
        Dim readerLangue As StreamReader
        Dim sLine As String
        Dim sLangue, sMode As String
        Dim bVersChinois As Boolean

        'le fichier config_parametres.txt contient les parametres dernierement utilises
        readerLangue = New StreamReader(sFichierConfigLangue)
        sLine = readerLangue.ReadLine() 'sLine : "---LangueStart"
        sLine = readerLangue.ReadLine()
        sLangue = sLine
        sLine = readerLangue.ReadLine() 'sLine : "---ModeChinois"
        sLine = readerLangue.ReadLine()
        sMode = sLine
        sLine = readerLangue.ReadLine() 'sLine : "---VersChinois"
        sLine = readerLangue.ReadLine()
        If sLine = "True" Then
            bVersChinois = True
        Else
            bVersChinois = False
        End If

        readerLangue.Close()

        Dim ResLecture As Object() = {sLangue, sMode, bVersChinois}
        Return ResLecture

    End Function

    Public Sub SauvegardePolices(ByVal sFichierConfigPolice As String, _
                                 ByVal tFontSimpli() As Font, ByVal cColorSimpli As Color, _
                                 ByVal tFontTradi() As Font, ByVal cColorTradi As Color)
        Dim writerPolice As StreamWriter
        Dim sLine As String
        Dim i As Integer

        writerPolice = New StreamWriter(sFichierConfigPolice, False, Encoding.Unicode)
        sLine = "---FontSimpli"
        writerPolice.WriteLine(sLine)
        For i = 0 To tFontSimpli.Length - 1
            sLine = tFontSimpli(i).Name
            writerPolice.WriteLine(sLine)
            If tFontSimpli(i).Bold Then
                sLine = "Bold"
            ElseIf tFontSimpli(i).Italic Then
                sLine = "Italic"
            ElseIf tFontSimpli(i).Underline Then
                sLine = "Underline"
            ElseIf tFontSimpli(i).Strikeout Then
                sLine = "Strikeout"
            Else
                sLine = "Regular"
            End If
            writerPolice.WriteLine(sLine)
            sLine = tFontSimpli(i).Size.ToString()
            writerPolice.WriteLine(sLine)
        Next i
        sLine = "---FontColorSimpli"
        writerPolice.WriteLine(sLine)
        sLine = cColorSimpli.ToArgb.ToString()
        writerPolice.WriteLine(sLine)

        sLine = "---FontTradi"
        writerPolice.WriteLine(sLine)
        For i = 0 To tFontTradi.Length - 1
            sLine = tFontTradi(i).Name
            writerPolice.WriteLine(sLine)
            If tFontTradi(i).Bold Then
                sLine = "Bold"
            ElseIf tFontTradi(i).Italic Then
                sLine = "Italic"
            ElseIf tFontTradi(i).Underline Then
                sLine = "Underline"
            ElseIf tFontTradi(i).Strikeout Then
                sLine = "Strikeout"
            Else
                sLine = "Regular"
            End If
            writerPolice.WriteLine(sLine)
            sLine = tFontTradi(i).Size.ToString()
            writerPolice.WriteLine(sLine)
        Next i
        sLine = "---FontColorTradi"
        writerPolice.WriteLine(sLine)
        sLine = cColorTradi.ToArgb.ToString()
        writerPolice.WriteLine(sLine)

        writerPolice.Close()

    End Sub

    Public Sub SauvegardeParametres(ByVal sFichierConfigParametres As String, _
                                    ByVal iResPage As Integer, ByVal iDiffChinois As Integer, _
                                    ByVal iDiffPinyin As Integer, ByVal iDiffFrancais As Integer)
        Dim writerParametres As StreamWriter
        Dim sLine As String

        writerParametres = New StreamWriter(sFichierConfigParametres)
        sLine = "---NbResPage"
        writerParametres.WriteLine(sLine)
        sLine = iResPage.ToString()
        writerParametres.WriteLine(sLine)
        sLine = "---DiffMaxPinyin"
        writerParametres.WriteLine(sLine)
        sLine = iDiffPinyin.ToString()
        writerParametres.WriteLine(sLine)
        sLine = "---DiffMaxChinois"
        writerParametres.WriteLine(sLine)
        sLine = iDiffChinois.ToString()
        writerParametres.WriteLine(sLine)
        sLine = "---DiffMaxFrancais"
        writerParametres.WriteLine(sLine)
        sLine = iDiffFrancais.ToString()
        writerParametres.WriteLine(sLine)

        writerParametres.Close()

    End Sub

    Public Sub SauvegardeLangue(ByVal sFichierConfigLangue As String, _
                                    ByVal sLangue As String, ByVal sMode As String, _
                                    ByVal bVersChinois As Boolean)
        Dim writerLangue As StreamWriter
        Dim sLine As String

        writerLangue = New StreamWriter(sFichierConfigLangue)
        sLine = "---LangueStart"
        writerLangue.WriteLine(sLine)
        sLine = sLangue
        writerLangue.WriteLine(sLine)
        sLine = "---ModeChinois"
        writerLangue.WriteLine(sLine)
        sLine = sMode
        writerLangue.WriteLine(sLine)
        sLine = "---VersChinois"
        writerLangue.WriteLine(sLine)
        If bVersChinois Then
            sLine = "True"
        Else
            sLine = "False"
        End If
        writerLangue.WriteLine(sLine)

        writerLangue.Close()

    End Sub


    'Drag & Drop de la liste de resultats sur la barre de recherche
    Private DragDropActif As Boolean = False

    Private Sub List_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim List As RichTextBox
        List = New RichTextBox()
        List = sender
        'Cela sert a lancer le drag&drop seulement quand un bout de texte a ete selectionne
        If List.SelectedText() <> "" Then
            DragDropActif = True
            ToolTipDico.SetToolTip(List, "Glisser-déposer dans la barre de recherche")
        End If

    End Sub

    Private Sub List_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim List As RichTextBox
        List = New RichTextBox()
        List = sender
        'Si un bout de texte a deja ete selectionne, alors on lance le drag&drop
        If DragDropActif Then
            List.DoDragDrop(List.SelectedText(), DragDropEffects.Copy)
        End If
        DragDropActif = False
    End Sub

    Private Sub TxtMotRecherche_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) _
    Handles TxtMotRecherche.DragEnter
        'On verifie le format des donnees qui vont etre copiees
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            'On affiche le curseur qui autorise la copie
            e.Effect = DragDropEffects.Copy
        Else
            'On affiche le curseur qui interdit la copie
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TxtMotRecherche_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) _
    Handles TxtMotRecherche.DragDrop
        'On colle le texte (cela efface le precedent dans la barre de recherche)
        TxtMotRecherche.Text = e.Data.GetData(DataFormats.Text)
    End Sub


    'Caracteres speciaux pour le francais et l'allemand
    Private Sub LinkEaigu_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkEaigu.LinkClicked
        TxtMotRecherche.AppendText("é")
    End Sub

    Private Sub LinkEgrave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkEgrave.LinkClicked
        TxtMotRecherche.AppendText("è")
    End Sub

    Private Sub LinkAgrave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkAgrave.LinkClicked
        TxtMotRecherche.AppendText("à")
    End Sub

    Private Sub LinkUgrave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUgrave.LinkClicked
        TxtMotRecherche.AppendText("ù")
    End Sub

    Private Sub LinkCcedille_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCcedille.LinkClicked
        TxtMotRecherche.AppendText("ç")
    End Sub

    Private Sub LinkEtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkEtrema.LinkClicked
        TxtMotRecherche.AppendText("ë")
    End Sub

    Private Sub LinkItrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkItrema.LinkClicked
        TxtMotRecherche.AppendText("ï")
    End Sub

    Private Sub LinkAtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkAtrema.LinkClicked
        TxtMotRecherche.AppendText("ä")
    End Sub

    Private Sub LinkUtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUtrema.LinkClicked
        TxtMotRecherche.AppendText("ü")
    End Sub

    Private Sub LinkOtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkOtrema.LinkClicked
        TxtMotRecherche.AppendText("ö")
    End Sub

    Private Sub LinkSset_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkSset.LinkClicked
        TxtMotRecherche.AppendText("ß")
    End Sub

    Private Sub LinkAAtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkAAtrema.LinkClicked
        TxtMotRecherche.AppendText("Ä")
    End Sub

    Private Sub LinkUUtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUUtrema.LinkClicked
        TxtMotRecherche.AppendText("Ü")
    End Sub

    Private Sub LinkOOtrema_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkOOtrema.LinkClicked
        TxtMotRecherche.AppendText("Ö")
    End Sub

    Private Sub MenuAfficherCaractFra_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAfficherCaractFra.Click
        GroupLettresFra.Visible = True
    End Sub

    Private Sub MenuMasquerCaractFra_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasquerCaractFra.Click
        GroupLettresFra.Visible = False
    End Sub

    Private Sub MenuAfficherCaractAllem_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAfficherCaractAllem.Click
        GroupLettresAllem.Visible = True
    End Sub

    Private Sub MenuMasquerCaractAllem_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasquerCaractAllem.Click
        GroupLettresAllem.Visible = False
    End Sub

End Class

