using Bongo.DataAccess;
using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Mongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking _studyRoomBookingOne;
        private StudyRoomBooking _studyRoomBookingTwo;

        public StudyRoomBookingRepositoryTests()
        {
            _studyRoomBookingOne = new StudyRoomBooking
            {
                FirstName = "Carlos1",
                LastName = "Martins1",
                Date = new DateTime(2023, 1, 1),
                Email = "carlos@email.com",
                BookingId = 11,
                StudyRoomId = 1
            };
            
            _studyRoomBookingTwo = new StudyRoomBooking
            {
                FirstName = "Carlos2",
                LastName = "Martins2",
                Date = new DateTime(2023, 2, 2),
                Email = "carlos@email.com",
                BookingId = 22,
                StudyRoomId = 2
            };
        }

        [Test]
        public void SaveBooking_BookingOne_CheckTheValuesFromDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo")
                .Options;
            
            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(_studyRoomBookingOne);
            }
            
            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 11);
                Assert.AreEqual(_studyRoomBookingOne.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(_studyRoomBookingOne.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(_studyRoomBookingOne.LastName, bookingFromDb.LastName);
                Assert.AreEqual(_studyRoomBookingOne.Email, bookingFromDb.Email);
                Assert.AreEqual(_studyRoomBookingOne.Date, bookingFromDb.Date);
            }
        }
    }
}

