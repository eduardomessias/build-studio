using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BuildStudio.Data.Model
{
    public class Requirement
    {
        #region bindable properties
        public const string BindableProperties = "Name,Description,FunctionalityId";
        public const string BindablePropertiesForEdition = "Id,Name,Description,FunctionalityId";
        #endregion

        public int Id { get; set; }

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Rq#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Functionality")]
        public int FunctionalityId { get; set; }

        public Functionality Functionality { get; set; }
    }
}
