Imports System.IO
Imports System.Text

Public Class MiseAjour

    Private Sub MiseAjour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim readerTexteIntro As StreamReader
        Dim sLine As String

        Try
            ListTexteIntro.Clear()
            readerTexteIntro = New StreamReader("txt\txt_miseajour.txt", Encoding.Unicode)
            While Not readerTexteIntro.EndOfStream
                sLine = readerTexteIntro.ReadLine()
                If sLine = "" Then
                    ListTexteIntro.AppendText(vbNewLine)
                Else
                    ListTexteIntro.AppendText(sLine)
                End If
            End While
            readerTexteIntro.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Opening update info text - Error !")
        End Try

        DicoMain.ToolTipDico.SetToolTip _
        (LinkCfdictU8, "http://www.chine-informations.com/chinois/open/CFDICT/download.php")
        'DicoMain.ToolTipDico.SetToolTip _
        '(LinkCfdictXML, "http://www.chine-informations.com/chinois/open/CFDICT/download.php?file=xml")
        DicoMain.ToolTipDico.SetToolTip _
        (LinkSiteCfdict, "http://chine.in/mandarin/dictionnaire/CFDICT/")
        DicoMain.ToolTipDico.SetToolTip _
        (LinkCedictU8, "https://www.mdbg.net/chindict/export/cedict/cedict_1_0_ts_utf-8_mdbg.zip")
        DicoMain.ToolTipDico.SetToolTip _
        (LinkSiteCedict, "https://www.mdbg.net/chindict/chindict.php?page=cedict")
        DicoMain.ToolTipDico.SetToolTip _
        (LinkHandedictU8, "https://github.com/zydeo/HanDeDict/blob/master/handedict.u8")
        DicoMain.ToolTipDico.SetToolTip _
        (LinkSiteHandedict, "http://www.handedict.de/chinesisch_deutsch.php?mode=dl")

    End Sub


    'Liens vers les pages web et telechargements
    Private Sub LinkCfdictU8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCfdictU8.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("http://www.chine-informations.com/chinois/open/CFDICT/download.php")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkCfdictXML_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            System.Diagnostics.Process.Start _
            ("http://www.chine-informations.com/chinois/open/CFDICT/download.php?file=xml")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkSiteCfdict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkSiteCfdict.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("http://chine.in/mandarin/dictionnaire/CFDICT/")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkCedictU8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkCedictU8.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("https://www.mdbg.net/chindict/export/cedict/cedict_1_0_ts_utf-8_mdbg.zip")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkSiteCedict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkSiteCedict.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("https://www.mdbg.net/chindict/chindict.php?page=cedict")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkHandedictU8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkHandedictU8.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("https://github.com/zydeo/HanDeDict/blob/master/handedict.u8")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

    Private Sub LinkSiteHandedict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkSiteHandedict.LinkClicked
        Try
            System.Diagnostics.Process.Start _
            ("http://www.handedict.de/chinesisch_deutsch.php?mode=dl")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Download link - Error !")
        End Try

    End Sub

End Class