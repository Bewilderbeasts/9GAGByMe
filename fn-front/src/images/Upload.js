import React, { useState } from 'react';
import './images.css';
import { useNavigate } from "react-router-dom";
import jwt from 'jwt-decode';

function UploadImageForm() {

    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [userId, setUserId] = useState('');
    const [message, setMessage] = useState("");
    var invalidUpload;
    let navigate = useNavigate();

    let handleUpload = async (e) => {
        e.preventDefault();
        var data = new FormData();
        var imagedata = document.querySelector('input[type="file"]').files[0];
        data.append("data", imagedata);
        const token = localStorage.getItem("jwt");
        const user = jwt(token); // decode your token here
        const userId = user.unique_name;
        
            let res = await fetch("https://localhost:5001/api/Images", {
                method: "POST",
                body: JSON.stringify({
                    "UserId": userId,
                    "Title": title,
                    "Description": description,
                    "ImageFile": data,
                })
            });
            let resJson = await res.json();
            if (res.status === 200) {
                setTitle("");
                setMessage("Uploaded image successfully");
                invalidUpload = false;
                navigate("/redirect", { replace: true });
            } else {
                invalidUpload = true;
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
                    <form encType="multipart/form-data" action="" onSubmit={handleUpload}>
                <div className="title">
                            <label className="form__label" htmlFor="title" id="title">Title </label>
                            <input type="title" value={title} onChange={(e) => setTitle(e.target.value)} id="title" className="form__input" placeholder="Title" />
                </div>
                <div className="description">
                            <label className="form__label" htmlFor="description" id="description">Description </label>
                            <input type="description" value={description} onChange={(e) => setDescription(e.target.value)} id="description" className="form__input" placeholder="Description" />
                </div>
                <div className="uploadImage">
                    <label for="file-upload" class="custom-file-upload">
                        Upload Image
                    </label>
                    <div>
                        <input type="file" name="imageUpload" />         
                    </div>
                            
                </div>
                    <button type="submit" class="btn">Upload</button>
                    </form>
                </div>
            </div>
            
            
        </div>
    )
}
export default UploadImageForm;