Public Class Parametres

    Private Sub Parametres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ChoixNbResPage.Value = DicoMain.NbResPage
            ChoixNbResPage.Minimum = 1

            ChoixDiffMaxChinois.Value = DicoMain.DiffMaxChinois
            ChoixDiffMaxPinyin.Value = DicoMain.DiffMaxPinyin
            ChoixDiffMaxFrancais.Value = DicoMain.DiffMaxFrancais

        Catch ex As Exception
            DicoMain.NbResPage = 10
            DicoMain.DiffMaxChinois = 5
            DicoMain.DiffMaxPinyin = 10
            DicoMain.DiffMaxFrancais = 20

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Loading parameters - Error !")
        End Try
        
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        DicoMain.NbResPage = ChoixNbResPage.Value
        DicoMain.DiffMaxChinois = ChoixDiffMaxChinois.Value
        DicoMain.DiffMaxPinyin = ChoixDiffMaxPinyin.Value
        DicoMain.DiffMaxFrancais = ChoixDiffMaxFrancais.Value

        Me.Close()
    End Sub

    Private Sub BtnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnnuler.Click
        Me.Close()
    End Sub

End Class