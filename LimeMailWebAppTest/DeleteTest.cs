using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimeMailWebApp.Controllers;
using LimeMailWebApp.Services;
using Lime.Domain;

namespace LimeMailWebApp.UnitTests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void DeleteSuccessTest()
        {
            int idExist = 175;
            int idNull = 9999;
            MailServices mailServices = new();
            MessageController messageController = new(mailServices);

            var deleted = messageController.Delete(idExist);


            Assert.IsNotNull(deleted);

            try
            {
                var notFound = messageController.Delete(idNull);
            }
            catch (Exception)
            {
                Assert.Fail();
            }


        }
    }
}
