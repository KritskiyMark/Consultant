using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryConsultant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryConsultant.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void Check_8Char()
        {
            string password = "12345678";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithDigits()
        {

            string password = "ASDqwe1$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_PasswordWithSpecSimvols()
        {

            string password = "Aqwe123";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}