import React from 'react'
import Axios from 'axios'

import * as Auth from '../../auth'

import config from '../../../config.json'

const defaultApiRoute = '/login'
const defautlApiUrl = config.URL_API + defaultApiRoute

const defaultState = {
    userName: 'admin',
    password: 'ADMIN@notas02'
}

class Login extends React.Component {

    constructor(props) {
        super(props)
        this.state = defaultState
    }

    handleChange(e) {
        let state = this.state
        state[e.target.name] = e.target.value
        this.setState(state)
    }

    handleSubmit(e) {
        const props = this.props
        let user = this.state
        Axios.post(defautlApiUrl, user)
            .then(response => {
                if(response.data) {
                    Auth.signIn(response.data)
                    props.history.push('/')
                }
            })
    }

    render() {
        return (
            <div className="container h-100 w-100">
                <form className="align-middle" onSubmit={() => false}>
                    <div className="form-group">
                        <label htmlFor="userName">Email address</label>
                        <input
                            className="form-control"
                            type="text"
                            id="userName"
                            name="userName"
                            value={this.state.userName}
                            onChange={this.handleChange.bind(this)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input
                            className="form-control"
                            type="password"
                            id="password"
                            name="password"
                            value={this.state.password}
                            onChange={this.handleChange.bind(this)}
                        />
                    </div>
                    <button
                        type="button"
                        className="btn btn-primary"
                        onClick={this.handleSubmit.bind(this)}
                    >Enter</button>
                </form>
            </div>
        )
    }
}

export default Login