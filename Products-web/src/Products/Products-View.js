import React, { useState, useEffect } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc } from 'firebase/firestore';
import { db } from "../Login/ConfiguracionFirebase";
import "./productAdmin/index.css";

const Products_View = () => {

    //const [post1, setPost] = useState([]);
    const [produc, setProduc] = useState([]);
    const producCollectionRef = collection(db, 'productos');
    const [mostrar, SetMostrar] = useState([]);

    const getProduc = async () => {
        const data = await getDocs(producCollectionRef);
        //console.log(data);
        setProduc(data.docs.map((doc) => ({ ...doc.data(), id: doc.id })));
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
                    <div className="row row-cols-1 row-cols-md-4 g-5" id="test10">
                        {
                            produc.map((produc) => {
                                return (
                                    <div className="col">
                                        <div id="div25" className="card h-100">

                                            <div className="divimagen10">
                                                <img src={produc.imagen} className="card-img-top " id="cardPro" width="auto" height="auto" />
                                            </div>
                                            <div className="Titulo">{produc.titulo}</div>
                                            <div className="card-body">

                                                <p className="card-text" >Descripcion: {produc.descripcion}</p>
                                                <div>RD$ {produc.precio}</div>
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
                    <div class="modal-content">
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
                                    <input type="text" className="form-control" id="recipient-name" />
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Comprar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div>

            </div>
        </div>
    );
}

export default Products_View;