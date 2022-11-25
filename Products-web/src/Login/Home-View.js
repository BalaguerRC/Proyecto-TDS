import React, { useState, useEffect } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import Products from "../Products/Products";
import Products_View from "../Products/Products-View";
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
                                <a class="nav-link" href="#">Store</a>
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
            <div className="VistaProducto">
                <div className="carouselMe">
                    <div id="carouselExampleControls" class="carousel carousel-dark slide" data-bs-ride="carousel">
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="https://st.depositphotos.com/1502235/1685/i/600/depositphotos_16852709-stock-photo-parcels-ready-for-dispatch.jpg" class="d-block w-100" alt="..." />
                            </div>
                            <div class="carousel-item">
                                <img src="https://st2.depositphotos.com/2288675/5791/i/450/depositphotos_57916281-stock-photo-gift-packages-wrapped-in-brown.jpg" class="d-block w-100" alt="..." />
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.hamex.hu/wp-content/uploads/2018/09/csomag.jpg" class="d-block w-100" alt="..." />
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
                <div>
                    <Products_View />
                </div>
            </div>
            <footer className="bd-footer py-4 py-md-5 mt-5 bg-light">
                <div className="container py-4 py-md-5 px-4 px-md-3">Prueba</div>
            </footer>
        </div>
    );
    ;
}

export default Home_view;