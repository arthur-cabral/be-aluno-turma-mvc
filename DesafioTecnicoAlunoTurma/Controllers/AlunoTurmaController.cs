using DesafioTecnicoAlunoTurma.DTO;
using DesafioTecnicoAlunoTurma.Interfaces.Services;
using DesafioTecnicoAlunoTurma.Models;
using DesafioTecnicoAlunoTurma.Pagination;
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

        public async Task<IActionResult> GetAll(PaginationParametersDTO paginationParametersDTO)
        {
            var alunoTurma = await _alunoTurmaService.GetAll(paginationParametersDTO);
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
            var createAlunoTurma = await _alunoTurmaService.Create(alunoTurma);
            if (!createAlunoTurma.Success)
            {
                ModelState.AddModelError(string.Empty, createAlunoTurma.Message);
                return View("FormCreateAlunoTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Update(AlunoTurma alunoTurma)
        {
            var updateAlunoTurma = await _alunoTurmaService.Update(alunoTurma);
            if (!updateAlunoTurma.Success)
            {
                ModelState.AddModelError(string.Empty, updateAlunoTurma.Message);
                return View("FormUpdateAlunoTurma");
            }
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Delete(AlunoTurma alunoTurma)
        {
            var deleteAlunoTurma = await _alunoTurmaService.Delete(alunoTurma.Id);
            if (!deleteAlunoTurma.Success)
            {
                ModelState.AddModelError(string.Empty, deleteAlunoTurma.Message);
                return View("GetAll");
            }
            return RedirectToAction("GetAll");
        }
    }
}
