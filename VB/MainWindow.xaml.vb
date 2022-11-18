Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.PropertyGrid
Imports System
Imports System.Windows

Namespace CollectionEditorEvents

    Public Partial Class MainWindow
        Inherits ThemedWindow

        Public Sub New()
            Me.InitializeComponent()
            Me.propertyGrid.SelectedObject = New IssueView With {.ProductName = "PropertyGridControl", .UserName = "Peter Dirk", .Issues = New IssueList From {New Bug With {.Header = "Rendering problem", .Assignee = "Jack Plank", .Owner = "Adam Smith", .Severity = Severity.Severe}, New Question With {.Header = "Rendering problem", .Assignee = "Elsa Lynch", .Owner = "Peter Dirk"}, New BreakingChange With {.Header = "Layout update", .ChangeType = ChangeType.BehaviorChange, .Owner = "Adam Smith"}, New Question With {.Header = "Focusing problem", .Assignee = "Elsa Lynch", .Owner = "Peter Dirk"}}}
        End Sub

        Private Sub OnCollectionButtonsVisibility(ByVal sender As Object, ByVal e As CollectionButtonsVisibilityEventArgs)
            If e.ButtonKind = CollectionButtonKind.Remove Then
                Dim issueView = TryCast(Me.propertyGrid.SelectedObject, IssueView)
                Dim issue = TryCast(e.Value, Issue)
                If issue IsNot Nothing AndAlso issueView IsNot Nothing AndAlso Not String.Equals(issue.Owner, issueView.UserName) Then e.IsVisible = False
            End If
        End Sub

        Private Sub OnCollectionButtonClick(ByVal sender As Object, ByVal e As CollectionButtonClickEventArgs)
            If e.ButtonKind = CollectionButtonKind.Remove Then
                If ThemedMessageBox.Show(title:=$"Delete {e.Value.GetType().Name}", text:=$"Do you want to delete this {e.Value.GetType().Name}?", messageBoxButtons:=MessageBoxButton.YesNo, messageBoxParameters:=New ThemedMessageBoxParameters With {.WindowStartupLocation = WindowStartupLocation.CenterOwner, .TimerTimeout = TimeSpan.FromSeconds(5)}) = MessageBoxResult.No Then e.Handled = True
            End If
        End Sub
    End Class
End Namespace
