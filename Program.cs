namespace TrabalhoThread;
class Program
{
    static void Main(string[] args)
    {
        /* O programa abaixo recebe pelo usuário uma quantidade de 
        cálculos fatoriais a serem realizados e os números de cada 
        um. Em seguida, instancia uma thread para cada cálculo e 
        inicia uma thread após a outra. */

        Console.WriteLine("Digite a quantidade de cálculos a serem realizados: ");
        int quantidadeCalculo = Convert.ToInt32(Console.ReadLine());

        int[] vetorNumeros = new int[quantidadeCalculo];

        for (int j = 0; j < vetorNumeros.Length; j++)
        {
            Console.Write($"Digite o número para o {j+1}º cálculo de fatorial: ");
            vetorNumeros[j] = Convert.ToInt32(Console.ReadLine());
        }

        int i = 0;
        while (i < quantidadeCalculo)
        {
            Thread thread = new Thread(() => CalcularFatorial(vetorNumeros[i]));
            thread.Name = "Thread " + i;
            thread.Start();
            
            if (i == quantidadeCalculo-1)
                break;
                        
            i++;
        }

        void CalcularFatorial(int x)
        {
            long fatorialAcumulado = 1;

            Console.WriteLine($"{Thread.CurrentThread.Name} - Iniciou");

            for (int i = x; i > 1; i--)
            {
                fatorialAcumulado *= i;
                Console.WriteLine($"{Thread.CurrentThread.Name} - {i} (cálculo iteração: {fatorialAcumulado})");
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} - Resultado {fatorialAcumulado}");
            fatorialAcumulado = 1;
        }
    }
}