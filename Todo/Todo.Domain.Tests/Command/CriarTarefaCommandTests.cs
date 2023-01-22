using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.Command
{
    [TestClass]
    public class CriarTarefaCommandTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void Dado_Um_Comando_Invalido()
        {
            var command = new CriarTarefaCommand("", DateTime.Now, "");
            command.Validate();
            Assert.AreEqual(command.Valid, false);
        }

        [TestMethod]
        public void Dado_Um_Comando_Valido()
        {
            var command = new CriarTarefaCommand("Título da Tarefa", DateTime.Now, "Danilo Silva");
            command.Validate();
            Assert.AreEqual(command.Valid, true);
        }
    }
}
