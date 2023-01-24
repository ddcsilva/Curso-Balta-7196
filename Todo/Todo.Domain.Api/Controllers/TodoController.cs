
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasTarefas([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodas(usuario);
        }

        [Route("concluidas")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidas([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasConcluidas(usuario);
        }

        [Route("nao-concluidas")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidas([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasNaoConcluidas(usuario);
        }

        [Route("concluidas/hoje")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidasHoje([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasPorPeriodo(usuario, DateTime.Now.Date, true);
        }

        [Route("nao-concluidas/hoje")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidasHoje([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasPorPeriodo(usuario, DateTime.Now.Date, false);
        }

        [Route("concluidas/amanha")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasConcluidasAmanha([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasPorPeriodo(usuario, DateTime.Now.Date.AddDays(1), true);
        }

        [Route("nao-concluidas/amanha")]
        [HttpGet]
        public IEnumerable<Tarefa> RetornarTodasNaoConcluidasAmanha([FromServices] ITarefaRepository repository)
        {
            var usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return repository.RetornarTodasPorPeriodo(usuario, DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult CriarTarefa([FromBody] CriarTarefaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult AtualizarTarefa([FromBody] CriarTarefaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("marcar-como-concluida")]
        [HttpPut]
        public GenericCommandResult MarcarComoConcluida([FromBody] MarcarComoConcluidaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("marcar-como-nao-concluida")]
        [HttpPut]
        public GenericCommandResult MarcarComoNaoConcluida([FromBody] MarcarComoNaoConcluidaCommand command, [FromServices] TarefaHandler handler)
        {
            command.Usuario = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
