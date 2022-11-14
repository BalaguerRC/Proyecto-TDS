import React, { useState, useEffect } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import Products from "../Products/Products";
import Show from "../Products/test/show";
//import Login from "./Login";
//import Muro from "./Muro";



const Home = () => {
    const [userF, setUserF] = useState("");
    //const[userAdmin,setUserAdmin]=useState("")

    const cerrarSesion = () => {
        fire.auth().signOut();
    };
    useEffect(() => {
        fire.auth().onAuthStateChanged((userfirebase) => {

            setUserF(userfirebase.email);
        })
    }, []);
    return (
        <div>
            <div></div>
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark sticky-top" id="muestra">
                <h2 className="navbar-brand">Bienvenido</h2>
                <div class="container-fluid">
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="index.html">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Vista.html">test</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <a>Usuario: {userF}</a>
                <button className="btn button3" onClick={cerrarSesion}>Cerrar Sesion</button>
            </nav>
            <div>
                <Show />
            </div>
        </div>
    );
    ;
}

export default Home;
