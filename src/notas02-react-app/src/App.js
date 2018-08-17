import React from 'react'
import { Provider } from 'react-redux'
import { Router } from 'react-router'

import Routes from './app/routes'

export default (props) => (
  <Provider store={props.store}>
    <Router history={props.history}>
      <Routes />
    </Router>
  </Provider>
)