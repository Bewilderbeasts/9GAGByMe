import logo from './logo.svg';
import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';
import './App.css';
import RegistrationForm from './registry/Register';
import LoginForm from './registry/Login';


class App extends Component {
    render() {
        return (
            <Router>
                <div>
                    <Routes>
                        <Route path='/register' element={<RegistrationForm />}/>
                        <Route path='/login' element={<LoginForm />} />
                    </Routes>
                </div>
            </Router>
        );
    }
}

export default App;