import React from 'react'
import { Route } from "react-router";

import Cliente from '../containers/cliente'

export default {
    ClienteRouter: () => (<Route path="/cliente" component={Cliente} />)
}