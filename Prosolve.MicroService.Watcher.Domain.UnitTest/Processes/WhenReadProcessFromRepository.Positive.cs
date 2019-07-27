using FluentAssertions;

using NUnit.Framework;

using Prosolve.MicroService.Identity.UnitTest;
using Prosolve.MicroService.Watcher.Domain.Processes;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes
{
    [TestFixture]
    [Category(nameof(Processes))]
    [Parallelizable(ParallelScope.All)]
    public class WhenReadProcessFromRepository_Positive
    {
        [Test]
        public void WhenReadProcessFromRepository_ResultShouldBeTrue()
        {
            // Act:
            var processDataModel = Create.ProcessDataModel.Please();
            var watcherContext = Create.WatcherContext.With(processDataModel).Please();
            var specification = Create.ProcessNameLengthSpecification.WithCriteria(50).Please();
            var processRepository = new ProcessRepository(watcherContext);

            // Arrange:
            var result = processRepository.Read(specification);

            // Assert:
            result.Result.Success.Should()
                  .BeTrue($" we are create new {nameof(IProcessEntity)} with external id");
        }
    }
}
