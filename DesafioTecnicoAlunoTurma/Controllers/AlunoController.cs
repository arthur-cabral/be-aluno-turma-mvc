using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
using DesafioTecnicoAlunoTurma.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioTecnicoAlunoTurma.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        public async Task<IActionResult> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var alunos = await _alunoService.GetAll(paginationParametersDTO);
            return View(alunos);
        }

        public async Task<IActionResult> FormCreateAluno()
        {
            return View();
        }

        public async Task<IActionResult> FormUpdateAluno(Aluno aluno)
        {
            return View(aluno);
        }
        
        public async Task<IActionResult> Create(Aluno aluno)
        {
            var createAluno = await _alunoService.Create(aluno);
            if (!createAluno.Success)
            {
                ModelState.AddModelError(string.Empty, createAluno.Message);
                return View("FormCreateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(Aluno aluno)
        {
            var updateAluno = await _alunoService.Update(aluno);
            if (!updateAluno.Success)
            {
                ModelState.AddModelError(string.Empty, updateAluno.Message);
                return View("FormUpdateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(Aluno aluno)
        {
            await _alunoService.Delete(aluno.Id);
            return RedirectToAction("GetAll");
        }

    }
}
