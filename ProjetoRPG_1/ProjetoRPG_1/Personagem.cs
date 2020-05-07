using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
    public abstract class Personagem
    {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Life { get; set; }
        public int Energia { get; set; }
        public int Animo { get; set; }
        public int Persistencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        
        //atacar recebe o inimigo, o nome do item ou o nome da habilidade
        public int atacar(Personagem inimigo,string nomeItem, string nomeHabilidade)
        {
            //SE O ATACANTE FOR UM MONSTRO É SÓ NÃO PASSAR O nomeItem
            //OBS: SE A HABILIDADE OU ITEM TIVER DANO, ELE DEVE SER REALIZADO AQUI, OS METODOS DE USARHABILIDADE E USARITEM destinam-se a outros efeitos sem ser o de dano 
            //procura a habilidade ou item passado e aplica seus efeitos no inimigo ou no proprio jogador
            //depois descarta o item ou marca a habilidade como usada
            //se a habilidade tiver relação com incapacitar habilidade do inimigo (faz os procedimentos dela aqui ou em um metodo que seja chamado aqui)
            //retorna 1 ou 0; em caso de erro
            return 1;
        }

        public int calculoDano(Personagem inimigo, int dano) 
        {
            return 1;
        }

        public abstract bool StartHabilidade();
        
       
        public abstract bool UsarHabilidade(Habilidade habilidade);
        
    }
}
