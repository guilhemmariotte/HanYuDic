Public Class Word
    Public Tradi As String
    Public Simpli As String
    Public Pinyin As String
    Public Traduc(0) As String

    Public Sub setTradi(ByVal sTradi As String)
        Me.Tradi = sTradi
    End Sub

    Public Sub setSimpli(ByVal sSimpli As String)
        Me.Simpli = sSimpli
    End Sub

    Public Sub setPinyin(ByVal sPinyin As String)
        Me.Pinyin = sPinyin
    End Sub

    Public Sub setTraduc(ByVal sTraduc As String)
        Dim N As Integer
        N = Me.Traduc.Length
        Me.Traduc(N - 1) = sTraduc
        ReDim Preserve Me.Traduc(N)
    End Sub

    Public Function isWordNothing() As Boolean
        If Me.Tradi = Nothing And Me.Simpli = Nothing And Me.Pinyin = Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
