namespace StandCurrencies.ResourceModels
{
    /// <summary>
    /// Данные сервера http://phisix-api3.appspot.com
    /// </summary>
    public class PhisixEntry
    {
        /// <summary>
        /// Название валюты
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public int valume { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public double amount { get; set; }
    }
}
