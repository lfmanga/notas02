import React from 'react'
import { Route } from "react-router"
import PrivateRoute from './components/PrivateRoute'
import Login from '../containers/login'
import Home from '../containers/home'
import Cliente from '../containers/cliente'

export default class Routes extends React.Component {
    render() {
        return (
            <div>
                <Route path="/login" component={Login} />
                <PrivateRoute exact path="/" component={Home} />
                <PrivateRoute path="/cliente" component={Cliente} />
            </div>
        )
    }
}