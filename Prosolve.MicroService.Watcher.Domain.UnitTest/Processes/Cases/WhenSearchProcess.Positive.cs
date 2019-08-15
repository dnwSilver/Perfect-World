using System;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.MicroService.Watcher.Domain.Processes;
using Prosolve.MicroService.Watcher.Domain.Processes.Specifications;

using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Cases
{
    [TestFixture]
    [Category(nameof(Processes))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenSearchProcessPositive
    {
        //todo Во всех тестах повторяются одинаковые Act, надо эту проблему устранить.
        [Test]
        public void WhenFindProcess_ByPublicId_CountShouldBeOne()
        {
            // Act:
            var processDataModels = Create.ProcessDataModel.CountOf(10).Please();
            var watcherContext = Create.WatcherContext.With(processDataModels).Please();
            var processFactory = new ProcessFactory();
            var processRepository = new ProcessRepository(watcherContext, WatcherConfiguration.Mapper,processFactory);
            var processService = new ProcessService(processRepository);
            var specification = new ProcessPublicIdSpecification(processDataModels[0].PublicId);

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Value.Should().HaveCount(1);
        }

        [Test]
        public void WhenFindProcess_ByPublicId_ResultShouldBeTrue()
        {
            // Act:
            var processDataModel = Create.ProcessDataModel.CountOf(10).Please();
            var watcherContext = Create.WatcherContext.With(processDataModel).Please();
            var processFactory = new ProcessFactory();
            var processRepository = new ProcessRepository(watcherContext, WatcherConfiguration.Mapper, processFactory);
            var specification = new ProcessPublicIdSpecification(processDataModel[0].PublicId);
            var processService = new ProcessService(processRepository);

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Success.Should().BeTrue();
        }
        
        [Test]
        public void WhenFindProcess_ByPublicId_CountShouldBeZero()
        {
            // Act:
            var processDataModels = Create.ProcessDataModel.CountOf(10).Please();
            var watcherContext = Create.WatcherContext.With(processDataModels).Please();
            var processFactory = new ProcessFactory();
            var processRepository = new ProcessRepository(watcherContext, WatcherConfiguration.Mapper,processFactory);
            var specification = new ProcessPublicIdSpecification(Guid.NewGuid());
            var processService = new ProcessService(processRepository);

            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Value.Should().HaveCount(0);
        }
    }
}
