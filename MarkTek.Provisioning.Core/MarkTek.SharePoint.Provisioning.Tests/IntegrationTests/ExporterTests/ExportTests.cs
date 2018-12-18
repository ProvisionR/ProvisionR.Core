using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests
{
    [Ignore]
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TODO, moved into appsettings
        /// </summary>
        public string url = "https://markccap-admin.sharepoint.com";
        public string username = "markcccap@markccap.onmicrosoft.com";
        public string password = "Goodearl123";


        [TestMethod]
        public void Export_TermGroups()
        {
            var c = new Exporter.TermGroup.ExportTermGroup(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Lists()
        {
            var c = new Exporter.Lists.ListExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_ContentTypes()
        {
            var c = new Exporter.ContentTypes.ContentTypeExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Navigation()
        {
            var c = new Exporter.Navigation.NavigationExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Security()
        {
            var c = new Exporter.Security.SecurityExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_SiteFields()
        {
            var c = new Exporter.SiteFields.SiteFieldsExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Features()
        {
            var c = new Exporter.Features.FeaturesExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Properties()
        {
            var c = new Exporter.SiteProperties.SitePropertiesExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Files()
        {
            var c = new Exporter.Files.FilesExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_Pages()
        {
            var c = new Exporter.Pages.PagesExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_ClientSidePagesExporter()
        {
            var c = new Exporter.Export.ClientSidePagesExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

        [TestMethod]
        public void Export_ComposedLook()
        {
            var c = new Exporter.ComposedLook.ComposedLookExporter(url, username, password);
            c.SetExportPath(Environment.CurrentDirectory);
            c.Export();
        }

     

    }
}
