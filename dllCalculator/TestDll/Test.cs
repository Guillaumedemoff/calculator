using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dllCalculator;
using SuperComputer;

namespace TestDll
{
    [TestFixture()]
    class Test
    {
        [Test()]
        public void TestEvaluatePolynom()
        {
            EvaluatePolynom f = new EvaluatePolynom();

            Assert.That(f.Evaluate(new string[] { "1,4,5", "2" }), Is.EqualTo(17));
            Assert.That(f.Evaluate(new string[] { "1,4,-5", "2" }), Is.EqualTo(7));
            Assert.That(f.Evaluate(new string[] { "-5,1,4,5", "2" }), Is.EqualTo(-23));
            Assert.That(f.Evaluate(new string[] { "1,4,5", "-2" }), Is.EqualTo(1));
            Assert.That(delegate { f.Evaluate(new string[] { "a,4,5", "-2" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { "2,4,5", "-a" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { }); }, Throws.TypeOf<EvaluationException> ());
            Assert.That(f.Evaluate(new string[] { "1,4,5", "2", "5" }), Is.EqualTo(17));
        }

        [Test()]
        public void TestDerivate()
        {
            Derivative f = new Derivative();
            Assert.That(delegate { f.Evaluate(new string[] { "a,4,5", "-2" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { "&,4,5", "-a" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { }); }, Throws.TypeOf<EvaluationException>());
            //Assert.That(f.Evaluate(new string[] { "1,1", "2" }), Is.EqualTo(4));
        }

        [Test()]
        public void TestBinaryConverter()
        {
            BinairyConverter f = new BinairyConverter();
            Assert.That(f.Evaluate(new string[] {"d", "2"}), Is.EqualTo("10"));
            Assert.That(f.Evaluate(new string[] { "d", "12345" }), Is.EqualTo("11000000111001"));
            Assert.That(delegate { f.Evaluate(new string[] { "d", "dfgsdfg" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { "", "56" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { }); }, Throws.TypeOf<EvaluationException>());

            Assert.That(f.Evaluate(new string[] { "b", "10" }), Is.EqualTo("2"));
            Assert.That(f.Evaluate(new string[] { "b", "11000000111001" }), Is.EqualTo("12345"));
            Assert.That(delegate { f.Evaluate(new string[] { "b", "dfgsdfg" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { "", "010101" }); }, Throws.TypeOf<EvaluationException>());
            Assert.That(delegate { f.Evaluate(new string[] { }); }, Throws.TypeOf<EvaluationException>());
        }
    }
}
