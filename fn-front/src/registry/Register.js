import React, { useState } from 'react';
import './registry.css';
import { useNavigate } from "react-router-dom";


function RegistrationForm() {

    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");
    let navigate = useNavigate();
    let handleSubmit = async (e) => {
        e.preventDefault();
        try {
            let res = await fetch("https://localhost:5001/api/Users", {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify({
                    "email": email,
                    "username": username,
                    "password": password,
                })
            });
            navigate("/", { replace: true });
            let resJson = await res.json();
            if (res.status === 200) {
                setEmail("");
                setUsername("");
                setMessage("User created successfully");
               
            } else {
                setMessage("Some error occured");
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
            <div class="register" className="form-body">
                
                <div className="input-body">
                    <form onSubmit={handleSubmit}>
                        <label className="form__label" htmlFor="email" id="email" >Email </label>
                        <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} id="email" className="form__input"  placeholder="Email" />
                    
                   
                        <label className="form__label" htmlFor="username" id="username">Username </label>
                        <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} id="username" className="form__input" placeholder="Username" />
                    
                    
                        <label className="form__label" htmlFor="password">Password </label>
                        <input className="form__input" value={password} onChange={(e) => setPassword(e.target.value)} type="password" id="password" placeholder="Password" />
                 <button type="submit" class="btn">Register</button> 
                       
                    </form>
                    </div>
                
            </div>
            

        </div>


    )
}
export default RegistrationForm;