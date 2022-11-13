import React, { useState, useEffect} from "react";
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
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark sticky-top" id="muestra">
                <h2 className="navbar-brand">Market</h2>
                <a>Usuario Visitante: {userF}</a>
            
                <button className="btn button3" onClick={cerrarSesion}>Cerrar Sesion</button>
            </nav>
            <div>
                <Products_View />
            </div>
        </div>
    );
    ;
}

export default Home_view;