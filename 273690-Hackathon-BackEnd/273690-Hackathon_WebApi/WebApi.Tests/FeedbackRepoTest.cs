using System;
using FSE.BAL;
using FSE.BAL.Domain;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace WebApi.Tests
{
    public class FeedbackRepoTest
    {
        private FeedBackManagementSystemContext _Context;
        public FeedbackRepoTest()
        {
            InitContext();

        }
        [Fact]
        public void TestEventDetailsForFeedbackPage()
        {
            string expectedEventName = "Bags of Joy Distribution";
            var controller = new FeedbackRepo(_Context);
            Feedback result = controller.EventDetailsForFeedbackPage("EVNT00047261", 273690,1);
            Assert.Equal(expectedEventName, result.EventName);
        }
        [Fact]
        public void TestSaveFeedback()
        {
            bool IsSaved = false;
            var controller = new FeedbackRepo(_Context);
            Feedback saveObj = new Feedback();
            saveObj.EmployeeId = 273690;
            int result = controller.Save(saveObj);
            if(result==1)
            {
                IsSaved = true;
            }
            Assert.True(IsSaved);
        }
        internal void InitContext()
        {
            var builder = new DbContextOptionsBuilder<FeedBackManagementSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new FeedBackManagementSystemContext(builder.Options);
            var eventInfo = Enumerable.Range(1, 1)
                .Select(i => new TblEventEnrollmentDetails
                {
                    EmployeeId=273690,
                    
                    EventId = "EVNT00047261",
                    EventName = "Bags of Joy Distribution",

                });
            context.TblEventEnrollmentDetails.AddRange(eventInfo);
            int changed = context.SaveChanges();
            _Context = context;
        }
    }
}
