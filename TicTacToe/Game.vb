Public Class Game
    ' Game class
    ' Represents a game of tic tac toe

#Region "Fields and properties"

    Private m_squares() As SquareControl
    Private m_isPlayer1Turn As Boolean = True
    Private m_players(1%) As TicTacToePlayer

    Public ReadOnly Property Square(ByVal index As Int32) As SquareControl
        Get
            Return m_squares(index)
        End Get
    End Property ' Square

#End Region ' Fields and properties

#Region "Public methods"

    Public Sub Start()
        ' Start sub
        ' Starts a new game

        For pos As Int32 = 0% To 8%
            Call Me.Square(pos).DisplayBlank()
        Next pos
        Call startTurn(1%)
    End Sub ' Start

    Public Sub New(ByVal squares() As SquareControl)
        ' New sub
        ' Initializes a game of tic tac toe

        m_squares = squares
        If PlayVsCPU Then
            If PlayAsPlayer1 Then
                m_players(0%) = New HumanPlayer(squares, SquareStatusOptions.X, 1%)
                m_players(1%) = New CPUPlayer(squares, SquareStatusOptions.O, 2%)
            Else
                m_players(0%) = New CPUPlayer(squares, SquareStatusOptions.X, 1%)
                m_players(1%) = New HumanPlayer(squares, SquareStatusOptions.O, 2%)
            End If
        Else
            m_players(0%) = New HumanPlayer(squares, SquareStatusOptions.X, 1%)
            m_players(1%) = New HumanPlayer(squares, SquareStatusOptions.O, 2%)
        End If
    End Sub ' New

    Public Sub EndGame(ByVal winner As TicTacToePlayer)
        ' EndGame sub
        ' Ends the game

        MessageBox.Show(String.Format("{0} wins!", winner.ToString))
        Call Me.AbortGame()
    End Sub ' EndGame

    Public Sub AbortGame()
        ' AbortGame sub
        ' Aborts the game

        For i As Int32 = 0% To 1%
            Call m_players(i).Abort()
        Next i
        If m_isPlayer1Turn Then
            RemoveHandler m_players(0%).TurnTaken, AddressOf playerTurnTaken
        Else
            RemoveHandler m_players(1%).TurnTaken, AddressOf playerTurnTaken
        End If
    End Sub ' AbortGame

#End Region ' Public methods

#Region "Private methods"

    Private Sub startTurn(ByVal playerNum As Int32)
        ' startTurn sub
        ' Starts a turn for the player who has the parameter number

        AddHandler m_players(playerNum - 1%).TurnTaken, AddressOf playerTurnTaken
        Call m_players(playerNum - 1%).TakeTurn()
    End Sub ' startTurn

    Private Sub playerTurnTaken(ByVal sender As Object, ByVal e As EventArgs)
        ' playerTurnTaken sub
        ' Handles the event raised when a player takes a turn

        ' check for winner
        If isWinner() Then
            Call EndGame(DirectCast(sender, TicTacToePlayer))
            Exit Sub
        End If
        If catWins() Then
            Call EndGame(New CatPlayer)
            Exit Sub
        End If
        m_isPlayer1Turn = Not m_isPlayer1Turn
        If m_isPlayer1Turn Then
            RemoveHandler m_players(1%).TurnTaken, AddressOf playerTurnTaken
            Call startTurn(1%)
        Else
            RemoveHandler m_players(0%).TurnTaken, AddressOf playerTurnTaken
            Call startTurn(2%)
        End If
    End Sub ' playerTurnTaken

    Private Function catWins() As Boolean
        ' catWins sub
        ' Checks to see if the cat has won

        For pos As Int32 = 0% To 8%
            If m_squares(pos).Status = SquareStatusOptions.Blank Then Return False
        Next pos
        Return True
    End Function ' catWins

    Private Function isWinner() As Boolean
        ' isWinner sub
        ' Checks to see if someone has won

        Dim win As Boolean = False

        ' check for wins in the rows
        For pos As Int32 = 0% To 8% Step 3%
            If m_squares(pos).Status <> SquareStatusOptions.Blank Then
                If m_squares(pos).Status = m_squares(pos + 1%).Status And m_squares(pos).Status = m_squares(pos + 2%).Status Then win = True
            End If
        Next pos

        ' check for wins in the columns
        For pos As Int32 = 0% To 2%
            If m_squares(pos).Status <> SquareStatusOptions.Blank Then
                If m_squares(pos).Status = m_squares(pos + 3%).Status AndAlso m_squares(pos).Status = m_squares(pos + 6%).Status Then win = True
            End If
        Next pos

        ' check for wins in the diagonals
        If m_squares(0%).Status <> SquareStatusOptions.Blank Then
            If m_squares(0%).Status = m_squares(4%).Status AndAlso m_squares(0%).Status = m_squares(8%).Status Then win = True
        End If
        If m_squares(2%).Status <> SquareStatusOptions.Blank Then
            If m_squares(2%).Status = m_squares(4%).Status AndAlso m_squares(2%).Status = m_squares(6%).Status Then win = True
        End If

        ' return whether there is a winner
        Return win
    End Function ' isWinner

#End Region ' Private methods

End Class ' Game