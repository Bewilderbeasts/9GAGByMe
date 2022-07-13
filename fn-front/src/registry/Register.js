import React, { useState } from 'react';
import './registry.css';
function RegistrationForm() {
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
                    <div className="email">
                        <label className="form__label" for="email" id="email">Email </label>
                        <input type="email" id="email" className="form__input" placeholder="Email" />
                    </div>
                    <div className="username">
                        <label className="form__label" for="username" id="username">Username </label>
                        <input type="email" id="email" className="form__input" placeholder="Email" />
                    </div>
                    <div className="password">
                        <label className="form__label" for="password">Password </label>
                        <input className="form__input" type="password" id="password" placeholder="Password" />
                    </div>
                    <button type="submit" class="btn">Register</button>
                </div>
            </div>


        </div>
    )
}
export default RegistrationForm;