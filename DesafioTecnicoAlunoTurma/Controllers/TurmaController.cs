using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using DesafioTecnicoAlunoTurma.Services;
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

        public async Task<IActionResult> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var turmas = await _turmaService.GetAll(paginationParametersDTO);
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
            var createTurma = await _turmaService.Create(turma);
            if (!createTurma.Success)
            {
                ModelState.AddModelError(string.Empty, createTurma.Message);
                return View("FormCreateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(Turma turma)
        {
            var updateTurma = await _turmaService.Update(turma);
            if (!updateTurma.Success)
            {
                ModelState.AddModelError(string.Empty, updateTurma.Message);
                return View("FormUpdateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(Turma turma)
        {
            await _turmaService.Delete(turma.Id);
            return RedirectToAction("GetAll");
        }
    }
}
