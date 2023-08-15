import React from 'react';
import Student from '../interfaces/Student';

interface StudentsProps {
    students: Student[];
}

const Students: React.FC<StudentsProps> = ({ students }) => {
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

export default Students;
