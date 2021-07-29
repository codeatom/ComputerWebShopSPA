using ComputerWebShopSPA.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Repo
{
    public interface IComputerRepo
    {
        public Computer Create(Computer computer);

        public List<Computer> Read();

        public List<Computer> Read_2();

        public Computer Read(int id);

        public Computer Update(Computer computer);

        public bool Delete(Computer computer);

    }
}
