using System.Text.Json;
using generic_classes.Entities;

namespace generics_classes.Repositories
{
    public static class EntityExtensions
    {
        public static T? Copy<T>(this T itemtocopy) where T : IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemtocopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}