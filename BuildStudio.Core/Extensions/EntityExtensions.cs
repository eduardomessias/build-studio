using System.Reflection;
using System.Linq;

namespace BuildStudio.Core.Extensions
{
    using Data.Base;
    using Data.Base.Attributes;
    using Data.Base.Model;

    public static class EntityExtensions
    {
        public static PropertyInfo ParentProperty(this Entity entity)
        {
            var parentProperty = entity.GetType()
                                    .GetProperties()
                                    .FirstOrDefault(property => property.GetCustomAttributes(false)
                                                                    .Any(attribute => attribute.GetType()
                                                                                            .IsEquivalentTo(typeof(Parent))));
            return parentProperty;
        }

        public static IEntity Parent(this Entity entity)
        {
            var parentProperty = entity.ParentProperty();

            if (parentProperty != null)
            {
                var entityType = entity.GetType();
                var entityParent = entityType.GetProperty(parentProperty.Name).GetValue(entity) as Entity;

                return entityParent;
            }

            return null;
        }
    }
}
