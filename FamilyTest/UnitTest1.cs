using m3Oblig1;
using NUnit.Framework;

namespace FamilyTest
{
    public class Tests
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = "17",
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = "2000",
                DeathYear = "3000",
                Father = new Person() { Id = "23", FirstName = "Per" },
                Mother = new Person() { Id = "29", FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void TestNoFields()
        {
            var p = new Person

            {
                Id = "1"
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = "17",
                FirstName = "Ola",
                LastName = "Nordmann",
                Father = new Person() { Id = "23", FirstName = "Per" },
                Mother = new Person() { Id = "29", FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void Test()
        {
            var sverreMagnus = new Person { Id = "1", FirstName = "Sverre Magnus", BirthYear = "2005" };
            var ingridAlexandra = new Person { Id = "2", FirstName = "Ingrid Alexandra", BirthYear = "2004" };
            var haakon = new Person { Id = "3", FirstName = "Haakon Magnus", BirthYear = "1973" };
            var harald = new Person { Id = "6", FirstName = "Harald", BirthYear = "1937" };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) F�dt: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) F�dt: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) F�dt: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [Test]
        public void TestSomeKids()
        {
            var sverreMagnus = new Person { Id = "1", FirstName = "Sverre Magnus", BirthYear = "2005" };
            var ingridAlexandra = new Person { Id = "2", FirstName = "Ingrid Alexandra", BirthYear = "2004" };
            var haakon = new Person { Id = "3", FirstName = "Haakon Magnus", BirthYear = "1973" };
            var harald = new Person { Id = "6", FirstName = "Harald", BirthYear = "1937" };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 2");
            var expectedResponse = "Ingrid Alexandra (Id=2) F�dt: 2004 Far: Haakon Magnus (Id=3)\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}