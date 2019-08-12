using FluentAssertions;

using NUnit.Framework;

using Prosolve.MicroService.Watcher.Domain.Processes;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Cases
{
    [TestFixture]
    [Category(nameof(Processes))]
    [Category("Positive")]
    [Parallelizable(ParallelScope.All)]
    public class WhenSearchProcess_Positive
    {
        [Test]
        public void WhenFindProcess_ById_ResultShouldBeTrue()
        {
            // Act:
            var processDataModel = Create.ProcessDataModel.Please();
            var watcherContext = Create.WatcherContext.With(processDataModel).Please();
            var processRepository = new ProcessRepository(watcherContext);
            var specification = Create.ProcessIdSpecification.WithId(processDataModel.PublicId).Please();
            var processService = new ProcessService(processRepository);
            
            // Arrange:
            var result = processService.Find(specification);

            // Assert:
            result.Result.Success.Should()
                  .BeTrue($" we are create new {nameof(IProcessEntity)} with external id");
        }
    }
}
