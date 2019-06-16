namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объектов используемых при тестировании.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Тип собираемого объекта.</typeparam>
    /// <remarks>
    ///     По-хорошему строитель должен упрощать создание объекта настолько, чтобы код был понятен
    ///     доменному эксперту. Особенно стоит использовать строитель для объектов, которые требуют
    ///     настройки перед началом работы.
    /// </remarks>
    public interface ITestBuilder<out TBuildingObjectType>
    {
        /// <summary>
        ///     Построение объекта <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="TBuildingObjectType" /></returns>
        TBuildingObjectType Please();
    }
}
