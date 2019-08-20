using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Watcher.Domain.Processes;
using Prosolve.Services.Watcher.Domain.Processes.DataSources;
using Prosolve.Services.Watcher.Domain.Processes.Factories;
using Prosolve.Services.Watcher.Domain.Processes.Specifications;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Watcher.Domain.UnitTest.Processes.Cases
{
    [TestFixture]
    [Category(nameof(Processes))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenSearchProcessPositive
    {
        /// <summary>
        ///     Подготовка сервиса для тестирования. Создание всех необходимых объектов и заполнение
        ///     данными виртуальное хранилище.
        /// </summary>
        /// <param name="processDataModels">Данные находящиеся в виртуальном хранилище.</param>
        /// <returns>Сервис готовый для тестов.</returns>
        private ProcessService AllocateProcessService(out IList<ProcessDataModel> processDataModels)
        {
            processDataModels = Create.ProcessDataModel.CountOf(10).Please();
            var watcherContext = Create.WatcherContext.With(processDataModels).Please().First();
            var integrationBus = Create.IntegrationBus.Please().First();
            var unitOfWork = new DatabaseUnitOfWork<WatcherContext>(watcherContext);
            var processFactory = new ProcessFactory();
            var processRepository = new ProcessRepository(processFactory, WatcherConfiguration.Mapper);
            var processService = new ProcessService(unitOfWork, integrationBus, processRepository);

            return processService;
        }

        [Test]
        public void WhenFindProcess_ByPublicId_CountShouldBeOne()
        {
            // Act:
            var processService = this.AllocateProcessService(out var processDataModels);
            var specification =
                new ProcessPublicIdSpecification(processDataModels.First().PublicId);

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Value.Should().HaveCount(1);
        }

        [Test]
        public void WhenFindProcess_ByPublicId_CountShouldBeZero()
        {
            // Act:
            var processService = this.AllocateProcessService(out var _);
            var specification = new ProcessPublicIdSpecification(Guid.NewGuid());

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Value.Should().HaveCount(0);
        }

        [Test]
        public void WhenFindProcess_ByPublicId_ResultShouldBeTrue()
        {
            // Act:
            var processService = this.AllocateProcessService(out var processDataModels);
            var specification =
                new ProcessPublicIdSpecification(processDataModels.First().PublicId);

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Success.Should().BeTrue();
        }
    }
}
