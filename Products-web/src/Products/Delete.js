import React, { useState, useRef } from "react";
import fire from "./ConfiguracionFirebase";
import "firebase/auth";
import {collection, doc,deleteDoc} from "firebase/firestore";

const Delete=async (id)=>{
    await deleteDoc(doc(fire, 'productos', id));
}

export default Delete;