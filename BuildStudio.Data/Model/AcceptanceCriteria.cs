﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Model;

    public class AcceptanceCriteria : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,RequirementId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,RequirementId";
        #endregion

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Ac#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Requirement")]
        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }

        public ICollection<Condition> Conditions { get; set; }
    }
}
