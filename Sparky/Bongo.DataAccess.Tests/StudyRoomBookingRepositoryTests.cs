using System.Collections;
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
        private DbContextOptions<ApplicationDbContext> _options;

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

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo")
                .Options;
        }

        [Test]
        public void SaveBooking_BookingOne_CheckTheValuesFromDatabase()
        {
            // Act
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(_studyRoomBookingOne);
            }
            
            // Assert
            using (var context = new ApplicationDbContext(_options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 11);
                Assert.AreEqual(_studyRoomBookingOne.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(_studyRoomBookingOne.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(_studyRoomBookingOne.LastName, bookingFromDb.LastName);
                Assert.AreEqual(_studyRoomBookingOne.Email, bookingFromDb.Email);
                Assert.AreEqual(_studyRoomBookingOne.Date, bookingFromDb.Date);
            }
        }

        [Test]
        public void SaveBooking_BookingOneAndTwo_CheckBothTheBookingFromDatabase()
        {
            // Arrange
            var expectedResult = new List<StudyRoomBooking> {_studyRoomBookingOne, _studyRoomBookingTwo};

            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(_studyRoomBookingOne);
                repository.Book(_studyRoomBookingTwo);
            }

            // Act
            List<StudyRoomBooking> actualList;
            using (var context = new ApplicationDbContext(_options))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualList = repository.GetAll(null).ToList();
            }
            
            // Assert
            CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object? x, object? y)
            {
                var booking1 = (StudyRoomBooking) x;
                var booking2 = (StudyRoomBooking) y;

                if (booking1.BookingId != booking2.BookingId)
                {
                    return 1;
                }

                return 0;
            }
        }
    }
}

