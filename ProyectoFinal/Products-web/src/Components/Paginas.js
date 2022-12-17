import React from 'react';
import { Switch, Route} from 'react-router-dom';
import {Inicio} from "./Inicio/Inicio"
import Products_View from '../Products/Products-View';
import Show from '../Products/productAdmin/Products-Admin';
import Home from '../Login/Home';
import Home_view from '../Login/Home-View';
import App from '../App';
import Login from '../Login/Login';

export const Paginas=()=>{
    return(
        <section>
            <Switch>
                <Route path='/' exact component={Login}/>
                <Route path='/productos' exact component={Products_View}/>
                <Route path='/home' exact component={Home_view}/>
                <Route path='/homeadmin' exact component={Home}/>                
                <Route path='/homeadmin/productosadmin' exact component={Show}/>
            </Switch>
        </section>
    )
}