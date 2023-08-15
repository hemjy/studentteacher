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
    let headers = new Headers();

    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
  
    headers.append('Access-Control-Allow-Origin', 'http://localhost:3000');
    headers.append('Access-Control-Allow-Credentials', 'true');
  
    headers.append('GET', 'POST');
    useEffect(() => {
      // Fetch data from the API endpoint
      fetch('http://localhost:5055/api/student/all?pagenumber=1', {
        method: 'GET',
        headers,
    })
        .then((response) => response.json())
        .then((data) => setStudents(data))
        .catch((error) => console.error('Error fetching data:', error));
    }, []);
    console.log('stud', students);
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
