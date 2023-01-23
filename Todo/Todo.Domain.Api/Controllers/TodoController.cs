
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasTarefas([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodas("danilosilva");
        }

        [Route("concluidas")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidas([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasConcluidas("danilosilva");
        }

        [Route("nao-concluidas")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidas([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasNaoConcluidas("danilosilva");
        }

        [Route("concluidas/hoje")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidasHoje([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasPorPeriodo("danilosilva", DateTime.Now.Date, true);
        }

        [Route("nao-concluidas/hoje")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidasHoje([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasPorPeriodo("danilosilva", DateTime.Now.Date, false);
        }

        [Route("concluidas/amanha")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidasAmanha([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasPorPeriodo("danilosilva", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("nao-concluidas/amanha")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidasAmanha([FromServices] ITarefaRepository repository)
        {
            return repository.RetornarTodasPorPeriodo("danilosilva", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CriarTarefa([FromBody] CriarTarefaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = "danilosilva";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult AtualizarTarefa([FromBody] CriarTarefaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = "danilosilva";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("marcar-como-concluida")]
        [HttpPut]
        public GenericCommandResult MarcarComoConcluida([FromBody] MarcarComoConcluidaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = "danilosilva";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("marcar-como-nao-concluida")]
        [HttpPut]
        public GenericCommandResult MarcarComoNaoConcluida([FromBody] MarcarComoNaoConcluidaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = "danilosilva";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
