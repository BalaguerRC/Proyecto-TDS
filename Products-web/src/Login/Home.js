import React, { useState, useEffect } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import Show from "../Products/productAdmin/Products-Admin";
import Products_View from "../Products/Products-View";
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
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark sticky-top" id="muestraVisitante">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Market</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavDropdown">
                        <ul class="navbar-nav flex-row flex-wrap">
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="#">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Vista.html">Graphic</a>
                            </li>
                        </ul>
                        <ul class="navbar-nav flex-row flex-wrap ms-md-auto">
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    User
                                </a>
                                <ul class="dropdown-menu dropdown-menu-end" data-bs-popper="static">
                                    <li><a class="dropdown-item">{userF}</a></li>
                                    <li><hr className="dropdown-divider" /></li>
                                    <li><a class="dropdown-item" onClick={cerrarSesion}>Cerrar Sesion</a></li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>

            </nav>
            <div className="Productos SegundaVista rounded">
                <Show />
            </div>
        </div>
    );
    ;
}

export default Home;
