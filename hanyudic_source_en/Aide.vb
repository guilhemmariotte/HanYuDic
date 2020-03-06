Imports System.IO
Imports System.Text

Public Class Aide

    Private Sub Aide_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim readerTexteIntro As StreamReader
        Dim sLine As String

        Try
            ListTexteIntro.Clear()
            readerTexteIntro = New StreamReader("txt\txt_aide.txt", Encoding.Unicode)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Ouverture Aide - Error !")
        End Try
    End Sub

End Class