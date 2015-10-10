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
        public void GetGetsAddedValue()
        {
            var e = new Entity();
            e.Add(new StringComponent("a")).Add(new StringComponent("b"));
            var actual = e.Get<StringComponent>();
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Value, Is.EqualTo("b"));
        }

        [Test]
        public void GetReturnsEmptyListIfNoComponentsAreAdded()
        {
            var e = new Entity();
            Assert.Throws<ArgumentException>(() => e.Get<StringComponent>());
        }

        [Test]
        public void AddSetsComponentEntityToMe()
        {
            var e = new Entity();
            var s = new StringComponent("abc");
            e.Add(s);
            Assert.That(s.Entity, Is.EqualTo(e));
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

