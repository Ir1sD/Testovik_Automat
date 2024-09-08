
namespace Testovik_Core.Models
{
	/// <summary>
	/// Модель заказа
	/// </summary>
	public class Tovar
	{
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор бренда
        /// </summary>
        public long IdBrend { get; set; }

		/// <summary>
		/// Путь до логотипа
		/// </summary>
		public string LogoPath { get; set; } = string.Empty;

		/// <summary>
		/// Цена
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Количество
		/// </summary>
		public int Count { get; set; }

		private Tovar() { }

        /// <summary>
        /// Создает объект класса
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Название</param>
        /// <param name="idBrend">Идентификатор бренда</param>
        /// <param name="logoPath">Путь до лого</param>
        /// <param name="price">Цена</param>
        /// <param name="count">Количество</param>
        /// <returns></returns>
        public static Tovar New(long id , string name , long idBrend , string logoPath , int price , int count)
		{
			return new Tovar()
			{
				  Id = id ,
				  Name = name ,
				  IdBrend = idBrend ,
				  LogoPath = logoPath ,
				  Price = price,
				  Count = count
			};
		}
	}
}
