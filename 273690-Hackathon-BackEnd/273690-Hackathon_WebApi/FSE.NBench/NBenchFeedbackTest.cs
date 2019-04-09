using System;
using System.Diagnostics;
using System.Linq;
using FSE.BAL;
using FSE.BAL.Domain;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using NBench;
using Pro.NBench.xUnit.XunitExtensions;
using Xunit;
using Xunit.Abstractions;

namespace FSE.NBench
{

    public class NBenchFeedbackTest
    {
        private FeedBackManagementSystemContext _context;
        public NBenchFeedbackTest(ITestOutputHelper output)
        {
            InitContext();
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));

        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 50000)]
        [NBenchFact]
        public void TestEventDetailsForFeedbackPage_EllaspedTime()
        {
            var controller = new FeedbackRepo(_context);
            Feedback result = controller.EventDetailsForFeedbackPage("EVNT00047261", 273690, 1);

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        [NBenchFact]
        public void TestEventDetailsForFeedbackPage_GC()
        {
            var controller = new FeedbackRepo(_context);
            Feedback result = controller.EventDetailsForFeedbackPage("EVNT00047261", 273690, 1);

        }

        [NBenchFact]
        [PerfBenchmark(Description = "Checking Memory",
             RunMode = RunMode.Iterations, RunTimeMilliseconds = 2500, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.SixtyFourKb)]
        public void TestEventDetailsForFeedbackPage_Memory()
        {
            var controller = new FeedbackRepo(_context);
            Feedback result = controller.EventDetailsForFeedbackPage("EVNT00047261", 273690, 1);

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

                    EventId = "EVNT00047261",
                    EventName = "Bags of Joy Distribution",

                });
            context.TblEventEnrollmentDetails.AddRange(eventInfo);
            int changed = context.SaveChanges();
            _context = context;
        }

    }
}

