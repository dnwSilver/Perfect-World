using Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Mocks;
using Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Stubs;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest
{
    /// <summary>
    ///     Шаблон простой: создаём статический класс и собираем в него всех строителей.
    /// </summary>
    /// <remarks>
    ///     ObjectMother  начинается  с  шаблона factory путем доставки готовых объектов, готовых к
    ///     тестированию, с помощью  простого вызова метода. Он  выходит за пределы области factory
    ///     на  облегчая  настройку  созданных  объектов,  предоставление  методов  для  обновления
    ///     объектов  во  время  испытаний и если  необходимо, удаление объекта  из  базы данных по
    ///     завершении теста.
    ///     Некоторые причины использования ObjectMother:
    ///     - Уменьшите дублирование кода в тестах, повысив надежность обслуживания
    ///     - Сделать тестовые объекты супер-легкодоступными, побуждая разработчиков писать тесты.
    ///     - Каждый тест работает со свежими данными.
    ///     - Тесты всегда очищаются после себя.
    /// </remarks>
    internal static class Create
    {
        /// <summary>
        ///     Создание процесса.
        /// </summary>
        /// <returns>Готовый для тестов процесс.</returns>
        /// >
        internal static ProcessEntityStub ProcessEntity => new ProcessEntityStub();

        /// <summary>
        ///     Создание модели для процесса.
        /// </summary>
        /// <returns>Готовый для тестов процесс.</returns>
        /// >
        internal static ProcessDataModelStub ProcessDataModel => new ProcessDataModelStub();

        /// <summary>
        ///     Создание контекста для смотрящего.
        /// </summary>
        /// >
        internal static VirtualWatcherContextMock WatcherContext => new VirtualWatcherContextMock();
    }
}
