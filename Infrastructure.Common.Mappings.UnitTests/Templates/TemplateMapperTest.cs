using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistributedServices.Entities;
using System.Collections.Generic;
using Infrastructure.Common.Mappings.Templates;

namespace Infrastructure.Common.Mappings.UnitTests.Templates
{
    [TestClass]
    public class TemplateMapperTest
    {
        #region Fields

        private readonly Domain.Entities.Template _domainObject = new Domain.Entities.Template
        {
            Property1 = (new Random()).Next().ToString(),
            Property2 = (new Random()).Next(),
            Id = 1,
            DateCreated = DateTime.Now
        };

        private readonly TemplateDto _dtoObject = new TemplateDto
        {
            Property1 = (new Random()).Next().ToString(),
            Property2 = (new Random()).Next(),
            Id = 2
        };

        private readonly List<Domain.Entities.Template> _domainObjects = new List<Domain.Entities.Template>()
        {
                new Domain.Entities.Template
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    Id = 1,
                    DateCreated = DateTime.Now
                },
                new Domain.Entities.Template
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    Id = 2,
                    DateCreated = DateTime.Now
                }
            };


        private readonly List<TemplateDto> _dtoObjects = new List<TemplateDto>
            {
                new TemplateDto
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    Id = 1
                },
                new TemplateDto
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    Id = 1
                }
            };


        #endregion

        #region Test methods

        [TestMethod]
        public void Map_WithDtoObject_ReturnsDomainObject()
        {
            // Arrange
            var mapper = new TemplateMapper();

            // Act
            var domainObject = mapper.Map(_dtoObject);

            // Assert
            Assert.IsInstanceOfType(domainObject, typeof(Domain.Entities.Template));
        }

        [TestMethod]
        public void Map_WithDtoObjects_ReturnsDomainObjects()
        {
            // Arrange
            var mapper = new TemplateMapper();

            // Act
            var domainObjects = mapper.Map(_dtoObjects);

            // Assert
            Assert.IsInstanceOfType(domainObjects, typeof(List<Domain.Entities.Template>));
        }

        [TestMethod]
        public void Map_WithDomainObject_ReturnsDtoObject()
        {
            // Arrange
            var mapper = new TemplateMapper();

            // Act
            var dtoObject = mapper.Map(_domainObject);

            // Assert
            Assert.IsInstanceOfType(dtoObject, typeof(TemplateDto));
        }

        [TestMethod]
        public void Map_WithDomainObjects_ReturnsDtoObjects()
        {
            // Arrange
            var mapper = new TemplateMapper();

            // Act
            var dtoObjects = mapper.Map(_domainObjects);

            // Assert
            Assert.IsInstanceOfType(dtoObjects, typeof(List<TemplateDto>));
        }

        #endregion

    }
}
