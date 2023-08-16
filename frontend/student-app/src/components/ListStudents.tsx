import React, { useEffect, useState } from 'react';
import "./ListStudent.css";

interface Student {
    name: string;
    surname: string;
    nationalId: string;
    studentNumber: string;
    dob: Date;
}

const ListStudents: React.FC = () => {
  
    const [students, setStudents] = useState<Student[]>([]);
    useEffect(() => {
      // Fetch data from the API endpoint
      fetch('http://localhost:5055/api/student/all?pagenumber=1')
        .then((response) => response.json())
        .then((data) => setStudents(data.data))
        .catch((error) => console.error('Error fetching data:', error));
    }, []);
    console.log('stud', students);
    return (
        <div>
            <h2>List of Student</h2>
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
