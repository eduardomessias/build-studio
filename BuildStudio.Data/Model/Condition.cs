using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Model;

    public class Condition : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,AcceptanceCriteriaId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,AcceptanceCriteriaId";
        #endregion

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
