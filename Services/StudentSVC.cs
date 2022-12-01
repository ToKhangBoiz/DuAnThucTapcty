using ASM.Share.Interfaces;
using cty.Helpers;
using cty.Models;
using cty.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cty.Services
{
    public class StudentSVC : Istudent
    {
        protected DataContext _context;
        protected EncodeHelper _mahoaHelper;
        public StudentSVC(DataContext context, EncodeHelper mahoaHelper)
        {
            _context = context;
            _mahoaHelper = mahoaHelper;
        }
        public int AddStudent(Student student)
        {
            int ret = 0;
            try
            {
                student.PassWord = _mahoaHelper.Encode(student.PassWord);
                _context.Add(student);
                _context.SaveChanges();
                ret = student.ID_Student;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

      

        public int DeleteStudent(int id)
        {
            int ret = 0;
            try
            {
                var student = GetStudentId(id);
                _context.Remove(student);
                _context.SaveChanges();
                ret = student.ID_Student;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public int EditStudent(int id, Student student)
        {
            int ret = 0;
            try
            {
                student.PassWord = _mahoaHelper.Encode(student.PassWord);
                _context.Update(student);
                _context.SaveChanges();
                ret = student.ID_Student;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public List<Student> GetStudentAll()
        {
            List<Student> list = new List<Student>();
            list = _context.students.ToList();
            return list;
        }

        public Student GetStudentId(int id)
        {
            Student khachHang = null;
            khachHang = _context.students.Find(id);
            return khachHang;
        }

        public int KHEditStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }

     
        public Student Login(ViewLogin viewLogin)
        {
            var user = _context.students.Where(
               p => p.Name.Equals(viewLogin.UserName)
               && p.PassWord.Equals(_mahoaHelper.Encode(viewLogin.Password))
               ).FirstOrDefault();
            return user;
        }
    }
}
