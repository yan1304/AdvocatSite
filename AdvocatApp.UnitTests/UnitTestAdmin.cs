using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvocatApp.Controllers;
using System.Web.Mvc;
using AdvocatApp.BL.Interfaces;
using Moq;
using AdvocatApp.BL.DTO;
using System.Collections.Generic;
using AdvocatApp.DAL.Entities;

namespace AdvocatApp.UnitTests
{
    /// <summary>
    /// Класс тестов для контроллера администратора
    /// </summary>
    [TestClass]
    public class UnitTestAdmin
    {
        private AdminController controller;
        private ViewResult result;
        private Mock<ISiteService> mockSite;
        [TestInitialize]
        public void SetupContext()
        {
            mockSite = new Mock<ISiteService>();
            mockSite.Setup(s => s.GetPages()).Returns(
                new List<PageDTO>
                {
                    new PageDTO {Id = 1,Name="Index",Header = "Head1", Text = "Text1",Type=TypePage.Statie },
                    new PageDTO {Id = 2,Name="Price",Header = "Head2", Text = "Text2",Type=TypePage.Statie },
                    new PageDTO {Id = 3,Name="First",Header = "Head3", Text = "Text3",Type=TypePage.Statie },
                    new PageDTO {Id = 4,Name="",Header = "Head4", Text = "Text4",Type=TypePage.News},
                    new PageDTO {Id = 5,Name="",Header = "Head5", Text = "Text5",Type=TypePage.Warrings },
                });
            controller = new AdminController(mockSite.Object);
            result = new ViewResult();
        }
        //Tests for Index()
        [TestMethod]
        public void IndexNotNull()
        {
            result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void IndexReturnPageList()
        {
            List<PageDTO> list = new List<PageDTO>
                {
                    new PageDTO {Id = 1,Name="Index",Header = "Head1", Text = "Text1",Type=TypePage.Statie },
                    new PageDTO {Id = 2,Name="Price",Header = "Head2", Text = "Text2",Type=TypePage.Statie },
                    new PageDTO {Id = 3,Name="First",Header = "Head3", Text = "Text3",Type=TypePage.Statie },
                    new PageDTO {Id = 4,Name="",Header = "Head4", Text = "Text4",Type=TypePage.News},
                    new PageDTO {Id = 5,Name="",Header = "Head5", Text = "Text5",Type=TypePage.Warrings },
                };
            result = controller.Index() as ViewResult;
            Assert.AreEqual(list.GetType(), result.Model.GetType());
        }
        //Tests for Page()
        [TestMethod]
        public void PageNotNull()
        {
            PageDTO page = new PageDTO { Id = 1, Name = "Index", Header = "Head1", Text = "Text1", Type = TypePage.Statie };

            result = controller.Page(page) as ViewResult;

            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void PageCheckValue()
        {
            PageDTO page = new PageDTO { Id = 1, Name = "Index", Header = "Head1", Text = "Text1", Type = TypePage.Statie };

            result = controller.Page(page) as ViewResult;

            Assert.AreEqual(1, page.Id);
            Assert.AreEqual(TypePage.Statie, page.Type);
    }
}
