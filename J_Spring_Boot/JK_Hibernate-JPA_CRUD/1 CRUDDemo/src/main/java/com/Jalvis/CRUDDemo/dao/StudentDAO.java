package com.Jalvis.CRUDDemo.dao;

import com.Jalvis.CRUDDemo.entity.Student;

public interface StudentDAO {
    public void add(Student student);
    public Student get(Integer id);

}
