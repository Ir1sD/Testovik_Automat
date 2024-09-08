
namespace Testovik_Core.Models
{
    /// <summary>
	/// Модель заказа
	/// </summary>
	public class Order
	{
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime DateCreate { get; set; }

		/// <summary>
		/// Сумма заказа
		/// </summary>
		public int Sum { get; set; }

		private Order() { }

        /// <summary>
        /// Создает объект класса
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="date">Дата создания</param>
        /// <param name="sum">Сумма заказа</param>
        /// <returns>Объект класса</returns>
        public static Order New(long id, DateTime date, int sum)
		{
			return new Order()
			{
				Id = id,
				DateCreate = date,
				Sum = sum
			};
		}

	}
}
