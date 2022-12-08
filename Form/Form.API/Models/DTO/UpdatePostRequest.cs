namespace Form.API.Models.DTO
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
