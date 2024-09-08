using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IUserRepository
	{
		/// <summary>
		/// Возвращает объект пользователя
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="hash">Хеш пароля</param>
		/// <returns></returns>
		Task<User> Get(string login, string hash);
	}
}