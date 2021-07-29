using ComputerWebShopSPA.Models.Data;
using ComputerWebShopSPA.Models.Repo;
using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Service
{
    public class ComputerService : IComputerService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IComputerRepo _computerRepo;

        public ComputerService(ICategoryRepo categoryRepo, IComputerRepo computerRepo)
        {
            _categoryRepo = categoryRepo;
            _computerRepo = computerRepo;
        }

        public Computer Add(CreateComputer createComputer)
        {
            Computer computer = new Computer();
            Category category = _categoryRepo.Read(createComputer.CategoryId);

            if (category == null)
            {
                return null;
            }

            computer.Name = createComputer.Name;
            computer.Description = createComputer.Description;
            computer.ComputerSpecs = createComputer.ComputerSpecs;
            computer.Price = createComputer.Price;
            computer.ImageUrl = createComputer.ImageUrl;
            computer.ImageThumbnailUrl = createComputer.ImageThumbnailUrl;
            computer.IsInStock = createComputer.IsInStock;
            computer.IsOnSale = createComputer.IsOnSale;
            computer.CategoryId = createComputer.CategoryId;
            computer.Category = category;
            computer.CategoryName = category.Name;

            computer = _computerRepo.Create(computer);

            category.ComputerList.Add(computer);

            return computer;
        }

        public ComputerViewModel All()
        {
            ComputerViewModel computerViewModel = new ComputerViewModel();
            computerViewModel.ComputerList = _computerRepo.Read();

            return computerViewModel;
        }

        public ComputerViewModel All_2()
        {
            ComputerViewModel computerViewModel = new ComputerViewModel();
            computerViewModel.ComputerList = _computerRepo.Read_2();

            return computerViewModel;
        }

        public Computer FindById(int id)
        {
            return _computerRepo.Read(id);
        }

        public Computer Edit(int id, CreateComputer createComputer)
        {
            Computer originalComputer = FindById(id);

            if (originalComputer == null)
            {
                return null;
            }

            originalComputer.Name = createComputer.Name;
            originalComputer.Description = createComputer.Description;
            originalComputer.ComputerSpecs = createComputer.ComputerSpecs;
            originalComputer.Price = createComputer.Price;
            originalComputer.ImageUrl = createComputer.ImageUrl;
            originalComputer.ImageThumbnailUrl = createComputer.ImageThumbnailUrl;
            originalComputer.IsInStock = createComputer.IsInStock;
            originalComputer.IsOnSale = createComputer.IsOnSale;
            originalComputer.CategoryId = createComputer.CategoryId;
            originalComputer.Category = _categoryRepo.Read(createComputer.CategoryId);

            originalComputer = _computerRepo.Update(originalComputer);

            Category category = _categoryRepo.Read(createComputer.CategoryId);

            if (category != null)
            {
                category.ComputerList.Add(originalComputer);
            }

            return originalComputer;
        }

        public CreateComputer ComputerToCreateComputer(Computer computer)
        {
            CreateComputer createComputer = new CreateComputer();

            createComputer.Name = computer.Name;
            createComputer.Description = computer.Description;
            createComputer.ComputerSpecs = computer.ComputerSpecs;
            createComputer.Price = computer.Price;
            createComputer.ImageUrl = computer.ImageUrl;
            createComputer.ImageThumbnailUrl = computer.ImageThumbnailUrl;
            createComputer.IsInStock = computer.IsInStock;
            createComputer.IsOnSale = computer.IsOnSale;
            createComputer.CategoryId = computer.CategoryId;
            createComputer.Category = _categoryRepo.Read(computer.CategoryId);

            return createComputer;
        }

        public bool Remove(int id)
        {
            Computer computer = _computerRepo.Read(id);

            if (computer != null)
            {
                return _computerRepo.Delete(computer);
            }

            return false;
        }
    }
}
