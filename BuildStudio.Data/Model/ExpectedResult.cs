using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Model;

    public class ExpectedResult : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,ConditionId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,ConditionId";
        #endregion

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Er#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Condition")]
        public int ConditionId { get; set; }

        public Condition Condition { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
