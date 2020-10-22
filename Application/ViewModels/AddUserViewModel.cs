namespace Application.ViewModels
{
    public class AddUserViewModel
    {
        public class Request
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class Response
        {
            public bool IsSuccessful { get; set; }
        }
    }
}