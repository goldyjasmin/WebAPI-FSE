using System;
using FSE.BAL;
using FSE.BAL.Domain;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;


namespace WebApi.Tests
{
    public class EventDetailRepositoryTest
    {
        private FeedBackManagementSystemContext _Context;

        public EventDetailRepositoryTest()
        {
            InitContext();
           
        }
        [Fact]
        public  void TestGetEventDetailsById()
        {
            string expectedEventName = "Bags of Joy Distribution";
            var controller = new EventDetailRepository(_Context);
            EventDetails result = controller.GetEventDetailsById("EVNT00047261");
            Assert.Equal(expectedEventName, result.EventName);
        }

        [Fact]
        public void TestGeAllEventIdListByuserId()
        {
            var controller = new EventDetailRepository(_Context);
            EventDetails result = controller.GeAllEventIdListByuserId(273690);
            Assert.NotNull(result.EventNames);
        }

        internal void InitContext()
        {
            var builder = new DbContextOptionsBuilder<FeedBackManagementSystemContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new FeedBackManagementSystemContext(builder.Options);
            var eventInfo = Enumerable.Range(1, 1)
                .Select(i => new TblEventEnrollmentDetails  {EventId= "EVNT00047261", EventName = "Bags of Joy Distribution",
                
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
                   RoleId= 1,

                }); 
            context.TblEventEnrollmentDetails.AddRange(eventInfo);
            int changed = context.SaveChanges();

            context.TblNotParticipated.AddRange(eventNames);
            int changedTblNotParticipated = context.SaveChanges();

            context.TblLogin.AddRange(login);
            int changedTblLogin = context.SaveChanges();

            _Context = context;
        }


    }

}

