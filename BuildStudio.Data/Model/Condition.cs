using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    public class Condition
    {
        #region bindable properties
        public const string BindableProperties = "Name,Description,AcceptanceCriteriaId";
        public const string BindablePropertiesForEdition = "Id,Name,Description,AcceptanceCriteriaId";
        #endregion

        public int Id { get; set; }

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Cn#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Acceptance criteria")]
        public int AcceptanceCriteriaId { get; set; }

        [Display(Name = "Acceptance criteria")]
        public AcceptanceCriteria AcceptanceCriteria { get; set; }

        [Display(Name = "Expected results")]
        public ICollection<ExpectedResult> ExpectedResults { get; set; }
    }
}
