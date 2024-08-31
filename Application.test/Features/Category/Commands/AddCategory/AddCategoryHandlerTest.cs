using Application.Contracts.Persistence;
using Application.Features.Category.Commands;
using Application.Models;
using Application.Profiles;
using AutoMapper;
using Moq;

namespace Application.test.Features.Category.Commands.AddCategory
{
    public class AddCategoryHandlerTest
    {
        [Fact]
        public async Task Hadle_HappyFlow_CategoryShouldCreated()
        {
            
            var command  = new AddCategoryCommand(new AddCategoryRequestDto{
                Name = "Test Category",
                UrlHandle = "test-category",
            });

            var token = CancellationToken.None;
            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(it => it.AddCategoryAsync(It.IsAny<Domain.Entities.Category>()))
                .ReturnsAsync(new Domain.Entities.Category {
                    Name = "Test Category",
                    UrlHandle = "test-category",
                    Id = Guid.NewGuid()
                });
            var mapper = new MapperConfiguration(config => config.AddProfile<CategoryProfile>())
                .CreateMapper();
            var handler = new AddCategoryHandler(categoryRepository.Object, mapper);
            // Act
            var result = await handler.Handle(command, token);
            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
        }


    }
}