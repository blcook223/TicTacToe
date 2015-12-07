Imports Microsoft.VisualBasic.PowerPacks

Public Class SquareControl
    ' SquareControl class
    ' A visual representation of a tic tac toe square

#Region "Fields and properties"

    Private m_status As SquareStatusOptions

    Public ReadOnly Property Status As SquareStatusOptions
        Get
            Return m_status
        End Get
    End Property ' Status

#End Region ' Fields and properties

#Region "Methods"

    Public Sub New()
        ' New sub
        ' Constructs a new square control

        Call InitializeComponent()
        m_status = SquareStatusOptions.Blank
    End Sub ' New

    Public Sub DisplayX()
        ' DisplayX sub
        ' Displays an X in the control

        Call DisplayBlank()
        Dim canvas As New ShapeContainer
        canvas.Parent = Me
        Dim l1 As New LineShape
        Dim l2 As New LineShape
        l1.Parent = canvas
        l2.Parent = canvas
        l1.BorderWidth = 5%
        l2.BorderWidth = 5%
        l1.X1 = 20%
        l1.Y1 = 20%
        l1.X2 = 80%
        l1.Y2 = 80%
        l2.X1 = 20%
        l2.Y1 = 80%
        l2.X2 = 80%
        l2.Y2 = 20%
        m_status = SquareStatusOptions.X
    End Sub ' DisplayX

    Public Sub DisplayO()
        ' DisplayO sub
        ' Displays an O in the control

        Call DisplayBlank()
        Dim canvas As New ShapeContainer
        canvas.Parent = Me
        Dim o As New OvalShape
        o.Parent = canvas
        o.BorderWidth = 5%
        o.Location = New Point(20%, 20%)
        o.Size = New Size(60%, 60%)
        m_status = SquareStatusOptions.O
    End Sub ' DisplayO

    Public Sub DisplayBlank()
        ' DisplayBlank sub
        ' Displays a blank square

        If Me.HasChildren Then Call Me.Controls.Clear()
        m_status = SquareStatusOptions.Blank
    End Sub ' DisplayBlank

    Public Sub Display(ByVal opt As SquareStatusOptions)
        ' Display sub
        ' Displays the parameter option in the square

        If Not [Enum].IsDefined(GetType(SquareStatusOptions), opt) Then Throw New ArgumentException
        Select Case opt
            Case SquareStatusOptions.Blank
                Call DisplayBlank()
            Case SquareStatusOptions.X
                Call DisplayX()
            Case SquareStatusOptions.O
                Call DisplayO()
        End Select
    End Sub ' Display

#End Region ' Methods

End Class ' SquareControl

Public Enum SquareStatusOptions As Int32
    ' SquareStatusOptions enum
    ' Represents the various options for the status of a square

    Blank = 0%
    X = 1%
    O = 2%
End Enum ' SquareStatusOptions