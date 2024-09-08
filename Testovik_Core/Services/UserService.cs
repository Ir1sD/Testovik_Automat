using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository repository)
		{
			_userRepository = repository;
		}
		
	    /// <summary>
		/// Возвращает объект пользователя
		/// </summary>
		/// <param name="login">Логин</param>
		/// <param name="hash">Хеш пароля</param>
		/// <returns></returns>
		public async Task<User> Get(string login, string hash)
		{
			return await _userRepository.Get(login, hash);
		}
	}
}
