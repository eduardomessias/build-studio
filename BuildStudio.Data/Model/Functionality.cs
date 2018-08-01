using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BuildStudio.Data.Model
{
    public class Functionality
    {
        #region bindable properties
        public const string BindableProperties = "Name,Description,FunctionalSpecificationId";
        public const string BindablePropertiesForEdition = "Id,Name,Description,FunctionalSpecificationId";
        #endregion

        public int Id { get; set; }

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Fn#{(Id.ToString()).PadLeft(3, '0')}"; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Functional Specification")]
        public int FunctionalSpecificationId { get; set; }

        [Display(Name= "Functional Specification")]
        public virtual FunctionalSpecification FunctionalSpecification { get; set; }

        public ICollection<Requirement> Requirements { get; set; }

        
    }
}
