namespace handball_IS.Objects.Actors.super
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int phoneNumber { get; set; }
        public int Username { get; set; }
        private int Password { get; set; }
    }
}
