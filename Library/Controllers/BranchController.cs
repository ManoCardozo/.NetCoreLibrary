﻿using Library.Models.Branch;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private ILibraryBranch _branch;

        public BranchController(ILibraryBranch branch)
        {
            _branch = branch;
        }

        public IActionResult Index()
        {
            var branches = _branch
                .GetAll()
                .Select(b => new BranchDetailModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    IsOpen = _branch.IsBranchOpen(b.Id),
                    NumberOfAssets = _branch.GetAssets(b.Id).Count(),
                    NumberOfPatrons = _branch.GetPatrons(b.Id).Count(),
                });

            var model = new BranchIndexModel
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);

            var model = new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfAssets = _branch.GetAssets(id).Count(),
                NumberOfPatrons = _branch.GetPatrons(id).Count(),
                TotalAssetValue = _branch.GetAssets(id).Sum(a => a.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branch.GetBranchHours(id)
            };

            return View(model);
        }
    }
}
