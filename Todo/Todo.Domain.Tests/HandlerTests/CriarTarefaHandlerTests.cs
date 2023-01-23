using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CriarTarefaHandlerTests
    {
        [TestMethod]
        public void Dado_Um_Comando_Invalido_Deve_Interromper_A_Execucao()
        {
            var command = new CriarTarefaCommand("", DateTime.Now, "");
            var handler = new TodoHandler(null);
            Assert.Fail();
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido_Deve_Criar_A_Tarefa()
        {
            Assert.Fail();
        }
    }
}