import React, { useState, useEffect } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import Show from "../Products/productAdmin/Products-Admin";
import Products_View from "../Products/Products-View";
//import {Link} from "react-router-dom";
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
                            <li class="nav-item">
                                <a class="nav-link" href="#">Producto</a>
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
            <div>
                <div className="SegundaVista">
                    <div className="container">
                        <div class="p-5 mb-4 text-bg-dark rounded-3">
                            <div class="container-fluid py-5">
                                <h1 class="display-5 fw-bold">Apartado Administrativo</h1>
                                <p class="col-md-8 fs-4">Aqui puede agregar los diferentes productos para mostrarse en la tienda, tambien poder editarlos y eliminarlos.</p>
                                <a class="btn btn-primary btn-lg" type="button" href="#TodoProducto">Productos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="Productos SegundaVista rounded" id="TodoProducto">
                <Show />
            </div>
            <footer className="bd-footer py-4 py-md-5 mt-5 text-bg-dark">
                <div className="container py-4 py-md-5 px-4 px-md-3">Prueba</div>
            </footer>
        </div>
    );
    ;
}

export default Home;
