namespace PdfConverter.Tests.LibraryTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.Library;
    using Contoso.PdfConverter.Library.Contracts;
    using Contoso.PdfConverter.Library.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PdfConverterTests
    {
        [TestMethod]
        public void Convert_To_Pdf_Must_Return_True()
        {
            // ARRANGE
            var sut = Mock.Create<PdfConverter>(Behavior.CallOriginal); // system under test

            var mockSvc = new MockPdfConversionService();
            Mock.NonPublic.Arrange<IPdfConversionService>(sut,"PdfConversionService").Returns(mockSvc);

            // ACT
           var result = sut.ConvertToPdf(@"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\input.txt", @"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\output.txt").Result;

            // ASSERT
            Assert.IsTrue(result.Response);



        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        public void Should_Throw_Exception_If_License_Is_Invalid()
        {
            var sut = Mock.Create<PdfConverter>(Behavior.CallOriginal); // system under test
            
            Mock.NonPublic.Arrange<bool>(sut, "IsLicenseValid").Returns(false);

            Mock.Arrange(() => sut.ConvertToPdf(@"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\input.txt",@"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\output.txt")).Throws<SecurityException>();

            sut.ConvertToPdf(@"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\input.txt",@"D:\Afzal\Projects\PdfConverter\PdfConverter\testfiles\output.txt");


        }
    }

    public class MockPdfConversionService : IPdfConversionService
    {
        public MockPdfConversionService()
        {
            this.AppUnitOfWork = new MockAppUnitOfWork();
        }
        public Task<AppResponse<byte[]>> Convert(byte[] fileBytes, string fileType)
        {
            return Task.Run(
                () =>
                    {
                        var fakeResponse = new AppResponse<byte[]>
                                               {
                                                   Response = new byte[100],
                                                   Exceptions = new Dictionary<string, string>()
                                               };
                        return fakeResponse;
                    });

        }

        public IAppUnitOfWork AppUnitOfWork { get; private set; }
    }

    public class MockAppUnitOfWork : IAppUnitOfWork
    {
        public MockAppUnitOfWork()
        {
            this.ClientRepository = Mock.Create<IClientRepository>();
            this.DocumentRepository = Mock.Create<IDocumentRepository>();
        }
        public IClientRepository ClientRepository { get; private set; }

        public IDocumentRepository DocumentRepository { get; private set; }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
