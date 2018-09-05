using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Attributes;
    using Core.Data.Base.Model;

    public class Functionality : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,FunctionalSpecificationId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,FunctionalSpecificationId";
        #endregion

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Fn#{(Id.ToString()).PadLeft(3, '0')}"; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Functional Specification")]
        public int FunctionalSpecificationId { get; set; }

        [Parent]
        [Display(Name= "Functional Specification")]
        public virtual FunctionalSpecification FunctionalSpecification { get; set; }

        public ICollection<Requirement> Requirements { get; set; }
    }
}
