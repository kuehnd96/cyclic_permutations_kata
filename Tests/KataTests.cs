using System;
using System.Collections.Generic;
using System.Linq;
using Kata;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private readonly KataClass kata = new KataClass();

        [Test]
        public void TestCyclicPermutations2()
        {
            Assert.AreEqual("", kata.CyclicPermutations(0));
            Assert.AreEqual("1", kata.CyclicPermutations(1));
            Assert.AreEqual("12\n21", kata.CyclicPermutations(2));
            Assert.AreEqual("123\n312\n231", kata.CyclicPermutations(3));
            Assert.AreEqual("1234\n4123\n3412\n2341", kata.CyclicPermutations(4) );
            Assert.AreEqual("12345\n51234\n45123\n34512\n23451",kata.CyclicPermutations(5));
            Assert.AreEqual("123456\n612345\n561234\n456123\n345612\n234561", kata.CyclicPermutations(6));
            Assert.AreEqual("1234567\n7123456\n6712345\n5671234\n4567123\n3456712\n2345671", kata.CyclicPermutations(7));
            Assert.AreEqual("12345678\n81234567\n78123456\n67812345\n56781234\n45678123\n34567812\n23456781", kata.CyclicPermutations(8));
            Assert.AreEqual("123456789\n912345678\n891234567\n789123456\n678912345\n567891234\n456789123\n345678912\n234567891",kata.CyclicPermutations(9));
        }

    }
}