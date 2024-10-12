
using System;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;

using System.Text;
using System.Management;
using System.Security;
using NUnit.Framework;

namespace SKGLTest
{
    public class SKGLPlusTest
    {
        [Test]
        public void test()
        {
            SKGL.Plus.Generate gen = new SKGL.Plus.Generate();

            var a = gen.doKey(3, 3, 1, 2);

            SKGL.Plus.Validate val = new SKGL.Plus.Validate();

            val.Key = a;

            //problem with max users. 1 -> 10?
            
           
        }
    }
}
