using ComputerWebShopSPA.Database;
using ComputerWebShopSPA.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public class ComputerRepo : IComputerRepo
    {
        private readonly AppDbContext _appDbContext;

        public ComputerRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Computer Create(Computer computer)
        {
            _appDbContext.Computers.Add(computer);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return computer;
        }

        public List<Computer> Read()
        {
            return _appDbContext.Computers
                .Include(c => c.Category)
                .ToList();
        }

        public List<Computer> Read_2()
        {
            List<Computer> computers = _appDbContext.Computers
                .Include(c => c.Category)
                .ToList();

            foreach (Computer computer in computers)
            {
                computer.Category = null;
            }

            return computers;
        }

        public Computer Read(int id)
        {
            return _appDbContext.Computers
                .Include(c => c.Category)
                .SingleOrDefault(c => c.Id == id);
        }

        public Computer Update(Computer computer)
        {
            Computer originalComputer = Read(computer.Id);

            if (originalComputer == null)
            {
                return null;
            }

            _appDbContext.Update(computer);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalComputer;
        }

        public bool Delete(Computer computer)
        {
            Computer originalComputer = Read(computer.Id);

            if (originalComputer == null)
            {
                return false;
            }

            _appDbContext.Computers.Remove(originalComputer);

            int result = _appDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        }
    }
}
