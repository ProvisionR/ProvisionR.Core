using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Tokenisation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Tokenisation
{
    [TestClass]
    public class TokeniserTests
    {
        private Tokeniser tokeniser;

        [TestInitialize]
        public void Setup()
        {
            tokeniser = new Tokeniser(MockObjects.MockObjects.GetMockDirectoryService(true).Object);
        }

        [TestMethod]
        public void Tokeniser_Implements_ITokeniser()
        {
            Assert.IsInstanceOfType(tokeniser, typeof(ITokeniser));
        }

        [TestMethod]
        public void Can_Tokenise_Entire_Directory_Recursive()
        {
            tokeniser.TokeniseDirectory(Environment.CurrentDirectory, new System.Collections.Generic.List<SharePoint.Provisioning.Core.Configuration.Token>(), true);
        }

    }
}