package com.Jalvis.CRUDDemo.dao;

import com.Jalvis.CRUDDemo.entity.Student;

import java.util.List;

public interface StudentDAO {
     void add(Student student);
     Student get(Integer id);
     List<Student> getStudents();
     List<Student> getByLastName(String name);
     void updateStudent(Student student);

}
