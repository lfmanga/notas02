import React from 'react'
import { Route } from "react-router"
import PrivateRoute from '../components/route/PrivateRoute'

import Login from '../containers/login'
import Cliente from '../containers/cliente'

export default {
    Login : () => (<Route path="/login" component={Login}/>),
    Cliente : () => (<PrivateRoute path="/cliente" component={Cliente} />)
}