using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.DataAccess
{
    public static class EmployeeClass
    {
        public static List<EmployeeModel> LoadEmployee()
        {
            return DataAccessClass.LoadData<EmployeeModel>("spGetAll_Employee");
        }

        public static void InsertEmployee(string firstname, string lastname, string email,
        string address, string position, decimal salary)
        {
            EmployeeModel data = new EmployeeModel
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Address = address,
                Position = position,
                Salary = salary
            };

            DataAccessClass.SaveData("spInsert_Employee @FirstName, @LastName, @Email, @Address, @Position, @Salary", data);
        }

        public static void UpdateEmployee(int id, string firstname, string lastname, string email,
        string address, string position, decimal salary)
        {
            EmployeeModel data = new EmployeeModel
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Address = address,
                Position = position,
                Salary = salary
            };

            DataAccessClass.SaveData("spUpdateById_Employee @Id, @FirstName, @LastName, @Email, @Address, @Position, @Salary", data);
        }

        public static void DeleteEmployee(int id)
        {
            DataAccessClass.SaveData("spDeleteById_Employee @Id", new { Id = id });
        }
    }
}
