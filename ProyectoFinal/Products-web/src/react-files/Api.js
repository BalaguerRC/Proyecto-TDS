import React, { useState, useRef } from "react";
import fire from "./ConfiguracionFirebase";
import { basededato } from "../Login/ConfiguracionFirebase";
import "firebase/auth";
import { collection, getDocs, query, doc, getDoc, addDoc, deleteDoc, updateDoc, setDoc, where } from "firebase/firestore";

export const saveCollection=(titulo,descripcion,precio)=>{
    addDoc(collection(basededato,'productos'), {titulo,descripcion,precio})
}

export const getCollection=async () =>{
    const result=await getDocs(query(collection(basededato, 'productos')));
}