using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game_of_Life;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLlegirTauler()
        {
            bool[,] tauler, result = { { true, true, true }, { true, true, false }, { true, false, true } };
            Game partida = new Game();
            partida.llegirTauler("3,3;111110101");
            tauler = partida.Tauler;
            CollectionAssert.AreEqual(result, tauler);
        }
        [TestMethod]
        public void TestLlegirTauler2()
        {
            bool[,] tauler, result = { { false, false, false, false }, { false, true, false, true }, { false, true, true, false }, { false, false, false, false } };
            Game partida = new Game();
            partida.llegirTauler("4,4;0000 0101 0110 0000");
            tauler = partida.Tauler;
            CollectionAssert.AreEqual(result, tauler);
        }

        [TestMethod]
        public void TestCelulaNoViu()
        {
            bool[,] tauler = {
                        { false, false, false, false },
                        { false, true, false, true },
                        { false, true, true, false },
                        { false, false, false, false } };
            bool result;
            Game partida = new Game();
            partida.Tauler = tauler;
            result = partida.Viu(0, 2);
            Assert.AreEqual(false, result);
            result = partida.Viu(3, 3);
            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void TestCelulaViu()
        {
            bool[,] tauler = { 
                { false, false, false, false }, 
                { false, true, false, true }, 
                { false, false, true, false }, 
                { false, false, false, false } };
            bool result;
            Game partida = new Game();
            partida.Tauler = tauler;
            result = partida.Viu(1, 2);
            Assert.AreEqual(true, result);
            result = partida.Viu(2, 2);
            Assert.AreEqual(true, result);
        }
    }
}
