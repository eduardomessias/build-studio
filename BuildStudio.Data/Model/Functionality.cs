using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuildStudio.Data.Model
{
    public class Functionality
    {
        public int Id { get; set; }

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Fn#{Id.ToString().PadLeft(3, '0')}"; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Functional Specification")]
        public int FunctionalSpecificationId { get; set; }
        public virtual FunctionalSpecification FunctionalSpecification { get; set; }

        public const string BindableProperties = "Id,Name,Description,FunctionalSpecificationId";
    }
}
