using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PdfConverter.Tests.ServiceTests
{
    using System.Diagnostics.CodeAnalysis;

    using Contoso.PdfConverter.Library;

    using Telerik.JustMock;

    /// <summary>
    /// Summary description for PdfConversionServiceTests
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PdfConversionServiceTests
    {
        public PdfConversionServiceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void File_Should_Be_Converted()
        {
            // ARRANGE
            var sut = new PdfConversionService();

            // ACT
            
            
            var fileBytes = new byte[1000];
            var random = new Random();
            random.NextBytes(fileBytes);
            var response = sut.Convert(fileBytes, @"D:\SomeFile.pdf").Result;

            Assert.IsNotNull(response.Response);

        }

        [TestMethod]
       public void Should_Throw_Exception_If_InputFile_is_Pdf()
        {
            // ARRANGE
            var sut = new PdfConversionService();

            // ACT


            var fileBytes = new byte[1000];
            var random = new Random();
            random.NextBytes(fileBytes);
           var response = sut.Convert(fileBytes, @"D:\SomeFile.pdf").Result;

            Assert.AreEqual(1, response.Exceptions.Count);


        }
    }
}
