using NUnit.Framework;
using System;

namespace SKGLTest
{
    public class UnitTest1
    {
        [Test]
        public void MachineCodeTest()
        {
            SKGL.Generate gen = new SKGL.Generate();
            string a= gen.MachineCode.ToString();
        }

        [Test]
        public void CreateAndValidateSimple()
        {
            SKGL.Generate gen = new SKGL.Generate();
            string a  = gen.doKey(30);

            SKGL.Validate val = new SKGL.Validate();

            val.Key = a;
            
            Assert.That( val.IsValid, Is.True );
            Assert.That( val.IsExpired, Is.False );
            Assert.That( val.SetTime, Is.EqualTo(30));

        }
        [Test]
        public void CreateAndValidateA()
        {

            SKGL.Validate val = new SKGL.Validate();

            val.Key = "MXNBF-ITLDZ-WPOBY-UCHQW";
            val.secretPhase = "567";

            Assert.That(val.IsValid, Is.True);
            Assert.That(val.IsExpired, Is.True);
            Assert.That(val.SetTime, Is.EqualTo(30));

        }
        [Test]
        public void CreateAndValidateC()
        {
            SKGL.SerialKeyConfiguration skm = new SKGL.SerialKeyConfiguration();

            SKGL.Generate gen = new SKGL.Generate(skm);
            skm.Features[0] = true;
            gen.secretPhase = "567";
            string a = gen.doKey(37);


            SKGL.Validate val = new SKGL.Validate();

            val.Key = a;
            val.secretPhase = "567";

            Assert.That( val.IsValid, Is.True );
            Assert.That( val.IsExpired, Is.False );
            Assert.That( val.SetTime, Is.EqualTo( 37 ) );
            Assert.That(val.Features[0], Is.True);
            Assert.That( val.Features[1], Is.False);

        }


        [Test]
        public void CreateAndValidateCJ()
        {


            SKGL.Validate val = new SKGL.Validate();

            val.Key = "LZWXQ-SMBAS-JDVDL-XTEHB";
            val.secretPhase = "567";

            int timeLeft = val.DaysLeft;

            Assert.That(val.IsValid, Is.True);
            Assert.That(val.IsExpired, Is.True );
            Assert.That( val.SetTime, Is.EqualTo( 30 ) );
            Assert.That(val.Features[0], Is.True );
            //Assert.IsTrue(val.Features[1] == false);

        }

        [Test]
        public void CreateAndValidateAM()
        {
            SKGL.Generate gen = new SKGL.Generate();
            string a = gen.doKey(30);

            SKGL.Validate ValidateAKey = new SKGL.Validate();

            ValidateAKey.Key = a;

            Assert.That(ValidateAKey.IsValid, Is.True );
            Assert.That(ValidateAKey.IsExpired, Is.False);
            Assert.That(ValidateAKey.SetTime, Is.EqualTo(30));

            if (ValidateAKey.IsValid)
            {
                // displaying date
                // remember to use .ToShortDateString after each date!
                Console.WriteLine("This key is created {0}", ValidateAKey.CreationDate.ToShortDateString());
                Console.WriteLine("This key will expire {0}", ValidateAKey.ExpireDate.ToShortDateString());

                Console.WriteLine("This key is set to be valid in {0} day(s)", ValidateAKey.SetTime);
                Console.WriteLine("This key has {0} day(s) left", ValidateAKey.DaysLeft);

            }
            else
            {
                // if invalid
                Console.WriteLine("Invalid!");
            }

        }
    }
}
