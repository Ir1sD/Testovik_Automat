
namespace Testovik_Core.Models
{
	public class User
	{
		public long Id { get; set; }
		public string Login {  get; set; }
		public string Password { get; set; }

		private User() { }

		public static User New(long id , string login , string password)
		{
			return new User
			{
				Id = id,
				Login = login,
				Password = password
			};
		}
	}
}
