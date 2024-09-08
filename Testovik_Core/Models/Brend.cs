
namespace Testovik_Core.Models
{
	/// <summary>
	/// Модель бренда
	/// </summary>
	public class Brend
	{

		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; } = string.Empty;

		private Brend() { }

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <returns>Объект класса</returns>
        public static Brend New(long id, string name)
		{
			return new Brend
			{
				Id = id ,
				Name = name
			};
		}

		

	}
}
