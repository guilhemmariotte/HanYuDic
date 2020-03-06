Imports System.Xml

Public Class AjoutMot

    Private Sub AjoutMot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Dim sFichierXml As String

        sFichierXml = Replace(DicoMain.FichierDico, ".xml", "_ext.xml")
        'Texte d'intro
        LblIntro.Text = "The new entry will be added to the extension of the current dictionary: " _
        & "Chinese/" & DicoMain.ListSelectLangue.Text & vbNewLine & "HanYuDic\" & sFichierXml

        'Drag&Drop pour les champs de saisie
        AddHandler TxtMotTradi.DragEnter, AddressOf TxtBarre_DragEnter
        AddHandler TxtMotTradi.DragDrop, AddressOf TxtBarre_DragDrop

        AddHandler TxtMotSimpli.DragEnter, AddressOf TxtBarre_DragEnter
        AddHandler TxtMotSimpli.DragDrop, AddressOf TxtBarre_DragDrop

        AddHandler TxtMotPinyin.DragEnter, AddressOf TxtBarre_DragEnter
        AddHandler TxtMotPinyin.DragDrop, AddressOf TxtBarre_DragDrop

        AddHandler TxtMotsTraduc.DragEnter, AddressOf TxtBarre_DragEnter
        AddHandler TxtMotsTraduc.DragDrop, AddressOf TxtBarre_DragDrop

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnOK.Click
        Dim xDoc As XmlDocument
        Dim xRacineDico, xWord As XmlNode
        Dim lxNoeudsDico, lxNoeudsWord As XmlNodeList
        Dim i As Integer
        Dim sSimpli As String
        Dim sFichierXml As String
        Dim isNewMot As Boolean = True

        Try
            If TxtMotTradi.Text <> "" And TxtMotSimpli.Text <> "" _
            And TxtMotPinyin.Text <> "" And TxtMotsTraduc.Text <> "" Then

                'On charge le fichier ..dict_ext.xml, l'extension du fichier dico de base
                sFichierXml = Replace(DicoMain.FichierDico, ".xml", "_ext.xml")
                xDoc = New XmlDocument()
                xDoc.Load(sFichierXml)
                xRacineDico = xDoc.DocumentElement()
                lxNoeudsDico = xRacineDico.ChildNodes()
                xWord = lxNoeudsDico.ItemOf(0)

                i = 0
                While i < lxNoeudsDico.Count And isNewMot
                    xWord = lxNoeudsDico.ItemOf(i)
                    lxNoeudsWord = xWord.ChildNodes()
                    sSimpli = lxNoeudsWord.ItemOf(1).InnerText()
                    If sSimpli = TxtMotSimpli.Text Then
                        'Si le mot en chinois simplifie est identique a une entree du dico
                        'alors ce mot est deja present, mais peut-etre avec d'autres traductions
                        isNewMot = False
                    End If
                    i = i + 1
                End While

                If isNewMot Then
                    'Si le mot n'est pas deja present dans le dico, on l'ajoute
                    AjouterMot(xDoc)
                    xDoc.Save(sFichierXml)
                    MessageBox.Show("Entry added", "Add entry", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim msgAvert As MsgBoxResult
                    msgAvert = MsgBox("This entry already exists" & vbNewLine & _
                                      "Do you want to delete it and replace it by this new one?", _
                                      MsgBoxStyle.YesNo, "Add entry")
                    If msgAvert = MsgBoxResult.Yes Then
                        xRacineDico.RemoveChild(xWord)
                        AjouterMot(xDoc)
                        xDoc.Save(sFichierXml)
                        MessageBox.Show("Entry replaced", "Add entry", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf msgAvert = MsgBoxResult.No Then
                        MessageBox.Show("Entry canceled", "Add entry", _
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Else
                MsgBox("Missing fields for this new entry", _
                       MsgBoxStyle.Critical, "Add entry - Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Add entry - Error !")
        End Try

    End Sub

    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Sub AjouterMot(ByVal xDoc As XmlDocument)
        Dim xNewWord, xTradi, xSimpli, xPinyin, xTraducs, xTraduc, xTraducCDATA As XmlNode
        Dim i As Integer
        Dim tsTraduc() As String

        'On cree un nouvel element "word" et on l'ajoute au dico
        xNewWord = xDoc.CreateNode(XmlNodeType.Element, "word", "")
        xDoc.DocumentElement.AppendChild(xNewWord)

        'On rentre le caractere traditionnel et on l'ajoute au word
        xTradi = xDoc.CreateNode(XmlNodeType.Element, "traditional", "")
        xTradi.InnerText = TxtMotTradi.Text
        xNewWord.AppendChild(xTradi)

        'On rentre le caractere simplifie et on l'ajoute au word
        xSimpli = xDoc.CreateNode(XmlNodeType.Element, "simplified", "")
        xSimpli.InnerText = TxtMotSimpli.Text
        xNewWord.AppendChild(xSimpli)

        'On rentre le pinyin auquel on ajoute des guillemets et on l'ajoute au word
        xPinyin = xDoc.CreateNode(XmlNodeType.Element, "pinyin", "")
        xPinyin.InnerText = """" & TxtMotPinyin.Text & """"
        xNewWord.AppendChild(xPinyin)

        'On cree l'element "translations" et on l'ajoute au word
        xTraducs = xDoc.CreateNode(XmlNodeType.Element, "translations", "")
        xNewWord.AppendChild(xTraducs)
        tsTraduc = Split(TxtMotsTraduc.Text, ";")
        For i = 0 To tsTraduc.Length - 1
            'on cree l'element "translation" et on l'ajoute a translations
            xTraduc = xDoc.CreateNode(XmlNodeType.Element, "translation", "")
            xTraducs.AppendChild(xTraduc)
            'on cree l'element en CData et on l'ajoute a translation
            xTraducCDATA = xDoc.CreateNode(XmlNodeType.CDATA, "", "")
            xTraducCDATA.InnerText = tsTraduc(i)
            xTraduc.AppendChild(xTraducCDATA)
        Next i

    End Sub


    'Drag & Drop
    Private Sub TxtBarre_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs)
        Dim TxtBarre As TextBox
        TxtBarre = New TextBox()
        TxtBarre = sender

        'On verifie le format des donnees qui vont etre copiees
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            'On affiche le curseur qui autorise la copie
            e.Effect = DragDropEffects.Copy
        Else
            'On affiche le curseur qui interdit la copie
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TxtBarre_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
        Dim TxtBarre As TextBox
        TxtBarre = New TextBox()
        TxtBarre = sender

        'On colle le texte (cela efface le precedent dans la barre de recherche)
        TxtBarre.Text = e.Data.GetData(DataFormats.Text)
    End Sub

End Class