Imports System.IO
Imports System.Xml
Imports System.Text

Public Class ConvertFichierDico

    Private Sub ConvertFichierDico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DicoMain.OpenFileDialog.Title = "Enter the dictionary database file to convert"
        DicoMain.OpenFileDialog.InitialDirectory = Application.StartupPath + "\data"
    End Sub

    Private Sub BtnSelectFichier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnSelectFichier.Click

        If DicoMain.OpenFileDialog.ShowDialog() = DialogResult.OK Then
            TxtFichier.Text = DicoMain.OpenFileDialog.FileName()
        End If

    End Sub

    Private Sub BtnConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConversion.Click
        Dim sFichierU8, sFichierXML As String
        Dim readerU8 As StreamReader
        Dim writerXML As XmlTextWriter
        Dim sLineDico, sComment As String
        Dim ResLigne() As Object
        Dim i, j As Integer

        Try
            'Affichage progress bar
            LblConversion.Visible = True
            ProgressBar.Visible = True

            'Le fichier a convertir au format .txt ou .u8
            sFichierU8 = TxtFichier.Text()
            'Nom du fichier converti en xml
            sFichierXML = Replace(sFichierU8, ".u8", ".xml")
            readerU8 = New StreamReader(sFichierU8)
            writerXML = New XmlTextWriter(sFichierXML, Encoding.UTF8)
            writerXML.Formatting = Formatting.Indented
            writerXML.Indentation = 2
            'Initialisation du document XML
            writerXML.WriteStartDocument()

            'Compte le nombre de lignes du fichier u8
            j = 0
            While Not readerU8.EndOfStream
                readerU8.ReadLine()
                j = j + 1
            End While
            ProgressBar.Minimum = 0
            ProgressBar.Maximum = j
            ProgressBar.Value = 1

            'Reinitialisation du reader
            readerU8 = New StreamReader(sFichierU8)

            sLineDico = readerU8.ReadLine()
            sComment = vbNewLine
            'Si la premiere ligne est un commentaire (reperee par "#" dans le fichier txt)
            While sLineDico.First = "#"
                sComment = sComment & sLineDico & vbNewLine
                sLineDico = readerU8.ReadLine()
            End While
            'On affecte le commentaire au début
            writerXML.WriteComment(sComment)
            'On demarre le dico, a ce niveau sLineDico n'est plus un commentaire
            writerXML.WriteStartElement("dic")

            While Not readerU8.EndOfStream
                ResLigne = LigneDicoSplit(sLineDico)

                writerXML.WriteStartElement("word")
                writerXML.WriteElementString("traditional", ResLigne(0))
                writerXML.WriteElementString("simplified", ResLigne(1))
                writerXML.WriteElementString("pinyin", ResLigne(2))
                writerXML.WriteStartElement("translations")
                For i = 1 To ResLigne(3).Length - 2
                    writerXML.WriteStartElement("translation")
                    writerXML.WriteCData(ResLigne(3)(i))
                    writerXML.WriteEndElement()
                Next i
                writerXML.WriteEndElement()
                writerXML.WriteEndElement()
                'Lecture de la ligne suivante
                sLineDico = readerU8.ReadLine()

                ProgressBar.Value = ProgressBar.Value + 1
            End While

            'On repete tout le processus pour la derniere ligne du fichier txt
            ResLigne = LigneDicoSplit(sLineDico)

            writerXML.WriteStartElement("word")
            writerXML.WriteElementString("traditional", ResLigne(0))
            writerXML.WriteElementString("simplified", ResLigne(1))
            writerXML.WriteElementString("pinyin", ResLigne(2))
            writerXML.WriteStartElement("translations")
            For i = 1 To ResLigne(3).Length - 2
                writerXML.WriteStartElement("translation")
                writerXML.WriteCData(ResLigne(3)(i))
                writerXML.WriteEndElement()
            Next i
            writerXML.WriteEndElement()
            writerXML.WriteEndElement()

            'Fin de l'element <dic>
            writerXML.WriteEndElement()
            'Fin du document
            writerXML.WriteEndDocument()
            writerXML.Close()
            readerU8.Close()
            LblConversion.Visible = False
            ProgressBar.Visible = False

            MsgBox("Conversion done!", _
                   MsgBoxStyle.Information, "XML conversion")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "XML conversion - Error !")
        End Try

    End Sub

    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnnuler.Click
        Me.Close()
    End Sub

    Private Function LigneDicoSplit(ByVal sLineDico As String) As Object()
        Dim tChinois(), tSinogrammes() As String
        Dim sTradi, sSimpli, sPinyin, tTraduc() As String

        sTradi = ""
        sSimpli = ""
        sPinyin = ""

        'Syntaxe de base :
        '中國 中国 [zhong1 guo2] /Chine/Empire du milieu/.../

        'On separe la ligne entre d'un cote ce qui concerne le chinois et de l'autre
        'les traductions, elles-memes separees
        tTraduc = Split(sLineDico, "/")

        If CBool(InStr(tTraduc(0), "[")) Then
            'La syntaxe de base est correcte, a priori pas d'erreur pour le cote chinois
            'On separe les sinogrammes du pinyin
            tChinois = Split(tTraduc(0), "[")
            'On separe les sinogrammes entre traditionnel et simplifie
            tSinogrammes = Split(RTrim(tChinois(0)), " ")
            sTradi = tSinogrammes(0)
            sSimpli = tSinogrammes(1)
            'On enleve tous les espaces et on met des guillemets >> "zhong1guo2"
            sPinyin = """" & Replace(Replace(tChinois(1), " ", ""), "]", """")
        End If

        Dim ResLigne() As Object = {sTradi, sSimpli, sPinyin, tTraduc}
        Return ResLigne

    End Function

End Class