using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnicoAlunoTurma.Controllers
{
    public class AlunoTurmaController : Controller
    {
        private readonly IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoTurmaService)
        {
            _alunoTurmaService = alunoTurmaService;
        }

        public async Task<IActionResult> GetAll()
        {
            var alunoTurma = await _alunoTurmaService.GetAll();
            return View(alunoTurma);
        }

        public async Task<IActionResult> FormCreateAlunoTurma()
        {
            return View();
        }

        public async Task<IActionResult> FormUpdateAlunoTurma(AlunoTurma alunoTurma)
        {
            return View(alunoTurma);
        }

        public async Task<IActionResult> Create(AlunoTurma alunoTurma)
        {
            await _alunoTurmaService.Create(alunoTurma);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(AlunoTurma alunoTurma)
        {
            await _alunoTurmaService.Update(alunoTurma);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(AlunoTurma alunoTurma)
        {
            await _alunoTurmaService.Delete(alunoTurma.Id);
            return RedirectToAction("GetAll");
        }
    }
}
