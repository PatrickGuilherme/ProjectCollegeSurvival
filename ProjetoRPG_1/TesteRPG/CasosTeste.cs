using NUnit.Framework;
using ProjetoRPG;
using System.Collections.Generic;
using System.Linq;

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
            wk.EquipamentosEquipados = new List<Equipamento>();
            ep.NivelRequerido = nivelequipamento;
            Assert.IsTrue(wk.EquiparEquipamento(ep));

            ep.NivelRequerido = 2;
            wk.Nivel = 2;
            wk.EquipamentosEquipados = new List<Equipamento>();
            Assert.IsTrue(wk.EquiparEquipamento(ep));
        }
        [Test]
        public void AtaqueMenorIgual_Defesa()
        {
            Worker worker = new Worker
            {
                Nome = "João None",
                Descricao = "",
                Life = 300,
                Energia = 500,
                MenuCraft = new Craft(),
                MaxEnergia = 500,
                MaxLife = 300,
                Animo = 20,
                Nivel = 1,
                Conhecimento = 0,
                Persistencia = 15,
                PosicaoX = 19,
                PosicaoY = 2,
                inventario = new Inventario()
                {
                    Itens = new List<Item>()
                },
                Habilidades = new List<Habilidade>()

            };
            worker.StartHabilidade();

            Gasefic gasefic = new Gasefic
            {
                Animo = 15,
                ConhecimentoDrop = 5,
                Life = 400,
                Energia = 150,
                Persistencia = 30
            };
            //defesa == ataque
            int result = worker.atacar(gasefic, null, worker.Habilidades.ElementAt<Habilidade>(0));
            Assert.AreEqual(0, result);

            //defesa maior ataque
            gasefic.Persistencia = 40;
            result = worker.atacar(gasefic, null, worker.Habilidades.ElementAt<Habilidade>(0));
            Assert.AreEqual(0, result);

        }
        [Test]
        public void AtaqueMaior_Defesa()
        {
            Worker worker = new Worker
            {
                Nome = "João None",
                Descricao = "",
                Life = 300,
                Energia = 500,
                MenuCraft = new Craft(),
                MaxEnergia = 500,
                MaxLife = 300,
                Animo = 20,
                Nivel = 1,
                Conhecimento = 0,
                Persistencia = 15,
                PosicaoX = 19,
                PosicaoY = 2,
                inventario = new Inventario()
                {
                    Itens = new List<Item>()
                },
                Habilidades = new List<Habilidade>()

            };
            worker.StartHabilidade();

            Gasefic gasefic = new Gasefic
            {
                Animo = 15,
                ConhecimentoDrop = 5,
                Life = 400,
                Energia = 150,
                Persistencia = 10
            };

            /*life: 200
             animo: 20
             dano da habilide: 10;
             dano habilidade + animo: 30

             persistencia: 10
             */
            int result = worker.atacar(gasefic, null, worker.Habilidades.ElementAt<Habilidade>(0));
            Assert.AreEqual(20, result);
        }
        [Test]
        public void HabilidadeNoListNivelMaiorIgual_nivelRequerido()
        {
            Worker worker = new Worker();
            worker.Nivel = 1;
            worker.Conhecimento = 240;
            worker.Habilidades = new List<Habilidade>();
            worker.LevelUp();

            Assert.AreEqual("Força do Ódio", worker.Habilidades.Last().Nome);

            worker.Conhecimento = 408;
            worker.LevelUp();

            Assert.AreEqual("Força do Ódio",worker.Habilidades.ElementAt<Habilidade>(0).Nome);
        }
        [Test]
        public void HabilidadeNoListNivelMenor_nivelRequerido()
        {
            Worker worker = new Worker();
            worker.Nivel = 1;
            worker.Habilidades = new List<Habilidade>();
            worker.StartHabilidade();

            Assert.AreNotEqual("Força do Ódio",worker.Habilidades.Last().Nome);
        }
        [Test]
        public void ConhecimentoMaiorIgual_Requerido()
        {
            Worker worker = new Worker();
            worker.Nivel = 1;
            worker.Conhecimento = 240;//igual
            worker.Habilidades = new List<Habilidade>();
            worker.LevelUp();

            Assert.AreEqual(2, worker.Nivel);//igual

            worker.Conhecimento = 500;
            worker.LevelUp();

            Assert.AreEqual(3,worker.Nivel);//maior
        }
        [Test]
        public void ConhecimentoMenor_Requerido()
        {
            Worker worker = new Worker();
            worker.Nivel = 1;
            worker.Conhecimento = 239;
            worker.Habilidades = new List<Habilidade>();
            worker.LevelUp();

            Assert.AreEqual(1, worker.Nivel);//igual
        }
        [Test]
        public void ConhecimentoRestante_posLevelUp()
        {
            Worker worker = new Worker();
            worker.Nivel = 1;
            worker.Conhecimento = 240;
            worker.Habilidades = new List<Habilidade>();
            worker.LevelUp();

            Assert.AreEqual(0,worker.Conhecimento);//zerar conhecimento

            worker.Conhecimento = 420;
            worker.LevelUp();

            Assert.AreEqual(12, worker.Conhecimento);//restante do nivel anterior
        }
    
    }
}

