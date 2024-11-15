namespace Entities
{
    public class Student : IDomainObject
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Speciality { get; set; }
        public int Id {  get; set; }
    }
}
