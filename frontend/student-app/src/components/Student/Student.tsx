import React, { useState } from 'react';
import { Student } from '../../interfaces/Student';
import PageLinkButton from '../PageLinkButton';



const StudentForm: React.FC = () => {
    const [studentData, setStudentData] = useState<Student>({
      name: '',
      surname: '',
      studentNumber: '',
      nationalIdNumber: '',
      dateOfBirth: ''
    });
  
    const [errors, setErrors] = useState<Partial<Student>>({});
  
    const validateForm = () => {
      const newErrors: Partial<Student> = {};
  
      if (!studentData.name) {
        newErrors.name = 'Name is required';
      }
  
      if (!studentData.surname) {
        newErrors.surname = 'Surname is required';
      }
  
      if (!studentData.nationalIdNumber) {
        newErrors.nationalIdNumber = 'National Id Number is required';
      }
  
      if (!studentData.studentNumber) {
        newErrors.studentNumber = 'Student Number is required';
      } 
        
        
      if (!studentData.dateOfBirth) {
        newErrors.dateOfBirth = 'Date of Birth is required';
       } else if(!isValidDate(studentData.dateOfBirth)) {
        newErrors.dateOfBirth = 'Invalid date format';
       }
       else if(!isValiddateOfBirth(studentData.dateOfBirth)) {
        newErrors.dateOfBirth = 'Student must not be older than 21 years';
       }
      setErrors(newErrors);
  
      return Object.keys(newErrors).length === 0;
    };

    const isValidDate = (dateString: string) => {
        const pattern = /^\d{4}-\d{2}-\d{2}$/;
        return pattern.test(dateString) && !isNaN(Date.parse(dateString));
      };

    const isValiddateOfBirth = (dateString: string) =>{
        const dateOfBirth = new Date(dateString);
        const today: Date = new Date();
        const maxDate: Date = new Date(today);
        maxDate.setDate(today.getDate() - 21);
         return maxDate >= dateOfBirth;
    }
    const handleSubmit = async (e: React.FormEvent) => {
      e.preventDefault();
  
      if (validateForm()) {
        // Perform form submission or other actions here
        try {
            const response = await fetch('http://localhost:5055/api/student', {
              method: 'POST',
              headers: {
                'Content-Type': 'application/json',
              },
              body: JSON.stringify(studentData),
            });
            console.log("req", JSON.stringify(studentData));
      console.log("res", response);
            if (response.ok) {
              alert('Post submitted successfully!');
              // Clear form fields after successful submission
              setStudentData({
                name: '',
                surname: '',
                studentNumber: '',
                nationalIdNumber: '',
                dateOfBirth: ''
              });
            } else {
               const err = await response.json();
               console.log("err", err.errors);
              alert(err.errors);
            }
          } catch (error) {
            console.error('Error submitting post:', error);
          }
        console.log('Student created:', studentData);
      }
    };
  
    const handleInputChange = (field: keyof Student, value: string) => {
      setStudentData({
        ...studentData,
        [field]: value,
      });
    };
  
    return (
      <div>
        <h2>Add New Student</h2>
        <form onSubmit={handleSubmit}>
          <div>
            <label>Name:</label>
            <input
              type="text"
              value={studentData.name}
              onChange={(e) => handleInputChange('name', e.target.value)}
            />
            <p className="error">{errors.name}</p>
          </div>
          <div>
            <label>Surname:</label>
            <input
              type="text"
              value={studentData.surname}
              onChange={(e) => handleInputChange('surname', e.target.value)}
            />
            <p className="error">{errors.surname}</p>
          </div>
          <div>
            <label>Student Number:</label>
            <input
              type="text"
              value={studentData.studentNumber}
              onChange={(e) => handleInputChange('studentNumber', e.target.value)}
            />
            <p className="error">{errors.studentNumber}</p>
          </div>
          <div>
            <label>National Id Number:</label>
            <input
              type="text"
              value={studentData.nationalIdNumber}
              onChange={(e) => handleInputChange('nationalIdNumber', e.target.value)}
            />
            <p className="error">{errors.nationalIdNumber}</p>
          </div>
          <div>
            <label>Date  of Birth:</label>
            <input
              type="text"
              value={studentData.dateOfBirth}
              onChange={(e) => handleInputChange('dateOfBirth', e.target.value)}
            />
            <p className="error">{errors.dateOfBirth}</p>
          </div>
          <button type="submit">Submit</button>
        </form>
        <PageLinkButton label="Back" to='/' />
      </div>
    );
  };
  
  export default StudentForm;