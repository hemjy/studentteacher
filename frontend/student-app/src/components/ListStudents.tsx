import React, { useEffect, useState } from 'react';

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
        .then((data) => setStudents(data))
        .catch((error) => console.error('Error fetching data:', error));
    }, []);
    console.log(students);
    return (
        <div>
            <h2>List of Student</h2>
            <ul>
                {students.map((student, index) => (
                    <li key={index}>
                       {student.studentNumber} {student.name} {student.surname}, 
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ListStudents;
