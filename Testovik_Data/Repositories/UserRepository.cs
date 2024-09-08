using Microsoft.EntityFrameworkCore;
using Testovik_Core.Models;
using Testovik_Data.Context;
using Testovik_Core.Abstractions;

namespace Testovik_Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly TestovikContext _context;
		public UserRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает объект пользователя
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="hash">Хеш пароля</param>
		/// <returns></returns>
		public async Task<User> Get(string login, string hash)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.Login.Equals(login) && u.Password.Equals(hash));

			if (user == null)
				return null;

			return User.New(user.Id, user.Login, user.Password);
		}
	}
}
