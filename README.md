# COLLEGE SURVIVAL

O projeto refere-se a um jogo de RPG de vista na segunda dimensão (2D) ambientado em uma instituição de graduação. O jogador deve derrotar todos os monstros da classe boss existentes no mapa.

# ENREDO DO JOGO

João None Workefield, Tais Fubica Expers e Zé Nobody Cheafer são estudante calouros na graduação de engenharia na instituição SENSE (Serviço Nacional de Sobrevivência Escolar). Como estudantes eles devem enfrentar os desafios da vida acadêmica, estes envolvem derrotar todos reis dos monstros do conhecimento  (Lapain, Toest, Atom e Anaculo) que farão de tudo para prender os estudantes em um looping infinito de repetição de acontecimentos, ou seja, a cada morte você irá reiniciar tudo. Cabe a você ajudar estes estudantes a enfrentarem estes desafios.

# ESTRUTURA DOS PERSONAGENS DO JOGO
| Atributo | Descrição do atributo |
| --- | --- |
| Nome | Nome do personagem em jogo |
| Descrição | Informações sobre a história e características do personagem |
| Life | São os pontos de vida do personagem |
| Energia | São os pontos de “magia” do personagem |
| Ânimo | São os pontos de força do personagem |
| Persistência | São os pontos de resistência (defesa) do personagem |
| Conhecimento | São os pontos de experiencia do personagem |


# MECÂNICAS DO JOGO

O jogo possui mecânicas de funcionamento baseadas nas questões de movimentação, combate, nível, dano, itens e equipamentos. 

* Movimentação

A movimentação é para as todas direções incluindo diagonais sob perspectiva 2D vista de cima. 

* Combate

O combate ocorre quando o usuário encontrar um monstro no mapa, no qual no combate baseado em turnos o jogador tem que utilizar habilidades e itens a sua disposição para derrotar o inimigo, sendo que ao fazer qualquer ação o turno muda para o monstro também executar ações de combate (Ataque e defesa).

* Dano

Os danos ao usuário só são gerados em combate no qual o dano envolve os atributos do personagem sendo eles: life, animo e persistência. O dano gerado por um personagem é dado pela formula (dano geral = animo + dano do item ou habilidade), entretanto o dano efetivo implementa a persistência dano geral = animo + dano do item ou habilidade - persistência)

* Níveis dos personagens

Existem um total de 5 níveis, no qual inicia-se no nível 1 até o 5, para subir de nível utiliza-se do atributo conhecimento do personagem tendo quantidades de pontos necessários diferentes em cada nível. O conhecimento necessário para subir de nível é estipulada pela formula (conhecimento atual + 100 +((conhecimento atual + 100) * 0.2)), isso significa que a cada nível aumenta-se 20% de conhecimento necessário. A cada nível pode-se desbloquear uma habilidade e os atributos do personagem são aumentados.

# PRÉ-REQUISITOS E INSTALAÇÃO
Para jogar o game é necessário que se tenha o visual studio 2019 ou posterior com os pacotes Universal Windows Plataform Development e .NET Desktop development. Apos abrir o jogo através do visual studio deve-se execultar e buildar a solução, com isso será iniciado o jogo em uma nova janela.   

# TECNOLOGIAS E FERRAMENTAS
* Interface gráfica em UWP
* Linguagem de programação C#
* Testes unitários com NUnit
* Biblioteca de classe .net standard
