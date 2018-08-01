import React from 'react'
import { Route } from "react-router"

export default class Login extends React.Component {
    render() {
        return (
            <h1>WARRR</h1>
        )
    }
}

export const LoginRoute = () => (<Route path="/login" Component={Login} />)