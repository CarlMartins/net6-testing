// using Moq;
// using NUnit.Framework;
//
// namespace Sparky;
//
// [TestFixture]
// public class ProductXUnitTests
// {
//     [Test]
//     public void GetProductPrice_PlatinumCostumer_ReturnPriceWith20Discount()
//     {
//         Product product = new() {Price = 50};
//
//         var result = product.GetPrice(new Customer {IsPlatinum = true});
//         
//         Assert.That(result, Is.EqualTo(40));
//     }
//     
//     [Test]
//     public void GetProductPriceMOQAbuse_PlatinumCostumer_ReturnPriceWith20Discount()
//     {
//         var customer = new Mock<ICustomer>();
//         customer.Setup(u => u.IsPlatinum).Returns(true);
//         
//         Product product = new() {Price = 50};
//
//         var result = product.GetPrice(customer.Object);
//         
//         Assert.That(result, Is.EqualTo(40));
//     }
// }