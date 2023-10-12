using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
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

        public async Task<IActionResult> GetAll(PaginationParameters paginationParameters)
        {
            var alunos = await _alunoService.GetAll(paginationParameters);
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
            await _alunoService.Create(aluno);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(Aluno aluno)
        {
            await _alunoService.Update(aluno);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(Aluno aluno)
        {
            await _alunoService.Delete(aluno.Id);
            return RedirectToAction("GetAll");
        }

    }
}
