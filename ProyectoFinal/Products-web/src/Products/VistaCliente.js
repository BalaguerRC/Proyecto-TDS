import React, { useState, useEffect } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc } from 'firebase/firestore';
import { db, basededato } from "../Login/ConfiguracionFirebase";

const VistaCliente = () => {
    const [produc, setProduc] = useState([]);
    //
    const [post1, setPost] = useState([]);
    const [post2, setPost2] = useState([]);
    const listado = []
    const listado2 = []
    //
    const [produc2, setProduc2] = useState([]);
    const producCollectionRef = collection(db, 'productos');
    const getProduc = async () => {
        const data = await getDocs(producCollectionRef);
        //console.log(data);

        setProduc(data.docs.map((doc) => ({ ...doc.data(), id: doc.id }),produc.forEach(post => {
            listado.push(post.imagen)
        })));
        setPost(listado);
        //console.log(post1); 
        for (let index = 2; index < post1.length; index++) {
            const element = post1[index];
            listado2.push(element);
            //s
        }
        setPost2(listado2)
        console.log(post2);
    }
    useEffect(() => {
        /*const listado = []
        const listado2 = []
        const listado3 = []
        basededato.collection('productos').get().then(resultado => {
            resultado.forEach(post => {
                listado.push(post.data().imagen);
            })
            setPost(listado);
            //console.log(listado);
            for (let index = 2; index < post1.length; index++) {
                const element = listado[index];
                listado2.push(element);
            }
            listado2.forEach(post=>{
                listado3.push(post)
            })
            setPost2(listado3)
            //console.log(post2); 
        }).catch(error => console.error(error));*/

        getProduc()
    }, []);

    return (
        <div>
            <div class="container marketing" >
                <div class="row">
                    {
                        listado2.map((produc) => {
                            return (
                                <div class="col-lg-4">
                                    <img src={produc} className="card-img-top"  id="cardPro" width="auto" height="auto" />
                                    <p><a class="btn btn-secondary" href="#">View details »</a></p>
                                </div>
                            )
                        })
                    }
                </div>
            </div>
        </div>
    )
}

export default VistaCliente;