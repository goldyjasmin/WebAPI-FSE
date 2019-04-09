using System;
using System.Diagnostics;
using System.Linq;
using FSE.BAL;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using NBench;
using Pro.NBench.xUnit.XunitExtensions;
using Xunit.Abstractions;

namespace FSE.NBench
{
    public class NBenchSettingsTest
    {
        private FeedBackManagementSystemContext _context;

        public NBenchSettingsTest(ITestOutputHelper output)
        {
            InitContext();
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test,
            SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 50000)]
        [NBenchFact]
        public void TestGetPendingFeedbackByEventId_EllaspedTime()
        {
            var controller = new SettingsRepo(_context);
            var result = controller.GetPendingFeedbackByEventId("EVNT00047261");
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        [NBenchFact]
        public void TestGetPendingFeedbackByEventId_GC()
        {
            var controller = new SettingsRepo(_context);
            var result = controller.GetPendingFeedbackByEventId("EVNT00047261");
        }

        [NBenchFact]
        [PerfBenchmark(Description = "Checking Memory",
            RunMode = RunMode.Iterations, RunTimeMilliseconds = 2500, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void TestGetPendingFeedbackByEventId_Memory()
        {
            var controller = new SettingsRepo(_context);
            var result = controller.GetPendingFeedbackByEventId("EVNT00047261");
        }

        internal void InitContext()
        {
            var builder = new DbContextOptionsBuilder<FeedBackManagementSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new FeedBackManagementSystemContext(builder.Options);
            var eventInfo = Enumerable.Range(1, 1)
                .Select(i => new TblEventEnrollmentDetails
                {
                    EmployeeId = 273690,
                    Id = 1,
                    EventId = "EVNT00047261",
                    EventName = "Bags of Joy Distribution"
                });

            var login = Enumerable.Range(1, 1)
                .Select(i => new TblLogin
                {
                    UserId = "273690",
                    RoleId = 1,
                    Id = 1
                });
            context.TblLogin.AddRange(login);
            var changedTblLogin = context.SaveChanges();

            context.TblEventEnrollmentDetails.AddRange(eventInfo);
            var changed = context.SaveChanges();

            _context = context;
        }
    }
}
