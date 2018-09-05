using System;
using System.Collections.Generic;
using System.Text;

namespace BuildStudio.Intelligence.Model
{
    using Core.Data.Base;
    using Core.Data.Base.Model;

    public class Footstep : Entity
    {
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string Property { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyOldValue { get; set; }

        public DateTime DateTime { get; set; }
        public string User { get; set; }

        public string ReadableDateTime { get => this.DateTime.ToString("MMMM dd, yyyy"); }
        public string ReadableUser { get => $"by: {User}"; }
        
        public string ReadableFootstepTitle { get => $"{EntityId}:The property {Property} has changed."; }
    }
}
