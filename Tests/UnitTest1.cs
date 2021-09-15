using System;
using Xunit;
using PetShop.Controllers;
using PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
namespace TestProject
{
    public class DiscountsControllerTests
    {
        [Fact]
        public void TestGet()
        {
            var mock = new Mock<PetShopDbContext>();
            Dictionary<int, Discounts> discounts = new Dictionary<int, Discounts>();
            discounts[1] =
                new Discounts { Id=1, info="", amout_of_discount=5};
            mock.Setup(x => x.Discounts.FindAsync(1)).Returns(async () => { return await Task.Run(() => discounts[1]); });
            var controller = new DiscountsController(mock.Object);
            Discounts result = controller.GetDiscounts(1).Result.Value;
            Assert.NotNull(result);
        }
        [Fact]
        public void TestPost()
        {
            Discounts discount = new Discounts { Id = 1, info = "", amout_of_discount = 5};
            List<Discounts> discounts = new List<Discounts>();
            var mock = new Mock<PetShopDbContext>();
            mock.Setup(x => x.Discounts.Add(discount)).Returns(() =>
            {
                discounts.Add(discount);
                return null;
            });
            var controller = new DiscountsController(mock.Object);
            var result = controller.PostDiscounts(discount);
            Assert.NotEmpty(discounts);
            Assert.Equal(discounts[0].Id, discount.Id);
        }
        [Fact]
        public async void TestDelete()
        {
            Dictionary<int, Discounts> discounts= new Dictionary<int, Discounts>();
            discounts[1] = new Discounts{ Id=1, info="", amout_of_discount=5};
            var mock = new Mock<PetShopDbContext>();
            mock.Setup(x => x.Discounts.FindAsync(1)).Returns(async () =>
            {
                return await Task.Run(() => {
                    return discounts[1];
                });
            });
            mock.Setup(x => x.Discounts.Remove(discounts[1])).Returns(() =>
            {
                discounts.Remove(1);
                return null;
            });
            CancellationToken token = new CancellationToken();
            mock.Setup(x => x.SaveChangesAsync(token)).Returns(async () => {
                return await Task.Run(() => { return 1; });
            });
            var controller = new DiscountsController(mock.Object);
            await controller.DeleteDiscounts(1);
            Assert.Empty(discounts);
        }

    }
}