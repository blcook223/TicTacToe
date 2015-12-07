Public Class OptionsForm
    ' OptionsForm class
    ' Represents a form allowing the user to select options

    Public Event OptionsChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()
        ' New sub
        ' Constructs a new options form

        InitializeComponent()
        If PlayAsPlayer1 Then
            Call Me.PlayAsPlayer1RadioButton.Select()
        Else
            Call Me.PlayAsPlayer2RadioButton.Select()
        End If
        If PlayVsCPU Then
            Call Me.PlayVsCPURadioButton.Select()
        Else
            Call Me.PlayVsHumanRadioButton.Select()
        End If
    End Sub ' New

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKButton.Click
        ' OKButton_Click sub
        ' Saves the options selected by the user

        PlayVsCPU = Me.PlayVsCPURadioButton.Checked
        PlayAsPlayer1 = Me.PlayAsPlayer1RadioButton.Checked
        RaiseEvent OptionsChanged(Me, New EventArgs)
        Call Me.Dispose()
    End Sub ' OKButton_Click

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelOptionsButton.Click
        ' CancelButton_Click sub
        ' Closes the options form

        Call Me.Dispose()
    End Sub ' CancelButton_Click

End Class ' OptionsForm