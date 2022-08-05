import { useState } from "react";
import { useNavigate } from "react-router-dom";
import './main.css';

function Redirecting() {
    const [redirectNow, setRedirectNow] = useState(false);
    const nav = useNavigate();
    setTimeout(() => setRedirectNow(true), 5000);
    return redirectNow ? (
        nav("/")
    ) : (
            <div class="site" className="welcome">
                <div class="content" className="welcome-left">
                    <div className="foreground" >
                        <div className="returnmessage">
                            Welcome back!
                        </div>
                    </div>
                </div>
            </div>
    );
}

export default Redirecting;