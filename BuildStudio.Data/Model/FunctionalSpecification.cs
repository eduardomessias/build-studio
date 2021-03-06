﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuildStudio.Data.Model
{
    using BuildStudio.Core.Data.Base.Attributes;
    using Core.Data.Base;
    using Core.Data.Base.Model;

    public class FunctionalSpecification : BindableEntity
    {
        #region bindable properties
        public new const string BindableProperties = "Id,Title,Author,Creation,Status,Version,Creator";
        public new const string BindablePropertiesForEdition = "Id,Title,Author,Creation,Status,Version";
        #endregion

        public string Title { get; set; }
        public string Author { get; set; }

        [Display(Name = "Version")]
        public string Version { get; set; } = new Version("1.0.0.0").ToString();

        public FunctionalSpecStatus Status { get; set; }

        public virtual ICollection<Functionality> Functionalities { get; set; }
    }

    public static class FunctionalSpecificationExtensions
    {
        public static void IncreaseVersion(this FunctionalSpecification functionalSpecification)
        {
            functionalSpecification.Version = functionalSpecification.Version.Incremented();
        }

        private static string Incremented(this string currentVersionString)
        {
            Version currentVersion = new Version(currentVersionString);
            Version newVersion;

            if (currentVersion.Revision.Equals(9))
            {
                if (currentVersion.Build.Equals(9))
                {
                    if (currentVersion.Minor.Equals(9))
                    {
                        newVersion = new Version(currentVersion.Major + 1, 0, 0, 0);
                    }
                    else
                    {
                        newVersion = new Version(currentVersion.Major, currentVersion.Minor + 1, 0, 0);
                    }
                }
                else
                {
                    newVersion = new Version(currentVersion.Major, currentVersion.Minor, currentVersion.Build + 1, 0);
                }
            }
            else
            {
                newVersion = new Version(currentVersion.Major, currentVersion.Minor, currentVersion.Build, currentVersion.Revision + 1);
            }

            return newVersion.ToString();
        }
    }

    public enum FunctionalSpecStatus
    {
        Draw,
        Published
    }
}
