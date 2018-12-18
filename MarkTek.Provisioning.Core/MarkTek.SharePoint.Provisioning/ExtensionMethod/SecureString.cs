using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Core
{
    public static class SecureStringToClear
    {
        public static SecureString GetSecureString(this string clearText)
        {
            SecureString password = new SecureString();
            foreach (char c in clearText.ToCharArray()) password.AppendChar(c);
            return password;
        }
    }
}
