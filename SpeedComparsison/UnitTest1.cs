using NUnit.Framework;
using System;


namespace SpeedComparsison
{
    public class UnitTest1
    {
        [Test]
        public void CreateAndValidateSimple()
        {
            SKGL.Generate gen = new SKGL.Generate();
            string a = gen.doKey(30);

            SKGL.Validate val = new SKGL.Validate();

            val.Key = a;

            Assert.That(val.IsValid, Is.True);
            Assert.That(val.IsExpired, Is.False);
            Assert.That(val.SetTime, Is.EqualTo(30));

        }
    }
}
