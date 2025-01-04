package com.Jalvis.CRUDDemo.dao;


import com.Jalvis.CRUDDemo.entity.Student;
import jakarta.persistence.EntityManager;
import jakarta.persistence.TypedQuery;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class StudentDAOImp implements StudentDAO {

    private EntityManager mngr;

    @Autowired
    public StudentDAOImp(EntityManager mngr){
        this.mngr=mngr;
    }

    @Override
    @Transactional
    public void add(Student student) {
        if(student!=null) {
            mngr.persist(student);
            return;
        }
        return;
    }

    @Override
    public Student get(Integer id) {
     return mngr.find(Student.class,id);
    }

    @Override
    public List<Student> getStudents() {
        TypedQuery<Student> query= mngr.createQuery("FROM Student", Student.class);
        return query.getResultList();
    }

    @Override
    public List<Student> getByLastName(String name) {
        TypedQuery<Student>query=mngr.createQuery("FROM Student WHERE lastName=:paramData", Student.class);
        query.setParameter("paramData", name);
        return query.getResultList();
    }

    @Override
    @Transactional
    public void updateStudent(Student student) {
        mngr.merge(student);
    }
}
