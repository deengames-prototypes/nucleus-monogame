using System;
using System.Linq;
using NUnit.Framework;
using Nucleus.Ecs;

namespace Nucleus.Tests.Ecs
{
    [TestFixture]
    public class EntityTest
    {
        [Test]
        public void GetGetsSetValue()
        {
            var e = new Entity();
            e.Add(new StringComponent("a")).Add(new StringComponent("b"));
            var actual = e.Get<StringComponent>();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Value, Is.EqualTo("b"));
        }

        [Test]
        public void GetReturnsEmptyListIfNoComponentsAreSet()
        {
            var e = new Entity();
            var ex = Assert.Throws<ArgumentException>(() => e.Get<StringComponent>());
        }


        class StringComponent : Component
        {
            public string Value { get;set; }

            public StringComponent(string value) {
                this.Value = value;
            }

        }
    }
}

