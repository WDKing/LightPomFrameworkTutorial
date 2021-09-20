namespace SampleFramework1
{
    public partial class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypes Gender { get; set; }

        public User(string firstName, string lastName, GenderTypes gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }
    }
}
