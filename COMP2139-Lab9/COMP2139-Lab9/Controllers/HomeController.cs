using COMP2139_Lab9.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Lab9.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel vm)
        {
            TempData[vm.Selected.Id] = vm.Selected.Mark;

            TempData["nextTurn"] = (vm.Selected.Mark == "X") ? "O" : "X";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var board = new TicTacToeBoard();
            var cells = board.GetCells();
            foreach(Cell cell in cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            board.CheckForWinner();

            var model = new TicTacToeViewModel
            {
                Cells = cells,
                Selected = new Cell{Mark = TempData["nextTurn"]?.ToString() ?? "x"},
                IsGameOver = board.HasWinner || board.HasAllCellsSelected

            };

            if (model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                TempData["message"] = (board.HasWinner) ? $"{board.WinningMark} wins:" : "It's a tie!";
            }
            else
            {
                TempData.Keep();
            }
            return View(model);
        }
    }
}
