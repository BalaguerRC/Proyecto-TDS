///import logo from './logo.svg';
import React, { useState, useEffect } from "react";
//import './App.css';
import fire from "./Login/ConfiguracionFirebase";
import Login from "./Login/Login";
import Home from "./Login/Home";
import Home_view from "./Login/Home-View";
import { BrowserRouter as Router } from 'react-router-dom';
import { Paginas } from "./Components/Paginas";


function App() {

  const [usuario, setUsuario] = useState(null);
  const [abrire, setAbrire] = useState(null);
  useEffect(() => {
    fire.auth().onAuthStateChanged((usuarioFirebase) => {
      console.log("ya tienes sesion iniciada con:", usuarioFirebase);
      setUsuario(usuarioFirebase);
      setAbrire(usuarioFirebase.email);
      /*if(usuarioFirebase.email=="admin@gmail.com"){
        console.log("es admin");
      
      else{
        console.log("no es admin");
      }*/
    })
  }, []);

  const abrir = () => {
    if (abrire == "admin@gmail.com") {
      //console.log("Administrador: ", abrire);
      return (<Home />);
    }
    else {
      //console.log("Visitante: ", abrire);
      return (<Home_view />)
    }
  }

  return (
    <div>
      <>
        {usuario ? abrir() : <Login setUsuario={setUsuario} />}
      </>
      <div>

      </div>
    </div>
  );
}

export default App;