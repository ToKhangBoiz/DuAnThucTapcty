using cty.Models;
using cty.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.Share.Interfaces
{
    public interface Istudent
    {
        List<Student> GetStudentAll();

        Student GetStudentId(int id);
        int AddStudent(Student student);
        int EditStudent(int id, Student student);
        int DeleteStudent(int id);
        Student Login(ViewLogin viewLogin);
      
        
    }
}
