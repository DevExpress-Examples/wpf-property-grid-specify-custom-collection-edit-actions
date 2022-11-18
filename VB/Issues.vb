Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace CollectionEditorEvents

    Public Class IssueView

        Private _Issues As IssueList

        Public Property ProductName As String

        <RefreshProperties(RefreshProperties.All)>
        Public Property UserName As String

        <NewItemInstanceInitializer(GetType(Bug))>
        <NewItemInstanceInitializer(GetType(Question))>
        <NewItemInstanceInitializer(GetType(BreakingChange))>
        Public Property Issues As IssueList
            Get
                Return _Issues
            End Get

            Friend Set(ByVal value As IssueList)
                _Issues = value
            End Set
        End Property
    End Class

    Public MustInherit Class Issue

        Public Property Header As String

        <NotifyParentProperty(True)>
        Public Property Owner As String
    End Class

    Public Enum Severity
        Minor
        Moderate
        Severe
    End Enum

    Public Class Bug
        Inherits Issue

        Public Property Severity As Severity

        Public Property Assignee As String
    End Class

    Public Class Question
        Inherits Issue

        Public Property Assignee As String
    End Class

    Public Enum ChangeType
        APIChange
        UIChange
        BehaviorChange
    End Enum

    Public Class BreakingChange
        Inherits Issue

        Public Property ChangeType As ChangeType
    End Class

    Public Class IssueList
        Inherits List(Of Issue)

        Public Overrides Function ToString() As String
            Return "Issues"
        End Function
    End Class
End Namespace
