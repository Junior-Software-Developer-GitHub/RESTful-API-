using System.Collections.Generic;
using Core;
using Core.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DatabaseContext _dbContext;

        public StudentController(DatabaseContext context)
        {
            _dbContext = context;
            _unitOfWork = new UnitOfWork(_dbContext);
        }
        
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _unitOfWork.StudentRepository.GetAll(x => x.Id != 0);
        }
        
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _unitOfWork.StudentRepository.Get(id);
        }
        
        [HttpPost]
        public void Post(JObject value)
        {
            var studentModel = value.ToObject<Student>();
            _unitOfWork.StudentRepository.Add(studentModel);
            _unitOfWork.Save();
        }
        
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] JObject value)
        {
            var studentModel = value.ToObject<Student>();
            _unitOfWork.StudentRepository.Update(studentModel);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.StudentRepository.Remove(id);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
        }
    }
}