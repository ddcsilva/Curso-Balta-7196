using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly Tarefa _validTodo = new Tarefa("Titulo Aqui", DateTime.Now, "danilosilva");

        [TestMethod]
        public void Dado_Um_Novo_Todo_O_Mesmo_Nao_Pode_Ser_Concluido()
        {
            Assert.AreEqual(_validTodo.Concluido, false);
        }
    }
}