import { applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import routeMiddleware from './routes'
export default applyMiddleware(routeMiddleware, thunk)