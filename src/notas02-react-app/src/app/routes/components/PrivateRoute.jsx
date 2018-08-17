import React from 'react'
import { Route, Redirect } from 'react-router'
import { isAuthenticated } from '../../auth'

export default ({ component: Component, ...rest }) => (
    <Route
        {...rest}
        render={props =>
            isAuthenticated() ?
                (
                    <Component {...props} />
                ) :
                (
                    <Redirect
                        to={{
                            pathname: "/login",
                            state: { from: props.location }
                        }}
                    />
                )
        }
    />
)