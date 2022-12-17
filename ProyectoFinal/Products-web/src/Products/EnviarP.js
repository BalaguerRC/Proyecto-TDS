import React,{useRef,useEffect,useState} from "react";
import { basededato } from "../Login/ConfiguracionFirebase";
import fire from "../Login/ConfiguracionFirebase";

function EnviarP({AddPost}){
    const descripcion=useRef(null);
    const Title=useRef(null);
    const Price=useRef(null);

    const agregarpost=()=>{
        const post={
            titulo: Title.current.value,
            descripcion: descripcion.current.value,
            precio: Price.current.value
        }
        basededato.collection('productos').add(post);

        Title.current.value="";
        descripcion.current.value="";
        Price.current.value="";
        AddPost(post);
    }
    
    return(
        <div>
            <h1>Enviar un producto</h1>
            <div id="pdeenvio">
                <p>Apartado Admin</p>
            </div>
            <div>
                <input ref={Title} type="text" placeholder="Titulo"></input>
                <p></p>
                <input type="text" placeholder="Link Imagen"></input>
                <p></p>
                <input ref={descripcion} type="text" placeholder="Descripcion"></input>
                <p></p>
                <input ref={Price} type="text" placeholder="Precio"></input>
                <p></p>
                <button className="btn boton-envio" onClick={agregarpost}>Enviar</button>
            </div>
        </div>
    )
}
export default EnviarP;