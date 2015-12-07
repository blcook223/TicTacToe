Public MustInherit Class TicTacToePlayer
    ' TicTacToePlayer class
    ' Represents a tic tac toe player

#Region "Fields and properties"

    Private m_squares() As SquareControl
    Private m_symbol As SquareStatusOptions
    Private m_playerNumber As Int32

    Public ReadOnly Property Symbol As SquareStatusOptions
        Get
            Return m_symbol
        End Get
    End Property ' Symbol

    Public ReadOnly Property Square(ByVal index As Int32) As SquareControl
        Get
            Return m_squares(index)
        End Get
    End Property ' Square

#End Region ' Fields and properties

#Region "Methods"

    Public Event TurnTaken(ByVal sender As Object, ByVal e As EventArgs)
    Public MustOverride Sub TakeTurn()
    Public MustOverride Sub Abort()

    Public Sub New(ByVal squares() As SquareControl, ByVal mySymbol As SquareStatusOptions, ByVal playerNum As Int32)
        ' New sub
        ' Constructs a new player

        m_squares = squares
        m_symbol = mySymbol
        m_playerNumber = playerNum
    End Sub ' New

    Public Overrides Function ToString() As String
        ' ToString function
        ' Returns a string representing the player

        Return String.Format("Player {0}", m_playerNumber.ToString)
    End Function ' ToString

    Protected Sub OnTurnTaken(ByVal sender As Object, ByVal e As EventArgs)
        ' OnTurnTaken sub
        ' Raises an event indicating the player has taken a turn

        RaiseEvent TurnTaken(sender, e)
    End Sub ' OnTurnTaken

#End Region ' Methods

End Class ' TicTacToePlayer

Public Class CatPlayer
    Inherits TicTacToePlayer
    ' CatPlayer class
    ' Represent a dummy derived class of a tic tac toe player

#Region "Methods"

    Public Sub New()
        ' New sub
        ' Constructs a new cat player

        MyBase.New(Nothing, SquareStatusOptions.Blank, 0%)
    End Sub ' New

    Public Overrides Function ToString() As String
        ' ToString function
        ' Returns a string representing the cat

        Return "The cat"
    End Function ' ToString

    Public Overrides Sub TakeTurn()
    End Sub ' TakeTurn

    Public Overrides Sub Abort()
    End Sub ' Abort

#End Region ' Methods

End Class ' CatPlayer

Public Class HumanPlayer
    Inherits TicTacToePlayer
    ' HumanPlayer class
    ' Represents a human tic tac toe player

    Private m_hasHandlers As Boolean = False

#Region "Methods and events"

    Public Sub New(ByVal squares() As SquareControl, ByVal mySymbol As SquareStatusOptions, ByVal playerNum As Int32)
        ' New sub
        ' Constructs a new player

        MyBase.New(squares, mySymbol, playerNum)
    End Sub ' New

    Public Overrides Sub TakeTurn()
        ' TakeTurn sub
        ' Allows the human player to take a turn

        For i As Int32 = 0% To 8%
            AddHandler Me.Square(i).Click, AddressOf attemptMark
        Next i
        m_hasHandlers = True
    End Sub ' TakeTurn

    Public Overrides Sub Abort()
        ' Abort sub
        ' Aborts the player object

        If m_hasHandlers Then
            For i As Int32 = 0% To 8%
                RemoveHandler Me.Square(i).Click, AddressOf attemptMark
            Next i
        End If
    End Sub

    Private Sub attemptMark(ByVal sender As Object, ByVal e As EventArgs)
        ' attemptMark sub
        ' Attempts to mark a square for the player

        Dim s As SquareControl = DirectCast(sender, SquareControl)
        If s.Status = SquareStatusOptions.Blank Then
            Call s.Display(Me.Symbol)
            For i As Int32 = 0% To 8%
                RemoveHandler Me.Square(i).Click, AddressOf attemptMark
            Next i
            m_hasHandlers = False
            Call OnTurnTaken(Me, New EventArgs)
        End If
    End Sub ' attemptMark

#End Region ' Methods

End Class ' HumanPlayer

Public Class CPUPlayer
    Inherits TicTacToePlayer
    ' CPUPlayer class
    ' Represents a CPU tic tac toe player

#Region "Public methods and events"

    Public Sub New(ByVal squares() As SquareControl, ByVal mySymbol As SquareStatusOptions, ByVal playerNum As Int32)
        ' New sub
        ' Constructs a new player

        MyBase.New(squares, mySymbol, playerNum)
    End Sub ' New

    Public Overrides Sub TakeTurn()
        ' TakeTurn sub
        ' Forces the cpu to take a turn

        If makeWinningPlay() Then Exit Sub
        If makeBlockingPlay() Then Exit Sub
        If makeStrategicPlay() Then Exit Sub
        Call makeOtherPlay()
    End Sub ' TakeTurn

    Public Overrides Sub Abort()
    End Sub

#End Region ' Methods and events

#Region "Private methods"

    Private m_firstPlayPosition As Int32 = -1%
    Private m_secondPlayPosition As Int32 = -1%

    Private Sub mark(ByVal position As Int32)
        ' mark sub
        ' Attempts to mark the indicated square and returns true if successful

        Call Me.Square(position).Display(Me.Symbol)
        Call OnTurnTaken(Me, New EventArgs)
    End Sub ' mark

    Private Function isNumBlankAndSymbol(ByVal numBlank As Int32, ByVal symbol As SquareStatusOptions, ByVal ParamArray positions() As Int32) As Int32
        ' isNumBlankAndSymbol function
        ' Returns true if the parameter array indicates positions of 1 blank square and 2 squares with the specified symbol

        Dim numSymbol As Int32
        If numBlank = 1% Then
            numSymbol = 2%
        Else
            numSymbol = 1%
        End If
        Dim countBlank As Int32 = 0%
        Dim countSymbol As Int32 = 0%
        Dim blankPos As Int32
        For i As Int32 = 0% To 2%
            If Me.Square(positions(i)).Status = SquareStatusOptions.Blank Then
                countBlank += 1
                blankPos = positions(i)
            ElseIf Me.Square(positions(i)).Status = symbol Then
                countSymbol += 1
            End If
        Next i
        If countBlank = numBlank And countSymbol = numSymbol Then Return blankPos
        Return -1%
    End Function ' isNumBlankAndSymbol

    Private Function makeWinningPlay() As Boolean
        ' makeWinningPlay sub
        ' Makes a winning play if possible and returns true, otherwise returns false

        Return blockOrWin(Me.Symbol)
    End Function ' makeWinningPlay

    Public Function makeBlockingPlay() As Boolean
        ' makeBlockingPlay function
        ' Makes a blocking play if possible and returns true, otherwise returns false

        Dim otherSymbol As SquareStatusOptions
        If Me.Symbol = SquareStatusOptions.O Then
            otherSymbol = SquareStatusOptions.X
        Else
            otherSymbol = SquareStatusOptions.O
        End If
        Return blockOrWin(otherSymbol)
    End Function ' makeBlockingPlay

    Private Function blockOrWin(ByVal symbol As SquareStatusOptions) As Boolean
        ' blockOrWin function
        ' Makes a blocking or winning play depending on the symbol

        Dim blankPos As Int32

        ' check rows
        Dim rowStart As Int32
        For row As Int32 = 0% To 2%
            rowStart = row * 3%
            blankPos = isNumBlankAndSymbol(1%, symbol, rowStart, rowStart + 1%, rowStart + 2%)
            If blankPos <> -1% Then
                Call mark(blankPos)
                Return True
            End If
        Next row

        ' check columns
        For col As Int32 = 0% To 2%
            blankPos = isNumBlankAndSymbol(1%, symbol, col, col + 3%, col + 6%)
            If blankPos <> -1% Then
                Call mark(blankPos)
                Return True
            End If
        Next col

        ' check diagonals
        blankPos = isNumBlankAndSymbol(1%, symbol, 0%, 4%, 8%)
        If blankPos <> -1% Then
            Call mark(blankPos)
            Return True
        End If
        blankPos = isNumBlankAndSymbol(1%, symbol, 2%, 4%, 6%)
        If blankPos <> -1% Then
            Call mark(blankPos)
            Return True
        End If

        ' no winning or blocking play found
        Return False
    End Function ' blockOrWin

    Private Function makeStrategicPlay() As Boolean
        ' makeStrategicPlay function
        ' Makes a strategic play

        ' determine number of turns that have been played
        Dim numPlayed As Int32 = 0%
        For i As Int32 = 0% To 8%
            If Me.Square(i).Status <> SquareStatusOptions.Blank Then numPlayed += 1%
        Next i

        ' determine what kind of move to make
        Select Case numPlayed
            Case 0%
                Return makeFirstPlay()
            Case 1%
                Return makeSecondPlay()
            Case 2%
                Return makeThirdPlay()
            Case 3%
                Return makeFourthPlay()
            Case 4%
                Return makeFifthPlay()
        End Select

        ' no play was made
        Return False
    End Function ' makeStrategicPlay

    Private Function makeFirstPlay() As Boolean
        ' makeFirstPlay function
        ' Makes a first play

        Call mark(0%)
        Return True
    End Function ' makeFirstPlay

    Private Function makeSecondPlay() As Boolean
        ' makeSecondPlay function
        ' Makes a second play

        ' find position of first play
        For i As Int32 = 0% To 8%
            If Me.Square(i).Status <> SquareStatusOptions.Blank Then m_firstPlayPosition = i
        Next i

        ' make play based on where first play was
        If m_firstPlayPosition <> 4% Then
            Call mark(4%)
            Return True
        End If

        ' no turn taken
        Return False
    End Function ' makeSecondPlay

    Private Function makeThirdPlay() As Boolean
        ' makeThirdPlay function
        ' Makes a third play

        ' find the position of the second play
        For i As Int32 = 1% To 8%
            If Me.Square(i).Status <> SquareStatusOptions.Blank Then m_secondPlayPosition = i
        Next i

        ' if second play was in a side position
        If (m_secondPlayPosition Mod 2%) = 1% Then
            Call mark(4%)
            Return True
        End If

        ' if second play was directly across from first play
        If m_secondPlayPosition = 8% Then
            Call mark(6%)
            Return True
        End If

        ' if second play was somewhere else
        Call mark(8%)
        Return True
    End Function ' makeThirdPlay

    Private Function makeFourthPlay() As Boolean
        ' makeFourthPlay function
        ' Makes a fourth play

        Dim blankPos As Int32

        ' check rows
        Dim rowStart As Int32
        For row As Int32 = 0% To 2%
            rowStart = row * 3%
            blankPos = isNumBlankAndSymbol(2%, Symbol, rowStart, rowStart + 1%, rowStart + 2%)
            If blankPos <> -1% Then
                Call mark(blankPos)
                Return True
            End If
        Next row

        ' check columns
        For col As Int32 = 0% To 2%
            blankPos = isNumBlankAndSymbol(2%, Symbol, col, col + 1%, col + 2%)
            If blankPos <> -1% Then
                Call mark(blankPos)
                Return True
            End If
        Next col

        ' check diagonals
        blankPos = isNumBlankAndSymbol(2%, Symbol, 0%, 4%, 8%)
        If blankPos <> -1% Then
            Call mark(blankPos)
            Return True
        End If
        blankPos = isNumBlankAndSymbol(2%, Symbol, 2%, 4%, 6%)
        If blankPos <> -1% Then
            Call mark(blankPos)
            Return True
        End If

        ' no strategic play found
        Return False
    End Function ' makeFourthPlay

    Private Function makeFifthPlay() As Boolean
        ' makeFifthPlay function
        ' Makes a fifth play

        ' if second play was in an odd position
        Select Case m_secondPlayPosition
            Case 1%
                Call mark(3%)
                Return True
            Case 3%
                Call mark(1%)
                Return True
            Case 5%
                Call mark(6%)
                Return True
            Case 7%
                Call mark(2%)
                Return True
            Case 8%
                Call mark(2%)
                Return True
        End Select
        Return False
    End Function ' makeFifthPlay

    Private Sub makeOtherPlay()
        ' makeOtherPlay sub
        ' Makes a valid play

        Dim sq As New List(Of Int32)
        For pos As Int32 = 0% To 8%
            If Me.Square(pos).Status = SquareStatusOptions.Blank Then Call sq.Add(pos)
        Next pos
        Dim rand As New Random
        Dim index As Int32 = rand.Next(0%, sq.Count - 1%)
        Call mark(sq(index))
    End Sub ' makeOtherPlay

#End Region ' Private methods

End Class ' CPUPlayer