using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace CollectionEditorEvents {
    public class IssueView {
        public string ProductName { get; set; }
        [RefreshProperties(RefreshProperties.All)]
        public string UserName { get; set; }
        [NewItemInstanceInitializer(typeof(Bug))]
        [NewItemInstanceInitializer(typeof(Question))]
        [NewItemInstanceInitializer(typeof(BreakingChange))]
        public IssueList Issues { get; internal set; }
    }
    public abstract class Issue {
        public string Header { get; set; }
        [NotifyParentProperty(true)]
        public string Owner { get; set; }

    }
    public enum Severity {
        Minor,
        Moderate,
        Severe
    }
    public class Bug : Issue {
        public Severity Severity { get; set; }
        public string Assignee { get; set; }
    }
    public class Question : Issue {
        public string Assignee { get; set; }
    }
    public enum ChangeType {
        APIChange,
        UIChange,
        BehaviorChange
    }
    public class BreakingChange : Issue {
        public ChangeType ChangeType { get; set; }
    }
    public class IssueList : List<Issue> {
        public override string ToString() {
            return "Issues";
        }
    }
}
