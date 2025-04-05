namespace SorterLibrary
{
    public class Person : IComparable<Person>
    {
        public int Id { get; set; }

        public Person(int id)
        {
            this.Id = id;
        }

        public int CompareTo(Person? other)
        {
            
            if(other is null) 
                return 1; //This instance is greater than the null

            return this.Id.CompareTo(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is Person other && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Person(Id={Id})";
        }
    }
}
