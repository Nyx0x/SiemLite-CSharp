using System;
using System.Collections.Generic; // Importante para usar Queue e List

namespace SiemLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> filaDeLogs = new Queue<string>();

            // Cenários simulados:
            filaDeLogs.Enqueue("Firewall,500");
            filaDeLogs.Enqueue("BancoDeDados,ErroCritico"); // ERRO: Não é número, vai cair no FormatException
            filaDeLogs.Enqueue("IdentityServer,-100");   // ERRO: Prejuízo negativo (Lógica), vai cair no Exception genérico
            filaDeLogs.Enqueue("Mainframe,2500");

            decimal prejuizoTotal = 0;

            Console.WriteLine(">>> INICIANDO PROCESSAMENTO DE AMEAÇAS (SIEM) <<<\n");

            while (filaDeLogs.Count > 0)
            {
                // Dequeue: Retira o próximo item da fila para processar
                string logBruto = filaDeLogs.Dequeue();
                Console.Write($"Processando log [{logBruto}]... ");

                try
                {
                    // Quebra a string "Sistema,Valor"
                    string[] partes = logBruto.Split(',');

                    // Validação básica a fim de evitar IndexOutOfRangeException
                    if (partes.Length != 2)
                        throw new Exception("Log em formato inválido.");

                    string sistema = partes[0];
                    // Tenta converter o valor (Isso pode gerar FormatException)
                    decimal valor = decimal.Parse(partes[1]);

                    if (valor < 0)
                    {
                        // Forçando o erro para que o sistema de captura trate
                        throw new Exception("Valor inconsistente detectado (Negativo).");
                    }

                    // Se passou pelo throw, soma e avisa
                    prejuizoTotal += valor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("SUCESSO.");
                    Console.ResetColor();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FALHA: Formato numérico inválido.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"ALERTA: {ex.Message}");
                    Console.ResetColor();
                }

                finally
                {
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\n--------------------------");
            // Exibe o total formatado como moeda (Currency)
            Console.WriteLine($"PREJUÍZO FINANCEIRO TOTAL: {prejuizoTotal:C}");

        }
    }
}
