import React from 'react';
import Students from './Students';
import Student from '../interfaces/Student';

const ListStudents: React.FC = () => {
    const students: Student[] = [
        { name: 'John', surname: 'Doe', studentNumber: '30', nationalId: "etas", dob: new Date() },
        { name: 'Johng', surname: 'Doe', studentNumber: '3440', nationalId: "etas", dob: new Date() },
    ];

    return (
        <div>
            <h1>Student List</h1>
            <Students students={students} />
        </div>
    );
};

export default ListStudents;
