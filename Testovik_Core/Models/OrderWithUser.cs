
namespace Testovik_Core.Models
{
	/// <summary>
	/// Модель подробного заказа
	/// </summary>
	public class OrderWithUser
	{
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public long IdOrder { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public long IdTovar { get; set; }

		/// <summary>
		/// Название товара
		/// </summary>
		public string NameTovar { get; set; } = string.Empty;

		/// <summary>
		/// Количество
		/// </summary>
		public int Count { get; set; }

		private OrderWithUser() { }

        /// <summary>
        /// Создает объект класса
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="idOrder">Идентификатор заказа</param>
        /// <param name="idTovar">Идентификатор товара</param>
        /// <param name="nameTovar">Название товара</param>
        /// <param name="count">Количество</param>
        /// <returns>Объект класса</returns>
        public static OrderWithUser New(long id , long idOrder , long idTovar , string nameTovar , int count)
		{
			return new OrderWithUser()
			{
				Id = id,
				IdOrder = idOrder,
				IdTovar = idTovar,
				NameTovar = nameTovar,
				Count = count
			};
		}
	}
}
