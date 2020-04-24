namespace Forum.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Forum.Data.Common.Repositories;
    using Forum.Data.Models;
    using Moq;
    using Xunit;

    public class CategoriesTests
    {
        public List<Category> GetTestData()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "TestName1",
                    Title = "TestTitle1",
                    Description = "TestDescription1",
                    ImageUrl = "TestImgUrl1",
                },
            };
        }

        [Fact]
        public void Test1()
        {
            //var repo = new Mock<IDeletableEntityRepository<Category>>();
            //repo.Setup(r => r.)
            //    .Returns(this.GetTestData());

            //var validationAttribute = new CategoriesService(repo);
            
        }
    }
}
