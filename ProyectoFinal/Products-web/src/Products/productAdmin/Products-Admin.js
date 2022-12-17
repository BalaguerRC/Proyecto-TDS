import React, { useState, useEffect, useRef } from "react";
import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc, addDoc } from 'firebase/firestore';
import { db } from "../../Login/ConfiguracionFirebase";
import { async } from "@firebase/util";
import EnviarP from "../EnviarP";
import "./index.css";
import { saveProduct, editProduct, removeProduct } from "./crud";

const Show = () => {
    const Descripcion = useRef(null);
    const Title = useRef(null);
    const Imagen = useRef(null);
    const Price = useRef(null);
    //
    const Descripcion2 = useRef(null);
    const Title2 = useRef(null);
    const Price2 = useRef(null);
    const Imagen2 = useRef(null);
    /*const [newtitulo, setTitulo] = useState(null);
    const [newdescripcion, setDescripcion] = useState(null);
    const [newprecio, setPrecio] = useState(null);*/

    const [produc, setProduc] = useState([]);
    const producCollectionRef = collection(db, 'productos');

    const [mostrar, SetMostrar] = useState([]);

    //const [post1, setPost] = useState([]);
    const getProduc = async () => {
        const data = await getDocs(producCollectionRef);
        //console.log(data);
        setProduc(data.docs.map((doc) => ({ ...doc.data(), id: doc.id })));

        Title2.current.value = "";
        Imagen2.current.value = "";
        Descripcion2.current.value = "";
        Price2.current.value = "";
    }
    const AddProduct = () => {
        if (Title2.current.value == "" || Descripcion2.current.value == "" || Price2.current.value == "") {
            /*return (
                <div>
                    <div class="modal fade" id="ModalData" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    ...
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    <button type="button" class="btn btn-primary">Save changes</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            )*/
        }
        else {
            if (Imagen2.current.value == "") {
                Imagen2.current.value = "https://cdn-icons-png.flaticon.com/512/25/25400.png";
                saveProduct(
                    Title2.current.value,
                    Imagen2.current.value,
                    Descripcion2.current.value,
                    Price2.current.value
                )
            }
            else {
                saveProduct(
                    Title2.current.value,
                    Imagen2.current.value,
                    Descripcion2.current.value,
                    Price2.current.value
                )
            }
            getProduc();
        }
    }
    const EditPost = (id, titulo, imagen, descripcion, precio) => {
        const pos = {
            id: id,
            titulo: titulo,
            imagen: imagen,
            descripcion: descripcion,
            precio: precio
        }
        Title.current.value = pos.titulo;
        Imagen.current.value = pos.imagen;
        Descripcion.current.value = pos.descripcion;
        Price.current.value = pos.precio;
        SetMostrar(pos);

        //console.log(pos);
    }
    const EditarPost = async (id, titulo, imagen, descripcion, precio) => {
        if (imagen == "") {
            imagen = "https://cdn-icons-png.flaticon.com/512/25/25400.png";
            await editProduct(id, titulo, imagen, descripcion, precio)
        }
        else {
            await editProduct(id, titulo, imagen, descripcion, precio)
        }
        getProduc();
    }

    const deletePost = async (id) => {
        await removeProduct(id);
        getProduc();
    }

    useEffect(() => {
        getProduc()
    }, [])

    return (
        <div className="container">
            <hr class="featurette-divider"></hr>
            <h1 class="display-5 fw-bold">Productos</h1>
            <h3 className="fw-bold">Cantidad de productos: {produc.length}</h3>
            <div id="envio" className="EnviarProducto" >
                <p>
                    <a class="btn btn-primary botonCentro" data-bs-toggle="collapse" href="#multiCollapseExample1" role="button" aria-expanded="false" aria-controls="multiCollapseExample1">+</a>
                </p>
                <div class="row">
                    <div class="col">
                        <div class="collapse multi-collapse" id="multiCollapseExample1">
                            <div class="envio3" >
                                <div>
                                    <h1>Enviar un producto</h1>
                                    <div id="pdeenvio">
                                        <p>Apartado Admin</p>
                                    </div>
                                    <div>
                                        <input ref={Title2} type="text" placeholder="Titulo" id="validationCustom05" required></input>
                                        <p></p>
                                        <input ref={Imagen2} type="text" placeholder="Link Imagen"></input>
                                        <p></p>
                                        <input ref={Descripcion2} type="text" placeholder="Descripcion" id="validationCustom01" required></input>
                                        <p></p>
                                        <input ref={Price2} type="text" placeholder="Precio" id="validationCustom02" required></input>
                                        <p></p>
                                        <button className="btn boton-envio" onClick={AddProduct} >Enviar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div className="row row-cols-1 row-cols-sm-2 row-cols-md-4 g-3">
                    {produc.map((produc) => {
                        return (
                            <div className="col">
                                <div key={produc.id}>

                                    <div id="div25" className="card h-100">
                                        <h3 className="ID">ID: {produc.id}</h3>
                                        <div className="divimagen10">
                                            <img src={produc.imagen} className="card-img-top" id="cardPro" width="auto" height="auto" />
                                        </div>
                                        <div className="card-body">
                                            <h5 className="card-tittle">Titulo: {produc.titulo}</h5>
                                            <p className="card-text" >Descripcion: {produc.descripcion}</p>
                                            <div>RD$ {produc.precio}</div>
                                        </div>

                                        <div className="btn-group" role="group" aria-label="Basic outlined example">
                                            <button type="button" className="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal" onClick={() => { EditPost(produc.id, produc.titulo, produc.imagen, produc.descripcion, produc.precio) }}>Editar</button>
                                            <button type="button" data-bs-toggle="modal" className="btn btn-danger btnDelete" data-bs-target="#Deleteconfirm" onClick={() => { EditPost(produc.id, produc.titulo, produc.imagen, produc.descripcion, produc.precio) }}>Borrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>
            <div class="modal fade" id="Deleteconfirm" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content contenidoModal">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Confirmacion de borrado</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            Esta seguro de eliminar este producto ID: {mostrar.id}?
                        </div>
                        <div class="modal-footer">
                            <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <button class="btn btn-primary" onClick={() => { deletePost(mostrar.id) }} data-bs-dismiss="modal">Confirmar</button>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div className="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog modal-dialog-centered ">
                        <div className="modal-content contenidoModal">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="exampleModalLabel" >Editar</h1>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <div className="text-break">
                                    Id: {mostrar.id}
                                    <br />
                                    Titulo: {mostrar.titulo}
                                    <br />
                                    Imagen: {mostrar.imagen}
                                    <br />
                                    Descripcion: {mostrar.descripcion}
                                    <br />
                                    Precio: {mostrar.precio}
                                    <br />
                                </div>

                                <form>
                                    <div className="mb-3">
                                        <label for="recipient-name" className="col-form-label">Titulo:</label>
                                        <input ref={Title} type="text" className="form-control" id="recipient-name" />
                                    </div>
                                    <div className="mb-3">
                                        <label for="recipient-name" className="col-form-label">Imagen:</label>
                                        <input ref={Imagen} type="text" className="form-control" id="recipient-name" />
                                    </div>
                                    <div className="mb-3">
                                        <label for="recipient-name" className="col-form-label">Precio:</label>
                                        <input ref={Price} type="text" className="form-control" id="recipient-name" />
                                    </div>
                                    <div className="mb-3">
                                        <label for="message-text" className="col-form-label">Descripcion:</label>
                                        <textarea ref={Descripcion} className="form-control" id="message-text"></textarea>
                                    </div>
                                </form>
                            </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <button className="btn btn-primary" onClick={() => { EditarPost(mostrar.id, Title.current.value, Imagen.current.value, Descripcion.current.value, Price.current.value) }} data-bs-dismiss="modal">Editar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div >
    )
}

export default Show;