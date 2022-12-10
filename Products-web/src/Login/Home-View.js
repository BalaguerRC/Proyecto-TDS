import React, { useState, useEffect } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import Products_View from "../Products/Products-View";
import VistaCliente from "../Products/VistaCliente";
//import Login from "./Login";
//import Muro from "./Muro";



const Home_view = () => {
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

    //<Products_View />
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
                                <a class="nav-link active" aria-current="page" href="index.html">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#TodoProducto2">Store</a>
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
            <div className="SegundaVista">
                <div class="p-5 mb-4 text-bg-dark rounded-3">
                    <div class="container-fluid py-5">
                        <h1 class="display-5 fw-bold">Tienda Productos</h1>
                        <p class="col-md-8 fs-4">Aqui puedes comprar los productos que necesites para tu gestor de productos, recuerda que necesitas un link para enviar los datos a la base de datos del gestor.</p>
                        <a class="btn btn-primary btn-lg" type="button" href="#TodoProducto2">Productos</a>
                    </div>
                </div>
            </div>

            <div className="SegundaVista rounded" id="TodoProducto2">
                <hr class="featurette-divider"></hr>
                <Products_View />
            </div>
            
            <footer className="bd-footer py-4 py-md-5 mt-5 text-bg-dark">
                <div className="container py-4 py-md-5 px-4 px-md-3">Prueba</div>
            </footer>
        </div>
    );
    ;
}

export default Home_view;