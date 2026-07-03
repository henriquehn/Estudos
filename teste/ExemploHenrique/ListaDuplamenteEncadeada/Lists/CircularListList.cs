using System;
using System.Collections.Generic;
using System.Text;

namespace ListaDuplamenteEncadeada.Lists
{
    /// <summary>
    /// Implementa uma lista circular duplamente encadeada com nó cabeça
    /// </summary>
    public partial class CircularList
    {
        /* Cria o nó cabeça e impede que ele seja alterado */
        private readonly Node head = new();

        /// <summary>
        /// Adiciona um novo valor à lista
        /// </summary>
        /// <param name="value"></param>
        public void Add(object value)
        {
            /*
             * o trecho "_ =" informa ao compilador que o valor não precisa ser armazenado em uma variável, evitando warning
             * apesar disso, o valor não será descartado pelo coletor de lixo, já que ele vai ter uma referência interna a partir do nó cabeça
             */
            _ = new Node(head.Previous, head, value);
        }

        /// <summary>
        /// Remove a primeira ocorrência de um valor da lista
        /// </summary>
        /// <param name="value"></param>
        /// <returns>returna True se um valor for removido e false caso contrário</returns>
        public bool Remove(object value)
        {
            var current = head.Next;
            while (current != head)
            {
                if (value.Equals(current.Value))
                {
                    current.UnBind();
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Apaga todos os valores da lista
        /// </summary>
        public void Clear()
        {
            /* Ao desvincular o nó cabeça, as referências para outros nós são removidas e a lista fica vazia.
             * Não existe necessidade de detruir esses objetos, o coletor de lixo fará isso.
             */
            head.UnBind();
        }

        /// <summary>
        /// Lista todos os valores no console
        /// </summary>
        public void List()
        {
            var current = head.Next;
            if (current != head)
            {
                /* O string builder serve para concatenação eficiente de strings 
                 * Ele é milhares de vezes mais rápido que a concatenação usando o operador "+".
                 */
                var sb = new StringBuilder();
                int count = 0;
                while (current != head)
                {
                    count++;
                    sb.Append(current.Value);
                    sb.AppendLine();
                    current = current.Next;
                }
                /* Uma string iniciada por $ é chamada de string interpolada 
                 * Ela permite que você parametrize valoes usando variáveis para formar a string final
                 * O método Insert do String Builder permite que você insira uma string em uma posição específica da string resultante
                 */
                sb.Insert(0, $"A lista contém {count} elementos:\r\n");
                Console.Write(sb.ToString());
            }
            else
            {
                Console.WriteLine("A lista está vazia.");
            }

        }
    }
}
