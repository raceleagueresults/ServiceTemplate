using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using AcceptanceTests.Tests.Helpers;
using System.Net;
using AcceptanceTests.Tests.Models;
using System.Collections.Generic;

namespace AcceptanceTests.Tests
{
    [TestClass]
    public class TemplateTests
    {
        [TestMethod]
        public void GetTemplates_WithUserNameAndPassword_ReturnsTemplates()
        {
            // Arrange
            HttpStatusCode httpStatusCode;

            var uriString = "http://localhost:49562/api/templates";

            // Act
            var response = HttpInvoke.Get<Response<List<Template>>>(new Uri(uriString), out httpStatusCode);

            var templates = response.Data;

            // Assert
            Assert.IsTrue(templates.Count > 0);
        }
    }
}
