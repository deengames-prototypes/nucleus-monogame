using System;
using NUnit.Framework;

namespace Nucleus.Tests
{
    [TestFixture]
    public class TwoDComponentTest
    {
        [Test]
        public void XAndYGetValuesFromConstructor()
        {
            var twoD = new TwoDComponent(100, 50);
            Assert.That(twoD.X, Is.EqualTo(100));
            Assert.That(twoD.Y, Is.EqualTo(50));
        }

        [Test]
        public void PositionGetsValuesFromXAndY()
        {
            var twoD = new TwoDComponent();
            twoD.X = -17;
            twoD.Y = -37;
            Assert.That(twoD.Position.X, Is.EqualTo(-17));
            Assert.That(twoD.Position.Y, Is.EqualTo(-37));
        }
    }
}

