package com.Jalvis.CRUDDemo;

import com.Jalvis.CRUDDemo.dao.StudentDAOImp;
import com.Jalvis.CRUDDemo.entity.Student;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

import java.util.Scanner;

@SpringBootApplication
public class CrudDemoApplication {

	public static void main(String[] args) {
		SpringApplication.run(CrudDemoApplication.class, args);
	}

	@Bean
	public CommandLineRunner commandLineRunner(StudentDAOImp std){
		return runner->{
           System.out.print("Find student by Id:");
			Scanner scnr=new Scanner(System.in);
			int id=scnr.nextInt();
			System.out.print(getStudentById(id,std).toString());
		};
	}

	private void createStudent(StudentDAOImp std){
		Student student=new Student("Bruce","Wayne","bruce@gmail.com");
		System.out.println("Student object created.");
		std.add(student);
		System.out.println("Student: "+student.getFirstName()+" of id: "+student.getId()+" saved");
	}

	private Student getStudentById(Integer id, StudentDAOImp std){
		if(id!=null){
			return std.get(id);
		}
		System.out.println("Student of id:"+id+" not found.");
		return null;
	}

}
