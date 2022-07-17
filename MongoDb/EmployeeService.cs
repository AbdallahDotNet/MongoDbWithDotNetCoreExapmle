using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _students;
        private DataContext _context;
        public EmployeeService(DataContext context)
        {
            _context = context;
            var database = _context.CreateConnection();
            _students = database.GetCollection<Employee>("Employee");
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _students.Find(s => true).ToListAsync();
        }
        public async Task<Employee> GetByIdAsync(string id)
        {
            return await _students.Find<Employee>(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Employee> CreateAsync(Employee student)
        {
            await _students.InsertOneAsync(student);
            return student;
        }
        public async Task UpdateAsync(string id, Employee student)
        {
            await _students.ReplaceOneAsync(s => s.Id == id, student);
        }
        public async Task DeleteAsync(string id)
        {
            await _students.DeleteOneAsync(s => s.Id == id);
        }
    }
}
