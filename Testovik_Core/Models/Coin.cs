
namespace Testovik_Core.Models
{
	/// <summary>
	/// Модель монет
	/// </summary>
	public class Coin
	{
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Наминал
		/// </summary>
		public int Num { get; set; }

		/// <summary>
		/// Количество
		/// </summary>
		public int Count { get; set; }

		private Coin() { }

        /// <summary>
        /// Создает объект класса
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="num">Наминал</param>
        /// <param name="count">Количество</param>
        /// <returns>Объект класса</returns>
        public static Coin New(int id, int num , int count)
		{
			return new Coin()
			{
				Id = id,
				Num = num,
				Count = count
			};
		}
	}

	
}
