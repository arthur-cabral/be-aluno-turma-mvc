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

        public async Task<IActionResult> FormUpdateAluno(AlunoDTO alunoDTO)
        {
            return View(alunoDTO);
        }
        
        public async Task<IActionResult> Create(AlunoDTO alunoDTO)
        {
            var createAluno = await _alunoService.Create(alunoDTO);
            if (!createAluno.Success)
            {
                ModelState.AddModelError(string.Empty, createAluno.Message);
                return View("FormCreateTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(AlunoDTO alunoDTO)
        {
            var updateAluno = await _alunoService.Update(alunoDTO);
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
