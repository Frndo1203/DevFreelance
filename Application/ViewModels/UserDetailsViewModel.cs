namespace Application.ViewModels
{
  public class UserDetailsViewModel
  {
    public UserDetailsViewModel(string fullName, string email, DateTime birthDate)
    {
      FullName = fullName;
      Email = email;
      BirthDate = birthDate;
    }

    public string FullName { get; private set; }

    public String Email { get; private set; }

    public DateTime BirthDate { get; private set; }
  }
}