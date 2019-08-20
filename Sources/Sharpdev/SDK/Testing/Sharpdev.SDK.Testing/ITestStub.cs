﻿namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для заглушек используемых при тестировании.
    /// </summary>
    /// <typeparam name="TBuildingObjectType">Тип собираемого объекта.</typeparam>
    /// <remarks>
    ///     Заглушка  заменяет  класс  небольшим  заменителем,  реализующим  тот же  интерфейс. Для
    ///     использования заглушек необходимо  разработать приложение таким образом,  чтобы  каждый
    ///     компонент зависел только от интерфейса, а не от других компонентов.
    ///     По-хорошему строитель должен упрощать создание объекта настолько, чтобы код был понятен
    ///     доменному эксперту. Особенно стоит использовать строитель для объектов, которые требуют
    ///     настройки перед началом работы.
    /// </remarks>
    public interface ITestStub<out TBuildingObjectType>
    {
        /// <summary>
        ///     Построение заглушки <see cref="TBuildingObjectType" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="TBuildingObjectType" />.</returns>
        TBuildingObjectType Please();

        /// <summary>
        /// Количество заглушек для генерации.
        /// </summary>
        /// <param name="countStubObjects">Количество создаваемых объектов.</param>
        /// <returns>Строитель для заглушек.</returns>
        ITestStub<TBuildingObjectType> CountOf(int countStubObjects);
    }
}
