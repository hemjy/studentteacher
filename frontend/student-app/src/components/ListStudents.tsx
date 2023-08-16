import React, { useEffect, useState } from 'react';
import { Student } from '../interfaces/Student';
import { useNavigate } from 'react-router-dom';
import "./ListStudent.css";


const ListStudents: React.FC = () => {
    const navigate = useNavigate();
  
    const [students, setStudents] = useState<Student[]>([]);
    useEffect(() => {
      // Fetch data from the API endpoint
      fetch('http://localhost:5055/api/student/all?pagenumber=1')
        .then((response) => response.json())
        .then((data) => setStudents(data.data))
        .catch((error) => console.error('Error fetching data:', error));
    }, []);
    const AddNewStudent = () => {
  
        navigate('/student'); 
      };
    return (
        <div>
            <h2>List of Student</h2>
            <button onClick={AddNewStudent}>Add new Student </button>
            <table>
            <tr>
                    <th>Student Number</th>
                    <th>Name</th>
                    <th>Surname</th>
                </tr>
                {students.map((student, index) => (
                     <tr>
                     <td>{student.studentNumber}</td>
                     <td>{student.name}</td>
                     <td>{student.surname}</td>
                   </tr>
                ))}
            </table>
        </div>
    );
};

export default ListStudents;
