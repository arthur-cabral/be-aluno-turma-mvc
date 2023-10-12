using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoAlunoTurma.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        public async Task<IActionResult> GetAll(PaginationParameters paginationParameters)
        {
            var turmas = await _turmaService.GetAll(paginationParameters);
            return View(turmas);
        }

        public async Task<IActionResult> FormCreateTurma()
        {
            return View();
        }

        public async Task<IActionResult> FormUpdateTurma(Turma turma)
        {
            return View(turma);
        }


        public async Task<IActionResult> Create(Turma turma)
        {
            await _turmaService.Create(turma);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(Turma turma)
        {
            await _turmaService.Update(turma);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(Turma turma)
        {
            await _turmaService.Delete(turma.Id);
            return RedirectToAction("GetAll");
        }
    }
}
