///import logo from './logo.svg';
import React, {useState, useEffect} from "react";
//import './App.css';
import fire from "./Login/ConfiguracionFirebase";
import Login from "./Login/Login";
import Home from "./Login/Home";


function App() {

  const [usuario,setUsuario] = useState(null);
  useEffect(()=>{
    fire.auth().onAuthStateChanged((usuarioFirebase)=>{
      console.log("ya tienes sesion iniciada con:", usuarioFirebase);
      setUsuario(usuarioFirebase);
      /*if(usuarioFirebase.email=="admin@gmail.com"){
        console.log("es admin");
      }
      else{
        console.log("no es admin");
      }*/
    })
  },[]);
  
  return (
    <div>
     <>
     {usuario ? <Home/> : <Login setUsuario={setUsuario}/>}
     </>
    </div>
  );
}

export default App;