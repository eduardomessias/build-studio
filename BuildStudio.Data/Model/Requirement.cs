using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Model;

    public class Requirement : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,FunctionalityId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,FunctionalityId";
        #endregion

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Rq#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Functionality")]
        public int FunctionalityId { get; set; }

        public Functionality Functionality { get; set; }

        [Display(Name = "Acceptance criterias")]
        public ICollection<AcceptanceCriteria> AcceptanceCriterias { get; set; }
    }
}
