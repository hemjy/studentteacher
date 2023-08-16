import React from 'react';
import { BrowserRouter as Router, Routes, Route }
    from "react-router-dom";
import ListStudents from './components/ListStudents';
import StudentForm from './components/Student/Student';

const App: React.FC = () => {
    return (
         <Router>
         <Routes>
           <Route path="/student" element={<StudentForm />}/>
           <Route path="/" element={<ListStudents/>}/>
         </Routes>
       </Router>
    );
};

export default App;
