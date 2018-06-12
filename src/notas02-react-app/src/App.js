import React, { Component } from 'react'

import { Provider } from 'react-redux'
import { Route, Router } from "react-router";

import Routes from './app/routes'

class Home extends Component {
  render() {
    return (
      <h1>Home</h1>
    );
  }
}

class Rogerio extends Component {
  render() {
    return (
      <h1>Rogerio</h1>
    );
  }
}

class Lekinho extends Component {
  render() {
    return (
      <h1>Lekinho</h1>
    );
  }
}

export default (props) => (
  <Provider store={props.store}>
    <Router history={props.history}>
      <div>
        <Routes.ClienteRouter />
        <Route exact path="/" component={Home} />
        <Route path="/rogerio" component={Rogerio} />
        <Route path="/lekinho" component={Lekinho} />
      </div>
    </Router>
  </Provider>
)