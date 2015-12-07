Public Class MainForm
    ' MainForm class
    ' Represents a form for playing tic tac toe
    'TODO: edit application to use settings

#Region "Fields"

    Private m_currentGame As Game
    Private m_squares() As SquareControl
    Private WithEvents m_aboutBox As TicTacToeAboutBox
    Private WithEvents m_optionsForm As OptionsForm

#End Region ' Fields

#Region "Methods"

    Public Sub New()
        ' New sub
        ' Constructs a new main form

        Call InitializeComponent()
        PlayVsCPU = False
        PlayAsPlayer1 = True
    End Sub ' New

    Friend Sub StartNewGame()
        ' StartNewGame sub
        ' Starts a new game of tic tac toe

        If Not m_currentGame Is Nothing Then Call m_currentGame.AbortGame()
        m_currentGame = New Game(m_squares)
        Call m_currentGame.Start()
    End Sub ' StartNewGame

#End Region ' Methods

#Region "Event handlers"

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' MainForm_Load sub
        ' Initializes the form for a new game

        ' initialize squares
        ReDim m_squares(0% To 8%)
        For pos As Int32 = 0% To 8%
            m_squares(pos) = New SquareControl
            m_squares(pos).Location = New Point(10% + (110% * (pos Mod 3%)), 10% + (110% * (pos \ 3)))
            Call Me.MainFormPanel.Controls.Add(m_squares(pos))
        Next pos

        ' start a game
        Call StartNewGame()
    End Sub ' MainForm_Load

    Private Sub NewGameMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewGameMenuItem.Click
        ' NewGameMenuItem_Click sub
        ' Starts a new game of tic tac toe

        Call StartNewGame()
    End Sub ' NewGameMenuItem_Click

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AboutMenuItem.Click
        ' AboutToolStripMenuItem_Click sub
        ' Displays an about box

        If Not m_aboutBox Is Nothing AndAlso Not m_aboutBox.IsDisposed Then Call m_aboutBox.Dispose()
        m_aboutBox = New TicTacToeAboutBox
        Call m_aboutBox.Show()
        Call m_aboutBox.Focus()
    End Sub ' AboutToolStripMenuItem_Click

    Private Sub OptionsMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OptionsMenuItem.Click
        ' OptionsMenuItem_Click sub
        ' Launches an options form

        If Not m_optionsForm Is Nothing AndAlso Not m_optionsForm.IsDisposed Then Call m_optionsForm.Dispose()
        m_optionsForm = New OptionsForm
        Call m_optionsForm.Show()
        Call m_optionsForm.Focus()
    End Sub 'OptionsMenuItem_Click

    Private Sub OptionsChanged(ByVal sender As Object, ByVal e As EventArgs) Handles m_optionsForm.OptionsChanged
        ' OptionsChanged sub
        ' Starts a new game

        Call StartNewGame()
    End Sub ' OptionsChanged

#End Region ' Event handlers

End Class ' MainForm
