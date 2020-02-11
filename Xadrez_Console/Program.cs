using System;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {

            try {
                //Criando uma nova partida_com_as_regras_do_xadrez
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) {

                    try {
                        Console.Clear();
                        //imprimindo tabuleiro entre outras coisas da partida
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        //Inserindo dados de origem (char, int) > a1 exemplo
                        Console.Write("Origem: ");
                        //lendo minha posição
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        //validando regras de origem
                        partida.validarPosicaoDeOrigem(origem);

                        //cor clareado das minhas posições possiveis
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        //imprimindoTabuleiro__Atualizando posições
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();

                        //Inserindo dados de destino(char, int) > a1 exemplo
                        Console.Write("Destino: ");
                        //lendo minha posição
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        //Validando (regras) posições de destino, 
                        partida.validarPosicaoDeDestino(origem, destino);
                        //realizando minha peça na posição de destino
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                //Atualizando Tabuleiro com as peças nas posições destinadas
                Tela.imprimirPartida(partida);
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
