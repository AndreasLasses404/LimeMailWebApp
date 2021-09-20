using Lime.Domain;
using LimeMailWebApp.Controllers;
using LimeMailWebApp.Models;
using LimeMailWebApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LimeMailWebApp.UnitTests
{
    [TestClass]
    public class DeleteTest
    {
        [TestInitialize]
        public void StartupTest()
        {
            MailServices.GetMessages();
        }



        [TestMethod]
        public void DeleteSuccessTest()
        {
            int idExist = 91;
            MailServices mailServices = new();

            var deleted = mailServices.Delete(idExist);
            Assert.IsTrue(deleted);

        }

        [TestMethod]
        public void DeleteFailedTest()
        {
            int idNull = 9999;
            MailServices mailServices = new();

            var notFound = mailServices.Delete(idNull);
            Assert.IsFalse(notFound);
        }

    }
}
