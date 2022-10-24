import React,{useState,useEffect} from "react";
import { basededato } from "../Login/ConfiguracionFirebase";
import Post from "./post";

const Products=()=>{

    const[post1,setPost]=useState([]);

    const AddPost=(post)=>{
        const tempPost= post1.slice();
        tempPost.push(post);
        setPost(tempPost);
    }

    useEffect(()=>{

        
        const listado=[]
        basededato.collection('productos').get().then(result=>{
            result.forEach(post=>{
                listado.push(post.data());
            })
            
         }).catch(error=>console.error(error));
    }, []);

    return(
        <div>
            {
                post1 && post1.slice().reverse().map((post,i)=>{
                    const {titulo,descripcion,precio}= post
                    return(<Post key={i} titulo={titulo} descripcion={descripcion} precio={precio}/>)
                })
            }
        </div>
    );
}

export default Products;