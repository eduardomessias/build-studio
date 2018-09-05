using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using Core.Data.Base.Model;

    public class Result : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Name,Description,Expected,ExpectedResultId,Creator";
        public new const string BindablePropertiesForEdition = "Id,Name,Description,Expected,ExpectedResultId";
        #endregion

        [Display(Name = "Identifier")]
        public string ReadableId { get => $"Rs#{(Id.ToString()).PadLeft(3, '0')}"; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Match with the expected")]
        public bool Expected { get; set; }

        [Display(Name = "Description")]
        public string ShortDescription { get => Description?.Length > 50 ? $"{Description.Remove(50)}..." : Description; }

        [Display(Name = "Expected result")]
        public int ExpectedResultId { get; set; }

        public ExpectedResult ExpectedResult { get; set; }
    }
}
