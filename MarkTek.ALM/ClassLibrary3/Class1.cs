using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    class Program
    {
        static void Main(string[] args)
        {
            new MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.ExportManager().Export("https://scottishwaterdev.sharepoint.com/sites/DevelopmentServices-Demo", "sharepointadmin@scottishwaterdev.onmicrosoft.com", "U2NvdHRpc2hXYXRlckFzdHJvU1A=", @"C:\Users\macunnin\Desktop\Extract");

        }
    }
}
