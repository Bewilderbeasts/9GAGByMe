import logo from './logo.svg';
import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';
import './App.css';
import RegistrationForm from './registry/Register';
import LoginForm from './registry/Login';
import WelcomeBack from './pages/Main';
import { useNavigate } from 'react-router-dom';



class App extends Component {
    

    render() {
        var value;
        function logOut(){
            sessionStorage.removeItem("jwt");
        }

        function isLoggedIn() {
            let tokenValue = sessionStorage.getItem("jwt");
            
            if (tokenValue != null) {
                value = true;
                console.log(value);
            } else {
                value = false;
                console.log(value);
            }      
        }

        let button;
        if (value) {
            button = <a href="/login" class="split" onClick={logOut} >Logout</a>;
        } else {
            button = <><a href="/login" class="split">Login</a><a href="/register" class="split">Register</a></>;
        }

        return (
            <Router>
                <div>
                    <div class="topnav" id="myTopnav">
                        <a href="/" class="active">Home</a>
                        <a href="#about">About</a>
                        { isLoggedIn}
                        <a isLoggedIn={value} ></a>
                        {button}

                        {/*<div className="logout" >*/}
                        {/*    { isLoggedIn ? (*/}
                        {/*            <a href="/login" class="split" onClick={logOut} >Logout</a>*/}
                        {/*    ) : (*/}
                        {/*            <><a href="/login" class="split">Login</a></>*/}
                        {/*    )}*/}
                        {/*</div>*/}

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