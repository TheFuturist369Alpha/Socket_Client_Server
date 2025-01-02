package com.Jalvis.CRUDDemo.dao;


import com.Jalvis.CRUDDemo.entity.Student;
import jakarta.persistence.EntityManager;
import jakarta.transaction.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

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
}
