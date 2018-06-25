import { combineReducers } from 'redux'
import { routerReducer } from 'react-router-redux'

import clienteReducer from './containers/cliente/reducer'

export default combineReducers({
    clienteReducer: clienteReducer,
    routerReducer: routerReducer
})