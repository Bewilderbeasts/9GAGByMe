import React, { useState } from 'react';
import './registry.css';

function LoginForm() {
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
                <div className="email">
                    <label className="form__label" for="email" id="emial">Email </label>
                    <input type="email" id="email" className="form__input" placeholder="Email" />
                </div>
                <div className="password">
                    <label className="form__label" for="password">Password </label>
                    <input className="form__input" type="password" id="password" placeholder="Password" />
                </div>
                    <button type="submit" class="btn">Login</button>
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