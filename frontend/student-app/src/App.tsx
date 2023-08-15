import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import ListStudents from './components/ListStudents';
import PageLinkButton from './components/PageLinkButton';

const App: React.FC = () => {
    return (
       <div>
        <ListStudents />
       </div>
    );
};

export default App;
