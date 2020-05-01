using NUnit.Framework;

namespace TesteRPG
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EquipamentoNivel_Maior()
        {
            int nivel = 1;
            int niveleqp = 2;
            Worker wk = new Worker();
            Equipamento ep = new Equipamento();
            wk.Nivel = nivel;
            ep.NivelRequerido = niveleqp;
            Assert.IsFalse(wk.EquiparEquipamento(ep));
        }
        [Test]
        public void EquipametoNivel_MenorIgual() {
            int nivel = 2;
            int nivelequipamento = 1;
            Worker wk = new Worker();
            Equipamento ep = new Equipamento();
            wk.Nivel = nivel;
            ep.NivelRequerido = nivelequipamento;
            Assert.IsTrue(wk.EquiparEquipamento(ep));
        }
    }
}
