using System.Collections.Generic;
using Core;
using Core.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers
{
    public class TeacherController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DatabaseContext _dbContext;


        public TeacherController(DatabaseContext context)
        {
            _dbContext = context;
            _unitOfWork = new UnitOfWork(_dbContext);
        }
        
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return _unitOfWork.TeacherRepository.GetAll(x => x.Id != 0);
        }
        
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return _unitOfWork.TeacherRepository.Get(id);
        }
        
        [HttpPost]
        public void Post(JObject value)
        {
            var teacherModel = value.ToObject<Teacher>();
            _unitOfWork.TeacherRepository.Add(teacherModel);
            _unitOfWork.Save();
        }
        
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] JObject value)
        {
            var teacherModel = value.ToObject<Teacher>();
            _unitOfWork.TeacherRepository.Update(teacherModel);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unitOfWork.TeacherRepository.Remove(id);
            _unitOfWork.Save();
            _unitOfWork.Dispose();
        }
    }
}