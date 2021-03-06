// <copyright file="XmlHelperTest.cs">Copyright ©  2015</copyright>
using System;
using System.Linq;
using System.Collections.Generic;
using EMIE.Parser.Library.Entities;
using EMIE.Parser.Library.Utils;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMIE.Parser.Library.Utils.Tests
{
    /// <summary>This class contains parameterized unit tests for XmlHelper</summary>
    [PexClass(typeof(XmlHelper))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexArguments(@"C:\Projects\GitHub\emie-parser\EMIE\EMIE.Parser.Library.Tests\Files\sample.xml")]
    [TestClass]
    public partial class XmlHelperTest
    {
        /// <summary>Test stub for ReadEnterpriseDiscoveryXml(String)</summary>
        [PexMethod]
        public IEnumerable<Entry> ReadEnterpriseDiscoveryXmlTest(string fileName)
        {
            var result = new List<Entry>();

            for (int i = 0; i < 20; i++)
                result.AddRange(XmlHelper.ReadEnterpriseDiscoveryXml(fileName));


            Assert.IsTrue(result.Count() == 20);
            return result;
        }
    }
}
