import React, { useState, useEffect } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc } from 'firebase/firestore';
import { db } from "../Login/ConfiguracionFirebase";
import Post from "./post";
import EnviarP from "./EnviarP";
import "../Products/test/index.css";

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
    const MostrarProduct = (id, titulo, descripcion, precio) => {
        const pos = {
            id: id,
            titulo: titulo,
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
    return (
        <div>
            <div className="Contenedor ps-lg-2">
                <div className="Productos container">
                    <div className="row row-cols-1 row-cols-md-auto g-4" id="test10">
                        {
                            produc.map((produc) => {
                                return (
                                    <div className="producto_footer col card5">
                                        <div id="div2" className="card">
                                            <div className="Titulo">{produc.titulo}</div>
                                            <img src="https://cdn-icons-png.flaticon.com/512/25/25400.png" className="card-img-top" id="cardPro" width="160" height="160" />
                                            <p className="card-text" >Descripcion: {produc.descripcion}</p>
                                            <div>RD$ {produc.precio}</div>
                                            <button className="btn button3" data-bs-toggle="modal" data-bs-target="#exampleModal" onClick={() => { MostrarProduct(produc.id, produc.titulo, produc.descripcion, produc.precio) }}>Comprar</button>
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
                            Titulo: {mostrar.titulo}
                            <br />
                            Descripcion: {mostrar.descripcion}
                            <br />
                            Precio: {mostrar.precio}
                            <br />
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