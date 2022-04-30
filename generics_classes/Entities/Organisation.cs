using generic_classes.Entities;

namespace generics_classes.Entities
{
    public class Organisation : EntityBase
    {

        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}