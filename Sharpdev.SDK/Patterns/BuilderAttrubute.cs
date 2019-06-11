namespace Sharpdev.SDK.Patterns
{
    /// <summary>
    ///     Строитель для объектов.
    /// </summary>
    /// <remarks>
    ///     Отделяет  конструирование сложного объекта от его представления так, что  в  результате
    ///     одного и того  же  процесса  конструирования  могут  получаться  разные  представления.
    /// </remarks>
    public class Builder : PatternAttribute
    {
        /// <summary>
        ///     Признак отвечающий за заполнение всех полей в строителе.
        /// </summary>
        /// <returns>
        ///     True - все поля заполнены.
        ///     False - не все поля заполнены.
        /// </returns>
        public bool IsValid()
        {
            return true;
        }
    }
}
