//using System;
//using System.Threading;
//using MarkTek.SharePoint.Provisioning.Core;
//using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Lists;
//using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.TermGroup;
//using Microsoft.SharePoint.Client;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace MarkTek.SharePoint.Provisioning.Tests
//{
//    [Ignore]
//    [TestClass]
//    public class UnitTest1
//    {
//        /// <summary>
//        /// TODO, moved into appsettings
//        /// </summary>
//        public string url = "https://markccap-admin.sharepoint.com";
//        public string username = "markcccap@markccap.onmicrosoft.com";
//        public string password = "Goodearl123";
//        private ClientContext _context;


//        [TestInitialize]
//        public void Setup()
//        {
//                _context = new   Microsoft.SharePoint.Client.ClientContext(url)
//                {
//                    Credentials = new SharePointOnlineCredentials(username, password.GetSecureString()),
//                    RequestTimeout = Timeout.Infinite
//                };
//        }

//        [TestMethod]
//        public void Export_TermGroups()
//        {
//            var c = new ExportTermGroup(_context);// url, username, password);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Lists()
//        {
//            var c = new ListExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_ContentTypes()
//        {
//            var c = new ContentTypeExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Navigation()
//        {
//            var c = new NavigationExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Security()
//        {
//            var c = new Exporter.Security.SecurityExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_SiteFields()
//        {
//            var c = new Exporter.SiteFields.SiteFieldsExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Features()
//        {
//            var c = new Exporter.Features.FeaturesExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Properties()
//        {
//            var c = new Exporter.SiteProperties.SitePropertiesExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Files()
//        {
//            var c = new Exporter.Files.FilesExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_Pages()
//        {
//            var c = new Exporter.Pages.PagesExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_ClientSidePagesExporter()
//        {
//            var c = new Exporter.Export.ClientSidePagesExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

//        [TestMethod]
//        public void Export_ComposedLook()
//        {
//            var c = new Exporter.ComposedLook.ComposedLookExporter(_context);
//            c.SetExportPath(Environment.CurrentDirectory);
//            c.Export();
//        }

     

//    }
//}
