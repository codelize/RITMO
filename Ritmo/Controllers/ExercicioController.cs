using Microsoft.AspNetCore.Mvc;
using Ritmo.Models;
using System.Collections.Generic;

namespace Ritmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        // Lista estática de exercícios para fins de exemplo
        private static List<Exercicio> Exercicios = new List<Exercicio>
        {
            new Exercicio { Id = 1, Nome = "Corrida", Descricao = "Corrida em esteira", Duracao = 30, Calorias = 300 },
            new Exercicio { Id = 2, Nome = "Caminhada", Descricao = "Caminhada ao ar livre", Duracao = 45, Calorias = 200 }
        };

        // GET: api/exercicio
        [HttpGet]
        public ActionResult<IEnumerable<Exercicio>> GetExercicios()
        {
            return Ok(Exercicios);
        }

        // GET: api/exercicio/5
        [HttpGet("{id}")]
        public ActionResult<Exercicio> GetExercicio(int id)
        {
            var exercicio = Exercicios.Find(e => e.Id == id);
            if (exercicio == null)
                return NotFound();
            return Ok(exercicio);
        }

        // POST: api/exercicio
        [HttpPost]
        public ActionResult<Exercicio> CreateExercicio(Exercicio exercicio)
        {
            Exercicios.Add(exercicio);
            return CreatedAtAction(nameof(GetExercicio), new { id = exercicio.Id }, exercicio);
        }

        // PUT: api/exercicio/5
        [HttpPut("{id}")]
        public IActionResult UpdateExercicio(int id, Exercicio exercicio)
        {
            var existingExercicio = Exercicios.Find(e => e.Id == id);
            if (existingExercicio == null)
                return NotFound();

            existingExercicio.Nome = exercicio.Nome;
            existingExercicio.Descricao = exercicio.Descricao;
            existingExercicio.Duracao = exercicio.Duracao;
            existingExercicio.Calorias = exercicio.Calorias;

            return NoContent();
        }

        // DELETE: api/exercicio/5
        [HttpDelete("{id}")]
        public IActionResult DeleteExercicio(int id)
        {
            var exercicio = Exercicios.Find(e => e.Id == id);
            if (exercicio == null)
                return NotFound();

            Exercicios.Remove(exercicio);
            return NoContent();
        }
    }
}
