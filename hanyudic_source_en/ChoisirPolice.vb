Imports System.Math
Imports System.IO

Public Class ChoisirPolice

    'Lancement
    Private Sub ChoisirPolice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Dim i As Integer
        Dim iNbFontSimpli, iNbFontTradi As Integer

        Try
            'Entree de la liste de polices en memoire pour le chinois simplifie
            iNbFontSimpli = DicoMain.TabFontSimpli.Length
            For i = 0 To iNbFontSimpli - 1
                SelectPoliceChinoisSimpli(DicoMain.TabFontSimpli(iNbFontSimpli - 1 - i))
            Next i
            BtnColorSimpli.BackColor() = DicoMain.FontColorSimpli

            'Entree de la liste de polices en memoire pour le chinois traditionnel
            iNbFontTradi = DicoMain.TabFontTradi.Length
            For i = 0 To iNbFontTradi - 1
                SelectPoliceChinoisTradi(DicoMain.TabFontTradi(iNbFontTradi - 1 - i))
            Next i
            BtnColorTradi.BackColor() = DicoMain.FontColorTradi

        Catch ex As Exception
            ReDim DicoMain.TabFontSimpli(0)
            DicoMain.TabFontSimpli(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Bold)
            DicoMain.FontColorSimpli = Color.Black
            SelectPoliceChinoisSimpli(DicoMain.TabFontSimpli(0))
            BtnColorSimpli.BackColor = DicoMain.FontColorSimpli

            ReDim DicoMain.TabFontTradi(0)
            DicoMain.TabFontTradi(0) = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Regular)
            DicoMain.FontColorTradi = Color.DarkGray
            SelectPoliceChinoisTradi(DicoMain.TabFontTradi(0))
            BtnColorTradi.BackColor = DicoMain.FontColorTradi

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading fonts - Error !")
        End Try

    End Sub


    'Boutons de selection des parametres de police
    Private Sub BtnPoliceChinoisSimpli_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnPoliceChinoisSimpli.Click

        If DicoMain.FontDialogChinois.ShowDialog() = DialogResult.OK Then
            SelectPoliceChinoisSimpli(DicoMain.FontDialogChinois.Font)
        End If

    End Sub

    Private Sub BtnPoliceChinoisTradi_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnPoliceChinoisTradi.Click

        If DicoMain.FontDialogChinois.ShowDialog() = DialogResult.OK Then
            SelectPoliceChinoisTradi(DicoMain.FontDialogChinois.Font)
        End If

    End Sub

    Private Sub BtnColorSimpli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnColorSimpli.Click

        If DicoMain.ColorDialogChinois.ShowDialog() = DialogResult.OK Then
            BtnColorSimpli.BackColor = DicoMain.ColorDialogChinois.Color()
        End If

    End Sub

    Private Sub BtnColorTradi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnColorTradi.Click

        If DicoMain.ColorDialogChinois.ShowDialog() = DialogResult.OK Then
            BtnColorTradi.BackColor = DicoMain.ColorDialogChinois.Color()
        End If

    End Sub

    Private Sub LblSetFontDefaut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LblSetFontDefaut.Click
        Dim fontParDefaut1, fontParDefaut2 As System.Drawing.Font

        fontParDefaut1 = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Bold)
        SelectPoliceChinoisSimpli(fontParDefaut1)
        BtnColorSimpli.BackColor = Color.Black

        fontParDefaut2 = New System.Drawing.Font("Microsoft Sans Serif", 28, FontStyle.Regular)
        SelectPoliceChinoisTradi(fontParDefaut2)
        BtnColorTradi.BackColor = Color.DarkGray

    End Sub


    'Validation/enregistrement du choix - Annulation
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnOK.Click
        Dim sName As String
        Dim fStyle As System.Drawing.FontStyle
        Dim iTaille As Integer
        Dim i As Integer

        Try
            'Enregistrement des polices selectionnees pour le chinois simplifie
            'on place d'abord la police choisie en tete de la liste
            ListFontSimpli.Items.Insert(0, ListFontSimpli.SelectedItem)
            ListFontSimpli.Items.RemoveAt(ListFontSimpli.SelectedIndex())
            'on stocke ensuite toute la liste dans le tableau TabFontSimpli
            ReDim DicoMain.TabFontSimpli(ListFontSimpli.Items.Count - 1)
            For i = 0 To ListFontSimpli.Items.Count - 1
                sName = ListFontSimpli.Items.Item(i).ToString()
                If ListFontStyleSimpli.SelectedIndex() = 0 Then
                    fStyle = FontStyle.Regular
                ElseIf ListFontStyleSimpli.SelectedIndex() = 1 Then
                    fStyle = FontStyle.Bold
                ElseIf ListFontStyleSimpli.SelectedIndex() = 2 Then
                    fStyle = FontStyle.Italic
                ElseIf ListFontStyleSimpli.SelectedIndex() = 3 Then
                    fStyle = FontStyle.Underline
                ElseIf ListFontStyleSimpli.SelectedIndex() = 4 Then
                    fStyle = FontStyle.Strikeout
                End If
                iTaille = CInt(ListFontTailleSimpli.SelectedItem.ToString)

                DicoMain.TabFontSimpli(i) = New System.Drawing.Font(sName, iTaille, fStyle)
            Next i
            'Enregistrement de la couleur selectionnee
            DicoMain.FontColorSimpli = BtnColorSimpli.BackColor()

            'Enregistrement des polices selectionnees pour le chinois traditionnel
            'on place d'abord la police choisie en tete de la liste
            ListFontTradi.Items.Insert(0, ListFontTradi.SelectedItem)
            ListFontTradi.Items.RemoveAt(ListFontTradi.SelectedIndex())
            'on stocke ensuite toute la liste dans le tableau TabFontTradi
            ReDim DicoMain.TabFontTradi(ListFontTradi.Items.Count - 1)
            For i = 0 To ListFontTradi.Items.Count - 1
                sName = ListFontTradi.Items.Item(i).ToString()
                If ListFontStyleTradi.SelectedIndex() = 0 Then
                    fStyle = FontStyle.Regular
                ElseIf ListFontStyleTradi.SelectedIndex() = 1 Then
                    fStyle = FontStyle.Bold
                ElseIf ListFontStyleTradi.SelectedIndex() = 2 Then
                    fStyle = FontStyle.Italic
                ElseIf ListFontStyleTradi.SelectedIndex() = 3 Then
                    fStyle = FontStyle.Underline
                ElseIf ListFontStyleTradi.SelectedIndex() = 4 Then
                    fStyle = FontStyle.Strikeout
                End If
                iTaille = CInt(ListFontTailleTradi.SelectedItem.ToString)

                DicoMain.TabFontTradi(i) = New System.Drawing.Font(sName, iTaille, fStyle)
            Next i
            'Enregistrement de la couleur selectionnee
            DicoMain.FontColorTradi = BtnColorTradi.BackColor()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Saving parameters - Error !")
        End Try

        Me.Close()
    End Sub

    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnAnnuler.Click
        Me.Close()
    End Sub


    'Procedures de selection des champs dispo en fonction fontChoisie
    Private Sub SelectPoliceChinoisSimpli(ByVal fontChoisie As System.Drawing.Font)
        Dim sName As String
        Dim bNewFont As Boolean
        Dim iFontChoisie As Integer
        Dim iTaille As Integer
        Dim i As Integer

        'Recuperation du nom de la police, et sauvegarde si celui-ci ne l'a pas encore ete
        If ListFontSimpli.Items.Count < 1 Then
            ListFontSimpli.Items.Add(fontChoisie.Name)
            ListFontSimpli.SelectedIndex() = 0
        Else
            bNewFont = True
            For i = 0 To ListFontSimpli.Items.Count - 1
                sName = ListFontSimpli.Items.Item(i).ToString()
                If fontChoisie.Name = sName Then
                    bNewFont = False
                    iFontChoisie = i
                End If
            Next i
            If bNewFont Then 'si on ajoute une nouvelle police a la liste
                ListFontSimpli.Items.Insert(0, fontChoisie.Name)
                ListFontSimpli.SelectedIndex() = 0
                'On limite a 10 le nombre de polices dans la liste des dernieres utilisees
                'si on insere une 11eme nouvelle police, la derniere de la liste est effacee
                If ListFontSimpli.Items.Count > 10 Then
                    ListFontSimpli.Items.RemoveAt(10)
                End If
            Else 'sinon, on selectionne juste la police choisie
                ListFontSimpli.SelectedIndex() = iFontChoisie
            End If
        End If
        'Recuperation du style de cette police
        If fontChoisie.Bold Then
            ListFontStyleSimpli.SelectedIndex() = 1
        ElseIf fontChoisie.Italic Then
            ListFontStyleSimpli.SelectedIndex() = 2
        ElseIf fontChoisie.Underline Then
            ListFontStyleSimpli.SelectedIndex() = 3
        ElseIf fontChoisie.Strikeout Then
            ListFontStyleSimpli.SelectedIndex() = 4
        Else
            ListFontStyleSimpli.SelectedIndex() = 0
        End If
        'Recuperation de la taille de cette police
        For i = 0 To ListFontTailleSimpli.Items.Count - 1
            iTaille = CInt(ListFontTailleSimpli.Items.Item(i).ToString)
            If Abs(fontChoisie.Size - iTaille) < 0.5 Then
                ListFontTailleSimpli.SelectedIndex() = i
            End If
        Next i

    End Sub

    Private Sub SelectPoliceChinoisTradi(ByVal fontChoisie As System.Drawing.Font)
        Dim sName As String
        Dim bNewFont As Boolean
        Dim iFontChoisie As Integer
        Dim iTaille As Integer
        Dim i As Integer

        'Recuperation du nom de la police, et sauvegarde si celui-ci ne l'a pas encore ete
        If ListFontTradi.Items.Count < 1 Then
            ListFontTradi.Items.Add(fontChoisie.Name)
            ListFontTradi.SelectedIndex() = 0
        Else
            bNewFont = True
            For i = 0 To ListFontTradi.Items.Count - 1
                sName = ListFontTradi.Items.Item(i).ToString()
                If fontChoisie.Name = sName Then
                    bNewFont = False
                    iFontChoisie = i
                End If
            Next i
            If bNewFont Then 'si on ajoute une nouvelle police a la liste
                ListFontTradi.Items.Insert(0, fontChoisie.Name)
                ListFontTradi.SelectedIndex() = 0
                'On limite a 10 le nombre de polices dans la liste des dernieres utilisees
                'si on insere une 11eme nouvelle police, la derniere de la liste est effacee
                If ListFontTradi.Items.Count > 10 Then
                    ListFontTradi.Items.RemoveAt(10)
                End If
            Else 'sinon, on place juste la police choisie en tete de la liste
                ListFontTradi.SelectedIndex() = iFontChoisie
            End If
        End If
        'Recuperation du style de cette police
        If fontChoisie.Bold Then
            ListFontStyleTradi.SelectedIndex() = 1
        ElseIf fontChoisie.Italic Then
            ListFontStyleTradi.SelectedIndex() = 2
        ElseIf fontChoisie.Underline Then
            ListFontStyleTradi.SelectedIndex() = 3
        ElseIf fontChoisie.Strikeout Then
            ListFontStyleTradi.SelectedIndex() = 4
        Else
            ListFontStyleTradi.SelectedIndex() = 0
        End If
        'Recuperation de la taille de cette police
        For i = 0 To ListFontTailleTradi.Items.Count - 1
            iTaille = CInt(ListFontTailleTradi.Items.Item(i).ToString)
            If Abs(fontChoisie.Size - iTaille) < 0.5 Then
                ListFontTailleTradi.SelectedIndex() = i
            End If
        Next i

    End Sub

End Class