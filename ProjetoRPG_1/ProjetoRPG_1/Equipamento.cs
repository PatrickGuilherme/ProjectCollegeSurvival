using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG {
    public class Equipamento : Item {
        public string Tipo { get; set; }
        public List<Equipamento> eq = new List<Equipamento>();
        
        /// <summary>
        ///  Calculo de boost dos equipamentos
        /// </summary>
        public void calcBoostEquipamento(Equipamento equipamento) {
        adcionarEquipamento();
        foreach (var item in eq) {
            if (equipamento.Nome.Equals(item.Nome)) {
                //Verrifica se o nome do equipamento passado por parametro é igual a de algum equipamento a lista
                if(item.BuffEnergia != 0) { // Se o BuffEnergia for diferente de zero retorna-se o valor por sem(porcentagen)
                    equipamento.BuffPersistencia = 0;
                    equipamento.BuffEnergia = item.BuffEnergia * 100;
                }
                else if(item.BuffPersistencia != 0) {// Se o BuffPersistencia for diferente de zero retorna-se o valor por sem(porcentagen)
                    equipamento.BuffEnergia = 0;
                    equipamento.BuffPersistencia = item.BuffPersistencia * 100;
                }
                   
            }
        }
        //Se ele sair do foreach significa que não foi encontrado nenhum equipamento passado na lista e por isso o valor que se retorna
        // do boost será zero
        }

        /// <summary>
        /// Nessa Funcao é adcionado em uma lista os dados de cada equipamento
        /// </summary>
        public void adcionarEquipamento() { 
            Equipamento[] e = new Equipamento[11];
            e[0] = new Equipamento("Agenda", "A agenda é um equipamento para aumentar o nivel de energia do personagem.",
                "Caderno",5,0,0,0,1);
            e[1] = new Equipamento("Caderno 1M", "O caderno 1M é um equipamento para aumentar o nivel de energia do personagem, possuindo 1 matéria para portar anotações.",
                "Caderno", 10,0,0,0,2);
            e[2] = new Equipamento("Caderno 10M", "O caderno 10M é um equipamento para aumentar o nivel de energia do personagem, possuindo 10 matéria para portar anotações.",
                "Caderno", 15,0,0,0,3);
            e[3] = new Equipamento("Enciclopedia", "A enciclopédia é um equipamento para aumentar o nivel de energia do personagem, possuindo uma variação imensa de informações.",
                "Caderno", 20,0,0,0,4);
            e[4] = new Equipamento("Notebook", "O notebook é um equipamento para aumentar o nivel de energia do personagem, possuindo uma fonte ilimitada de informações",
                "Caderno", 25,0,0,0,5);
            e[5] = new Equipamento("Lapis", "O lápis é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
                "Lapis",0,0,5,0,1);
            e[6] = new Equipamento("Lapis Mecanico", "O lápis Mecânico é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
                "Lapis", 0,0,10,0,3);
            e[7] = new Equipamento("Caneta", "A caneta é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
                "Lapis", 0,0,15,0,5);
            e[8] = new Equipamento("Borracha Branca", "A borracha branca é um equipamento para a persistência do personagem.",
                "Borracha", 0,0,0,5,2);
            e[9] = new Equipamento("Borracha Azul", "A borracha azul é um equipamento para a persistência do personagem.",
                "Borracha", 0,0,0,8,3);
            e[10] = new Equipamento("Borracha Duas Cores", "A borracha duas cores é um equipamento para a persistência do personagem.",
                "Borracha", 0,0,0,13,5);
            foreach (var item in e) {
                eq.Add(item);
            }
        }


        /// <summary>
        /// Metodo construtor de equipamento 
        /// </summary>
        public Equipamento(string Nome, string Descricao,string Tipo, int BuffEnergia, int BuffLife,int BuffAnimo, int BuffPersistencia, int nivelRequerido) {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Tipo = Tipo;
            this.BuffEnergia = BuffEnergia;
            this.BuffLife = BuffLife;
            this.BuffAnimo = BuffAnimo;
            this.BuffPersistencia = BuffPersistencia;
            this.NivelRequerido = nivelRequerido;
        }

        /// <summary>
        /// Metodo construtor em construção
        /// </summary>
        public Equipamento() {

        }
    }
}
