using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoRPG;

namespace Teste {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void NivelEquipamento_Maior() {
            int nivel = 7;
            int eqnivel = 10;
            Equipamento eq = new Equipamento();
            Worker w = new Worker();
            w.Nivel = nivel;
            eq.NivelRequerido = eqnivel;
            try {
                w.EquiparEquipamento(eq);
            }
            catch (System.ArgumentException e) {
                StringAssert.Contains(e.Message, PersonagemJogavel.mensagem);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void NivelEquipamento_Menor_Igual() {
            int nivel = 5;
            int nIveleqp = 3;
            Worker wk = new Worker();
            wk.Nivel = nivel;
            Equipamento eqp = new Equipamento();
            eqp.NivelRequerido = nIveleqp;
            //Não está funcionando do jeito correto
            Assert.IsFalse(wk.EquiparEquipamento(eqp));
            
        }
        [TestMethod]
        public void NivelHabilidade_Maior() {
            int nivel = 1;
            int nivelhbl = 5;
            Expert ex = new Expert();
            Habilidade h = new Habilidade();
            ex.Nivel = nivel;
            h.NivelRequerido = nivelhbl;
            try {
                ex.ImplementarHabilidade(h);
            }
            catch(System.ArgumentException e) {
                StringAssert.Contains(e.Message, PersonagemJogavel.mensagem2);
                return;
            }
            Assert.Fail("Deu erro");
        }
        [TestMethod]
        public void NivelHabilidade_Menor_Igual() {
            int nivel = 2;
            int nivelhbl = 1;
            Expert ex = new Expert();
            Habilidade h = new Habilidade();
            ex.Nivel = nivel;
            h.NivelRequerido = nivelhbl;
            Assert.IsTrue(ex.ImplementarHabilidade(h));
        }
    }
   
}
