import { collection, getDocs, getDoc, deleteDoc, doc, updateDoc, addDoc } from 'firebase/firestore';
import { db } from "../../Login/ConfiguracionFirebase";

export const saveProduct= async(titulo,imagen,descripcion,precio)=>{
    await addDoc(collection(db, 'productos'), {titulo: titulo,
    imagen: imagen,
    descripcion: descripcion,
    precio: precio})
}

export const editProduct=async(id, titulo, imagen, descripcion, precio)=>{
    await updateDoc(doc(db, 'productos', id), { titulo, imagen, descripcion, precio });
}

export const removeProduct=async(id)=>{
    const productDoc = doc(db, 'productos', id);
    await deleteDoc(productDoc);
}


