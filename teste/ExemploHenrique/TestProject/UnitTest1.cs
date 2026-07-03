using ListaDuplamenteEncadeada.Lists;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;

namespace TestProject
{
    public class Tests
    {
        private static CircularList list;

        [SetUp]
        public void Setup()
        {
            try
            {
                list = new CircularList();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Não foi possível criar uma instância da lista: {ex.Message}");
            }
        }

        [Test(Description = "Adicionando os valores 1, 15, 3, 10, 350, 15 nessa exata ordem"), Order(1)]
        public void AdicionandoItens()
        {
            string message;

            Assert.That(AddItem(1, out message), Is.True, message);
            Assert.That(AddItem(15, out message), Is.True, message);
            Assert.That(AddItem(3, out message), Is.True, message);
            Assert.That(AddItem(10, out message), Is.True, message);
            Assert.That(AddItem(350, out message), Is.True, message);
            Assert.That(AddItem(15, out message), Is.True, message);
        }

        private bool AddItem(object value, out string message)
        {
            message = "";
            try
            {
                list.Add(value);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        [Test(Description = "Listando itens inseridos"), Order(2)]
        public void ListItemsAfterAdd()
        {
            bool success = false;
            string message = "";
            try
            {
                list.List();
                success = true;
            }
            catch (Exception ex)
            {
                message = $"Falha listar itens: {ex.Message}";
            }
            Assert.That(success, Is.True, message);
        }

        [Test(Description = "Removendo a primeira ocorrência do item 15"), Order(3)]
        public void RemovendoItem15()
        {
            bool success = false;
            string message = "";
            try
            {
                list.Remove(15);
                success = true;
            }
            catch (Exception ex)
            {
                message = $"Falha ao remover o item 15: {ex.Message}";
            }
            Assert.That(success, Is.True, message);
        }

        [Test(Description = "Listando itens após remoção do item 15"), Order(4)]
        public void ListItemsAfterRemove()
        {

            bool success = false;
            string message = "";
            try
            {
                list.List();
                success = true;
            }
            catch (Exception ex)
            {
                message = $"Falha listar itens: {ex.Message}";
            }
            Assert.That(success, Is.True, message);
        }


        [Test(Description = "Esvaziando a lista"), Order(5)]
        public void Cleaning()
        {
            bool success = false;
            string message = "";
            try
            {
                list.Clear();
                success = true;
            }
            catch (Exception ex)
            {
                message = $"Falha ao esvaziar lista: {ex.Message}";
            }
            Assert.That(success, Is.True, message);
        }

        [Test(Description = "Listando itens após esvaziar a lista"), Order(6)]
        public void ListItemsAfterClear()
        {
            bool success = false;
            string message = "";
            try
            {
                list.List();
                success = true;
            }
            catch (Exception ex)
            {
                message = $"Falha listar itens: {ex.Message}";
            }
            Assert.That(success, Is.True, message);
        }

    }
}
