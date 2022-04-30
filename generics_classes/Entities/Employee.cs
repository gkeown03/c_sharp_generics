using generic_classes.Entities;

namespace generics_classes.Entities
{
    public class Employee : EntityBase
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}