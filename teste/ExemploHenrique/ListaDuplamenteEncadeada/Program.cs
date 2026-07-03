using ListaDuplamenteEncadeada.Lists;

namespace ListaDuplamenteEncadeada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste com a lista encadeada circular com nó cabeça:");
            Console.WriteLine("Adicionando os valores 1, 15, 3, 10, 350, 15 nessa exata ordem (o valor 15 está repetido propositalmente)");
            var list = new CircularList();

            list.Add(1);
            list.Add(15);
            list.Add(3);
            list.Add(10);
            list.Add(350);
            list.Add(15);

            Console.WriteLine("Listando conteúdo da lista:");
            list.List();

            Console.WriteLine("Removendo o valor 15 e listando novamente:");
            list.Remove(15);
            list.List();

            Console.WriteLine("Esvaziando a lista e listando novamente:");
            list.Clear();
            list.List();

            Console.Write("Pressione alguma tecla para encerrar...");
            Console.ReadKey();
        }
    }
}
