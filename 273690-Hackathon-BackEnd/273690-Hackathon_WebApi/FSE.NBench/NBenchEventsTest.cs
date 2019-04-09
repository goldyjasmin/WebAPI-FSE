using System;
using System.Diagnostics;
using System.Linq;
using FSE.BAL;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using NBench;
using Pro.NBench.xUnit.XunitExtensions;
using Xunit;
using Xunit.Abstractions;


[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace FSE.NBench
{

    public class NBenchEventsTest
    {
        private FeedBackManagementSystemContext _context;
        public NBenchEventsTest(ITestOutputHelper output)
        {
            InitContext();
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));

        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 50000)]
        [NBenchFact]
        public void TestGetEventDetailsById_EllaspedTime()
        {

            var controller = new EventDetailRepository(_context);
            controller.GetEventDetailsById("EVNT00047261");

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        [NBenchFact]
        public void TestGetEventDetailsById_GC()
        {
            var controller = new EventDetailRepository(_context);
            controller.GetEventDetailsById("EVNT00047261");
        }

        [NBenchFact]
        [PerfBenchmark(Description = "Checking Memory",
             RunMode = RunMode.Iterations, RunTimeMilliseconds = 2500, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void TestGetEventDetailsById_Memory()
        {
            var controller = new EventDetailRepository(_context);
            controller.GetEventDetailsById("EVNT00047261");
        }

        internal void InitContext()
        {

            var builder = new DbContextOptionsBuilder<FeedBackManagementSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new FeedBackManagementSystemContext(builder.Options);
            var eventInfo = Enumerable.Range(1, 1)
                .Select(i => new TblEventEnrollmentDetails
                {
                    EventId = "EVNT00047261",
                    EventName = "Bags of Joy Distribution",

                });

            var eventNames = Enumerable.Range(1, 1)
                .Select(i => new TblNotParticipated
                {
                    EventId = "EVNT00047261",
                    EventName = "Bags of Joy Distribution",

                });

            var login = Enumerable.Range(1, 1)
                .Select(i => new TblLogin
                {
                    UserId = "273690",
                    RoleId = 1,

                });
            context.TblEventEnrollmentDetails.AddRange(eventInfo);
            int changed = context.SaveChanges();

            context.TblNotParticipated.AddRange(eventNames);
            int changedTblNotParticipated = context.SaveChanges();

            context.TblLogin.AddRange(login);
            int changedTblLogin = context.SaveChanges();

            _context = context;
        }

    }
}

