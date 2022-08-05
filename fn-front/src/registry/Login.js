import React, { useState } from 'react';
import './registry.css';
import { useNavigate } from "react-router-dom";

function LoginForm() {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");
    var invalidLogin;
    let navigate = useNavigate();

    let handleLogin = async (e) => {
        e.preventDefault();
        try {
            let res = await fetch("https://localhost:5001/api/Login", {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify({
                    "email": email,
                    "password": password,
                })
            });
            let resJson = await res.json();
            if (res.status === 200) {
                setEmail("");
                setMessage("Logged in successfully");
                const token = resJson.token;              
                localStorage.setItem("jwt", token);
                invalidLogin = false;
                navigate("/", { replace: true });
            } else {
                invalidLogin = true
            }
        } catch (err) {
            console.log(err);
        }
    };


    return (       
        <div class="site" className="form">
            <div class="content" className="leftside_content">
                <div className="textonsite">
                <div> FUNNYIMAGES.pl </div>
                <div> Share the laugh with the others. </div>
                </div>
            </div>
            <div class="login" className="form-body">
                <div className="input-body">
                    <form onSubmit={handleLogin}>
                <div className="email">
                            <label className="form__label" htmlFor="email" id="emial">Email </label>
                            <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} id="email" className="form__input" placeholder="Email" />
                </div>
                <div className="password">
                            <label className="form__label" htmlFor="password">Password </label>
                            <input className="form__input" value={password} onChange={(e) => setPassword(e.target.value)} type="password" id="password" placeholder="Password" />
                </div>
                    <button type="submit" class="btn">Login</button>
                    </form>
                </div>

                <span>or</span>

                <div className="register">                    
                <a href="/register"><button class="btn">Create an account</button></a>
                </div>
            </div>
            
            
        </div>
    )
}
export default LoginForm;