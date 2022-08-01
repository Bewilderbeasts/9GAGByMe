import logo from './logo.svg';
import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';
import './App.css';
import RegistrationForm from './registry/Register';
import LoginForm from './registry/Login';
import WelcomeBack from './pages/Main';


class App extends Component {
    render() {
        return (
            <Router>
                <div>
                    <div class="topnav" id="myTopnav">
                        <a href="/" class="active">Home</a>
                        <a href="#about">About</a>

                        <a href="/register" class="split">Register</a>
                        <a href="/Login" class="split">Login</a>

                        <a href="javascript:void(0);" class="icon" onClick={myFunction}>
                            <i class="fa fa-bars"></i>
                        </a>

                    </div>

                    <Routes>
                        <Route path='/register' element={<RegistrationForm />}/>
                        <Route path='/login' element={<LoginForm />} />
                        <Route path='/' element={<WelcomeBack />} />
                    </Routes>
                </div>
            </Router>

        );
    }
}
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    }

    else {
        x.className = "topnav";
    }
}

export default App;