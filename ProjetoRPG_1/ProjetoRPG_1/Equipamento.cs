using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG {
    public class Equipamento : Item {
        public string Tipo { get; set; }
        List<Equipamento> eq = new List<Equipamento>();
        
        public double calcBoostEquipamento(Equipamento equipamento) {
            adcionarEquipamento();
            foreach (var item in eq) {
                if (equipamento.Nome.Equals(item.Nome)) {
                    //Verrifica se o nome do equipamento passado por parametro é igual a de algum equipamento a lista
                    if(item.BuffEnergia != 0) { // Se o BuffEnergia for diferente de zero retorna-se o valor por sem(porcentagen)
                        return item.BuffEnergia * 100;
                    }
                    else if(item.BuffPersistencia != 0) {// Se o BuffPersistencia for diferente de zero retorna-se o valor por sem(porcentagen)
                        return item.BuffPersistencia * 100;
                    }
                   
                }
            }
            //Se ele sair do foreach significa que não foi encontrado nenhum equipamento passado na lista e por isso o valor que se retorna
            // do boost será zero
            return 0;
        }
        public void adcionarEquipamento() { //Nessa Funcao é adcionado em uma lista os dados de cada equipamento
            Equipamento[] e = new Equipamento[11];
            e[0] = new Equipamento("Agenda", "A agenda é um equipamento para aumentar o nivel de energia do personagem.",
                "Equipavel",5,0,0,0);
            e[1] = new Equipamento("Caderno 1M", "O caderno 1M é um equipamento para aumentar o nivel de energia do personagem, possuindo 1 matéria para portar anotações.",
             "Equipavel",10,0,0,0);
            e[2] = new Equipamento("Caderno 10M", "O caderno 10M é um equipamento para aumentar o nivel de energia do personagem, possuindo 10 matéria para portar anotações.",
                "Equipavel",15,0,0,0);
            e[3] = new Equipamento("Enciclopedia", "A enciclopédia é um equipamento para aumentar o nivel de energia do personagem, possuindo uma variação imensa de informações.",
               "Equipavel",20,0,0,0);
            e[4] = new Equipamento("Notebook", "O notebook é um equipamento para aumentar o nivel de energia do personagem, possuindo uma fonte ilimitada de informações",
                "Equipavel",25,0,0,0);
            e[5] = new Equipamento("Lapis", "O lápis é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
                "Equipavel",0,0,0,0);
            e[6] = new Equipamento("Lapis Mecanico", "O lápis Mecânico é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
                "Equipavel",0,0,0,0);
            e[7] = new Equipamento("Caneta", "A caneta é um equipamento para aumentar o animo do personagem e utiliza-lo contra inimigos.",
            "Equipavel",0,0,0,0);
            e[8] = new Equipamento("Borracha Branca", "A borracha branca é um equipamento para a persistência do personagem.",
            "Equipavel",0,0,0,5);
            e[9] = new Equipamento("Borracha Azul", "A borracha azul é um equipamento para a persistência do personagem.",
            "Equipavel",0,0,0,8);
            e[10] = new Equipamento("Borracha Duas Cores", "A borracha duas cores é um equipamento para a persistência do personagem.",
            "Equipavel",0,0,0,13);
            foreach (var item in e) {
                eq.Add(item);
            }
        }
        public Equipamento(string Nome, string Descricao,string Tipo, int BuffEnergia, int BuffLife,int BuffAnimo, int BuffPersistencia) {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Tipo = Tipo;
            this.BuffEnergia = BuffEnergia;
            this.BuffLife = BuffLife;
            this.BuffAnimo = BuffAnimo;
            this.BuffPersistencia = BuffPersistencia;
        }
    }
}
