using DevExpress.Xpf.Core;
using DevExpress.Xpf.PropertyGrid;
using System;
using System.Windows;

namespace CollectionEditorEvents {
    public partial class MainWindow : ThemedWindow {
        public MainWindow() {
            InitializeComponent();
            propertyGrid.SelectedObject = new IssueView {
                ProductName = "PropertyGridControl",
                UserName = "Peter Dirk",
                Issues = new IssueList {
                    new Bug { Header = "Rendering problem", Assignee = "Jack Plank", Owner = "Adam Smith", Severity = Severity.Severe },
                    new Question { Header = "Rendering problem", Assignee = "Elsa Lynch", Owner = "Peter Dirk" },
                    new BreakingChange { Header = "Layout update", ChangeType = ChangeType.BehaviorChange, Owner = "Adam Smith" },
                    new Question { Header = "Focusing problem", Assignee = "Elsa Lynch", Owner = "Peter Dirk" }
                }
            };
        }

        void OnCollectionButtonsVisibility(object sender, CollectionButtonsVisibilityEventArgs e) {
            if (e.ButtonKind == CollectionButtonKind.Remove) {
                var issueView = propertyGrid.SelectedObject as IssueView;
                var issue = e.Value as Issue;
                if (issue != null && issueView != null && !string.Equals(issue.Owner, issueView.UserName))
                    e.IsVisible = false;
            }
        }

        void OnCollectionButtonClick(object sender, CollectionButtonClickEventArgs e) {
            if (e.ButtonKind == CollectionButtonKind.Remove) {
                if (ThemedMessageBox.Show(title: "", text: $"Do you want to delete this {e.Value.GetType().Name}?", messageBoxButtons: MessageBoxButton.YesNo,
                messageBoxParameters: new ThemedMessageBoxParameters { WindowStartupLocation = WindowStartupLocation.CenterOwner, TimerTimeout = TimeSpan.FromSeconds(5) }) == MessageBoxResult.No)
                    e.Handled = true;
            }
        }
    }
}
