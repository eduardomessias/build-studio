using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    public class ExpectedResult
    {
        #region bindable properties
        public const string BindableProperties = "Name,Description,ConditionId";
        public const string BindablePropertiesForEdition = "Id,Name,Description,ConditionId";
        #endregion

        public int Id { get; set; }

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
