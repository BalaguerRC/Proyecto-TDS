import firebase from "firebase/app";
import "firebase/auth";
import "firebase/firestore"


const firebaseConfig = {
    apiKey: "AIzaSyBRYUGDgpmS00OCGBnXel9oiAv9rWCQ_eE",
    authDomain: "proyectotds-38bad.firebaseapp.com",
    projectId: "proyectotds-38bad",
    storageBucket: "proyectotds-38bad.appspot.com",
    messagingSenderId: "1006764712659",
    appId: "1:1006764712659:web:1aa39b6053c6b581776a26"
};

const fire = firebase.initializeApp(firebaseConfig);
export const basededato=fire.firestore();
export default fire;

