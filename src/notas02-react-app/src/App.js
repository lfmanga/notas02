import React from 'react'
import { Provider } from 'react-redux'
import { Router } from 'react-router'
import { LoginRoute } from './app/containers/login'

export default (props) => (
  <Provider store={props.store}>
    <Router history={props.history}>
      <div>
        <LoginRoute />
      </div>
    </Router>
  </Provider>
)