import React, { useState, useEffect, useRef } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc } from 'firebase/firestore';
import { db } from "../Login/ConfiguracionFirebase";
import "./productAdmin/index.css";

const Products_View = () => {

    //const [post1, setPost] = useState([]);
    const Link = useRef(null);
    const [produc, setProduc] = useState([]);
    const listado = []
    const listado2 = []
    const producCollectionRef = collection(db, 'productos');
    const [mostrar, SetMostrar] = useState([]);

    //
    const [post1, setPost] = useState([]);
    const [post2, setPost2] = useState([]);
    //

    const getProduc = async () => {
        const data = await getDocs(producCollectionRef);
        //console.log(data);
        setProduc(data.docs.map((doc) => ({ ...doc.data(), id: doc.id })));
        /*for (let index = 2; index < produc.length; index++) {
            const element = produc[index];
            console.log(element);
        }*/
        produc.forEach(post => {
            listado.push(post.imagen)

        })
        setPost(listado);
        //console.log(listado);
        for (let index = 2; index < listado.length; index++) {
            const element = listado[index];
            listado2.push(element);
            //s
        }
        setPost2(listado2)
        //console.log(listado2);
    }
    const MostrarProduct = (id, titulo, imagen, descripcion, precio) => {
        const pos = {
            id: id,
            titulo: titulo,
            imagen: imagen,
            descripcion: descripcion,
            precio: precio
        }
        SetMostrar(pos);

        //console.log(pos);
    }

    const Compra = (titulo, descripcion, precio) => {
        if (Link.current.value == "") {
            //return
        }
        else {
            const envio = {
                Titulo: titulo,
                Descripcion: descripcion,
                Precio: precio
            };
            console.log(envio);
            try {
                fetch(Link.current.value, {
                    method: 'POST',
                    //body: formData
                    body: JSON.stringify(envio),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                }).then(res => res.json())
                    .then(text => console.log(text))

                /*fetch('https://localhost:44336/api/Producto/')
                    .then(response => response.json())
                    .then(data => console.log(data))
                    .catch(error => console.log(error))*/
            }
            catch (error) {
                console.log(error);
            }
        }
    }
    useEffect(() => {
        getProduc()
    }, []);

    //div3
    //div className="Contenedor ps-lg-2"
    //div className="Productos container"
    return (
        <div>
            <div>
                <div>
                    <h1 class="display-5 fw-bold">Productos</h1>
                    <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-3" id="test10">
                        {
                            produc.map((produc) => {
                                return (
                                    <div className="col">
                                        <div id="div25" className="card h-100">

                                            <div className="divimagen10">
                                                <img src={produc.imagen} className="card-img-top " id="cardPro" width="auto" height="auto" />
                                            </div>

                                            <div className="card-body">
                                                <h4 className="card-tittle">{produc.titulo}</h4>
                                                <p className="card-text" >Descripcion: {produc.descripcion}</p>
                                                <h5>RD$ {produc.precio}</h5>
                                            </div>

                                            <button className="btn button3" data-bs-toggle="modal" data-bs-target="#exampleModal" onClick={() => { MostrarProduct(produc.id, produc.titulo, produc.imagen, produc.descripcion, produc.precio) }}>Comprar</button>
                                        </div>
                                    </div>
                                );
                            })
                        }
                    </div>
                </div>
            </div>
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content contenidoModal">
                        <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Comprar</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <div className="text-break">
                                Titulo: {mostrar.titulo}
                                <br />
                                Link Imagen: {mostrar.imagen}
                                <br />
                                Descripcion: {mostrar.descripcion}
                                <br />
                                Precio: {mostrar.precio}
                                <br />
                            </div>

                            <form>
                                <div className="mb-3">
                                    <label for="recipient-name" className="col-form-label">Link de la Base de Datos:</label>
                                    <input ref={Link} type="text" className="form-control" id="recipient-name" />
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btn-primary" data-bs-dismiss="modal" onClick={() => { Compra(mostrar.titulo, mostrar.descripcion, mostrar.precio) }}>Comprar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div>
                    <div class="container marketing" >
                        <div class="row">
                            {
                                post1.slice().reverse().map((produc) => {
                                    console.log(produc)
                                    /*return (
                                        <div class="col-lg-4" key={i}>
                                            <img src={produc} className="card-img-top"  id="cardPro" width="auto" height="auto" />
                                            <p><a class="btn btn-secondary" href="#">View details »</a></p>
                                        </div>
                                    )*/
                                })
                            }
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Products_View;