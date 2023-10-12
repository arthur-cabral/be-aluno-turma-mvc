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

        public async Task<IActionResult> FormUpdateTurma(TurmaDTO turmaDTO)
        {
            return View(turmaDTO);
        }


        public async Task<IActionResult> Create(TurmaDTO turmaDTO)
        {
            var createTurma = await _turmaService.Create(turmaDTO);
            if (!createTurma.Success)
            {
                ModelState.AddModelError(string.Empty, createTurma.Message);
                return View("FormCreateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(TurmaDTO turmaDTO)
        {
            var updateTurma = await _turmaService.Update(turmaDTO);
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
