using Backend_Web.Models;

namespace Backend_Web.Services
{
    public class EmployeeService
    {
        private AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) throw new KeyNotFoundException("Employee not found");
            return employee;
        }

        public void CreateEmployee(Employee model)
        {
            // validate
            Employee employee = new Employee();
            employee.EmployeeName = model.EmployeeName;
            employee.BirthDate = model.BirthDate;
            employee.Gender = model.Gender;
            employee.EmployeeAvatar = model.EmployeeAvatar;

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(int id, Employee model)
        {
            var employee = GetEmployeeById(id);
            employee.EmployeeName = model.EmployeeName;
            employee.BirthDate = model.BirthDate;
            employee.Gender = model.Gender;
            employee.EmployeeAvatar = model.EmployeeAvatar;

            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
