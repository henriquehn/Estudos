namespace ListaDuplamenteEncadeada.Lists
{
    public partial class CircularList
    {
        /// <summary>
        /// Implementa um nó da lista
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Propriedade somente para leitura que retorna o próximo objeto da lista
            /// </summary>
            public Node Next { get; private set; } /* private set garante que o valor da propriedade pode ser atribuído dentro da própria classe */
            /// <summary>
            /// Propriedade somente para leitura que retorna o elemento anterior da lista
            /// </summary>
            public Node Previous { get; private set; } /* private set garante que o valor da propriedade pode ser atribuído dentro da própria classe */
            public object Value { get; } /* a ausência do bloco set impede a atribuição de valor fora do contrutor, exceto na própria declaração da propriedade */

            /// <summary>
            /// Inicializa o objeto sem valor, com next e previous apontando para o próprio objeto
            /// </summary>
            /// <remarks>
            /// O valor é inicializado 
            /// </remarks>
            public Node(): this(new object()) /* chamei um construtor que já existe para economizar trabalho */ { }

            public Node(object value)
            {
                /* somente o construtor tem a prerrogativa de atribuir valor a uma propriedade somente leitura fora da linha de declaração da propriedade */
                this.Value = value;
                this.Previous = this;
                this.Next = this;
            }
            public Node(Node previous, Node next, object value): this(value) /* chamei um construtor que já existe para economizar trabalho */ 
            {
                this.Bind(previous, next);
            }

            /// <summary>
            /// Insere o nó atual entre dois outros nós, garantindo o vínculo correto
            /// </summary>
            /// <param name="previous">nó anterior</param>
            /// <param name="next">nó seguinte</param>
            public void Bind(Node previous, Node next)
            {
                this.Previous = previous;
                this.Next = next;
                this.Previous.Next = this;
                this.Next.Previous = this;
            }

            /// <summary>
            /// Remove o nó da lista, desvinculando dos nós próximos, ajustando os vínculos corretos
            /// </summary>
            public void UnBind()
            {
                this.Next.Previous = this.Previous;
                this.Previous.Next = this.Next;
                this.Previous = this;
                this.Next = this;
            }
        }
    }
}
